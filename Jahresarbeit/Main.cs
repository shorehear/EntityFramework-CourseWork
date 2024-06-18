using System;
using System.Net;
using System.Windows;

namespace kaidy
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Authorization authorizationWindow = new Authorization();
            authorizationWindow.Show();

            Application app = new Application();
            app.Run();
        }
    }
}
