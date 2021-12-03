#include "Engine.h"
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <WinSock2.h>

DWORD recvWorkerClient(void* ptr)
{
    const SOCKET sock = reinterpret_cast<SOCKET>(ptr);
    char buffer[1024];

    while (true)
    {
        int recvSize = recv(sock, buffer, 1024, 0);
        if (recvSize == SOCKET_ERROR || recvSize == 0)
        {
            engPrint("Server shutdown");
            return 0;
        }
        engPrint("%.*s", recvSize, buffer);
    }
}

#ifdef CLIENT
int WinMain(HINSTANCE, HINSTANCE, char*, int)
{
    WSADATA wsaData;
    WSAStartup(MAKEWORD(2,2), &wsaData);

    SOCKET sock = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);

    uint8_t ipBytes[] = { 127, 0, 0, 1 };
    sockaddr_in connectAddr;
    connectAddr.sin_family = AF_INET;
    connectAddr.sin_addr.s_addr = *reinterpret_cast<uint32_t*>(ipBytes);
    connectAddr.sin_port = htons(666);

    connect(sock, reinterpret_cast<sockaddr*>(&connectAddr), sizeof connectAddr);

    CreateThread(
        nullptr,
        0,
        recvWorkerClient,
        reinterpret_cast<void*>(sock),
        0,
        nullptr
    );
    
    engInit();

    while(engBeginFrame())
    {
        if(engKeyPressed(Key::Space))
        {
            const char* msg = "F***!";
            send(sock, msg, strlen(msg), 0);
        }
        engSetColor(0x222222FF);
        engClear();
    }
    return 0;
}
#endif