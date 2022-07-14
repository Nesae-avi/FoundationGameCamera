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
        private string GithubLink => "https://github.com/";

        private readonly List<string> SupportedGames = new()
        {
            "ROTTR.exe",
            "SOTTR.exe"
        };

        public LauncherWindow()
        {
            InitializeComponent();
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

            // Try to find the game process id.

            int processId = 0;

            foreach (var game in SupportedGames)
            {
                processId = DllInjector.GetProcessId(game);

                if (processId != 0)
                    break;
            }

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
    }
}