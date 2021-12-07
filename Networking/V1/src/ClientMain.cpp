#include "Engine.h"
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <WinSock2.h>

#ifdef CLIENT
DWORD recvWorker(void* ptr)
{
    const SOCKET sock = reinterpret_cast<SOCKET>(ptr);

    while (true)
    {
        static char buffer[1024];
        int recvSize = recv(sock, buffer, 1024, 0);
        if (recvSize == SOCKET_ERROR || recvSize == 0)
        {
            engPrint("Server shutdown");
            return recvSize;
        }
        engPrint("%.*s", recvSize, buffer);
    }
}

int WinMain(HINSTANCE, HINSTANCE, char*, int)
{
    WSADATA wsaData;
    WSAStartup(MAKEWORD(2,2), &wsaData);

    SOCKET sock = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);

    uint8_t ipBytes[] = { 10, 20, 2, 178 };
    sockaddr_in connectAddr;
    connectAddr.sin_family = AF_INET;
    connectAddr.sin_addr.s_addr = *reinterpret_cast<uint32_t*>(ipBytes);
    connectAddr.sin_port = htons(666);

    engInit();
    
    connect(sock, reinterpret_cast<sockaddr*>(&connectAddr), sizeof connectAddr);


    CreateThread(
        nullptr,
        0,
        recvWorker,
        reinterpret_cast<void*>(sock),
        0,
        nullptr
    );


    while(engBeginFrame())
    {
        if(engKeyPressed(Key::Space))
        {
            const char* msg = "BITCONNEEEEEEEEEEEEEECT!";
            send(sock, msg, strlen(msg), 0);
        }
        engSetColor(0x222222FF);
        engClear();
    }
    return 0;
}
#endif