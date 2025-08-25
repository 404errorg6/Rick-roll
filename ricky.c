#include <windows.h>

int main(){
    ShellExecute(0, "open", "https://www.youtube.com/watch?v=dQw4w9WgXcQ", 0, 0, SW_SHOWNORMAL);
    return 0;
}
