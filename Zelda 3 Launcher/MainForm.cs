using System.Diagnostics;
using System.Text;
using LibGit2Sharp;

namespace Zelda_3_Launcher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            if (Directory.Exists(Program.repoDir))
            {
                UpdateMainForm();
            }
        }

        private void launch_click(object sender, EventArgs e)
        {
            this.launch.Text = "Launching...";
            this.Enabled = false;

            this.build.Enabled= false;
            this.settings.Enabled = false;

            this.launch.Text = "Running...";
            this.WindowState = FormWindowState.Minimized;
            if (runProcess("cmd.exe", "/C zelda3.exe"))
            {
                MessageBox.Show("Error occurred while launching Zelda 3.\n\nPlease refer to " + Path.Combine(Program.currentDirectory, "zelda3.log") + " for further details.");
            }

            this.launch.Text = "Launch Zelda 3";
            this.Enabled = true;

            this.build.Enabled = true;
            this.settings.Enabled = true;

            this.WindowState = FormWindowState.Normal;
        }

        private void build_Click(object sender, EventArgs e)
        {
            this.build.Text = "Downloading...";
            this.build.Enabled = false;

            this.launch.Enabled = false;
            this.settings.Enabled = false;

            using (progressForm cloneRepo = new progressForm("Repository Download", "Downloading a fresh copy of the zelda3 repository..."))
            {
                if (cloneRepo.ShowDialog() == DialogResult.OK)
                {
                    cloneRepo.Dispose();
                }
            }

            if (!Directory.Exists(Program.repoDir))
            {
                ExitBuild();
                return;
            }

            using (progressForm copyROM = new progressForm("Copying ROM File", "Copying ROM file to proper directory..."))
            {
                if (copyROM.ShowDialog() == DialogResult.OK)
                {
                    copyROM.Dispose();
                }
            }

            if (!File.Exists(Path.Combine(Program.repoDir, "tables", "zelda3.sfc")))
            {
                MessageBox.Show("No ROM provided. Process cancelled.", "No ROM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateMainForm();
                return;
            }

            using (progressForm downloadTCC = new progressForm("Downloading TCC", "Downloading TCC build tools..."))
            {
                if (downloadTCC.ShowDialog() == DialogResult.OK)
                {
                    downloadTCC.Dispose();
                }
            }

            using (progressForm downloadSDL2 = new progressForm("Downloading SDL2", "Downloading SDL2..."))
            {
                if (downloadSDL2.ShowDialog() == DialogResult.OK)
                {
                    downloadSDL2.Dispose();
                }
            }

            using (progressForm downloadPython = new progressForm("Downloading Python", "Downloading Python..."))
            {
                if (downloadPython.ShowDialog() == DialogResult.OK)
                {
                    downloadPython.Dispose();
                }
            }
            using (progressForm downloadPip = new progressForm("Downloading pip", "Downloading pip..."))
            {
                if (downloadPip.ShowDialog() == DialogResult.OK)
                {
                    downloadPip.Dispose();
                }
            }

            this.build.Text = "Building...";

            progressCompile.Visible = true;
            labelCompileStatus.Visible = true;

            var pythonEXE = @".\tables\python.exe";
            var python311 = @".\zelda3\tables\python311._pth";
            var python311Old = @".\zelda3\tables\python311._pth.old";

            File.AppendAllText(Program.currentDirectory + "\\zelda3.log", "Starting commandline processess...");

            labelCompileStatus.Text = "Modifying python311._pth...";
            // Modify python311._pth to allow for pip installation
            File.Move(python311, python311Old);
            using (var pythonFile = File.AppendText(python311))
            {
                foreach (var line in File.ReadLines(python311Old))
                {
                    if (line == "#import site") pythonFile.WriteLine("import site");
                    else pythonFile.WriteLine(line);
                }
            }
            File.Delete(python311Old);

            // Download pip
            labelCompileStatus.Text = "Downloading pip...";
            if (runProcess("cmd.exe", "/C " + pythonEXE + @" .\tables\get-pip.py"))
            {
                MessageBox.Show("Error occurred while downloding pip.\n\nPlease refer to " + Path.Combine(Program.currentDirectory, "zelda3.log") + " for further details.");
                return;
            }

            // Install dependencies
            labelCompileStatus.Text = "Installing dependencies...";
            if (runProcess("cmd.exe", @"/C " + pythonEXE + " -m pip install --upgrade pip pillow pyyaml"))
            {
                MessageBox.Show("Error occurred while installing/updating dependencies.\n\nPlease refer to " + Path.Combine(Program.currentDirectory, "zelda3.log") + " for further details.");
                return;
            }

            labelCompileStatus.Text = "Extracting assets...";
            if (runProcess("cmd.exe", @"/C cd .\tables && python restool.py --extract-from-rom"))
            {
                MessageBox.Show("Error occurred while extracting resources.\n\nPlease refer to " + Path.Combine(Program.currentDirectory, "zelda3.log") + " for further details.");
                return;
            }

            // Need to make some small modifications to bat before exectuting
            labelCompileStatus.Text = "Modifying installation bat...";
            var batOld = Path.Combine(Program.repoDir, "run_with_tcc.bat");
            var batNew = Path.Combine(Program.repoDir, "radzprower.bat");
            using (var pythonFile = File.AppendText(batNew))
            {
                foreach (var line in File.ReadLines(batOld))
                {
                    if (line == "pause") ;
                    else if (line == "echo Running...") ;
                    else if (line == "zelda3.exe") ;
                    else pythonFile.WriteLine(line);
                }
            }

            // build zelda3.exe
            labelCompileStatus.Text = "Building zelda3.exe...";
            if (runProcess("cmd.exe", @"/C radzprower.bat"))
            {
                MessageBox.Show("Error occurred while building executable.\n\nPlease refer to " + Path.Combine(Program.currentDirectory, "zelda3.log") + " for further details.");
                return;
            }

            labelCompileStatus.Text = "Backing up zelda3.ini...";
            var iniFile = Path.Combine(Program.repoDir, "zelda3.ini");
            var iniCopy = Path.Combine(Program.repoDir, "saves", "zelda3.ini");

            if (File.Exists(iniCopy)) File.Delete(iniCopy);
            File.Move(iniFile, iniCopy);

            labelCompileStatus.Text = "Modifying zelda3.ini...";
            using (var modifiedFile = File.AppendText(iniFile))
            {
                foreach (var line in File.ReadLines(iniCopy))
                {
                    if (!line.Equals("# Change the appearance of Link by loading a ZSPR file") &&
                        !line.Equals("# See all sprites here: https://snesrev.github.io/sprites-gfx/snes/zelda3/link/") &&
                        !line.Equals("# Download the files with \"git clone https://github.com/snesrev/sprites-gfx.git\"") &&
                        !line.Equals("# LinkGraphics = sprites-gfx/snes/zelda3/link/sheets/megaman-x.2.zspr") &&
                        !line.Equals("# This default is suitable for QWERTZ keyboards.") &&
                        !line.Equals("#Controls = Up, Down, Left, Right, Right Shift, Return, x, y, s, a, c, v") &&
                        !line.Equals("# This one is suitable for AZERTY keyboards.") &&
                        !line.Equals("#Controls = Up, Down, Left, Right, Right Shift, Return, x, w, s, q, c, v") &&
                        !line.Equals("# Language = de"))
                    {
                        modifiedFile.WriteLine(line);
                    }
                    else if (line.Equals("# Language = de"))
                    {
                        modifiedFile.WriteLine("Language = us");
                    }
                }
            }

            ExitBuild();
        }

        private void ExitBuild()
        {
            progressCompile.Text = "Done";
            progressCompile.Visible = false;
            labelCompileStatus.Visible = false;

            File.AppendAllText(Program.currentDirectory + "\\zelda3.log", "\n\n\n\n");
            UpdateMainForm();
        }

        private void UpdateMainForm()
        {
            this.build.Text = "Download";
            if (Directory.Exists(Program.repoDir))
            {
                Repository repo = new Repository(Program.repoDir);

                var status = repo.RetrieveStatus();

                if (repo.Head.TrackingDetails.BehindBy > 0) this.build.Text = "Update";
                else if (status.IsDirty) this.build.Text = "Restore";
                else this.build.Text = "Re-build";
            }
            this.build.Enabled = true;

            if (File.Exists(Path.Combine(Program.repoDir, "zelda3.exe")))
            {
                this.launch.Enabled = true;
                this.settings.Enabled = true;

                if (File.Exists(Path.Combine(Program.repoDir, "zelda3.ini")))
                {
                    this.settings.Text = "Settings";
                }
                else
                {
                    this.settings.Text = "Restore INI";
                }
            }
        }

        private void settings_click(object sender, EventArgs e)
        {
            using (settingsForm settings = new settingsForm())
            {
                if (!settings.IsDisposed && settings.ShowDialog() == DialogResult.OK)
                {
                    settings.Dispose();
                }
            }

            UpdateMainForm();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.build = new System.Windows.Forms.Button();
            this.launch = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.labelCompileStatus = new System.Windows.Forms.Label();
            this.progressCompile = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // build
            // 
            this.build.AutoSize = true;
            this.build.Location = new System.Drawing.Point(8, 8);
            this.build.Name = "build";
            this.build.Size = new System.Drawing.Size(175, 50);
            this.build.TabIndex = 1;
            this.build.Text = "Download";
            this.build.UseVisualStyleBackColor = true;
            this.build.Click += new System.EventHandler(this.build_Click);
            // 
            // launch
            // 
            this.launch.AutoSize = true;
            this.launch.Enabled = false;
            this.launch.Location = new System.Drawing.Point(8, 64);
            this.launch.Name = "launch";
            this.launch.Size = new System.Drawing.Size(175, 50);
            this.launch.TabIndex = 0;
            this.launch.Text = "Launch Zelda 3";
            this.launch.UseVisualStyleBackColor = true;
            this.launch.Click += new System.EventHandler(this.launch_click);
            // 
            // settings
            // 
            this.settings.AutoSize = true;
            this.settings.Enabled = false;
            this.settings.Location = new System.Drawing.Point(8, 120);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(175, 50);
            this.settings.TabIndex = 2;
            this.settings.Text = "Settings";
            this.settings.UseVisualStyleBackColor = true;
            this.settings.Click += new System.EventHandler(this.settings_click);
            // 
            // labelCompileStatus
            // 
            this.labelCompileStatus.Location = new System.Drawing.Point(8, 173);
            this.labelCompileStatus.Name = "labelCompileStatus";
            this.labelCompileStatus.Size = new System.Drawing.Size(175, 23);
            this.labelCompileStatus.TabIndex = 1;
            this.labelCompileStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelCompileStatus.Visible = false;
            // 
            // progressCompile
            // 
            this.progressCompile.Location = new System.Drawing.Point(8, 199);
            this.progressCompile.Maximum = 3000;
            this.progressCompile.Minimum = 543;
            this.progressCompile.Name = "progressCompile";
            this.progressCompile.Size = new System.Drawing.Size(175, 23);
            this.progressCompile.TabIndex = 2;
            this.progressCompile.Value = 543;
            this.progressCompile.Visible = false;
            // 
            // MainForm
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.progressCompile);
            this.Controls.Add(this.labelCompileStatus);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.launch);
            this.Controls.Add(this.build);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public Boolean runProcess(string filename, string arguments)
        {
            var logFile = Program.currentDirectory + "\\zelda3.log";

            File.AppendAllText(logFile, "\n" + DateTime.Now.ToString() + "\n----------------------------\n");

            File.AppendAllText(logFile, "Executing via " + filename + ":\n " + arguments + "\n");

            ProcessStartInfo sInfo = new ProcessStartInfo();
            sInfo.FileName = filename;
            sInfo.Arguments = arguments;
            sInfo.WorkingDirectory = Program.repoDir;
            sInfo.RedirectStandardOutput = true;
            sInfo.RedirectStandardError = true;
            sInfo.UseShellExecute = false;
            sInfo.CreateNoWindow = true;

            Process process = new Process();
            process.StartInfo = sInfo;
            processes.Add(process);

            while (!IsHandleCreated)
            {
                this.CreateHandle();
            }

            process.OutputDataReceived += new DataReceivedEventHandler((s, e) =>
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    File.AppendAllText(logFile, e.Data + "\n");
                }));
            });

            process.ErrorDataReceived += new DataReceivedEventHandler((s, e) =>
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    File.AppendAllText(logFile, e.Data + "\n");
                }));
            });

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            while (!process.HasExited)
            {
                if (!filename.Equals(".\\zelda3\\zelda3.exe"))
                {
                    var fileCount = Directory.GetFiles(Program.repoDir, "*", SearchOption.AllDirectories).Count();
                    if (fileCount > 2900) progressCompile.Value = fileCount - 1000;
                    else progressCompile.Value = fileCount;
                }
                Application.DoEvents();
            }

            processes.Remove(process);

            if (process.ExitCode > 0)
            {
                return true;
            }

            process.Close();

            File.AppendAllText(logFile, "\n");

            if (File.Exists(logFile))
            {
                var fileInfo = new FileInfo(logFile);

                while (fileInfo.Length > (51200))
                {
                    var lines = File.ReadLines(logFile).ToArray();

                    File.WriteAllLines(logFile, lines.Skip(1).ToArray());

                    fileInfo = new FileInfo(logFile);
                }
            }

            return false;
        }

        List<Process> processes = new List<Process>();
    }
}