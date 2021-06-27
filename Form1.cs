using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Microsoft.Win32;

namespace muteAdio
{
    public partial class Form1 : Form
    {
        public static uint SND_ASYNC = 0x0001;
        public static uint SND_FILENAME = 0x00020000;

        public Form1()
        {
            InitializeComponent();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
            this.Dispose();
            this.Close();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            StartUp("1");
            SoundPlayer sp = new SoundPlayer(Properties.Resources.mute);
            sp.PlayLooping();
        }

        /// <summary>
        /// 修改程序在注册表中的键值
        /// </summary>
        /// <param name="flag">1:开机启动</param>
        private void StartUp(string flag)
        {
            string path = Application.StartupPath;
            string keyName = path.Substring(path.LastIndexOf("\\") + 1);
            Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (flag.Equals("1"))
            {
                if (Rkey == null)
                {
                    Rkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                }
                Rkey.SetValue(keyName, path + @"\EqualizerAPO-driver-fix.exe");
            }
            else
            {
                if (Rkey != null)
                {
                    Rkey.DeleteValue(keyName, false);
                }
            }
        }
    }
}
