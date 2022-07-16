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
    }
}