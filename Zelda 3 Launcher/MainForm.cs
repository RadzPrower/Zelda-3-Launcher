using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using LibGit2Sharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using XAct.Resources;

namespace Zelda_3_Launcher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            if (Directory.Exists(Program.repoDir))
            {
                Repository repo = new Repository(Program.repoDir);

                var status = repo.RetrieveStatus();

                if (repo.Head.TrackingDetails.BehindBy > 0) this.build.Text = "Update";
                else if (status.IsDirty) this.build.Text = "Restore";
                else this.build.Text = "Re-build";

                if (File.Exists(Path.Combine(Program.repoDir, "zelda3.exe")))
                {
                    this.launch.Enabled = true;
                }
                /*
                if (File.Exists(Path.Combine(Program.repoDir, "zelda3.ini")))
                {
                    this.settings.Enabled = true;
                }*/
            }
        }

        private void launch_click(object sender, EventArgs e)
        {
            this.launch.Text = "Launching...";
            this.Enabled = false;

            this.build.Enabled= false;
            this.settings.Enabled = false;

            this.launch.Text = "Running...";
            if (runProcess(@".\zelda3\zelda3.exe", ""))
            {
                MessageBox.Show("Error occurred while launching Zelda 3.\n\nPlease refer to " + Path.Combine(Program.currentDirectory, "log.txt") + " for further details.");
                return;
            }

            this.launch.Text = "Launch Zelda 3";
            this.Enabled = true;

            this.build.Enabled = true;
            //this.settings.Enabled = true;
        }

        private void build_Click(object sender, EventArgs e)
        {
            this.build.Text = "Downloading...";
            this.build.Enabled = false;

            this.launch.Enabled = false;

            using (progressForm cloneRepo = new progressForm("Repository Download", "Downloading a fresh copy of the zelda3 repository..."))
            {
                if (cloneRepo.ShowDialog() == DialogResult.OK)
                {
                    cloneRepo.Dispose();
                }
            }

            using (progressForm copyROM = new progressForm("Copying ROM File", "Copying ROM file to proper directory..."))
            {
                if (copyROM.ShowDialog() == DialogResult.OK)
                {
                    copyROM.Dispose();
                }
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

            var pythonEXE = @".\tables\python.exe";
            var python310 = @".\zelda3\tables\python310._pth";
            var python310Old = @".\zelda3\tables\python310._pth.old";

            File.AppendAllText(Program.currentDirectory + "\\log.txt", "Starting commandline processess...");

            // Modify python310._pth to allow for pip installation
            File.Move(python310, python310Old);
            using (var pythonFile = File.AppendText(python310))
            {
                foreach (var line in File.ReadLines(python310Old))
                {
                    if (line == "#import site") pythonFile.WriteLine("import site");
                    else pythonFile.WriteLine(line);
                }
            }
            File.Delete(python310Old);

            // Download pip
            if (runProcess("cmd.exe", "/C " + pythonEXE + @" .\tables\get-pip.py"))
            {
                MessageBox.Show("Error occurred while downloding pip.\n\nPlease refer to " + Path.Combine(Program.currentDirectory, "log.txt") + " for further details.");
                return;
            }

            if (runProcess("cmd.exe", @"/C " + pythonEXE + " -m pip install --upgrade pip pillow pyyaml"))
            {
                MessageBox.Show("Error occurred while installing/updating dependencies.\n\nPlease refer to " + Path.Combine(Program.currentDirectory, "log.txt") + " for further details.");
                return;
            }

            if (runProcess("cmd.exe", @"/C cd .\tables && python extract_resources.py"))
            {
                MessageBox.Show("Error occurred while extracting resources.\n\nPlease refer to " + Path.Combine(Program.currentDirectory, "log.txt") + " for further details.");
                return;
            }

            if (runProcess("cmd.exe", @"/C cd .\tables && python compile_resources.py"))
            {
                MessageBox.Show("Error occurred while compiling resources.\n\nPlease refer to " + Path.Combine(Program.currentDirectory, "log.txt") + " for further details.");
                return;
            }

            // Need to make some small modifications to bat before exectuting
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

            if (runProcess("cmd.exe", @"/C radzprower.bat"))
            {
                MessageBox.Show("Error occurred while building executable.\n\nPlease refer to " + Path.Combine(Program.currentDirectory, "log.txt") + " for further details.");
                return;
            }

            File.AppendAllText(Program.currentDirectory + "\\log.txt", "\n\n\n\n");

            Repository repo = new Repository(Program.repoDir);

            var status = repo.RetrieveStatus();

            if (repo.Head.TrackingDetails.BehindBy > 0) this.build.Text = "Update";
            else if (status.IsDirty) this.build.Text = "Restore";
            else this.build.Text = "Re-build";
            this.build.Enabled = true;

            if (File.Exists(Path.Combine(Program.repoDir, "zelda3.exe")))
            {
                this.launch.Enabled = true;
            }
            /*
            if (File.Exists(Path.Combine(Program.repoDir, "zelda3.ini")))
            {
                this.settings.Enabled = true;
            }*/
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.build = new System.Windows.Forms.Button();
            this.launch = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // build
            // 
            this.build.AutoSize = true;
            this.build.Location = new System.Drawing.Point(8, 8);
            this.build.Name = "build";
            this.build.Size = new System.Drawing.Size(175, 50);
            this.build.TabIndex = 0;
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
            this.settings.TabIndex = 0;
            this.settings.Text = "Settings";
            this.settings.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.launch);
            this.Controls.Add(this.build);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public Boolean runProcess(string filename, string arguments)
        {
            File.AppendAllText(Program.currentDirectory + "\\log.txt", "\n" + DateTime.Now.ToString() + "\n----------------------------\n");

            File.AppendAllText(Program.currentDirectory + "\\log.txt", "Executing via " + filename + ":\n " + arguments + "\n");

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

            process.OutputDataReceived += new DataReceivedEventHandler((s, e) =>
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    File.AppendAllText(Program.currentDirectory + "\\log.txt", e.Data + "\n");
                }));
            });

            process.ErrorDataReceived += new DataReceivedEventHandler((s, e) =>
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    File.AppendAllText(Program.currentDirectory + "\\log.txt", e.Data + "\n");
                }));
            });

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            while (!process.HasExited)
            {
                Application.DoEvents();
            }

            processes.Remove(process);

            if (process.ExitCode > 0)
            {
                return true;
            }

            process.Close();

            File.AppendAllText(Program.currentDirectory + "\\log.txt", "\n");

            return false;
        }

        List<Process> processes = new List<Process>();
    }
}