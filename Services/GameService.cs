using System.Diagnostics;
using System.IO;

namespace SCAN.Services
{
    public static class GameService
    {
        public static bool LaunchGame(
            string gamePath)
        {
            if (string.IsNullOrWhiteSpace(
                gamePath))
            {
                return false;
            }

            string exePath =
                Path.Combine(
                    gamePath,
                    "Spaceflight Simulator.exe");

            if (!File.Exists(exePath))
            {
                return false;
            }

            Process.Start(
                new ProcessStartInfo
                {
                    FileName = exePath,
                    WorkingDirectory = gamePath,
                    UseShellExecute = true
                });

            return true;
        }
    }
}