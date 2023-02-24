using IniParser;
using IniParser.Model;
using IniParser.Model.Configuration;
using IniParser.Parser;
using Microsoft.VisualBasic.Devices;
using SDL2;
using System.Net.Quic;
using System.Text;
using XAct;

namespace Zelda_3_Launcher
{
    public partial class keymapper : Form
    {
        bool changed = false;
        IniData settings = new IniData();
        string iniFile = Path.Combine(Program.repoDir, "zelda3.ini");
        MyController controller = new MyController();

        public keymapper()
        {
            InitializeComponent();

            ImportINI();

            if (controller.connected)
            {
                radioButtonController.Enabled = true;
                radioButtonController.Checked = true;
            }

            // Controller specific inputs since both keyboard and controller inputs can be set simultaneously
            textBoxDpadLeft.Click += ControllerMappings_Click;
            textBoxDpadUp.Click += ControllerMappings_Click;
            textBoxDpadDown.Click += ControllerMappings_Click;
            textBoxDpadRight.Click += ControllerMappings_Click;
            textBoxSelect.Click += ControllerMappings_Click;
            textBoxStart.Click += ControllerMappings_Click;
            textBoxA.Click += ControllerMappings_Click;
            textBoxB.Click += ControllerMappings_Click;
            textBoxX.Click += ControllerMappings_Click;
            textBoxY.Click += ControllerMappings_Click;
            textBoxL.Click += ControllerMappings_Click;
            textBoxR.Click += ControllerMappings_Click;

            // All other inputs can only be one key/button at a time
            textBoxReset.Click += AssortedMappings_Click;
            textBoxPause.Click += AssortedMappings_Click;
            textBoxIncreaseWindowSize.Click += AssortedMappings_Click;
            textBoxDecreaseWindowSize.Click += AssortedMappings_Click;
            textBoxVolumeDown.Click += AssortedMappings_Click;
            textBoxVolumeUp.Click += AssortedMappings_Click;
            textBoxLife.Click += AssortedMappings_Click;
            textBoxKey.Click += AssortedMappings_Click;
            textBoxNoClip.Click += AssortedMappings_Click;
            textBoxTurbo.Click += AssortedMappings_Click;
            textBoxRenderer.Click += AssortedMappings_Click;
            textBoxFPS.Click += AssortedMappings_Click;
            textBoxToggleReplay.Click += AssortedMappings_Click;
            textBoxStopReplay.Click += AssortedMappings_Click;
        }

        private void AssortedMappings_Click(object? sender, EventArgs e)
        {
            EnableWindow(false);
            AssortedMappings(sender);
            EnableWindow(true);
        }

        private void AssortedMappings(object? sender)
        {
            TextBox textBox = sender as TextBox;
            var original = textBox.Text;
            string result;

            var leftTrigger = false;
            var rightTrigger = false;

            // Clear textbox
            textBox.Text = "";
            this.Refresh();

            SDL.SDL_PumpEvents();
            SDL.SDL_FlushEvents(SDL.SDL_EventType.SDL_FIRSTEVENT, SDL.SDL_EventType.SDL_LASTEVENT);

            var window = SDL.SDL_CreateWindow("Awaiting input...", Form.ActiveForm.Location.X + 292, Form.ActiveForm.Location.Y + 199, 150, 50,
                SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_GRABBED |
                SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS |
                SDL.SDL_WindowFlags.SDL_WINDOW_ALWAYS_ON_TOP);

            SDL.SDL_ShowCursor(SDL.SDL_DISABLE);

            var stop = DateTime.Now.AddSeconds(5);

            while (true)
            {
                SDL.SDL_Event ev;

                // Wait for an event to occur
                SDL.SDL_PollEvent(out ev);

                switch (ev.type)
                {
                    case SDL.SDL_EventType.SDL_KEYDOWN:
                        if (SDL.SDL_GetKeyName(ev.key.keysym.sym) == "Escape")
                        {
                            textBox.Text = original;
                            SDL.SDL_DestroyWindow(window);
                            return;
                        }
                        else
                        {
                            textBox.Text = FormatKeyInput(ev.key.keysym.sym);
                            SDL.SDL_DestroyWindow(window);
                            return;
                        }
                    case SDL.SDL_EventType.SDL_CONTROLLERBUTTONDOWN:
                        textBox.Text = (MyController.ConvertButtonID(ev.cbutton.button));
                        SDL.SDL_DestroyWindow(window);
                        return;
                    case SDL.SDL_EventType.SDL_CONTROLLERAXISMOTION:
                        if (ev.caxis.axis == ((byte)SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERLEFT) && ev.caxis.axisValue == 0 && leftTrigger)
                        {
                            textBox.Text = "L2";
                            SDL.SDL_DestroyWindow(window);
                            return;
                        }
                        else if (ev.caxis.axis == ((byte)SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERRIGHT) && ev.caxis.axisValue == 0 && rightTrigger)
                        {
                            textBox.Text = "R2";
                            SDL.SDL_DestroyWindow(window);
                            return;
                        }
                        else if (ev.caxis.axis == ((byte)SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERLEFT))
                        {
                            leftTrigger = true;
                        }
                        else if (ev.caxis.axis == ((byte)SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERRIGHT))
                        {
                            rightTrigger = true;
                        }
                        break;
                }

                if (DateTime.Now >= stop)
                {
                    textBox.Text = original;
                    SDL.SDL_DestroyWindow(window);
                    return;
                }
            }
        }

        private string? FormatKeyInput(SDL.SDL_Keycode key)
        {
            var result = SDL.SDL_GetKeyName(key);

            if (result.Length.Equals(1))
            {
                result = result.ToLower();
            }

            if (result.Contains("Shift"))
            {
                MessageBox.Show("The Shift keys are not recognized by zelda3.exe and thus cannot be used.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (result.Contains("Ctrl"))
            {
                MessageBox.Show("The Control keys are not recognized by zelda3.exe and thus cannot be used.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (result.Contains("Alt"))
            {
                MessageBox.Show("The Alt keys are not recognized by zelda3.exe and thus cannot be used.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (result.Contains("F") && result.Length == 2 | result.Length == 3)
            {
                MessageBox.Show("The function keys are utilized by zelda3.exe's replay/savestate functionality and thus cannot be used for other inputs.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (result.IsNumeric())
            {
                MessageBox.Show("The number keys are utilized by zelda3.exe's replay/savestate functionality and thus cannot be used for other inputs.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (result.Equals("-") | result.Equals("=") | result.Equals("Backspace"))
            {
                MessageBox.Show("The " + result + " key is utilized by zelda3.exe's replay/savestate functionality and thus cannot be used for other inputs.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return result;
        }

        private void ControllerMappings_Click(object? sender, EventArgs e)
        {
            EnableWindow(false);
            ControllerMappings(sender);
            EnableWindow(true);
        }

        private void ControllerMappings(object? sender)
        {
            TextBox textBox = sender as TextBox;
            var original = textBox.Text;
            string result;

            var selection = groupBoxInput.Controls.OfType<RadioButton>()
                .FirstOrDefault(n => n.Checked).Text;

            // Clear textbox
            textBox.Text = "";
            this.Refresh();

            if (selection == "Controller") result = controller.GetButtonName();
            else result = GetKeyInput();

            if (result is null) textBox.Text = original;
            else
            {
                textBox.Text = result;
                changed = true;
            }
        }

        private string? GetKeyInput()
        {
            SDL.SDL_PumpEvents();
            SDL.SDL_FlushEvent(SDL.SDL_EventType.SDL_CONTROLLERBUTTONDOWN);

            var window = SDL.SDL_CreateWindow("Awaiting input...", Form.ActiveForm.Location.X + 292, Form.ActiveForm.Location.Y + 199, 150, 50,
                SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_GRABBED |
                SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS |
                SDL.SDL_WindowFlags.SDL_WINDOW_ALWAYS_ON_TOP);

            SDL.SDL_ShowCursor(SDL.SDL_DISABLE);

            var stop = DateTime.Now.AddSeconds(5);

            while (true)
            {
                SDL.SDL_Event ek;

                // Wait for an event to occur
                SDL.SDL_PollEvent(out ek);

                // Check if the event was a joystick button press
                if (ek.type == SDL.SDL_EventType.SDL_KEYDOWN)
                {
                    if (SDL.SDL_GetKeyName(ek.key.keysym.sym) == "Escape")
                    {
                        SDL.SDL_DestroyWindow(window);
                        return null;
                    }
                    else
                    {
                        SDL.SDL_DestroyWindow(window);
                        return FormatKeyInput(ek.key.keysym.sym);
                    }
                }

                if (DateTime.Now >= stop)
                {
                    SDL.SDL_DestroyWindow(window);
                    return null;
                }
            }
        }

        private void SaveINI()
        {
            var selection = groupBoxInput.Controls.OfType<RadioButton>()
                .FirstOrDefault(n => n.Checked).Text;

            SaveControllerSettings(selection);

            SaveAdditionalSettings();

            FileINI();
        }

        private void SaveAdditionalSettings()
        {
            settings["KeyMap"]["CheatLife"] = textBoxLife.Text;
            settings["KeyMap"]["CheatKeys"] = textBoxKey.Text;
            settings["KeyMap"]["CheatWalkThroughWalls"] = textBoxNoClip.Text;
            settings["KeyMap"]["StopReplay"] = textBoxStopReplay.Text;
            settings["KeyMap"]["Reset"] = textBoxReset.Text;
            settings["KeyMap"]["Turbo"] = textBoxTurbo.Text;
            settings["KeyMap"]["ReplayTurbo"] = textBoxToggleReplay.Text;
            settings["KeyMap"]["WindowBigger"] = textBoxIncreaseWindowSize.Text;
            settings["KeyMap"]["WindowSmaller"] = textBoxDecreaseWindowSize.Text;
            settings["KeyMap"]["VolumeUp"] = textBoxVolumeUp.Text;
            settings["KeyMap"]["VolumeDown"] = textBoxVolumeDown.Text;
            settings["KeyMap"]["ToggleRenderer"] = textBoxRenderer.Text;
            settings["KeyMap"]["DisplayPerf"] = textBoxFPS.Text;

            if (checkBoxDim.Checked)
            {
                settings["KeyMap"]["Pause"] = "Shift+" + textBoxPause.Text;
                settings["KeyMap"]["PauseDimmed"] = textBoxPause.Text;
            }
            else
            {

                settings["KeyMap"]["PauseDimmed"] = "Shift+" + textBoxPause.Text;
                settings["KeyMap"]["Pause"] = textBoxPause.Text;
            }
        }

        private void ImportINI()
        {
            // Check for INI and if missing restore from initial install backup
            if (!File.Exists(iniFile))
            {
                var iniBackup = Path.Combine(Program.repoDir, "saves", "zelda3.ini");

                if (!File.Exists(iniBackup)) settingsForm.DownloadFreshINI();

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

            settings = parser.Parse(iniText);

            // KeyMap Settings
            DisplayController();

            // Additional Settings
            textBoxLife.Text = settings["KeyMap"]["CheatLife"];
            textBoxKey.Text = settings["KeyMap"]["CheatKeys"];
            textBoxNoClip.Text = settings["KeyMap"]["CheatWalkThroughWalls"];
            textBoxStopReplay.Text = settings["KeyMap"]["StopReplay"];
            textBoxReset.Text = settings["KeyMap"]["Reset"];
            textBoxTurbo.Text = settings["KeyMap"]["Turbo"];
            textBoxToggleReplay.Text = settings["KeyMap"]["ReplayTurbo"];
            textBoxIncreaseWindowSize.Text = settings["KeyMap"]["WindowBigger"];
            textBoxDecreaseWindowSize.Text = settings["KeyMap"]["WindowSmaller"];
            textBoxVolumeUp.Text = settings["KeyMap"]["VolumeUp"];
            textBoxVolumeDown.Text = settings["KeyMap"]["VolumeDown"];

            if (settings["KeyMap"]["ToggleRenderer"] != null)
            {
                textBoxRenderer.Text = settings["KeyMap"]["ToggleRenderer"];
            }
            else
            {
                textBoxRenderer.Text = "r";
            }

            if (settings["KeyMap"]["DisplayPerf"] != null)
            {
                textBoxFPS.Text = settings["KeyMap"]["DisplayPerf"];
            }
            else
            {
                textBoxFPS.Text = "f";
            }

            if (settings["KeyMap"]["Pause"].Contains("Shift"))
            {
                checkBoxDim.Checked = true;
                textBoxPause.Text = settings["KeyMap"]["PauseDimmed"];
            }
            else
            {
                checkBoxDim.Checked = false;
                textBoxPause.Text = settings["KeyMap"]["Pause"];
            }
        }

        private void DisplayController()
        {
            var selection = groupBoxInput.Controls.OfType<RadioButton>()
                .FirstOrDefault(n => n.Checked).Text;

            if (selection == "Controller")
            {
                var controllerControls = settings["GamepadMap"]["Controls"].Replace(" ", "").Split(",");

                textBoxDpadUp.Text = controllerControls[0];
                textBoxDpadDown.Text = controllerControls[1];
                textBoxDpadLeft.Text = controllerControls[2];
                textBoxDpadRight.Text = controllerControls[3];
                textBoxSelect.Text = controllerControls[4];
                textBoxStart.Text = controllerControls[5];
                textBoxA.Text = controllerControls[6];
                textBoxB.Text = controllerControls[7];
                textBoxX.Text = controllerControls[8];
                textBoxY.Text = controllerControls[9];
                textBoxL.Text = controllerControls[10];
                textBoxR.Text = controllerControls[11];
            }
            else
            {
                var keyControls = settings["KeyMap"]["Controls"].Replace(" ", "").Split(",");

                textBoxDpadUp.Text = keyControls[0];
                textBoxDpadDown.Text = keyControls[1];
                textBoxDpadLeft.Text = keyControls[2];
                textBoxDpadRight.Text = keyControls[3];
                textBoxSelect.Text = keyControls[4];
                textBoxStart.Text = keyControls[5];
                textBoxA.Text = keyControls[6];
                textBoxB.Text = keyControls[7];
                textBoxX.Text = keyControls[8];
                textBoxY.Text = keyControls[9];
                textBoxL.Text = keyControls[10];
                textBoxR.Text = keyControls[11];

                if (textBoxSelect.Text.Contains("Shift")) textBoxSelect.Text = @"\";
            }
        }

        private void InputType_CheckedChanged(object sender, EventArgs e)
        {
            var selection = groupBoxInput.Controls.OfType<RadioButton>()
                .FirstOrDefault(n => !n.Checked).Text;

            if (changed)
            {
                var answer = MessageBox.Show("Do you want to save your changes to " + selection + " settings?", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (answer == DialogResult.Yes)
                {
                    SaveControllerSettings(selection);
                    FileINI();
                }
            }

            DisplayController();
        }

        private void FileINI()
        {
            var filer = new FileIniDataParser();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            filer.WriteFile(iniFile, settings, Encoding.GetEncoding(1252));
        }

        private void SaveControllerSettings(string selection)
        {
            if (selection == "Controller")
            {
                settings["GamepadMap"]["Controls"] =
                    textBoxDpadUp.Text + ", " +
                    textBoxDpadDown.Text + ", " +
                    textBoxDpadLeft.Text + ", " +
                    textBoxDpadRight.Text + ", " +
                    textBoxSelect.Text + ", " +
                    textBoxStart.Text + ", " +
                    textBoxA.Text + ", " +
                    textBoxB.Text + ", " +
                    textBoxX.Text + ", " +
                    textBoxY.Text + ", " +
                    textBoxL.Text + ", " +
                    textBoxR.Text;
            }
            else
            {
                settings["KeyMap"]["Controls"] =
                    textBoxDpadUp.Text + ", " +
                    textBoxDpadDown.Text + ", " +
                    textBoxDpadLeft.Text + ", " +
                    textBoxDpadRight.Text + ", " +
                    textBoxSelect.Text + ", " +
                    textBoxStart.Text + ", " +
                    textBoxA.Text + ", " +
                    textBoxB.Text + ", " +
                    textBoxX.Text + ", " +
                    textBoxY.Text + ", " +
                    textBoxL.Text + ", " +
                    textBoxR.Text;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveINI();

            this.Close();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            RestoreFromBackupINI();

            FileINI();

            ImportINI();
        }

        private void RestoreFromBackupINI()
        {
            var iniBackup = Path.Combine(Program.repoDir, "saves", "zelda3.ini");

            if (!File.Exists(iniBackup)) settingsForm.DownloadFreshINI();

            var iniText = File.ReadAllText(iniBackup);

            // INI parsing
            var config = new IniParserConfiguration();
            config.CommentString = "#";

            var parser = new IniDataParser(config);

            var backupSettings = parser.Parse(iniText);

            foreach (var option in backupSettings["KeyMap"])
            {
                settings["KeyMap"][option.KeyName] = option.Value;
            }

            foreach (var option in backupSettings["GamepadMap"])
            {
                settings["GamepadMap"][option.KeyName] = option.Value;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("The changes that you have made will not be saved.\n\nDo you wish to continue?", "Confirmation", MessageBoxButtons.YesNo);

            if (answer == DialogResult.No) return;

            this.Close();
        }

        private void buttonAssignAll_Click(object sender, EventArgs e)
        {
            EnableWindow(false);

            var selection = groupBoxInput.Controls.OfType<RadioButton>()
                .FirstOrDefault(n => n.Checked).Text;

            // Controller assignments
            buttonAssignAll.Text = "Up";
            ControllerMappings(textBoxDpadUp);

            buttonAssignAll.Text = "Down";
            ControllerMappings(textBoxDpadDown);

            buttonAssignAll.Text = "Left";
            ControllerMappings(textBoxDpadLeft);

            buttonAssignAll.Text = "Right";
            ControllerMappings(textBoxDpadRight);

            buttonAssignAll.Text = "Select";
            ControllerMappings(textBoxSelect);

            buttonAssignAll.Text = "Start";
            ControllerMappings(textBoxStart);

            buttonAssignAll.Text = "A";
            ControllerMappings(textBoxA);

            buttonAssignAll.Text = "B";
            ControllerMappings(textBoxB);

            buttonAssignAll.Text = "X";
            ControllerMappings(textBoxX);

            buttonAssignAll.Text = "Y";
            ControllerMappings(textBoxY);

            buttonAssignAll.Text = "L";
            ControllerMappings(textBoxL);

            buttonAssignAll.Text = "R";
            ControllerMappings(textBoxR);

            // Assorted functionality assignments
            buttonAssignAll.Text = "Reset";
            AssortedMappings(textBoxReset);

            buttonAssignAll.Text = "Pause";
            AssortedMappings(textBoxPause);

            buttonAssignAll.Text = "Increase Window Size";
            AssortedMappings(textBoxIncreaseWindowSize);

            buttonAssignAll.Text = "Decrease Window Size";
            AssortedMappings(textBoxDecreaseWindowSize);

            buttonAssignAll.Text = "Volume Up";
            AssortedMappings(textBoxVolumeUp);

            buttonAssignAll.Text = "Volume Down";
            AssortedMappings(textBoxVolumeDown);

            buttonAssignAll.Text = "Restore Health";
            AssortedMappings(textBoxLife);

            buttonAssignAll.Text = "One Key";
            AssortedMappings(textBoxKey);

            buttonAssignAll.Text = "No Clip";
            AssortedMappings(textBoxNoClip);

            buttonAssignAll.Text = "Turbo";
            AssortedMappings(textBoxTurbo);

            buttonAssignAll.Text = "Toggle Replay Speed";
            AssortedMappings(textBoxToggleReplay);

            buttonAssignAll.Text = "Stop Replay";
            AssortedMappings(textBoxStopReplay);

            buttonAssignAll.Text = "Toggle Renderer";
            AssortedMappings(textBoxRenderer);

            buttonAssignAll.Text = "Toggle FPS";
            AssortedMappings(textBoxFPS);

            buttonAssignAll.Text = "Assign All";
            EnableWindow(true);
        }

        private void EnableWindow(bool input)
        {
            groupBoxCheats.Enabled = input;
            groupBoxController.Enabled = input;
            groupBoxGame.Enabled = input;
            groupBoxReplays.Enabled = input;
            groupBoxPerformance.Enabled = input;

            buttonReset.Enabled = input;
            buttonCancel.Enabled = input;
            buttonSave.Enabled = input;
        }
    }
}
