# DiscordUnity
A DiscordAPI made for Unity but also usable as a standalone .NET Standard library.
Edit by Jelle Vermandere

### INSTALLATION
- Open your UnityProject where you want to install DiscordUnity.
- import the discord unity folder and the Discord manager as example
- Import the assets and you're set to go with DiscordManager as example.

### Usage 
- Create Empty GameObject
- Add DiscordManager Script
- Insert Bot-Token inside the Inspector

### Android Integration

- Create new UnityProject
- File -> Build Settings -> Android -> Switch Platform
- Download and Import the .unitypackage from: https://github.com/jilleJr/Newtonsoft.Json-for-Unity
- Edit -> Project Settings -> Player -> Configuration -> Change .Net Standard 2.0 to Net 4.x
- Navigate to the Asset Folder -> create file "csc.rsp" -> insert this line "-r:System.Web.dll"
- Install DiscordUnity (as described above)
