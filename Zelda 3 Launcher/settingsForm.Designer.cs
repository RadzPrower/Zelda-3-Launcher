namespace Zelda_3_Launcher
{
    partial class settingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            general = new GroupBox();
            checkBoxExtend = new CheckBox();
            disableFrameDelay = new CheckBox();
            noVisualFixes = new CheckBox();
            unchangedSprites = new CheckBox();
            aspectRatio = new GroupBox();
            steamdeck = new RadioButton();
            widescreen = new RadioButton();
            normal = new RadioButton();
            performance = new CheckBox();
            autosaveCheck = new CheckBox();
            toolTip1 = new ToolTip(components);
            radioFullscreenMode = new RadioButton();
            radioFullscreen = new RadioButton();
            radioWindowed = new RadioButton();
            height = new TextBox();
            width = new TextBox();
            customSize = new RadioButton();
            windowAuto = new RadioButton();
            checkPPU = new CheckBox();
            numericWindowScale = new NumericUpDown();
            labelScale = new Label();
            checkMode7 = new CheckBox();
            checkStretch = new CheckBox();
            checkSpriteLimit = new CheckBox();
            checkLinearFiltering = new CheckBox();
            buttonOpenShader = new Button();
            textBoxGLSLShader = new TextBox();
            buttonOpenSprites = new Button();
            textBoxCustomLink = new TextBox();
            checkBoxCustomLinkSprites = new CheckBox();
            checkBoxShader = new CheckBox();
            checkBoxEnableAudio = new CheckBox();
            labelAudioFrequency = new Label();
            labelAudioSamples = new Label();
            checkBoxQuickSwitch = new CheckBox();
            checkBoxLRLimit = new CheckBox();
            checkBoxDashTurning = new CheckBox();
            checkBoxMirrorDark = new CheckBox();
            checkBoxSwordItems = new CheckBox();
            checkBoxSwordPots = new CheckBox();
            checkBoxHeartBeep = new CheckBox();
            checkBoxIntroSkip = new CheckBox();
            checkBoxMaxResources = new CheckBox();
            checkBoxMoreBombs = new CheckBox();
            checkBoxLargerWallet = new CheckBox();
            checkBoxMiscFixes = new CheckBox();
            checkBoxMajorFixes = new CheckBox();
            checkBoxCancelBird = new CheckBox();
            groupBoxMSUSettings = new GroupBox();
            checkBoxMSUSymlink = new CheckBox();
            comboBoxMSU = new ComboBox();
            textBoxMSUDirectory = new TextBox();
            labelMSUVersion = new Label();
            labelMSUDirectory = new Label();
            numericMSUVolume = new NumericUpDown();
            checkBoxResumeMSU = new CheckBox();
            labelMSUVolume = new Label();
            buttonMSUDirectory = new Button();
            comboBoxSamples = new ComboBox();
            comboBoxFrequency = new ComboBox();
            checkBoxEnableMSU = new CheckBox();
            radioButtonStereo = new RadioButton();
            radioButtonMono = new RadioButton();
            buttonReset = new Button();
            buttonSave = new Button();
            buttonCancel = new Button();
            labelRenderMethod = new Label();
            comboRenderMethod = new ComboBox();
            linkLabelCustomSprites = new LinkLabel();
            buttonKeymapping = new Button();
            linkLabelMinorFixes = new LinkLabel();
            graphics = new GroupBox();
            linkLabelGLSLShaders = new LinkLabel();
            fullscreenMode = new GroupBox();
            windowSize = new GroupBox();
            windowSizeX = new Label();
            groupBoxSound = new GroupBox();
            groupBoxAudioChannels = new GroupBox();
            groupBoxGameplay = new GroupBox();
            linkLabelMajorFixes = new LinkLabel();
            labelHoverNote = new Label();
            labelMSUCopy = new Label();
            progressMSU = new ProgressBar();
            general.SuspendLayout();
            aspectRatio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericWindowScale).BeginInit();
            groupBoxMSUSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericMSUVolume).BeginInit();
            graphics.SuspendLayout();
            fullscreenMode.SuspendLayout();
            windowSize.SuspendLayout();
            groupBoxSound.SuspendLayout();
            groupBoxAudioChannels.SuspendLayout();
            groupBoxGameplay.SuspendLayout();
            SuspendLayout();
            // 
            // general
            // 
            general.Controls.Add(checkBoxExtend);
            general.Controls.Add(disableFrameDelay);
            general.Controls.Add(noVisualFixes);
            general.Controls.Add(unchangedSprites);
            general.Controls.Add(aspectRatio);
            general.Controls.Add(performance);
            general.Controls.Add(autosaveCheck);
            general.Location = new Point(220, 35);
            general.Name = "general";
            general.Size = new Size(381, 127);
            general.TabIndex = 5;
            general.TabStop = false;
            general.Text = "General";
            // 
            // checkBoxExtend
            // 
            checkBoxExtend.AutoSize = true;
            checkBoxExtend.Location = new Point(6, 47);
            checkBoxExtend.Name = "checkBoxExtend";
            checkBoxExtend.Size = new Size(72, 19);
            checkBoxExtend.TabIndex = 3;
            checkBoxExtend.Text = "Extend Y";
            toolTip1.SetToolTip(checkBoxExtend, "Displays 240 vertical lines rather than the default 224");
            checkBoxExtend.UseVisualStyleBackColor = true;
            // 
            // disableFrameDelay
            // 
            disableFrameDelay.AutoSize = true;
            disableFrameDelay.Location = new Point(99, 47);
            disableFrameDelay.Name = "disableFrameDelay";
            disableFrameDelay.Size = new Size(132, 19);
            disableFrameDelay.TabIndex = 4;
            disableFrameDelay.Text = "Disable Frame Delay";
            toolTip1.SetToolTip(disableFrameDelay, "Disable the SDL_Delay that happens on each frame (Gives slightly better performance if your display is set to exactly 60Hz)");
            disableFrameDelay.UseVisualStyleBackColor = true;
            // 
            // noVisualFixes
            // 
            noVisualFixes.AutoSize = true;
            noVisualFixes.Location = new Point(250, 47);
            noVisualFixes.Name = "noVisualFixes";
            noVisualFixes.Size = new Size(105, 19);
            noVisualFixes.TabIndex = 5;
            noVisualFixes.Text = "No Visual Fixes";
            toolTip1.SetToolTip(noVisualFixes, "Avoid fixing some graphics glitches. If enabled, memory compare will not work.");
            noVisualFixes.UseVisualStyleBackColor = true;
            // 
            // unchangedSprites
            // 
            unchangedSprites.AutoSize = true;
            unchangedSprites.Location = new Point(250, 22);
            unchangedSprites.Name = "unchangedSprites";
            unchangedSprites.Size = new Size(125, 19);
            unchangedSprites.TabIndex = 2;
            unchangedSprites.Text = "Unchanged Sprites";
            toolTip1.SetToolTip(unchangedSprites, "Avoid changing sprite spawn/die behavior. (Required for replay compatibility)");
            unchangedSprites.UseVisualStyleBackColor = true;
            // 
            // aspectRatio
            // 
            aspectRatio.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            aspectRatio.Controls.Add(steamdeck);
            aspectRatio.Controls.Add(widescreen);
            aspectRatio.Controls.Add(normal);
            aspectRatio.Location = new Point(6, 72);
            aspectRatio.Name = "aspectRatio";
            aspectRatio.Size = new Size(369, 50);
            aspectRatio.TabIndex = 6;
            aspectRatio.TabStop = false;
            aspectRatio.Text = "Aspect Ratio";
            toolTip1.SetToolTip(aspectRatio, "This is the aspect ratio which the game will render. All aspect ratios other than Normal will result in black bars on the left and right in various scenarios.");
            // 
            // steamdeck
            // 
            steamdeck.AutoSize = true;
            steamdeck.Location = new Point(238, 22);
            steamdeck.Name = "steamdeck";
            steamdeck.Size = new Size(125, 19);
            steamdeck.TabIndex = 2;
            steamdeck.Text = "Steam Deck (16:10)";
            toolTip1.SetToolTip(steamdeck, "Steam Deck's untraditional aspect ratio");
            steamdeck.UseVisualStyleBackColor = true;
            // 
            // widescreen
            // 
            widescreen.AutoSize = true;
            widescreen.Location = new Point(107, 22);
            widescreen.Name = "widescreen";
            widescreen.Size = new Size(118, 19);
            widescreen.TabIndex = 1;
            widescreen.Text = "Widescreen (16:9)";
            toolTip1.SetToolTip(widescreen, "Traditional widescreen screens");
            widescreen.UseVisualStyleBackColor = true;
            // 
            // normal
            // 
            normal.AutoSize = true;
            normal.Checked = true;
            normal.Location = new Point(6, 22);
            normal.Name = "normal";
            normal.Size = new Size(91, 19);
            normal.TabIndex = 0;
            normal.TabStop = true;
            normal.Text = "Normal (4:3)";
            toolTip1.SetToolTip(normal, "Original output of the SNES");
            normal.UseVisualStyleBackColor = true;
            // 
            // performance
            // 
            performance.AutoSize = true;
            performance.Location = new Point(99, 22);
            performance.Name = "performance";
            performance.Size = new Size(132, 19);
            performance.TabIndex = 1;
            performance.Text = "Performance in Title";
            toolTip1.SetToolTip(performance, "Show current performance in window title");
            performance.UseVisualStyleBackColor = true;
            // 
            // autosaveCheck
            // 
            autosaveCheck.AutoSize = true;
            autosaveCheck.Location = new Point(6, 22);
            autosaveCheck.Name = "autosaveCheck";
            autosaveCheck.Size = new Size(75, 19);
            autosaveCheck.TabIndex = 0;
            autosaveCheck.Text = "Autosave";
            toolTip1.SetToolTip(autosaveCheck, "Automatically save state on quit and reload on start");
            autosaveCheck.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            toolTip1.Tag = "toolTip1";
            // 
            // radioFullscreenMode
            // 
            radioFullscreenMode.AutoSize = true;
            radioFullscreenMode.Location = new Point(6, 72);
            radioFullscreenMode.Name = "radioFullscreenMode";
            radioFullscreenMode.Size = new Size(78, 19);
            radioFullscreenMode.TabIndex = 2;
            radioFullscreenMode.Text = "Fullscreen";
            toolTip1.SetToolTip(radioFullscreenMode, "Game will launch in exclusive fullscreen mode");
            radioFullscreenMode.UseVisualStyleBackColor = true;
            // 
            // radioFullscreen
            // 
            radioFullscreen.AutoSize = true;
            radioFullscreen.Location = new Point(6, 47);
            radioFullscreen.Name = "radioFullscreen";
            radioFullscreen.Size = new Size(135, 19);
            radioFullscreen.TabIndex = 1;
            radioFullscreen.Text = "Borderless Fullscreen";
            toolTip1.SetToolTip(radioFullscreen, "Game will launch in borderless fullscreen");
            radioFullscreen.UseVisualStyleBackColor = true;
            // 
            // radioWindowed
            // 
            radioWindowed.AutoSize = true;
            radioWindowed.Checked = true;
            radioWindowed.Location = new Point(6, 22);
            radioWindowed.Name = "radioWindowed";
            radioWindowed.Size = new Size(82, 19);
            radioWindowed.TabIndex = 0;
            radioWindowed.TabStop = true;
            radioWindowed.Text = "Windowed";
            toolTip1.SetToolTip(radioWindowed, "The game will play within a window on the desktop at your selected aspect ratio and window scaling");
            radioWindowed.UseVisualStyleBackColor = true;
            // 
            // height
            // 
            height.Enabled = false;
            height.Location = new Point(59, 71);
            height.MaxLength = 4;
            height.Name = "height";
            height.Size = new Size(35, 23);
            height.TabIndex = 3;
            toolTip1.SetToolTip(height, "Height");
            // 
            // width
            // 
            width.Enabled = false;
            width.Location = new Point(6, 71);
            width.MaxLength = 4;
            width.Name = "width";
            width.Size = new Size(35, 23);
            width.TabIndex = 2;
            toolTip1.SetToolTip(width, "Width");
            // 
            // customSize
            // 
            customSize.AutoSize = true;
            customSize.Location = new Point(6, 47);
            customSize.Name = "customSize";
            customSize.Size = new Size(67, 19);
            customSize.TabIndex = 1;
            customSize.Text = "Custom";
            toolTip1.SetToolTip(customSize, "Set a custom aspect ratio");
            customSize.UseVisualStyleBackColor = true;
            // 
            // windowAuto
            // 
            windowAuto.AutoSize = true;
            windowAuto.Checked = true;
            windowAuto.Location = new Point(6, 22);
            windowAuto.Name = "windowAuto";
            windowAuto.Size = new Size(51, 19);
            windowAuto.TabIndex = 0;
            windowAuto.TabStop = true;
            windowAuto.Text = "Auto";
            toolTip1.SetToolTip(windowAuto, "Automatically resize window to match selected aspect ratio");
            windowAuto.UseVisualStyleBackColor = true;
            windowAuto.CheckedChanged += customSizeChange;
            // 
            // checkPPU
            // 
            checkPPU.AutoSize = true;
            checkPPU.Checked = true;
            checkPPU.CheckState = CheckState.Checked;
            checkPPU.Location = new Point(6, 130);
            checkPPU.Name = "checkPPU";
            checkPPU.Size = new Size(136, 19);
            checkPPU.TabIndex = 2;
            checkPPU.Text = "Optimized SNES PPU";
            toolTip1.SetToolTip(checkPPU, "Use an optimized SNES PPU implementation (potentially buggy)");
            checkPPU.UseVisualStyleBackColor = true;
            // 
            // numericWindowScale
            // 
            numericWindowScale.Location = new Point(339, 151);
            numericWindowScale.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericWindowScale.Name = "numericWindowScale";
            numericWindowScale.Size = new Size(35, 23);
            numericWindowScale.TabIndex = 7;
            toolTip1.SetToolTip(numericWindowScale, "1 = 100%\r\n2 = 200%\r\n3 = 300%\r\netc.");
            numericWindowScale.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // labelScale
            // 
            labelScale.Location = new Point(238, 151);
            labelScale.Name = "labelScale";
            labelScale.Size = new Size(95, 23);
            labelScale.TabIndex = 4;
            labelScale.Text = "Window Scaling:";
            labelScale.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(labelScale, "This sets the scaling of the game window when not fullscreen");
            // 
            // checkMode7
            // 
            checkMode7.AutoSize = true;
            checkMode7.Checked = true;
            checkMode7.CheckState = CheckState.Checked;
            checkMode7.Location = new Point(6, 155);
            checkMode7.Name = "checkMode7";
            checkMode7.Size = new Size(118, 19);
            checkMode7.TabIndex = 5;
            checkMode7.Text = "Enhanced Mode7";
            toolTip1.SetToolTip(checkMode7, "Display the world map with higher resolution");
            checkMode7.UseVisualStyleBackColor = true;
            // 
            // checkStretch
            // 
            checkStretch.AutoSize = true;
            checkStretch.Location = new Point(152, 155);
            checkStretch.Name = "checkStretch";
            checkStretch.Size = new Size(63, 19);
            checkStretch.TabIndex = 6;
            checkStretch.Text = "Stretch";
            toolTip1.SetToolTip(checkStretch, "Stretches the graphics to take up the entire window/screen regardless of aspect ratio.");
            checkStretch.UseVisualStyleBackColor = true;
            // 
            // checkSpriteLimit
            // 
            checkSpriteLimit.AutoSize = true;
            checkSpriteLimit.Checked = true;
            checkSpriteLimit.CheckState = CheckState.Checked;
            checkSpriteLimit.Location = new Point(152, 130);
            checkSpriteLimit.Name = "checkSpriteLimit";
            checkSpriteLimit.Size = new Size(105, 19);
            checkSpriteLimit.TabIndex = 3;
            checkSpriteLimit.Text = "No Sprite Limit";
            toolTip1.SetToolTip(checkSpriteLimit, "Remove the sprite limit per scan line");
            checkSpriteLimit.UseVisualStyleBackColor = true;
            // 
            // checkLinearFiltering
            // 
            checkLinearFiltering.AutoSize = true;
            checkLinearFiltering.Location = new Point(270, 130);
            checkLinearFiltering.Name = "checkLinearFiltering";
            checkLinearFiltering.Size = new Size(104, 19);
            checkLinearFiltering.TabIndex = 4;
            checkLinearFiltering.Text = "Linear Filtering";
            toolTip1.SetToolTip(checkLinearFiltering, "Use linear filter. Softens image and results in less crisp pixels.");
            checkLinearFiltering.UseVisualStyleBackColor = true;
            // 
            // buttonOpenShader
            // 
            buttonOpenShader.AutoSize = true;
            buttonOpenShader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonOpenShader.Location = new Point(348, 284);
            buttonOpenShader.Name = "buttonOpenShader";
            buttonOpenShader.Size = new Size(26, 25);
            buttonOpenShader.TabIndex = 13;
            buttonOpenShader.Text = "...";
            toolTip1.SetToolTip(buttonOpenShader, "Opens a dialog for selecting your GLSL shader file.");
            buttonOpenShader.UseVisualStyleBackColor = true;
            buttonOpenShader.Click += buttonOpenShader_Click;
            // 
            // textBoxGLSLShader
            // 
            textBoxGLSLShader.Location = new Point(6, 285);
            textBoxGLSLShader.Name = "textBoxGLSLShader";
            textBoxGLSLShader.Size = new Size(336, 23);
            textBoxGLSLShader.TabIndex = 12;
            toolTip1.SetToolTip(textBoxGLSLShader, "The path where your .glsl or .slslp file is located");
            // 
            // buttonOpenSprites
            // 
            buttonOpenSprites.AutoSize = true;
            buttonOpenSprites.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonOpenSprites.Location = new Point(348, 233);
            buttonOpenSprites.Name = "buttonOpenSprites";
            buttonOpenSprites.Size = new Size(26, 25);
            buttonOpenSprites.TabIndex = 10;
            buttonOpenSprites.Text = "...";
            toolTip1.SetToolTip(buttonOpenSprites, "Opens a dialog for selecting your ZSPR custom sprite file.");
            buttonOpenSprites.UseVisualStyleBackColor = true;
            buttonOpenSprites.Click += buttonOpenSprites_Click;
            // 
            // textBoxCustomLink
            // 
            textBoxCustomLink.Location = new Point(6, 234);
            textBoxCustomLink.Name = "textBoxCustomLink";
            textBoxCustomLink.Size = new Size(336, 23);
            textBoxCustomLink.TabIndex = 9;
            toolTip1.SetToolTip(textBoxCustomLink, "The path where your .zspr file is located");
            // 
            // checkBoxCustomLinkSprites
            // 
            checkBoxCustomLinkSprites.AutoSize = true;
            checkBoxCustomLinkSprites.Location = new Point(6, 209);
            checkBoxCustomLinkSprites.Name = "checkBoxCustomLinkSprites";
            checkBoxCustomLinkSprites.Size = new Size(131, 19);
            checkBoxCustomLinkSprites.TabIndex = 0;
            checkBoxCustomLinkSprites.Text = "Custom Link Sprites";
            toolTip1.SetToolTip(checkBoxCustomLinkSprites, "Enables custom ZSPR Link sprites");
            checkBoxCustomLinkSprites.UseVisualStyleBackColor = true;
            checkBoxCustomLinkSprites.CheckedChanged += checkBoxCustomLinkSprites_CheckedChanged;
            // 
            // checkBoxShader
            // 
            checkBoxShader.AutoSize = true;
            checkBoxShader.Location = new Point(6, 263);
            checkBoxShader.Name = "checkBoxShader";
            checkBoxShader.Size = new Size(113, 19);
            checkBoxShader.TabIndex = 17;
            checkBoxShader.Text = "Use GLSL Shader";
            toolTip1.SetToolTip(checkBoxShader, "This will enable the use of GLSL shaders.\r\n\r\nThis is only supported by the OpenGL renderer.");
            checkBoxShader.UseVisualStyleBackColor = true;
            checkBoxShader.CheckedChanged += checkBoxShader_CheckedChanged;
            // 
            // checkBoxEnableAudio
            // 
            checkBoxEnableAudio.AutoSize = true;
            checkBoxEnableAudio.Checked = true;
            checkBoxEnableAudio.CheckState = CheckState.Checked;
            checkBoxEnableAudio.Location = new Point(619, 47);
            checkBoxEnableAudio.Name = "checkBoxEnableAudio";
            checkBoxEnableAudio.Size = new Size(96, 19);
            checkBoxEnableAudio.TabIndex = 7;
            checkBoxEnableAudio.Text = "Enable Audio";
            toolTip1.SetToolTip(checkBoxEnableAudio, "Enable audio output by the game");
            checkBoxEnableAudio.UseVisualStyleBackColor = true;
            checkBoxEnableAudio.CheckedChanged += checkBoxEnableAudio_CheckedChanged;
            // 
            // labelAudioFrequency
            // 
            labelAudioFrequency.AutoSize = true;
            labelAudioFrequency.Location = new Point(35, 84);
            labelAudioFrequency.Name = "labelAudioFrequency";
            labelAudioFrequency.Size = new Size(100, 15);
            labelAudioFrequency.TabIndex = 1;
            labelAudioFrequency.Text = "Audio Frequency:";
            toolTip1.SetToolTip(labelAudioFrequency, "DSP frequency in samples per second");
            // 
            // labelAudioSamples
            // 
            labelAudioSamples.AutoSize = true;
            labelAudioSamples.Location = new Point(46, 112);
            labelAudioSamples.Name = "labelAudioSamples";
            labelAudioSamples.Size = new Size(89, 15);
            labelAudioSamples.TabIndex = 2;
            labelAudioSamples.Text = "Audio Samples:";
            toolTip1.SetToolTip(labelAudioSamples, "Audio buffer size in samples");
            // 
            // checkBoxQuickSwitch
            // 
            checkBoxQuickSwitch.AutoSize = true;
            checkBoxQuickSwitch.Location = new Point(6, 22);
            checkBoxQuickSwitch.Name = "checkBoxQuickSwitch";
            checkBoxQuickSwitch.Size = new Size(157, 19);
            checkBoxQuickSwitch.TabIndex = 0;
            checkBoxQuickSwitch.Text = "Advanced Item Selection";
            toolTip1.SetToolTip(checkBoxQuickSwitch, resources.GetString("checkBoxQuickSwitch.ToolTip"));
            checkBoxQuickSwitch.UseVisualStyleBackColor = true;
            checkBoxQuickSwitch.CheckedChanged += checkBoxQuickSwitch_CheckedChanged;
            // 
            // checkBoxLRLimit
            // 
            checkBoxLRLimit.AutoSize = true;
            checkBoxLRLimit.Location = new Point(6, 47);
            checkBoxLRLimit.Name = "checkBoxLRLimit";
            checkBoxLRLimit.Size = new Size(192, 19);
            checkBoxLRLimit.TabIndex = 1;
            checkBoxLRLimit.Text = "Limit L/R Switch to First 4 Items";
            toolTip1.SetToolTip(checkBoxLRLimit, "Limit the items you will cycle through to just the first four items");
            checkBoxLRLimit.UseVisualStyleBackColor = true;
            // 
            // checkBoxDashTurning
            // 
            checkBoxDashTurning.AutoSize = true;
            checkBoxDashTurning.Location = new Point(6, 72);
            checkBoxDashTurning.Name = "checkBoxDashTurning";
            checkBoxDashTurning.Size = new Size(179, 19);
            checkBoxDashTurning.TabIndex = 2;
            checkBoxDashTurning.Text = "Allow Turning While Dashing";
            toolTip1.SetToolTip(checkBoxDashTurning, "Allows you to turn when dashing");
            checkBoxDashTurning.UseVisualStyleBackColor = true;
            // 
            // checkBoxMirrorDark
            // 
            checkBoxMirrorDark.AutoSize = true;
            checkBoxMirrorDark.Location = new Point(6, 97);
            checkBoxMirrorDark.Name = "checkBoxMirrorDark";
            checkBoxMirrorDark.Size = new Size(185, 19);
            checkBoxMirrorDark.TabIndex = 3;
            checkBoxMirrorDark.Text = "Mirror Teleports to Dark World";
            toolTip1.SetToolTip(checkBoxMirrorDark, "Magic Mirror works in both directions");
            checkBoxMirrorDark.UseVisualStyleBackColor = true;
            // 
            // checkBoxSwordItems
            // 
            checkBoxSwordItems.AutoSize = true;
            checkBoxSwordItems.Location = new Point(6, 122);
            checkBoxSwordItems.Name = "checkBoxSwordItems";
            checkBoxSwordItems.Size = new Size(148, 19);
            checkBoxSwordItems.TabIndex = 4;
            checkBoxSwordItems.Text = "Collect Items w/ Sword";
            toolTip1.SetToolTip(checkBoxSwordItems, "You can collect items with your sword from a distance");
            checkBoxSwordItems.UseVisualStyleBackColor = true;
            // 
            // checkBoxSwordPots
            // 
            checkBoxSwordPots.AutoSize = true;
            checkBoxSwordPots.Location = new Point(6, 147);
            checkBoxSwordPots.Name = "checkBoxSwordPots";
            checkBoxSwordPots.Size = new Size(134, 19);
            checkBoxSwordPots.TabIndex = 5;
            checkBoxSwordPots.Text = "Break Pots w/ Sword";
            toolTip1.SetToolTip(checkBoxSwordPots, "You can break pots if you have a L2 or higher sword");
            checkBoxSwordPots.UseVisualStyleBackColor = true;
            // 
            // checkBoxHeartBeep
            // 
            checkBoxHeartBeep.AutoSize = true;
            checkBoxHeartBeep.Location = new Point(6, 172);
            checkBoxHeartBeep.Name = "checkBoxHeartBeep";
            checkBoxHeartBeep.Size = new Size(150, 19);
            checkBoxHeartBeep.TabIndex = 6;
            checkBoxHeartBeep.Text = "Disable Low Heart Beep";
            toolTip1.SetToolTip(checkBoxHeartBeep, "Disables the beeping when you are low health");
            checkBoxHeartBeep.UseVisualStyleBackColor = true;
            // 
            // checkBoxIntroSkip
            // 
            checkBoxIntroSkip.AutoSize = true;
            checkBoxIntroSkip.Location = new Point(6, 197);
            checkBoxIntroSkip.Name = "checkBoxIntroSkip";
            checkBoxIntroSkip.Size = new Size(142, 19);
            checkBoxIntroSkip.TabIndex = 7;
            checkBoxIntroSkip.Text = "Skip Intro w/ Keypress";
            toolTip1.SetToolTip(checkBoxIntroSkip, "Allows you to skip the intro by pressing a key");
            checkBoxIntroSkip.UseVisualStyleBackColor = true;
            // 
            // checkBoxMaxResources
            // 
            checkBoxMaxResources.AutoSize = true;
            checkBoxMaxResources.Location = new Point(6, 222);
            checkBoxMaxResources.Name = "checkBoxMaxResources";
            checkBoxMaxResources.Size = new Size(150, 19);
            checkBoxMaxResources.TabIndex = 8;
            checkBoxMaxResources.Text = "Indicate Max Resources";
            toolTip1.SetToolTip(checkBoxMaxResources, "Values will appear as yellow/orange when you have max resources (rupees, arrows, bombs)");
            checkBoxMaxResources.UseVisualStyleBackColor = true;
            // 
            // checkBoxMoreBombs
            // 
            checkBoxMoreBombs.AutoSize = true;
            checkBoxMoreBombs.Location = new Point(6, 247);
            checkBoxMoreBombs.Name = "checkBoxMoreBombs";
            checkBoxMoreBombs.Size = new Size(130, 19);
            checkBoxMoreBombs.TabIndex = 9;
            checkBoxMoreBombs.Text = "More Active Bombs";
            toolTip1.SetToolTip(checkBoxMoreBombs, "Can have 4 active bombs instead of 2");
            checkBoxMoreBombs.UseVisualStyleBackColor = true;
            // 
            // checkBoxLargerWallet
            // 
            checkBoxLargerWallet.AutoSize = true;
            checkBoxLargerWallet.Location = new Point(6, 272);
            checkBoxLargerWallet.Name = "checkBoxLargerWallet";
            checkBoxLargerWallet.Size = new Size(95, 19);
            checkBoxLargerWallet.TabIndex = 10;
            checkBoxLargerWallet.Text = "Larger Wallet";
            toolTip1.SetToolTip(checkBoxLargerWallet, "Can carry 9999 rupees");
            checkBoxLargerWallet.UseVisualStyleBackColor = true;
            // 
            // checkBoxMiscFixes
            // 
            checkBoxMiscFixes.AutoSize = true;
            checkBoxMiscFixes.Location = new Point(6, 297);
            checkBoxMiscFixes.Name = "checkBoxMiscFixes";
            checkBoxMiscFixes.Size = new Size(165, 19);
            checkBoxMiscFixes.TabIndex = 11;
            checkBoxMiscFixes.Text = "Miscellaneous Minor Fixes";
            toolTip1.SetToolTip(checkBoxMiscFixes, "Miscellaneous bug fixes");
            checkBoxMiscFixes.UseVisualStyleBackColor = true;
            // 
            // checkBoxMajorFixes
            // 
            checkBoxMajorFixes.AutoSize = true;
            checkBoxMajorFixes.Location = new Point(6, 322);
            checkBoxMajorFixes.Name = "checkBoxMajorFixes";
            checkBoxMajorFixes.Size = new Size(165, 19);
            checkBoxMajorFixes.TabIndex = 12;
            checkBoxMajorFixes.Text = "Game Changing Bug Fixes";
            toolTip1.SetToolTip(checkBoxMajorFixes, "Some bug fixes that are significant enough to impact game behavior");
            checkBoxMajorFixes.UseVisualStyleBackColor = true;
            // 
            // checkBoxCancelBird
            // 
            checkBoxCancelBird.AutoSize = true;
            checkBoxCancelBird.Location = new Point(6, 347);
            checkBoxCancelBird.Name = "checkBoxCancelBird";
            checkBoxCancelBird.Size = new Size(86, 19);
            checkBoxCancelBird.TabIndex = 13;
            checkBoxCancelBird.Text = "Cancel Bird";
            toolTip1.SetToolTip(checkBoxCancelBird, "Allows you to cancel bird travel by hitting the X button");
            checkBoxCancelBird.UseVisualStyleBackColor = true;
            // 
            // groupBoxMSUSettings
            // 
            groupBoxMSUSettings.Controls.Add(checkBoxMSUSymlink);
            groupBoxMSUSettings.Controls.Add(comboBoxMSU);
            groupBoxMSUSettings.Controls.Add(textBoxMSUDirectory);
            groupBoxMSUSettings.Controls.Add(labelMSUVersion);
            groupBoxMSUSettings.Controls.Add(labelMSUDirectory);
            groupBoxMSUSettings.Controls.Add(numericMSUVolume);
            groupBoxMSUSettings.Controls.Add(checkBoxResumeMSU);
            groupBoxMSUSettings.Controls.Add(labelMSUVolume);
            groupBoxMSUSettings.Controls.Add(buttonMSUDirectory);
            groupBoxMSUSettings.Location = new Point(6, 155);
            groupBoxMSUSettings.Name = "groupBoxMSUSettings";
            groupBoxMSUSettings.Size = new Size(190, 223);
            groupBoxMSUSettings.TabIndex = 4;
            groupBoxMSUSettings.TabStop = false;
            groupBoxMSUSettings.Text = "MSU Settings";
            toolTip1.SetToolTip(groupBoxMSUSettings, "Settings specifically for MSU");
            // 
            // checkBoxMSUSymlink
            // 
            checkBoxMSUSymlink.AutoSize = true;
            checkBoxMSUSymlink.Location = new Point(6, 149);
            checkBoxMSUSymlink.Name = "checkBoxMSUSymlink";
            checkBoxMSUSymlink.Size = new Size(122, 19);
            checkBoxMSUSymlink.TabIndex = 9;
            checkBoxMSUSymlink.Text = "Use Symbolic Link";
            toolTip1.SetToolTip(checkBoxMSUSymlink, "Creates a Symbolic Link to the target folder, instead of copying its files.\\nSaves space, but only works on NTFS filesystems.");
            checkBoxMSUSymlink.UseVisualStyleBackColor = true;
            checkBoxMSUSymlink.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // comboBoxMSU
            // 
            comboBoxMSU.FormattingEnabled = true;
            comboBoxMSU.Items.AddRange(new object[] { "MSU", "MSU Deluxe", "OPUZ", "OPUZ Deluxe" });
            comboBoxMSU.Location = new Point(85, 73);
            comboBoxMSU.MaxDropDownItems = 4;
            comboBoxMSU.Name = "comboBoxMSU";
            comboBoxMSU.Size = new Size(99, 23);
            comboBoxMSU.TabIndex = 2;
            comboBoxMSU.Text = "MSU";
            toolTip1.SetToolTip(comboBoxMSU, "Select the version of MSU you wish to use");
            comboBoxMSU.SelectedIndexChanged += comboBoxMSU_SelectedIndexChanged;
            // 
            // textBoxMSUDirectory
            // 
            textBoxMSUDirectory.Location = new Point(6, 120);
            textBoxMSUDirectory.Name = "textBoxMSUDirectory";
            textBoxMSUDirectory.Size = new Size(146, 23);
            textBoxMSUDirectory.TabIndex = 3;
            toolTip1.SetToolTip(textBoxMSUDirectory, "MSU directory path");
            textBoxMSUDirectory.TextChanged += textBoxMSUDirectory_TextChanged;
            // 
            // labelMSUVersion
            // 
            labelMSUVersion.AutoSize = true;
            labelMSUVersion.Location = new Point(6, 76);
            labelMSUVersion.Name = "labelMSUVersion";
            labelMSUVersion.Size = new Size(73, 15);
            labelMSUVersion.TabIndex = 7;
            labelMSUVersion.Text = "MSU Version";
            labelMSUVersion.Click += labelMSUVersion_Click;
            // 
            // labelMSUDirectory
            // 
            labelMSUDirectory.AutoSize = true;
            labelMSUDirectory.Location = new Point(6, 99);
            labelMSUDirectory.Name = "labelMSUDirectory";
            labelMSUDirectory.Size = new Size(86, 15);
            labelMSUDirectory.TabIndex = 8;
            labelMSUDirectory.Text = "MSU Directory:";
            toolTip1.SetToolTip(labelMSUDirectory, "Directory where MSU files are located");
            labelMSUDirectory.Click += labelMSUDirectory_Click;
            // 
            // numericMSUVolume
            // 
            numericMSUVolume.Location = new Point(90, 44);
            numericMSUVolume.Name = "numericMSUVolume";
            numericMSUVolume.Size = new Size(42, 23);
            numericMSUVolume.TabIndex = 1;
            toolTip1.SetToolTip(numericMSUVolume, "Volume of MSU output (0-100)");
            numericMSUVolume.Value = new decimal(new int[] { 100, 0, 0, 0 });
            numericMSUVolume.ValueChanged += numericMSUVolume_ValueChanged;
            // 
            // checkBoxResumeMSU
            // 
            checkBoxResumeMSU.AutoSize = true;
            checkBoxResumeMSU.Location = new Point(6, 20);
            checkBoxResumeMSU.Name = "checkBoxResumeMSU";
            checkBoxResumeMSU.Size = new Size(96, 19);
            checkBoxResumeMSU.TabIndex = 0;
            checkBoxResumeMSU.Text = "Resume MSU";
            toolTip1.SetToolTip(checkBoxResumeMSU, "Resume MSU music from the same point in the track when returning to an area");
            checkBoxResumeMSU.UseVisualStyleBackColor = true;
            // 
            // labelMSUVolume
            // 
            labelMSUVolume.AutoSize = true;
            labelMSUVolume.Location = new Point(6, 48);
            labelMSUVolume.Name = "labelMSUVolume";
            labelMSUVolume.Size = new Size(78, 15);
            labelMSUVolume.TabIndex = 8;
            labelMSUVolume.Text = "MSU Volume:";
            toolTip1.SetToolTip(labelMSUVolume, "Volume of MSU output (0-100)");
            labelMSUVolume.Click += labelMSUVolume_Click;
            // 
            // buttonMSUDirectory
            // 
            buttonMSUDirectory.AutoSize = true;
            buttonMSUDirectory.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonMSUDirectory.Location = new Point(158, 119);
            buttonMSUDirectory.Name = "buttonMSUDirectory";
            buttonMSUDirectory.Size = new Size(26, 25);
            buttonMSUDirectory.TabIndex = 4;
            buttonMSUDirectory.Text = "...";
            toolTip1.SetToolTip(buttonMSUDirectory, "Open dialog to select MSU directory");
            buttonMSUDirectory.UseVisualStyleBackColor = true;
            buttonMSUDirectory.Click += buttonMSUDirectory_Click;
            // 
            // comboBoxSamples
            // 
            comboBoxSamples.FormattingEnabled = true;
            comboBoxSamples.Items.AddRange(new object[] { "512", "1024", "2048", "4096" });
            comboBoxSamples.Location = new Point(141, 109);
            comboBoxSamples.MaxDropDownItems = 4;
            comboBoxSamples.Name = "comboBoxSamples";
            comboBoxSamples.Size = new Size(55, 23);
            comboBoxSamples.TabIndex = 2;
            toolTip1.SetToolTip(comboBoxSamples, "Audio buffer size in samples");
            // 
            // comboBoxFrequency
            // 
            comboBoxFrequency.FormattingEnabled = true;
            comboBoxFrequency.Items.AddRange(new object[] { "48000", "44100", "32000", "22050", "11025" });
            comboBoxFrequency.Location = new Point(141, 80);
            comboBoxFrequency.MaxDropDownItems = 5;
            comboBoxFrequency.Name = "comboBoxFrequency";
            comboBoxFrequency.Size = new Size(55, 23);
            comboBoxFrequency.TabIndex = 1;
            toolTip1.SetToolTip(comboBoxFrequency, "DSP frequency in samples per second");
            // 
            // checkBoxEnableMSU
            // 
            checkBoxEnableMSU.AutoSize = true;
            checkBoxEnableMSU.Location = new Point(6, 130);
            checkBoxEnableMSU.Name = "checkBoxEnableMSU";
            checkBoxEnableMSU.Size = new Size(89, 19);
            checkBoxEnableMSU.TabIndex = 3;
            checkBoxEnableMSU.Text = "Enable MSU";
            toolTip1.SetToolTip(checkBoxEnableMSU, resources.GetString("checkBoxEnableMSU.ToolTip"));
            checkBoxEnableMSU.UseVisualStyleBackColor = true;
            checkBoxEnableMSU.CheckedChanged += checkBoxEnableMSU_CheckedChanged;
            // 
            // radioButtonStereo
            // 
            radioButtonStereo.AutoSize = true;
            radioButtonStereo.Checked = true;
            radioButtonStereo.Location = new Point(92, 22);
            radioButtonStereo.Name = "radioButtonStereo";
            radioButtonStereo.Size = new Size(58, 19);
            radioButtonStereo.TabIndex = 1;
            radioButtonStereo.TabStop = true;
            radioButtonStereo.Text = "Stereo";
            toolTip1.SetToolTip(radioButtonStereo, "Outputs audio to the left or right speakers based where the sound is generated on screen");
            radioButtonStereo.UseVisualStyleBackColor = true;
            // 
            // radioButtonMono
            // 
            radioButtonMono.AutoSize = true;
            radioButtonMono.Location = new Point(29, 22);
            radioButtonMono.Name = "radioButtonMono";
            radioButtonMono.Size = new Size(57, 19);
            radioButtonMono.TabIndex = 0;
            radioButtonMono.Text = "Mono";
            toolTip1.SetToolTip(radioButtonMono, "Uniform audio output across all speakers");
            radioButtonMono.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(12, 491);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(202, 35);
            buttonReset.TabIndex = 3;
            buttonReset.Text = "Default";
            toolTip1.SetToolTip(buttonReset, "Reset all settings to their default values");
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(399, 491);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(202, 35);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save";
            toolTip1.SetToolTip(buttonSave, "Save current settings and close window");
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(607, 491);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(202, 35);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            toolTip1.SetToolTip(buttonCancel, "Close window without saving any settings");
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // labelRenderMethod
            // 
            labelRenderMethod.AutoSize = true;
            labelRenderMethod.Location = new Point(6, 183);
            labelRenderMethod.Name = "labelRenderMethod";
            labelRenderMethod.Size = new Size(92, 15);
            labelRenderMethod.TabIndex = 11;
            labelRenderMethod.Text = "Render Method:";
            toolTip1.SetToolTip(labelRenderMethod, "Rendering software used. SDL-software rendering may give better performance on Raspberry Pi");
            // 
            // comboRenderMethod
            // 
            comboRenderMethod.FormattingEnabled = true;
            comboRenderMethod.Items.AddRange(new object[] { "SDL (Default)", "SDL-Software", "OpenGL" });
            comboRenderMethod.Location = new Point(104, 180);
            comboRenderMethod.MaxDropDownItems = 3;
            comboRenderMethod.Name = "comboRenderMethod";
            comboRenderMethod.Size = new Size(144, 23);
            comboRenderMethod.TabIndex = 8;
            toolTip1.SetToolTip(comboRenderMethod, "Rendering software used. SDL-software rendering may give better performance on Raspberry Pi");
            // 
            // linkLabelCustomSprites
            // 
            linkLabelCustomSprites.AutoSize = true;
            linkLabelCustomSprites.Location = new Point(230, 210);
            linkLabelCustomSprites.Name = "linkLabelCustomSprites";
            linkLabelCustomSprites.Size = new Size(144, 15);
            linkLabelCustomSprites.TabIndex = 11;
            linkLabelCustomSprites.TabStop = true;
            linkLabelCustomSprites.Text = "Custom Sprite Downloads";
            toolTip1.SetToolTip(linkLabelCustomSprites, "Click here for some custom sprites you can download");
            linkLabelCustomSprites.LinkClicked += linkLabelCustomSprites_LinkClicked;
            // 
            // buttonKeymapping
            // 
            buttonKeymapping.Location = new Point(12, 450);
            buttonKeymapping.Name = "buttonKeymapping";
            buttonKeymapping.Size = new Size(202, 35);
            buttonKeymapping.TabIndex = 0;
            buttonKeymapping.Text = "Keymapping";
            toolTip1.SetToolTip(buttonKeymapping, "Open a new settings menu exclusively for configuring keymappings for the game");
            buttonKeymapping.UseVisualStyleBackColor = true;
            buttonKeymapping.Click += buttonKeymapping_Click;
            // 
            // linkLabelMinorFixes
            // 
            linkLabelMinorFixes.AutoSize = true;
            linkLabelMinorFixes.Location = new Point(165, 298);
            linkLabelMinorFixes.Name = "linkLabelMinorFixes";
            linkLabelMinorFixes.Size = new Size(12, 15);
            linkLabelMinorFixes.TabIndex = 9;
            linkLabelMinorFixes.TabStop = true;
            linkLabelMinorFixes.Text = "?";
            toolTip1.SetToolTip(linkLabelMinorFixes, "This webpage will list the specific fixes");
            linkLabelMinorFixes.LinkClicked += linkLabelMinorFixes_LinkClicked;
            // 
            // graphics
            // 
            graphics.Controls.Add(linkLabelGLSLShaders);
            graphics.Controls.Add(linkLabelCustomSprites);
            graphics.Controls.Add(checkBoxShader);
            graphics.Controls.Add(checkBoxCustomLinkSprites);
            graphics.Controls.Add(textBoxCustomLink);
            graphics.Controls.Add(buttonOpenSprites);
            graphics.Controls.Add(checkStretch);
            graphics.Controls.Add(textBoxGLSLShader);
            graphics.Controls.Add(buttonOpenShader);
            graphics.Controls.Add(labelRenderMethod);
            graphics.Controls.Add(comboRenderMethod);
            graphics.Controls.Add(checkLinearFiltering);
            graphics.Controls.Add(checkSpriteLimit);
            graphics.Controls.Add(checkMode7);
            graphics.Controls.Add(numericWindowScale);
            graphics.Controls.Add(labelScale);
            graphics.Controls.Add(checkPPU);
            graphics.Controls.Add(fullscreenMode);
            graphics.Controls.Add(windowSize);
            graphics.Location = new Point(220, 168);
            graphics.Name = "graphics";
            graphics.Size = new Size(381, 317);
            graphics.TabIndex = 6;
            graphics.TabStop = false;
            graphics.Text = "Graphics";
            // 
            // linkLabelGLSLShaders
            // 
            linkLabelGLSLShaders.AutoSize = true;
            linkLabelGLSLShaders.Location = new Point(268, 264);
            linkLabelGLSLShaders.Name = "linkLabelGLSLShaders";
            linkLabelGLSLShaders.Size = new Size(106, 15);
            linkLabelGLSLShaders.TabIndex = 14;
            linkLabelGLSLShaders.TabStop = true;
            linkLabelGLSLShaders.Text = "Suggested Shaders";
            linkLabelGLSLShaders.LinkClicked += linkLabelGLSLShaders_LinkClicked;
            // 
            // fullscreenMode
            // 
            fullscreenMode.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fullscreenMode.Controls.Add(radioFullscreenMode);
            fullscreenMode.Controls.Add(radioFullscreen);
            fullscreenMode.Controls.Add(radioWindowed);
            fullscreenMode.Location = new Point(189, 22);
            fullscreenMode.Name = "fullscreenMode";
            fullscreenMode.Size = new Size(185, 102);
            fullscreenMode.TabIndex = 1;
            fullscreenMode.TabStop = false;
            fullscreenMode.Text = "Fullscreen Mode";
            // 
            // windowSize
            // 
            windowSize.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            windowSize.Controls.Add(height);
            windowSize.Controls.Add(windowSizeX);
            windowSize.Controls.Add(width);
            windowSize.Controls.Add(customSize);
            windowSize.Controls.Add(windowAuto);
            windowSize.Location = new Point(6, 22);
            windowSize.Name = "windowSize";
            windowSize.Size = new Size(177, 102);
            windowSize.TabIndex = 0;
            windowSize.TabStop = false;
            windowSize.Text = "Window Size";
            // 
            // windowSizeX
            // 
            windowSizeX.AutoSize = true;
            windowSizeX.Enabled = false;
            windowSizeX.ForeColor = SystemColors.ControlText;
            windowSizeX.Location = new Point(43, 76);
            windowSizeX.Name = "windowSizeX";
            windowSizeX.Size = new Size(14, 15);
            windowSizeX.TabIndex = 3;
            windowSizeX.Text = "X";
            // 
            // groupBoxSound
            // 
            groupBoxSound.Controls.Add(groupBoxMSUSettings);
            groupBoxSound.Controls.Add(comboBoxSamples);
            groupBoxSound.Controls.Add(comboBoxFrequency);
            groupBoxSound.Controls.Add(checkBoxEnableMSU);
            groupBoxSound.Controls.Add(groupBoxAudioChannels);
            groupBoxSound.Controls.Add(labelAudioSamples);
            groupBoxSound.Controls.Add(labelAudioFrequency);
            groupBoxSound.Location = new Point(607, 66);
            groupBoxSound.Name = "groupBoxSound";
            groupBoxSound.Size = new Size(202, 419);
            groupBoxSound.TabIndex = 8;
            groupBoxSound.TabStop = false;
            groupBoxSound.Text = "Sound";
            // 
            // groupBoxAudioChannels
            // 
            groupBoxAudioChannels.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBoxAudioChannels.Controls.Add(radioButtonStereo);
            groupBoxAudioChannels.Controls.Add(radioButtonMono);
            groupBoxAudioChannels.Location = new Point(6, 22);
            groupBoxAudioChannels.Name = "groupBoxAudioChannels";
            groupBoxAudioChannels.Size = new Size(190, 54);
            groupBoxAudioChannels.TabIndex = 0;
            groupBoxAudioChannels.TabStop = false;
            groupBoxAudioChannels.Text = "Audio Channels";
            // 
            // groupBoxGameplay
            // 
            groupBoxGameplay.Controls.Add(linkLabelMajorFixes);
            groupBoxGameplay.Controls.Add(checkBoxCancelBird);
            groupBoxGameplay.Controls.Add(linkLabelMinorFixes);
            groupBoxGameplay.Controls.Add(checkBoxMajorFixes);
            groupBoxGameplay.Controls.Add(checkBoxLargerWallet);
            groupBoxGameplay.Controls.Add(checkBoxMoreBombs);
            groupBoxGameplay.Controls.Add(checkBoxMiscFixes);
            groupBoxGameplay.Controls.Add(checkBoxMaxResources);
            groupBoxGameplay.Controls.Add(checkBoxIntroSkip);
            groupBoxGameplay.Controls.Add(checkBoxHeartBeep);
            groupBoxGameplay.Controls.Add(checkBoxSwordPots);
            groupBoxGameplay.Controls.Add(checkBoxSwordItems);
            groupBoxGameplay.Controls.Add(checkBoxMirrorDark);
            groupBoxGameplay.Controls.Add(checkBoxDashTurning);
            groupBoxGameplay.Controls.Add(checkBoxLRLimit);
            groupBoxGameplay.Controls.Add(checkBoxQuickSwitch);
            groupBoxGameplay.Location = new Point(12, 35);
            groupBoxGameplay.Name = "groupBoxGameplay";
            groupBoxGameplay.Size = new Size(202, 409);
            groupBoxGameplay.TabIndex = 4;
            groupBoxGameplay.TabStop = false;
            groupBoxGameplay.Text = "Gameplay";
            // 
            // linkLabelMajorFixes
            // 
            linkLabelMajorFixes.AutoSize = true;
            linkLabelMajorFixes.Location = new Point(165, 323);
            linkLabelMajorFixes.Name = "linkLabelMajorFixes";
            linkLabelMajorFixes.Size = new Size(12, 15);
            linkLabelMajorFixes.TabIndex = 9;
            linkLabelMajorFixes.TabStop = true;
            linkLabelMajorFixes.Text = "?";
            linkLabelMajorFixes.LinkClicked += linkLabel2_LinkClicked;
            // 
            // labelHoverNote
            // 
            labelHoverNote.Location = new Point(6, 9);
            labelHoverNote.Name = "labelHoverNote";
            labelHoverNote.Size = new Size(797, 23);
            labelHoverNote.TabIndex = 5;
            labelHoverNote.Text = "NOTE: You can hover over an option to get a more detailed description of what each setting does.";
            labelHoverNote.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelMSUCopy
            // 
            labelMSUCopy.Location = new Point(12, 538);
            labelMSUCopy.Name = "labelMSUCopy";
            labelMSUCopy.Size = new Size(797, 23);
            labelMSUCopy.TabIndex = 6;
            labelMSUCopy.Text = "Copying MSU Files...";
            labelMSUCopy.TextAlign = ContentAlignment.MiddleCenter;
            labelMSUCopy.Visible = false;
            // 
            // progressMSU
            // 
            progressMSU.Location = new Point(15, 564);
            progressMSU.Name = "progressMSU";
            progressMSU.Size = new Size(797, 23);
            progressMSU.TabIndex = 7;
            progressMSU.Visible = false;
            // 
            // settingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(821, 680);
            Controls.Add(buttonKeymapping);
            Controls.Add(progressMSU);
            Controls.Add(labelMSUCopy);
            Controls.Add(labelHoverNote);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(buttonReset);
            Controls.Add(groupBoxGameplay);
            Controls.Add(groupBoxSound);
            Controls.Add(graphics);
            Controls.Add(general);
            Controls.Add(checkBoxEnableAudio);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "settingsForm";
            Padding = new Padding(6);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            general.ResumeLayout(false);
            general.PerformLayout();
            aspectRatio.ResumeLayout(false);
            aspectRatio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericWindowScale).EndInit();
            groupBoxMSUSettings.ResumeLayout(false);
            groupBoxMSUSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericMSUVolume).EndInit();
            graphics.ResumeLayout(false);
            graphics.PerformLayout();
            fullscreenMode.ResumeLayout(false);
            fullscreenMode.PerformLayout();
            windowSize.ResumeLayout(false);
            windowSize.PerformLayout();
            groupBoxSound.ResumeLayout(false);
            groupBoxSound.PerformLayout();
            groupBoxAudioChannels.ResumeLayout(false);
            groupBoxAudioChannels.PerformLayout();
            groupBoxGameplay.ResumeLayout(false);
            groupBoxGameplay.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox general;
        private CheckBox autosaveCheck;
        private ToolTip toolTip1;
        private GroupBox aspectRatio;
        private RadioButton steamdeck;
        private RadioButton widescreen;
        private RadioButton normal;
        private CheckBox performance;
        private CheckBox noVisualFixes;
        private CheckBox unchangedSprites;
        private CheckBox disableFrameDelay;
        private GroupBox graphics;
        private RadioButton windowAuto;
        private GroupBox windowSize;
        private TextBox width;
        private RadioButton customSize;
        private TextBox height;
        private Label windowSizeX;
        private GroupBox fullscreenMode;
        private RadioButton radioFullscreenMode;
        private RadioButton radioFullscreen;
        private RadioButton radioWindowed;
        private NumericUpDown numericWindowScale;
        private Label labelScale;
        private CheckBox checkPPU;
        private CheckBox checkMode7;
        private CheckBox checkStretch;
        private Label labelRenderMethod;
        private ComboBox comboRenderMethod;
        private CheckBox checkLinearFiltering;
        private CheckBox checkSpriteLimit;
        private CheckBox checkBoxShader;
        private CheckBox checkBoxCustomLinkSprites;
        private TextBox textBoxCustomLink;
        private Button buttonOpenSprites;
        private TextBox textBoxGLSLShader;
        private Button buttonOpenShader;
        private GroupBox groupBoxSound;
        private ComboBox comboBoxFrequency;
        private GroupBox groupBoxAudioChannels;
        private RadioButton radioButtonStereo;
        private RadioButton radioButtonMono;
        private Label labelAudioSamples;
        private Label labelAudioFrequency;
        private CheckBox checkBoxEnableAudio;
        private ComboBox comboBoxSamples;
        private NumericUpDown numericMSUVolume;
        private GroupBox groupBoxMSUSettings;
        private CheckBox checkBoxResumeMSU;
        private Label labelMSUVolume;
        private CheckBox checkBoxEnableMSU;
        private TextBox textBoxMSUDirectory;
        private Label labelMSUDirectory;
        private Button buttonMSUDirectory;
        private GroupBox groupBoxGameplay;
        private CheckBox checkBoxCancelBird;
        private CheckBox checkBoxMajorFixes;
        private CheckBox checkBoxMiscFixes;
        private CheckBox checkBoxLargerWallet;
        private CheckBox checkBoxMoreBombs;
        private CheckBox checkBoxMaxResources;
        private CheckBox checkBoxIntroSkip;
        private CheckBox checkBoxHeartBeep;
        private CheckBox checkBoxSwordPots;
        private CheckBox checkBoxSwordItems;
        private CheckBox checkBoxMirrorDark;
        private CheckBox checkBoxDashTurning;
        private CheckBox checkBoxLRLimit;
        private CheckBox checkBoxQuickSwitch;
        private Button buttonReset;
        private Button buttonSave;
        private Button buttonCancel;
        private CheckBox checkBoxExtend;
        private Label labelHoverNote;
        private ComboBox comboBoxMSU;
        private Label labelMSUVersion;
        private LinkLabel linkLabelCustomSprites;
        private LinkLabel linkLabelGLSLShaders;
        private Label labelMSUCopy;
        private ProgressBar progressMSU;
        private Button buttonKeymapping;
        private LinkLabel linkLabelMinorFixes;
        private LinkLabel linkLabelMajorFixes;
        private CheckBox checkBoxMSUSymlink;
    }
}