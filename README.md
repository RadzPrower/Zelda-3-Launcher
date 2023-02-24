# Zelda 3 Launcher
This launcher is intended to be a near 1-click tool for downloading, extracting, and compiling steps required to play the Zelda 3 reimplementation (created by snesrev) on Windows.
# Prerequisites
1. A legitimately obtained copy of the Zelda 3 (A Link to the Past) US ROM. `66871d66be19ad2c34c927d6b14cd8eb6fc3181965b6e517cb361f7316009cfb`

And that's it outside of this exectuable itself.
# Build Instructions
1. [Download the the latest release](https://github.com/RadzPrower/Zelda-3-Launcher/releases/latest)
2. Unzip the file.
3. Run `Zelda 3 Launcher.exe` at which point you will be greated by a window that looks like this:

![image](https://user-images.githubusercontent.com/37708128/216780011-98f4ff41-01a6-4b95-9621-f1eef447df77.png)

4. Click the download button. If you happen to have a `zelda3.sfc` file in the same directory as the executable, it will copy it over automatically for you, but if not, a file selection dialog will open and allow you to select your ROM file (naming is not important).
5. The button will change from `Download` to indicate `Downloading...` This will quickly pop up a number of windows indicating download progress. Once the files are downloaded, the button will change to indicate `Building...` at which point it may take up to several minutes to complete the process depending on your system. You will know the process is complete when the window looks like this:

![image](https://user-images.githubusercontent.com/37708128/218764570-c36e7ffd-f604-4de0-8116-6e1f18174b57.png)

6. Click `Launch Zelda 3` and enjoy your time revisiting this classic natively on modern hardware.

The top button at this point should say `Restore` which will completely re-do the entire process again in case something was broken. However, as new updates are made to the zelda3 repository by snesrev, the launcher will detect those changes and change the button to say `Update`. This will let you know if there has been an update to the Zelda 3 reimplementation itself.

NOTE: There have been no updates since this functionality was programmed, so there is a chance it will not work. If you notice that it is not working, please let me know.

# Settings Menu
![image](https://user-images.githubusercontent.com/37708128/221297160-116ddea0-23fa-4b14-8735-44eed7293ed8.png)

There are a number of settings available for you to change here. I will briefly explain them here.

### Gameplay Settings
- Advanced Items Selection: Allows for extended item selection options including quick switching items with L/R or assigning items to the X, L, or R buttons in addition to Y. As long as no items are assigned to L or R, quick switching will remain enabled. If X is assigned an item, SELECT will become the map buttona nd the `Save and Quit` function will be moved to SELECT while the item menu is open.
- Limit L/R Switch to First 4 Items: This can only be enabled when the above option is turned on. It limits the quick swaping of items to just the first four items.
- Allow Turning While Dashing
- Mirror Teleports to Dark World: This allows you to use the Magic Mirror regardless of which world you are in to swap back and forth between them.
- Collect Items w/Sword: Allows you to collect items like hearts and rupees with a swing of your sword.
- Break Pots w/Sword: Allows you break pots with your sword if you have the Master Sword or higher.
- Disable Low Heart Beep
- Skip Intro w/Keypress: Allows you to skip the Triforce intro when you boot the game.
- Indicate Max Resources: When you have as many of an item as you can carry (bombs, rupees, etc.), the numbers will change color to yellow/orange.
- More Active Bombs: You are normally allowed only two bombs at once. This allows you to place up to four at once.
- Large Wallet
- [Miscelaneous Minor Fixes](https://github.com/snesrev/zelda3/wiki/Bug-Fixes-:-Misc.)
- [Game Changing Bug Fixes](https://github.com/snesrev/zelda3/wiki/Bug-Fixes-:-Game-Changing)
- Cancel Bird: This allows you to hit X to cancel traveling via bird/flute.
