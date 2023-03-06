using System.Data;
using System.Diagnostics;
using System.Net;
using System.Text;
using IniParser;
using IniParser.Model.Configuration;
using IniParser.Parser;
using XAct;

namespace Zelda_3_Launcher
{
    public partial class settingsForm : Form
    {
        private string v;

        private static volatile int progress = 0;

        public settingsForm()
        {
            InitializeComponent();

            try
            {
                ImportINI();
            }
            catch
            {
                var answer = MessageBox.Show("INI file is corrupted and preventing the settings menu from loading.\n\nDo you want to restore to default settings?", "Corrupted Settings", MessageBoxButtons.YesNo);

                if (answer == DialogResult.No)
                {
                    this.Close();
                    return;
                }

                buttonReset_Click(this, new EventArgs());
            }

            if (checkBoxEnableMSU.Checked == false) groupBoxMSUSettings.Enabled = false;
            if (checkBoxEnableAudio.Checked == false) groupBoxSound.Enabled = false;
        }

        private void ToggleCustomSizeTextFields()
        {
            if (customSize.Checked)
            {
                height.Enabled = true;
                width.Enabled = true;
                windowSizeX.Enabled = true;
            }
            else
            {
                height.Enabled = false;
                width.Enabled = false;
                windowSizeX.Enabled = false;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            this.buttonReset.Text = "Resetting...";

            this.Enabled = false;

            var answer = MessageBox.Show("This will reset the INI file immediately and cannot be reversed.\n\nDo you wish to continue?", "Confirmation", MessageBoxButtons.YesNo);

            if (answer == DialogResult.No)
            {
                this.Enabled = true;
                this.buttonReset.Text = "Reset";
                return;
            }
            
            restoreINI();
            try
            {
                ImportINI();
            }
            catch
            {
                answer = MessageBox.Show("INI backup file is corrupted and preventing the settings menu from loading.\n\nDo you want to download a clean copy from the zelda3 repository?", "Corrupted Settings", MessageBoxButtons.YesNo);

                if (answer == DialogResult.No)
                {
                    this.Close();
                    return;
                }

                File.Delete(Path.Combine(Program.repoDir, "saves", "zelda3.ini"));

                restoreINI();
                ImportINI();
            }

            this.Enabled = true;

            this.buttonReset.Text = "Reset";
        }

        private void restoreINI()
        {
            var iniFile = Path.Combine(Program.repoDir, "zelda3.ini");
            var iniBackup = Path.Combine(Program.repoDir, "saves", "zelda3.ini");

            File.Delete(iniFile);

            if (!File.Exists(iniBackup)) DownloadFreshINI();

            using (var modifiedFile = File.AppendText(iniFile))
            {
                foreach (var line in File.ReadLines(iniBackup))
                {
                    if (!line.Equals("# Change the appearance of Link by loading a ZSPR file") &&
                        !line.Equals("# See all sprites here: https://snesrev.github.io/sprites-gfx/snes/zelda3/link/") &&
                        !line.Equals("# Download the files with \"git clone https://github.com/snesrev/sprites-gfx.git\"") &&
                        !line.Equals("# LinkGraphics = sprites-gfx/snes/zelda3/link/sheets/megaman-x.2.zspr"))
                    {
                        modifiedFile.WriteLine(line);
                    }
                }
            }
        }

        internal static void DownloadFreshINI()
        {
            var filename = "zelda3.ini";
            Uri uri = new Uri("https://raw.githubusercontent.com/snesrev/zelda3/master/zelda3.ini");

            var directory = Path.Combine(Program.repoDir, "saves");
            var destination = Path.Combine(Program.repoDir, "saves", filename);

            if (!progressForm.IsConnectedToInternet())
            {
                MessageBox.Show("Your INI backup file is missing and you are unable to connect to the internet to download a fresh copy.\n\nPlease ensure you have a stable internet connection before attempting to reset settings.",
                    "No Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Task.Run(() =>
            {
                using (var client = new WebClient())
                {
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloadProgress);
                    client.DownloadFileAsync(uri, destination);
                }
            });

            while (!File.Exists(destination))
            {
                Application.DoEvents();
            }

            do
            {
            } while (progress < 100);
        }

        private static void downloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            progress = e.ProgressPercentage;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            buttonSave.Text = "Saving...";

            groupBoxGameplay.Enabled = false;
            general.Enabled = false;
            graphics.Enabled = false;
            checkBoxEnableAudio.Enabled = false;
            groupBoxSound.Enabled = false;
            buttonReset.Enabled = false;
            buttonSave.Enabled = false;
            buttonCancel.Enabled = false;

            SaveToINI();

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("The changes that you have made will not be saved.\n\nDo you wish to continue?", "Confirmation", MessageBoxButtons.YesNo);

            if (answer == DialogResult.No) return;

            this.Close();
        }

        private void checkBoxQuickSwitch_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxLRLimit.Enabled = checkBoxQuickSwitch.Checked;
        }

        private void customSizeChange(object sender, EventArgs e)
        {
            ToggleCustomSizeTextFields();
        }

        private void checkBoxCustomLinkSprites_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCustomLink.Enabled = checkBoxCustomLinkSprites.Checked;
            buttonOpenSprites.Enabled = checkBoxCustomLinkSprites.Checked;
        }

        private void checkBoxShader_CheckedChanged(object sender, EventArgs e)
        {
            textBoxGLSLShader.Enabled = checkBoxShader.Checked;
            buttonOpenShader.Enabled = checkBoxShader.Checked;

            if (checkBoxShader.Checked)
            {
                comboRenderMethod.SelectedIndex = 2;
                comboRenderMethod.Enabled = false;
            }
            else
            {
                comboRenderMethod.Enabled = true;
            }
        }

        private void checkBoxEnableAudio_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSound.Enabled = checkBoxEnableAudio.Checked;
        }

        private void checkBoxEnableMSU_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxMSUSettings.Enabled = checkBoxEnableMSU.Checked;
        }

        private void ImportINI()
        {
            var iniFile = Path.Combine(Program.repoDir, "zelda3.ini");

            // Check for INI and if missing restore from initial install backup
            if (!File.Exists(iniFile))
            {
                var iniBackup = Path.Combine(Program.repoDir, "saves", "zelda3.ini");

                if (!File.Exists(iniBackup)) DownloadFreshINI();

                using (var modifiedFile = File.AppendText(iniFile))
                {
                    foreach (var line in File.ReadLines(iniBackup))
                    {
                        if (!line.Equals("# Change the appearance of Link by loading a ZSPR file") &&
                            !line.Equals("# See all sprites here: https://snesrev.github.io/sprites-gfx/snes/zelda3/link/") &&
                            !line.Equals("# Download the files with \"git clone https://github.com/snesrev/sprites-gfx.git\"") &&
                            !line.Equals("# LinkGraphics = sprites-gfx/snes/zelda3/link/sheets/megaman-x.2.zspr") &&
                            !line.Equals("# This default is suitable for QWERTZ keyboards.") &&
                            !line.Equals("#Controls = Up, Down, Left, Right, Right Shift, Return, x, y, s, a, c, v") &&
                            !line.Equals("# This one is suitable for AZERTY keyboards.") &&
                            !line.Equals("#Controls = Up, Down, Left, Right, Right Shift, Return, x, w, s, q, c, v"))
                        {
                            modifiedFile.WriteLine(line);
                        }
                    }
                }
            }
            var iniText = File.ReadAllText(iniFile);

            // INI parsing
            var config = new IniParserConfiguration();
            config.CommentString = "#";

            var parser = new IniDataParser(config);

            var settings = parser.Parse(iniText);

            // General Settings

            autosaveCheck.Checked = settings["General"]["Autosave"].ToBool();
            performance.Checked = settings["General"]["DisplayPerfInTitle"].ToBool();
            disableFrameDelay.Checked = settings["General"]["DisableFrameDelay"].ToBool();

            unchangedSprites.Checked = false;
            noVisualFixes.Checked = false;
            checkBoxExtend.Checked = false;
            var ratioSettings = settings["General"]["ExtendedAspectRatio"].Split(',');
            foreach(var item in ratioSettings)
            {
                switch (item.Trim())
                {
                    case "unchanged_sprites":
                        unchangedSprites.Checked = true;
                        break;
                    case "no_visual_fixes":
                        noVisualFixes.Checked = true;
                        break;
                    case "extend_y":
                        checkBoxExtend.Checked = true;
                        break;
                    default:
                        SetAspectRatio(item.Trim());
                        break;
                }
            }

            // Graphics Settings

            if (!settings["Graphics"]["WindowSize"].Equals("Auto"))
            {
                var resolution = settings["Graphics"]["WindowSize"].Split("x");

                customSize.Checked = true;
                width.Text = resolution[0];
                height.Text = resolution[1];
            }
            else
            {
                windowAuto.Checked = true;
                width.Text = "";
                height.Text = "";
            }

            switch (settings["Graphics"]["Fullscreen"])
            {
                case "0":
                    radioWindowed.Checked = true;
                    break;
                case "1":
                    radioFullscreen.Checked = true;
                    break;
                case "2":
                    radioFullscreenMode.Checked = true;
                    break;
            }

            numericWindowScale.Value = Decimal.Parse(settings["Graphics"]["WindowScale"]);
            checkPPU.Checked = settings["Graphics"]["NewRenderer"].ToBool();
            checkMode7.Checked = settings["Graphics"]["EnhancedMode7"].ToBool();
            checkStretch.Checked = settings["Graphics"]["IgnoreAspectRatio"].ToBool();
            checkSpriteLimit.Checked = settings["Graphics"]["NoSpriteLimits"].ToBool();
            checkLinearFiltering.Checked = settings["Graphics"]["LinearFiltering"].ToBool();
            checkBoxDimFlashing.Checked = settings["Graphics"]["DimFlashes"].ToBool();
            
            switch (settings["Graphics"]["OutputMethod"])
            {
                case "SDL":
                    comboRenderMethod.SelectedIndex = 0;
                    break;
                case "SDL-Software":
                    comboRenderMethod.SelectedIndex = 1;
                    break;
                case "OpenGL":
                    comboRenderMethod.SelectedIndex = 2;
                    break;
            }

            if (settings["Graphics"]["LinkGraphics"] != null)
            {
                checkBoxCustomLinkSprites.Checked = true;
                textBoxCustomLink.Enabled = true;
                textBoxCustomLink.Text = settings["Graphics"]["LinkGraphics"];
                buttonOpenSprites.Enabled = true;
            }
            else
            {
                checkBoxCustomLinkSprites.Checked = false;
                textBoxCustomLink.Enabled = false;
                buttonOpenSprites.Enabled = false;
            }

            if (settings["Graphics"]["Shader"].Equals(""))
            {
                checkBoxShader.Checked = false;
                textBoxGLSLShader.Enabled = false;
                textBoxGLSLShader.Text = "";
                buttonOpenShader.Enabled = false;
            }
            else
            {
                checkBoxShader.Checked = true;
                textBoxGLSLShader.Enabled = true;
                textBoxGLSLShader.Text = settings["Graphics"]["Shader"];
                buttonOpenShader.Enabled = true;
            }

            // Sound Settings

            checkBoxEnableAudio.Checked = settings["Sound"]["EnableAudio"].ToBool();
            checkBoxResumeMSU.Checked = settings["Sound"]["ResumeMSU"].ToBool();
            textBoxMSUDirectory.Text = settings["Sound"]["MSUPath"];

            if (settings["Sound"]["AudioChannels"].Equals("1")) radioButtonMono.Checked = true;
            else radioButtonStereo.Checked = true;

            switch (settings["Sound"]["AudioFreq"])
            {
                case "48000":
                    comboBoxFrequency.SelectedIndex = 0;
                    break;
                case "32000":
                    comboBoxFrequency.SelectedIndex = 2;
                    break;
                case "22050":
                    comboBoxFrequency.SelectedIndex = 3;
                    break;
                case "11025":
                    comboBoxFrequency.SelectedIndex = 4;
                    break;
                default:
                    comboBoxFrequency.SelectedIndex = 1;
                    break;
            }

            switch (settings["Sound"]["AudioSamples"])
            {
                case "512":
                    comboBoxSamples.SelectedIndex = 0;
                    break;
                case "1024":
                    comboBoxSamples.SelectedIndex = 1;
                    break;
                case "2048":
                    comboBoxSamples.SelectedIndex = 2;
                    break;
                case "4096":
                    comboBoxSamples.SelectedIndex = 3;
                    break;
                default:
                    comboBoxSamples.Text = settings["Sound"]["AudioSamples"];
                    break;
            }

            var msuVolume = Decimal.Parse(settings["Sound"]["MSUVolume"].Replace("%", ""));
            if (msuVolume.IsBetween(0, 100)) numericMSUVolume.Value = msuVolume;
            else numericMSUVolume.Value = 100;

            if (settings["Sound"]["EnableMSU"].Equals("false"))
            {
                checkBoxEnableMSU.Checked = false;
            }
            else
            {
                checkBoxEnableMSU.Checked = true;
                switch (settings["Sound"]["EnableMSU"])
                {
                    case "deluxe":
                        comboBoxMSU.SelectedIndex = 1;
                        break;
                    case "opuz":
                        comboBoxMSU.SelectedIndex = 2;
                        break;
                    case "deluxe-opuz":
                        comboBoxMSU.SelectedIndex = 3;
                        break;
                    default:
                        comboBoxMSU.SelectedIndex = 0;
                        break;
                }
            }

            // Gameplay Settings

            if (settings["Features"]["ItemSwitchLR"].ToBool())
            {
                checkBoxQuickSwitch.Checked = true;
                checkBoxLRLimit.Enabled= true;
            }
            else
            {
                checkBoxQuickSwitch.Checked = false;
                checkBoxLRLimit.Enabled = false;
            }

            checkBoxLRLimit.Checked = settings["Features"]["ItemSwitchLRLimit"].ToBool();
            checkBoxDashTurning.Checked = settings["Features"]["TurnWhileDashing"].ToBool();
            checkBoxMirrorDark.Checked = settings["Features"]["MirrorToDarkworld"].ToBool();
            checkBoxSwordItems.Checked = settings["Features"]["CollectItemsWithSword"].ToBool();
            checkBoxSwordPots.Checked = settings["Features"]["BreakPotsWithSword"].ToBool();
            checkBoxHeartBeep.Checked = settings["Features"]["DisableLowHealthBeep"].ToBool();
            checkBoxIntroSkip.Checked = settings["Features"]["SkipIntroOnKeypress"].ToBool();
            checkBoxMaxResources.Checked = settings["Features"]["ShowMaxItemsInYellow"].ToBool();
            checkBoxMoreBombs.Checked = settings["Features"]["MoreActiveBombs"].ToBool();
            checkBoxLargerWallet.Checked = settings["Features"]["CarryMoreRupees"].ToBool();
            checkBoxMiscFixes.Checked = settings["Features"]["MiscBugFixes"].ToBool();
            checkBoxMajorFixes.Checked = settings["Features"]["GameChangingBugFixes"].ToBool();
            checkBoxCancelBird.Checked = settings["Features"]["CancelBirdTravel"].ToBool();
        }

        private void SaveToINI()
        {
            // Build INI data structure from existing zelda3.ini file
            var iniFile = Path.Combine(Program.repoDir, "zelda3.ini");
            var iniText = File.ReadAllText(iniFile);

            var config = new IniParserConfiguration();
            config.CommentString = "#";

            var parser = new IniDataParser(config);

            var settings = parser.Parse(iniText);

            //
            // General Settings
            //

            settings["General"]["Autosave"] = Convert.ToInt32(autosaveCheck.Checked).ToString();
            settings["General"]["DisplayPerfInTitle"] = Convert.ToInt32(performance.Checked).ToString();
            settings["General"]["DisableFrameDelay"] = Convert.ToInt32(disableFrameDelay.Checked).ToString();

            // Reading aspect ratio setting
            var selection = aspectRatio.Controls.OfType<RadioButton>()
                .FirstOrDefault(n => n.Checked).Text;
            switch (selection)
            {
                case "Steam Deck (16:10)":
                    settings["General"]["ExtendedAspectRatio"] = "16:10";
                    break;
                case "Widescreen (16:9)":
                    settings["General"]["ExtendedAspectRatio"] = "16:9";
                    break;
                default:
                    settings["General"]["ExtendedAspectRatio"] = "4:3";
                    break;
            }

            if (unchangedSprites.Checked) settings["General"]["ExtendedAspectRatio"] += ", unchanged_sprites";
            if (noVisualFixes.Checked) settings["General"]["ExtendedAspectRatio"] += ", no_visual_fixes";
            if (checkBoxExtend.Checked) settings["General"]["ExtendedAspectRatio"] += ", extend_y";

            //
            // Graphics Settings
            //

            // Reading custom window size or set to auto
            selection = windowSize.Controls.OfType<RadioButton>()
                .FirstOrDefault(n => n.Checked).Text;
            switch (selection)
            {
                case "Custom":
                    settings["Graphics"]["WindowSize"] = width.Text + "x" + height.Text;
                    break;
                default:
                    settings["Graphics"]["WindowSize"] = "Auto";
                    break;
            }

            // Reading fullscreen settings
            selection = fullscreenMode.Controls.OfType<RadioButton>()
                .FirstOrDefault(n => n.Checked).Text;
            switch (selection)
            {
                case "Borderless Fullscreen":
                    settings["Graphics"]["Fullscreen"] = "1";
                    break;
                case "Fullscreen":
                    settings["Graphics"]["Fullscreen"] = "2";
                    break;
                default:
                    settings["Graphics"]["Fullscreen"] = "0";
                    break;
            }

            settings["Graphics"]["NewRenderer"] = Convert.ToInt32(checkPPU.Checked).ToString();
            settings["Graphics"]["NoSpriteLimits"] = Convert.ToInt32(checkSpriteLimit.Checked).ToString();
            settings["Graphics"]["LinearFiltering"] = Convert.ToInt32(checkLinearFiltering.Checked).ToString();
            settings["Graphics"]["EnhancedMode7"] = Convert.ToInt32(checkMode7.Checked).ToString();
            settings["Graphics"]["IgnoreAspectRatio"] = Convert.ToInt32(checkStretch.Checked).ToString();
            settings["Graphics"]["WindowScale"] = Convert.ToInt32(numericWindowScale.Value).ToString();
            settings["Graphics"]["DimFlashes"] = Convert.ToInt32(checkBoxDimFlashing.Checked).ToString();
            
            switch (comboRenderMethod.SelectedIndex)
            {
                case 0:
                    settings["Graphics"]["OutputMethod"] = "SDL";
                    break;
                case 1:
                    settings["Graphics"]["OutputMethod"] = "SDL-Software";
                    break;
                case 2:
                    settings["Graphics"]["OutputMethod"] = "OpenGL";
                    break;
            }

            if (checkBoxCustomLinkSprites.Checked && File.Exists(textBoxCustomLink.Text))
            {
                if (settings["Graphics"]["LinkGraphics"] == null)
                {
                    settings["Graphics"].AddKey("LinkGraphics", textBoxCustomLink.Text);

                    var comment = new List<string>();
                    comment.Add(@" Change the appearance of Link by loading a ZSPR file");
                    comment.Add(@" See all sprites here: https://snesrev.github.io/sprites-gfx/snes/zelda3/link/");
                    comment.Add(" Download the files with \"git clone https://github.com/snesrev/sprites-gfx.git\"");

                    settings["Graphics"].GetKeyData("LinkGraphics").Comments = comment;
                }
                else settings["Graphics"]["LinkGraphics"] = textBoxCustomLink.Text;
            }
            else
            {
                if (settings["Graphics"]["LinkGraphics"] != null)
                {
                    settings["Graphics"].RemoveKey("LinkGraphics");
                }
            }

            if (checkBoxShader.Checked)
            {
                settings["Graphics"]["Shader"] = textBoxGLSLShader.Text;
            }
            else
            {
                settings["Graphics"]["Shader"] = "";
            }

            //
            // Sound Settings
            //

            // Reading simple settings
            settings["Sound"]["EnableAudio"] = Convert.ToInt32(checkBoxEnableAudio.Checked).ToString();
            settings["Sound"]["AudioFreq"] = comboBoxFrequency.Text;
            settings["Sound"]["ResumeMSU"] = Convert.ToInt32(checkBoxResumeMSU.Checked).ToString();
            settings["Sound"]["MSUVolume"] = numericMSUVolume.Value.ToString();
            if ((Convert.ToInt32(comboBoxSamples.Text) % 2) == 0)
            {
                settings["Sound"]["AudioSamples"] = comboBoxSamples.Text;
            }

            var MSUDir = Path.Combine(Program.repoDir, "msu");
            
            var msu = textBoxMSUDirectory.Text.Split("/");
            if (!msu[0].Equals("msu"))
            {
                var fileCount = Directory.EnumerateFiles(textBoxMSUDirectory.Text, "*.*", SearchOption.AllDirectories).Count();
                progressMSU.Maximum = fileCount;

                progressMSU.Visible = true;
                labelMSUCopy.Visible = true;
                labelMSUCopy.Enabled = true;
                labelMSUCopy.Refresh();

                if (!MSUDir.Equals(textBoxMSUDirectory.Text))
                {
                    if (Directory.Exists(MSUDir)) Directory.Delete(MSUDir, true);
                    try
                    {
                        Directory.CreateSymbolicLink(MSUDir, textBoxMSUDirectory.Text);
                    }
                    catch
                    {
                        var answer = MessageBox.Show("A symlink could not be created.\n\n" +
                            "It could be due to a lack of privileges, so running as administrator could allow for symlink creation. " +
                            "If you are already running the launcher as an administrator, your problem is likely filesystem related and cannot be avoided.\n\n" +
                            "At this point, you can copy the files instead of creating a symlink, but this will take up more space on your drive. " +
                            "Alternatively, you can choose to not copy the files over and the MSU directory setting will not be saved at which point you can restart the launcher as administrator and attempt again.\n\n" +
                            "Would you like to copy the files instead?", "Symlink Creation Failed", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (answer == DialogResult.Yes)
                        {
                            Directory.CreateDirectory(MSUDir);

                            //Now Create all of the directories
                            foreach (string dirPath in Directory.GetDirectories(textBoxMSUDirectory.Text, "*", SearchOption.AllDirectories))
                            {
                                Directory.CreateDirectory(dirPath.Replace(textBoxMSUDirectory.Text, MSUDir));
                            }

                            //Copy all the files & Replaces any files with the same name
                            foreach (string newPath in Directory.GetFiles(textBoxMSUDirectory.Text, "*.*", SearchOption.AllDirectories))
                            {
                                File.Copy(newPath, newPath.Replace(textBoxMSUDirectory.Text, MSUDir), true);
                                progressMSU.Value = Directory.EnumerateFiles(MSUDir, "*.*", SearchOption.AllDirectories).Count();
                            }
                        }
                    }
                }

                if (Directory.Exists(MSUDir))
                {
                    var files = Directory.EnumerateFiles(MSUDir, "*.pcm").Select(Path.GetFileName);
                    if (files.Count<string>() == 0)
                    {
                        files = Directory.EnumerateFiles(MSUDir, "*.opuz").Select(Path.GetFileName);
                    }

                    var prefix = findMSUPrefix(files);

                    settings["Sound"]["MSUPath"] = "msu/" + prefix;
                }

                labelMSUCopy.Visible = false;
                progressMSU.Visible = false;
            }

            // Reading audio channels setting
            selection = groupBoxAudioChannels.Controls.OfType<RadioButton>()
                .FirstOrDefault(n => n.Checked).Text;
            switch (selection)
            {
                case "Mono":
                    settings["Sound"]["AudioChannels"] = "1";
                    break;
                default:
                    settings["Sound"]["AudioChannels"] = "2";
                    break;
            }

            // Reading MSU version setting
            if (checkBoxEnableMSU.Checked)
            {
                switch (comboBoxMSU.SelectedIndex)
                {
                    case 1:
                        settings["Sound"]["EnableMSU"] = "deluxe";
                        settings["Sound"]["AudioFreq"] = "44100";
                        break;
                    case 2:
                        settings["Sound"]["EnableMSU"] = "opuz";
                        settings["Sound"]["AudioFreq"] = "48000";
                        break;
                    case 3:
                        settings["Sound"]["EnableMSU"] = "deluxe-opuz";
                        settings["Sound"]["AudioFreq"] = "48000";
                        break;
                    default:
                        settings["Sound"]["EnableMSU"] = "true";
                        settings["Sound"]["AudioFreq"] = "44100";
                        break;
                }
            }
            else settings["Sound"]["EnableMSU"] = "false";

            //
            // Gameplay Settings
            //

            // Reading simple settings
            settings["Features"]["ItemSwitchLR"] = Convert.ToInt32(checkBoxQuickSwitch.Checked).ToString();
            settings["Features"]["ItemSwitchLRLimit"] = Convert.ToInt32(checkBoxLRLimit.Checked).ToString();
            settings["Features"]["TurnWhileDashing"] = Convert.ToInt32(checkBoxDashTurning.Checked).ToString();
            settings["Features"]["MirrorToDarkworld"] = Convert.ToInt32(checkBoxMirrorDark.Checked).ToString();
            settings["Features"]["CollectItemsWithSword"] = Convert.ToInt32(checkBoxSwordItems.Checked).ToString();
            settings["Features"]["BreakPotsWithSword"] = Convert.ToInt32(checkBoxSwordPots.Checked).ToString();
            settings["Features"]["DisableLowHealthBeep"] = Convert.ToInt32(checkBoxHeartBeep.Checked).ToString();
            settings["Features"]["SkipIntroOnKeypress"] = Convert.ToInt32(checkBoxIntroSkip.Checked).ToString();
            settings["Features"]["ShowMaxItemsInYellow"] = Convert.ToInt32(checkBoxMaxResources.Checked).ToString();
            settings["Features"]["MoreActiveBombs"] = Convert.ToInt32(checkBoxMoreBombs.Checked).ToString();
            settings["Features"]["CarryMoreRupees"] = Convert.ToInt32(checkBoxLargerWallet.Checked).ToString();
            settings["Features"]["MiscBugFixes"] = Convert.ToInt32(checkBoxMiscFixes.Checked).ToString();
            settings["Features"]["GameChangingBugFixes"] = Convert.ToInt32(checkBoxMajorFixes.Checked).ToString();
            settings["Features"]["CancelBirdTravel"] = Convert.ToInt32(checkBoxCancelBird.Checked).ToString();

            // Save settings to zelda3.ini
            var filer = new FileIniDataParser();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            filer.WriteFile(iniFile, settings, Encoding.GetEncoding(1252));
        }

        private string findMSUPrefix(IEnumerable<string> files)
        {
            var fileCount = files.Count<string>();
            var length = files.Min(n => n.Length);

            var reference = files.FirstOrDefault();
            var result = "";

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j <= length; j++)
                {
                    int k;
                    String substring = reference.Substring(i, j - i);

                    for (k = 1; k < fileCount; k++)
                    {
                        if (!files.ElementAt(k).Contains(substring)) break;
                    }

                    if (k == fileCount && result.Length < substring.Length) result = substring;
                }
            }

            return result;
        }

        private void buttonOpenSprites_Click(object sender, EventArgs e)
        {
            var result = new OpenFileDialog();

            result.Filter = "ZSPR sprites (*.zspr)|*.zspr";
            result.ShowDialog();

            if (result.FileName.Equals("")) return;

            if (!result.FileName.EndsWith(".zspr"))
            {
                MessageBox.Show("Selected file must be of the .zspr format.", "Invalid File Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            textBoxCustomLink.Text = result.FileName;
        }

        private void buttonOpenShader_Click(object sender, EventArgs e)
        {
            var result = new OpenFileDialog();

            result.Filter = "Shaders (*.glsl, *glslp)|*.glsl;*.glslp";
            result.ShowDialog();

            if (result.FileName.Equals("")) return;

            if (!result.FileName.EndsWith(".glsl") && !result.FileName.EndsWith(".glslp"))
            {
                MessageBox.Show("Selected file must be of the .glsl or .glslp formats.", "Invalid File Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            textBoxGLSLShader.Text = result.FileName;
        }

        private void buttonMSUDirectory_Click(object sender, EventArgs e)
        {
            var result = new FolderBrowserDialog();

            result.ShowDialog();

            if (!result.SelectedPath.IsNullOrEmpty() && Directory.GetFiles(result.SelectedPath, "*.pcm").Length.Equals(0))
            {
                if (Directory.GetFiles(result.SelectedPath, "*.opuz").Length.Equals(0))
                {
                    MessageBox.Show("No MSU files were found in the selected directory. Please verify the correct folder was selected and that the proper .pcm or .opuz files are available.", "No MSU Files Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (!result.SelectedPath.Equals("")) textBoxMSUDirectory.Text = result.SelectedPath;
        }

        private void SetAspectRatio(string aspectRatio)
        {
            switch (aspectRatio)
            {
                case "4:3":
                    normal.Checked = true;
                    break;
                case "16:9":
                    widescreen.Checked = true;
                    break;
                case "16:10":
                    steamdeck.Checked = true;
                    break;
            }
        }

        private void linkLabelCustomSprites_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabelCustomSprites.LinkVisited = true;

            Process.Start(new ProcessStartInfo("https://snesrev.github.io/sprites-gfx/snes/zelda3/link/") { UseShellExecute = true });
        }

        private void linkLabelGLSLShaders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabelCustomSprites.LinkVisited = true;

            Process.Start(new ProcessStartInfo("https://github.com/snesrev/glsl-shaders") { UseShellExecute = true });
        }

        private void buttonKeymapping_Click(object sender, EventArgs e)
        {
            using (keymapper keymapper = new keymapper())
            {
                if (!keymapper.IsDisposed && keymapper.ShowDialog() == DialogResult.OK)
                {
                    keymapper.Dispose();
                }
            }
        }

        private void linkLabelMinorFixes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabelMinorFixes.LinkVisited = true;

            Process.Start(new ProcessStartInfo("https://github.com/snesrev/zelda3/wiki/Bug-Fixes-:-Misc.") { UseShellExecute = true });
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabelMajorFixes.LinkVisited = true;

            Process.Start(new ProcessStartInfo("https://github.com/snesrev/zelda3/wiki/Bug-Fixes-:-Game-Changing") { UseShellExecute = true });
        }
    }
}
