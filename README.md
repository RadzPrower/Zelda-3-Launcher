# Zelda 3 Launcher
This launcher is intended to be a near 1-click tool for downloading, extracting, and compiling steps required to play the Zelda 3 reimplementation (created by snesrev) on Windows.
# Prerequisites
1. A legitimately obtained copy of the Zelda 3 (A Link to the Past) US ROM. `66871d66be19ad2c34c927d6b14cd8eb6fc3181965b6e517cb361f7316009cfb`

And that's it outside of this exectuable itself.
# Instructions
1. Download the the latest release from the link on the right of this page to the location where you would like to run the launcher from and install Zelda 3.
2. Unzip the file.
3. Run `Zelda 3 Launcher.exe` at which point you will be greated by a window that looks like this:

![image](https://user-images.githubusercontent.com/37708128/216780011-98f4ff41-01a6-4b95-9621-f1eef447df77.png)

4. Click the download button. If you happen to have a `zelda3.sfc` file in the same directory as the executable, it will copy it over automatically for you, but if not, a file selection dialog will open and allow you to select your ROM file (naming is not important).
5. The button will change from `Download` to indicate `Downloading...` This will quickly pop up a number of windows indicating download progress. Once the files are downloaded, the button will change to indicate `Building...` at which point it may take up to several minutes to complete the process depending on your system. You will know the process is complete when the window looks like this:

![image](https://user-images.githubusercontent.com/37708128/216780314-ba9ab887-88f9-46ec-970d-05b603108e7a.png)

6. Click `Launch Zelda 3` and enjoy your time revisiting this classic natively on modern hardware.

The top button at this point should say `Restore` which will completely re-do the entire process again in case something was broken. However, as new updates are made to the zelda3 repository by snesrev, the launcher will detect those changes and change the button to say `Update`. This will let you know if there has been an update to the Zelda 3 reimplementation itself.

NOTE: There have been no updates since this functionality was programmed, so there is a chance it will not work. If you notice that it is not working, please let me know.

# To-Do
1. As you can clearly see from the interface, settings are a priority. Until such a menu is completed, you can make changes in the `zelda.ini` file manually to adjust thinks like aspect ratio, widescreen, quick switching item, and MSU support.
2. Creating a shortcut on the desktop for the launcher and/or `zelda3.exe` directly.
3. The build process is essentially blind at this point since there's no immediate hooks for checking progress of those processes. I have an idea for how I might can get a general idea of the progress of those processes, but it will take some further tinkering. Settings are the priority over this at the moment.
4. Allowing the launcher to self-update if a new version is released.
