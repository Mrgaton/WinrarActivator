using System;
using System.IO;
using System.Windows.Forms;

namespace WinrarActivator
{
    internal class Program
    {
        private static string AppName = "WinRaR";
        private static string WinRaRPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\" + AppName;
        private static string RarregPath = Path.Combine(WinRaRPath, "rarreg.key");

        private static void Main()
        {
            if (!File.Exists(Path.Combine(WinRaRPath, "Uninstall.exe")))
            {
                MessageBox.Show("WinRAR not found :C", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!File.Exists(RarregPath))
            {
                if (MessageBox.Show("Are you sure you want to activate " + AppName, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes) return;

                using (StreamWriter sw = File.CreateText(RarregPath))
                {
                    sw.WriteLine("RAR registration data");
                    sw.WriteLine("Federal Agency for Education");
                    sw.WriteLine("1000000 PC usage license");
                    sw.WriteLine("UID=b621cca9a84bc5deffbf");
                    sw.WriteLine("6412612250ffbf533df6db2dfe8ccc3aae5362c06d54762105357d");
                    sw.WriteLine("5e3b1489e751c76bf6e0640001014be50a52303fed29664b074145");
                    sw.WriteLine("7e567d04159ad8defc3fb6edf32831fd1966f72c21c0c53c02fbbb");
                    sw.WriteLine("2f91cfca671d9c482b11b8ac3281cb21378e85606494da349941fa");
                    sw.WriteLine("e9ee328f12dc73e90b6356b921fbfb8522d6562a6a4b97e8ef6c9f");
                    sw.WriteLine("fb866be1e3826b5aa126a4d2bfe9336ad63003fc0e71c307fc2c60");
                    sw.WriteLine("64416495d4c55a0cc82d402110498da970812063934815d81470829275");
                }

                MessageBox.Show(AppName + " activated", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to deactivate " + AppName, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

                File.Delete(RarregPath);

                MessageBox.Show(AppName + " deactivated", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}