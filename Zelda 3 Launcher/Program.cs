namespace Zelda_3_Launcher
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        public static string currentDirectory = Directory.GetCurrentDirectory();
        public static string repoDir = Path.Combine(currentDirectory, "zelda3");
        public static string third_partyDir = Path.Combine(repoDir, "third_party");
        public static Boolean messageMSU = false;
    }
}