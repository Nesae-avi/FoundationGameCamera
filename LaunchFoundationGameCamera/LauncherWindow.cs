using System.Diagnostics;

namespace LaunchFoundationGameCamera
{
    enum Sites
    {
        Github,
        Discord
    }

    public partial class LauncherWindow : Form
    {
        private readonly string DiscordInvite = "discord.gg/rdS8rtEGYG";
        private string DiscordInviteLink => DiscordInvite.Insert(0, "https://");
        private string GithubLink => "https://github.com/Nesae-avi/FoundationGameCamera";

        private readonly List<string> SupportedGames = new()
        {
            "ROTTR.exe",
            "SOTTR.exe"
        };

        public LauncherWindow()
        {
            InitializeComponent();
        }

        private void UpdateApplication()
        {
            try
            {
                var latestReleaseLink = $"{GithubLink}/releases/latest";

                using var client = new HttpClient();
                var result = client.GetAsync(latestReleaseLink).Result;

                if (result.RequestMessage != null && result.RequestMessage.RequestUri != null)
                {
                    // Get version from release title.

                    var Doc = new HtmlAgilityPack.HtmlDocument();
                    Doc.LoadHtml(result.Content.ReadAsStringAsync().Result);

                    var newVersion = Doc.DocumentNode.SelectSingleNode("//*[@id=\"repo-content-pjax-container\"]/div/div/div/div[1]/div[2]/div[1]/h1").InnerText;

                    // Check with current version and download new if available.

                    if (newVersion != AppInformation.Version)
                    {
                        if (MessageBox.Show("An update is available. Click OK to download and restart the application.",
                                            "Update",
                                            MessageBoxButtons.OKCancel,
                                            MessageBoxIcon.Asterisk) == DialogResult.OK)
                        {
                            var downloadLink = result.RequestMessage.RequestUri.ToString().Replace("tag", "download");
                            var launcherFileLink = $"{downloadLink}/LaunchFoundationGameCamera.exe";
                            var destinationFileName = $"LaunchFoundationGameCamera_{newVersion}.exe";

                            using var stream = client.GetStreamAsync(launcherFileLink).Result;
                            using var fileStream = new FileStream(destinationFileName, FileMode.Create);

                            stream.CopyTo(fileStream);
                            fileStream.Close();

                            // Start the new version and schedule closing the current instance.

                            Process.Start(destinationFileName);

                            Process.Start(new ProcessStartInfo()
                            {
                                Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
                                WindowStyle = ProcessWindowStyle.Hidden,
                                CreateNoWindow = true,
                                FileName = "cmd.exe"
                            });
                        }

                        Application.Exit();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Update check failed!",
                                "Update",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                Logger.LogLine(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Game process id</returns>
        private int FindGameProcess()
        {
            // Try to find the game process id.

            foreach (var game in SupportedGames)
            {
                var processId = DllInjector.GetProcessId(game);

                if (processId != 0)
                    return processId;
            }

            return 0;
        }

        private void OpenWebsite(Sites site)
        {
            string link = GithubLink;

            switch (site)
            {
                case Sites.Github: link = GithubLink; break;
                case Sites.Discord: link = DiscordInviteLink; break;
                default: break;
            }

            ProcessStartInfo psi = new(link)
            {
                UseShellExecute = true
            };

            Process.Start(psi);
        }

        private void StartFGC()
        {
            Logger.LogLine("Starting FGC");

            int processId = FindGameProcess();

            if (processId != 0)
            {
                var dllPath = Path.Combine(Path.GetTempPath(), "FoundationGameCamera.dll");

                if (!ResourceUnpacker.Unpack("LaunchFoundationGameCamera.FoundationGameCamera.dll", dllPath))
                {
                    Logger.LogLine("Cannot unpack the resource");
                    return;
                }

                if (DllInjector.Inject(processId, dllPath))
                {
                    Logger.LogLine("Finished successfully");
                }
            }
            else
            {
                Logger.LogLine("No supported game is running");
                return;
            }
        }

        private void StartFovFix()
        {
            Logger.LogLine("Starting fov fix");

            // Try to find the game process id.

            int processId = FindGameProcess();

            if (processId != 0)
            {
                var dllPath = Path.Combine(Path.GetTempPath(), "FoundationFovFix.dll");

                if (!ResourceUnpacker.Unpack("LaunchFoundationGameCamera.FoundationFovFix.dll", dllPath))
                {
                    Logger.LogLine("Cannot unpack the resource");
                    return;
                }

                if (DllInjector.Inject(processId, dllPath))
                {
                    Logger.LogLine("Finished successfully");
                }
            }
            else
            {
                Logger.LogLine("No supported game is running");
                return;
            }
        }

        private void LauncherWindow_Load(object sender, EventArgs e)
        {
            Text = $"Foundation Game Camera Launcher v{AppInformation.Version}";
            label_Supportinfo.Text = $"For support, troubleshooting and sharing screen captures join the discord: {DiscordInvite}";
        }

        private void PictureBox_Discord_Click(object sender, EventArgs e)
        {
            OpenWebsite(Sites.Discord);
        }

        private void PictureBox_Github_Click(object sender, EventArgs e)
        {
            OpenWebsite(Sites.Github);
        }

        private void Label_Supportinfo_Click(object sender, EventArgs e)
        {
            OpenWebsite(Sites.Discord);
        }

        private void Button_Start_Click(object sender, EventArgs e)
        {
            StartFGC();
        }

        private void Button_LoadFovFix_Click(object sender, EventArgs e)
        {
            StartFovFix();
        }

        private void LauncherWindow_Shown(object sender, EventArgs e)
        {
            UpdateApplication();
        }
    }
}