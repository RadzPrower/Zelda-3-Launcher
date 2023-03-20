# Zelda 3 Launcher
This launcher is intended to be a near 1-click tool for downloading, extracting, and compiling steps required to play the Zelda 3 reimplementation (created by snesrev) on Windows.
# Prerequisites
1. A legitimately obtained copy of the Zelda 3 (A Link to the Past) US ROM. `66871d66be19ad2c34c927d6b14cd8eb6fc3181965b6e517cb361f7316009cfb`

And that's it outside of this exectuable itself.
# Build Instructions
1. [Download the the latest release](https://github.com/RadzPrower/Zelda-3-Launcher/releases/latest)
2. Unzip the file.
3. Run `Zelda 3 Launcher.exe` at which point you will be greeted by a window that looks like this:

![image](https://user-images.githubusercontent.com/37708128/216780011-98f4ff41-01a6-4b95-9621-f1eef447df77.png)

4. Click the download button. If you happen to have a `zelda3.sfc` file in the same directory as the executable, it will copy it over automatically for you, but if not, a file selection dialog will open and allow you to select your ROM file (naming is not important).
5. The button will change from `Download` to indicate `Downloading...` This will quickly pop up a number of windows indicating download progress. Once the files are downloaded, the button will change to indicate `Building...` at which point it may take up to several minutes to complete the process depending on your system. You will know the process is complete when the window looks like this:

![image](https://user-images.githubusercontent.com/37708128/218764570-c36e7ffd-f604-4de0-8116-6e1f18174b57.png)

6. Click `Launch Zelda 3` and enjoy your time revisiting this classic natively on modern hardware.

The top button at this point should say `Restore` which will completely re-do the entire process again in case something was broken. However, as new updates are made to the zelda3 repository by snesrev, the launcher will detect those changes and change the button to say `Update`. This will let you know if there has been an update to the Zelda 3 reimplementation itself.

NOTE: There have been no updates since this functionality was programmed, so there is a chance it will not work. If you notice that it is not working, please let me know.

# Settings Menu
![image](https://user-images.githubusercontent.com/37708128/226472052-a12d4d64-4fe6-443c-85b0-283c5a335d1f.png)

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

### General
- Autosave: Essentially a "sleep mode". Automatically creates savestates as you close the game and will restart you in the exact same place the next time you start your game.
- Performance in Title: Displays the current FPS in the title bar of the window.
- Unchange Sprites: Ensures matching behavior to the original SNES version.
- Extend Y: Extends the vertical pixel height from 224 to 240.
- Disable Frame Delay: Disables SDL_Delay each frame. Can provide a performance boost if your display is set to 60hz).
- No Visual Fixes: Ensure that no graphical glitches are fixed.
- Aspect Ratio
  * Normal (4:3): This is the original aspect ratio of the game as output by the SNES.
  * Widescreen (16:9): This is the standard widescreen format used by most modern monitors and televisions.
  * Steam Deck (16:10): While not exclusively used by the Steam Deck, it is a prominent modern device that uses such as aspect ratio.

### Graphics
- Window Size
  * Auto: This will automatically size the window based on your selected `Fullscreen Mode` and `Window Scaling`.
  * Custom: Allows you to set the size of your window. The `Aspect Ratio` setting will still be respected, so if your window is not the same aspect ratio as that, you will end up with black bars.
- Fullscreen Mode
  * Windowed: This will provide you a window which can be move around your desktop. It's size can be changed via the `Window Scaling` option or using the assigned hotkey for increasing/decreasing the window size.
  * Borderless Fullscreen: This is still a window as part of your overall desktop, but it covers everything on a single monitor to appear as if it is fullscreen. This is generally considered the best performing option of the two fullscreen options.
  * Fullscreen: The screen is fully in control of a given monitor.
- Optimized SNES PPU: Use a more optimized but potentially buggy SNES PPU implementation.
- No Sprite Limit: No longer limits the number of sprites allowed to be rendered thus elminating flicker.
- Linear Filtering: Apply a linear filter to enlarged graphics. Results in a generally blurry image.
- Enhanced Mode7: Results in a higher resolution map.
- Dim Flashing: Lessens the flashing present in the game to a level much like the Virtual Console re-releases
- Stretch: Enabling this stretches the output to match the window size, this includes fullscreen modes, resulting a squashed or stretched visual. This can however be used to emulate a CRT since the 4:3 aspect ratio of a TV did not actually match the true 8:7 aspect ratio the SNES output.
- Window Scaling: Integer scaling of the display window. Only worked in `Windowed` mode.
- Render Method: Allows you to choose between SDL, SDL-Software, or OpenGL rendering. **NOTE: This setting may be overridden when certain other options are selected if they require a specific renderer to be used.**
- Custom Link Sprites: Allows you to select and load ZSPR files in order to use a custom Link sprite. A link is also provided to a database of options for quick and easy availability.
- Use GLSL Shader: Allows you to select and load shaders to change how the visuals are rendered. A link is provided to a list of verified compatible shaders for you to select from.

### Sound
- Enable Audio
- Audio Channels: Mono or Stereo
- Audio Frequency
- Audio Samples: Defaults to 512, but the larger the number the less cracking, but the longer lag between the audio and visuals.
- Enables MSU: Allows you to use high-quality audio tracks instead of the game's originals audio tracks.
  * Resume MSU: Resumes a track when you return to a given area rather than restarting from the beginning each time.
  * MSU Volume
  * MSU Version: MSU, MSU-Deluxe, OPUZ, and OPUZ-Deluxe
  * MSU Directory: The default MSU directory and the current file naming convention are always displayed here and only changes if the directory of a new set of MSU files. The files are copied into the required directory for use by `zelda3` and will be stored in the `msu` directory.

# Keymapper Utility
![image](https://user-images.githubusercontent.com/37708128/223178075-c2030a81-55d4-45c6-a2e6-842267aa2789.png)

This utility allows you to set all the available standard controls (SNES controller) and additional hotkeys for `zelda3` exclusive functionality. The keyboard and gamepad settings are stored simultaneously for the main controls in the INI, so you must select which version you want to set for those controls specifically. The hotkeys however are unique so they can be freely set to either a gamepad or keyboard input.

You can hit the `Assign All Input` button to be sequentially moved from input to input so that you can set all keys without having to click on each individual input.

### Game Functions
- Reset
- Pause: This pauses the game without bringing up the item menu.
- Dim When Paused: This toggles whether the screen dims when using the above pause function.
- Increase Window Size
- Decrease Window Size
- Volume Up
- Volume Down

### Cheats
- Restore Health: Full heal Link and restore magic.
- Give One Key: This hotkey will set your dungeon key count to 1 if you have no keys.
- No Clip: Allows you to freely walk through walls.
- Turbo: Increases game speed while held.

### Replays
- Toggle Replay Speed: Toggles replay speed between realtime and turbo.
- Stop Repaly: Stops the current replay and you assume control of the game.

### Performance
- Toggle Renderer: Allows you to toggle between the new optimized PPU or the original SNES PPU.
- Toggle FPS: Toggle a FPS display in the upper left corner of the game.
