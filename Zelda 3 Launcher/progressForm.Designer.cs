using System.Net;
using System.Text;

using LibGit2Sharp;
using System.Net.NetworkInformation;
using XSystem.Security.Cryptography;
using System.IO.Compression;

namespace Zelda_3_Launcher
{
    partial class ProgressForm : Form
    {
        private volatile int progress = 0;
        private volatile int max = 999999;

        public ProgressForm(string title, string message)
        {
            InitializeComponent();

            this.Text = title;
            this.updateLabel.Text = message;

            switch (title)
            {
                case "Repository Download":
                    this.Shown += new System.EventHandler(this.cloneRepo);
                    break;
                case "Copying ROM File":
                    this.Shown += new System.EventHandler(this.copyROM);
                    break;
                case "Downloading TCC":
                    this.Shown += new System.EventHandler(this.downloadTCC);
                    break;
                case "Downloading SDL2":
                    this.Shown += new System.EventHandler(this.downloadSDL2);
                    break;
                case "Downloading Python":
                    this.Shown += new System.EventHandler(this.downloadPython);
                    break;
                case "Downloading pip":
                    this.Shown += new System.EventHandler(this.downloadPip);
                    break;
            }
        }

        private void copyROM(object sender, EventArgs e)
        {
            this.Refresh();

            if (File.Exists(Path.Combine(Program.repoDir, "zelda3.sfc")))
            {
                this.Close();
                return;
            }

            if (File.Exists(Path.Combine(Program.currentDirectory, "zelda3.sfc")))
            {
                File.Move(Path.Combine(Program.currentDirectory, "zelda3.sfc"), Path.Combine(Program.repoDir, "zelda3.sfc"));
                this.Close();
                return;
            }

            Boolean exit = false;
            var result = new OpenFileDialog();
            result.Filter = "Zelda 3 ROM (*.sfc)|*.sfc";
            while (!exit)
            {
                if (result.ShowDialog() == DialogResult.OK)
                {
                    var hashCheck = checkHash(result.FileName);
                    if (hashCheck.success)
                    {
                        File.Copy(result.FileName, Path.Combine(Program.repoDir, "zelda3.sfc"));
                        exit = true;
                    }
                    else
                    {
                        var answer = MessageBox.Show("ROM hash is not valid for the English (US) version.\n\n" +
                            "The hash of the file selected is " + hashCheck.yourHash + ".\n\n" + 
                            "The correct hash is " + hashCheck.hash + ".\n\n" +
                            "Would you like to select another?", "Invalid ROM Hash", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (answer == DialogResult.No) exit = true;
                    }
                }
                else exit = true;
            }

            this.Close();
        }

        private void cloneRepo(object sender, EventArgs e)
        {
            this.Refresh();

            if (!IsConnectedToInternet())
            {
                MessageBox.Show("Unable to connect to the internet.\n\nPlease ensure you have a stable internet connection before updating your repository.", "No Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
                return;
            }

            var repoDir = Path.Combine(Program.currentDirectory, "zelda3");

            try
            {
                using (var repo = new Repository(repoDir))
                {
                    var iniFile = Path.Combine(repoDir, "zelda3.ini");
                    var iniBackup = Path.Combine(repoDir, "saves", "zelda3.ini");
                    if (File.Exists(iniFile)) File.Copy(iniFile, iniBackup, true);

                    var trackedBranch = repo.Head.TrackedBranch;

                    Commit originHeadCommit = repo.ObjectDatabase.FindMergeBase(repo.Branches[trackedBranch.FriendlyName].Tip, repo.Head.Tip);
                    repo.Reset(ResetMode.Hard, originHeadCommit,
                        new CheckoutOptions
                        {
                            OnCheckoutProgress = (clonePath, completed, total) => CheckoutProgress(clonePath, completed, total)
                        });

                    File.Copy(iniBackup, iniFile, true);
                }
            }
            catch
            {
                Task.Run(() =>
                {
                    Repository.Clone("https://github.com/snesrev/zelda3.git", repoDir,
                        new CloneOptions
                        {
                            OnCheckoutProgress = (clonePath, completed, total) => CheckoutProgress(clonePath, completed, total)
                        });
                });
            }

            while (!Directory.Exists(repoDir))
            {
                Application.DoEvents();
            }

            do
            {
                progBar.Value = progress;
                progBar.Maximum = max;
            } while (progress < max);

            this.Close();
        }

        public void CheckoutProgress(string path, int completed, int total)
        {
            max = total;
            progress = completed;
        }

        private async void downloadTCC(object sender, EventArgs e)
        {
            this.Refresh();

            IProgress<int> progressReporter = new Progress<int>(percentage =>
            {
                progBar.Value = Math.Clamp(percentage, 0, 100);
            });

            var directory = Path.Combine(
                Program.third_partyDir,
                "tcc");

            var filePath = Path.Combine(
                directory,
                "TCC.zip");

            try
            {
                await DownloadFileAsync(
                    new Uri("https://github.com/FitzRoyX/tinycc/releases/download/tcc_20221020/tcc_20221020.zip"),
                    filePath,
                    progressReporter
                );

                updateLabel.Text = $"Unzipping...";

                try
                {
                    await Task.Run(() =>
                    {
                        Directory.CreateDirectory(directory);

                        ZipFile.ExtractToDirectory(
                            filePath,
                            Program.third_partyDir,
                            overwriteFiles: true);
                    });
                }
                finally
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"The download failed:\n\n{ex.Message}",
                    "Download Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }
        }

        private async void downloadSDL2(object sender, EventArgs e)
        {
            this.Refresh();

            IProgress<int> progressReporter = new Progress<int>(percentage =>
            {
                progBar.Value = Math.Clamp(percentage, 0, 100);
            });

            var directory = Path.Combine(
                Program.third_partyDir,
                "SDL2-2.28.2");

            var filePath = Path.Combine(
                directory,
                "SDL2.zip");

            try
            {
                await DownloadFileAsync(
                    new Uri("https://github.com/libsdl-org/SDL/releases/download/release-2.28.2/SDL2-devel-2.28.2-VC.zip"),
                    filePath,
                    progressReporter
                );

                updateLabel.Text = $"Unzipping...";

                try
                {
                    await Task.Run(() =>
                    {
                        Directory.CreateDirectory(directory);

                        ZipFile.ExtractToDirectory(
                            filePath,
                            Program.third_partyDir,
                            overwriteFiles: true);
                    });
                }
                finally
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"The download failed:\n\n{ex.Message}",
                    "Download Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }
        }

        private async void downloadPython(object sender, EventArgs e)
        {
            this.Refresh();

            IProgress<int> progressReporter = new Progress<int>(percentage =>
            {
                progBar.Value = Math.Clamp(percentage, 0, 100);
            });

            var directory = Path.Combine(
                Program.repoDir,
                "assets");

            var filePath = Path.Combine(
                directory,
                "Python.zip");

            try
            {
                await DownloadFileAsync(
                    new Uri("https://www.python.org/ftp/python/3.11.1/python-3.11.1-embed-amd64.zip"),
                    filePath,
                    progressReporter
                );

                updateLabel.Text = $"Unzipping...";

                try
                {
                    await Task.Run(() =>
                    {
                        Directory.CreateDirectory(directory);

                        ZipFile.ExtractToDirectory(
                            filePath,
                            directory,
                            overwriteFiles: true);
                    });
                }
                finally
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"The download failed:\n\n{ex.Message}",
                    "Download Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }
        }

        private static readonly HttpClient httpClient = new()
        {
            Timeout = TimeSpan.FromMinutes(10)
        }; 

        private async Task DownloadFileAsync(
            Uri uri,
            string destination,
            IProgress<int> progressReporter = null)
        {
            var directory = Path.GetDirectoryName(destination);

            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var temporaryDestination = destination + ".download";

            try
            {
                using HttpResponseMessage response = await httpClient.GetAsync(
                    uri,
                    HttpCompletionOption.ResponseHeadersRead);

                response.EnsureSuccessStatusCode();

                var contentLength = response.Content.Headers.ContentLength;

                await using Stream source = await response.Content.ReadAsStreamAsync();

                await using FileStream target = new(
                    temporaryDestination,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None,
                    bufferSize: 81920,
                    useAsync: true);

                var buffer = new byte[81920];
                long totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = await source.ReadAsync(buffer)) > 0)
                {
                    await target.WriteAsync(buffer.AsMemory(0, bytesRead));

                    totalBytesRead += bytesRead;

                    if (contentLength is > 0)
                    {
                        int percentage = (int)(totalBytesRead * 100 / contentLength.Value);
                        progressReporter?.Report(percentage);
                    }
                }

                progressReporter?.Report(100);
            }
            catch
            {
                if (File.Exists(temporaryDestination))
                {
                    File.Delete(temporaryDestination);
                }

                throw;
            }

            if (File.Exists(destination))
            {
                File.Delete(destination);
            }

            File.Move(temporaryDestination, destination);
        }

        private async void downloadPip(object sender, EventArgs e)
        {
            this.Refresh();

            var filename = "get-pip.py";
            Uri uri = new Uri("https://bootstrap.pypa.io/get-pip.py");

            var directory = Path.Combine(Program.repoDir, "assets");
            var destination = Path.Combine(Program.repoDir, "assets", filename);

            if (File.Exists(destination)) File.Delete(destination);

            progBar.Minimum = 0;
            progBar.Maximum = 100;
            progBar.Value = 0;

            IProgress<int> progressReporter = new Progress<int>(percentage =>
            {
                progBar.Value = Math.Clamp(percentage, 0, 100);
            });

            try
            {
                await DownloadFileAsync(uri, destination, progressReporter);
                this.Close();
            }
            catch (HttpRequestException)
            {
                MessageBox.Show(
                    "Unable to download the file. Please ensure you have a stable internet connection.",
                    "Download Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"The download failed:\n\n{ex.Message}",
                    "Download Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }
        }

        public static bool IsConnectedToInternet()
        {
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send("github.com", 10000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch { }
            try
            {
                PingReply reply = p.Send("python.org", 10000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch { }
            try
            {
                PingReply reply = p.Send("google.com", 10000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch { }

            return false;
        }

        public (Boolean success, string hash, string yourHash) checkHash(string file, string version="us")
        {
            using (System.Security.Cryptography.SHA1 sha1Hasher = System.Security.Cryptography.SHA1.Create())
            using (FileStream stream = new FileStream(file, FileMode.Open))
            using (BufferedStream buffer = new BufferedStream(stream))
            {
                byte[] hash = sha1Hasher.ComputeHash(buffer);
                StringBuilder hashString = new StringBuilder(2 * hash.Length);
                foreach (byte b in hash)
                {
                    hashString.AppendFormat("{0:x2}", b);
                }

                string versionHash;
                var yourHash = hashString.ToString().ToUpper();

                switch (version)
                {
                    case "us":
                        versionHash = "6D4F10A8B10E10DBE624CB23CF03B88BB8252973";
                        if (yourHash == versionHash) return (true, versionHash, yourHash);
                        return (false, versionHash, yourHash);
                    case "de":
                        versionHash = "2E62494967FB0AFDF5DA1635607F9641DF7C6559";
                        if (yourHash == versionHash) return (true, versionHash, yourHash);
                        return (false, versionHash, yourHash);
                    case "fr":
                        versionHash = "229364A1B92A05167CD38609B1AA98F7041987CC";
                        if (yourHash == versionHash) return (true, versionHash, yourHash);
                        return (false, versionHash, yourHash);
                    case "fr-c":
                        versionHash = "C1C6C7F76FFF936C534FF11F87A54162FC0AA100";
                        if (yourHash == versionHash) return (true, versionHash, yourHash);
                        return (false, versionHash, yourHash);
                    case "en":
                        versionHash = "7C073A222569B9B8E8CA5FCB5DFEC3B5E31DA895";
                        if (yourHash == versionHash) return (true, versionHash, yourHash);
                        return (false, versionHash, yourHash);
                    case "es":
                        versionHash = "461FCBD700D1332009C0E85A7A136E2A8E4B111E";
                        if (yourHash == versionHash) return (true, versionHash, yourHash);
                        return (false, versionHash, yourHash);
                    case "pl":
                        versionHash = "3C4D605EEFDA1D76F101965138F238476655B11D";
                        if (yourHash == versionHash) return (true, versionHash, yourHash);
                        return (false, versionHash, yourHash);
                    case "pt":
                        versionHash = "D0D09ED41F9C373FE6AFDCCAFBF0DA8C88D3D90D";
                        if (yourHash == versionHash) return (true, versionHash, yourHash);
                        return (false, versionHash, yourHash);
                    case "redux":
                        versionHash = "B2A07A59E64C498BC1B2F28728F9BF4014C8D582";
                        if (yourHash == versionHash) return (true, versionHash, yourHash);
                        versionHash = "9325C22EB0A2A1F0017157C8B620BC3A605CEDE1";
                        if (yourHash == versionHash) return (true, versionHash, yourHash);
                        return (false, versionHash, yourHash);
                    case "nl":
                        versionHash = "FA8ADFDBA2697C9A54D583A1284A22AC764C7637";
                        if (yourHash == versionHash) return (true, versionHash, yourHash);
                        return (false, versionHash, yourHash);
                    case "sv":
                        versionHash = "43CD3438469B2C3FE879EA2F410B3EF3CB3F1CA4";
                        if (yourHash == versionHash) return (true, versionHash, yourHash);
                        return (false, versionHash, yourHash);
                }
            }
            return (false, "NULL", "NULL");
        }

        private ProgressBar progBar;
        private Label updateLabel;
    }
}