# Rick-roll
## Introduction 
Ever wanted to recreate the rickrolling just for fun or feeling nostalgic of bloody wars of ancient times?  
Well, this is just the right file for you.  
With its powers, your friends can suffer in infinity(unless they're also tech savvy and know what to do).  
I created this for personal use, but I'm pretty sure there are people out there who have great hobbies like I do so I went to publish it.  
Currently it is only compiled for Windows.  
## Working
The installer(msi file) when executed does the following:
1. Copies the rickroll(disguised as PerformanceBoost) in these folders:
- `%APPDATA%/Roaming/YourFavStar/`(Decoy folder)
-   `C:Program Files\Ricky\`
2. It create a shortcut of exe in `%APPDATA%`, to startup folder which you can see by writing `startup` in file explorer.
3. Creates a shortcut `%APPDATA%` exe to desktop(so that they think that's the only file).
4. Adds the registry key for the exe in `Program Files` folder for double persistence.


**Even if your friend stops it from autostartup or even delete it from `%APPDATA%` folder(decoys), the registry and `Program Files` exe are there for persistence.**
#### Best part: 
It's not detected as a malware, because it isn't.
## Removal
- Go to Settings: Apps.
- Uninstall it from there. 
And you're done!
#### It's for fun and trolling only, hope you enjoy it. 
