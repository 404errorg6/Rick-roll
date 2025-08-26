#include <windows.h>

int main(){
    ShellExecute(0, "open", "https://www.youtube.com/watch?v=dQw4w9WgXcQ", 0, 0, SW_SHOWNORMAL);
    Sleep(4000);
    MessageBoxW(NULL, L"Get a better PC peasant 💀", L"Bruh", MB_OK | MB_TOPMOST | MB_SYSTEMMODAL | MB_ICONINFORMATION);
    return 0;
}

