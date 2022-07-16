using System.Reflection;

namespace LaunchFoundationGameCamera
{
    internal static class AppInformation
    {
        public static string? Version => Assembly.GetExecutingAssembly().GetName().Version?.ToString(3);
    }
}
