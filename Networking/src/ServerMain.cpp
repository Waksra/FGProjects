﻿#include "Engine.h"
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <WinSock2.h>

#define USER_MAX 8
struct  User
{
    bool active = false;
    SOCKET sock;
};
User users[USER_MAX];

DWORD recvWorker(void* ptr)
{
    User* user = static_cast<User*>(ptr);
    char buffer[1024];
    
    while(true)
    {
        int recvSize = recv(user->sock, buffer, 1024, 0);
        if(recvSize == SOCKET_ERROR || recvSize == 0)
        {
            engPrint("User left");
            user->active = false;
            return 0;
        }
        engPrint("%.*s", recvSize, buffer);
    }
}

DWORD acceptWorker(void* ptr)
{
    const SOCKET listen_sock = reinterpret_cast<SOCKET>(ptr);
    while(true)
    {
        sockaddr_in acceptAddr;
        int acceptAddrLen = sizeof acceptAddr;

        const SOCKET newUserSock = accept(listen_sock, reinterpret_cast<sockaddr*>(&acceptAddr), &acceptAddrLen);

        int user_idx = -1;
        for (int i = 0; i < USER_MAX; i++)
        {
            if(users[i].active)
                continue;

            user_idx = i;
            break;
        }

        if(user_idx == -1)
        {
            closesocket(newUserSock);
            continue;
        }

        User* user = &users[user_idx];
        user->active = true;
        user->sock = newUserSock;
        
        engPrint("[%d.%d.%d.%d.%d] connected!",
            acceptAddr.sin_addr.s_net,
            acceptAddr.sin_addr.s_host,
            acceptAddr.sin_addr.s_lh,
            acceptAddr.sin_addr.s_impno,
            ntohs(acceptAddr.sin_port)
        );

        CreateThread(
            nullptr,
            0,
            recvWorker,
            user,
            0,
            nullptr
            );
    }
}

#ifdef SERVER
int WinMain(HINSTANCE, HINSTANCE, char*, int)
{
    engInit();

    //Create and bind a socket
    WSAData wsaData;
    WSAStartup(MAKEWORD(2,2), &wsaData);

    const SOCKET listen_sock = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if(listen_sock == INVALID_SOCKET)
    {
        return 1;
    }

    sockaddr_in bindAddr; 
    bindAddr.sin_family = AF_INET;
    bindAddr.sin_addr.s_addr = INADDR_ANY;
    bindAddr.sin_port = htons(666);

    if(bind(listen_sock, reinterpret_cast<sockaddr*>(&bindAddr), sizeof bindAddr))
    {
        return 1;
    }

    listen(listen_sock, 10);
    CreateThread(
        nullptr,
        0,
        acceptWorker,
        reinterpret_cast<void*>(listen_sock),
        0,
        nullptr
        );
    
    engPrint("Let's go!");

    while(engBeginFrame())
    {
        engSetColor(0x222222FF);
        engClear();
    }
    return 0;
}
#endif