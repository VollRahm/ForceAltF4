using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using MouseKeyboardLibrary;

namespace ForceAltF4
{
    
    public partial class mainFrm : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        KeyboardHook keyboard = new KeyboardHook();

        bool autostart;

        public mainFrm()
        {
            InitializeComponent();
            keyboard.KeyDown += new KeyEventHandler(kbPress);
            keyboard.Start();
            notifyIcon.Icon = this.Icon;
            this.Hide();
            if (File.Exists("config.altf4"))
            {
                StreamReader reader = new StreamReader("config.altf4");
                if (reader.ReadLine() == "1")
                {
                    autostart = true;
                    autostartItem.Checked = true;
                    autostartItem.CheckState = CheckState.Checked;
                }
                else if (reader.ReadLine() == "0")
                {
                    autostart = false;
                    autostartItem.Checked = false;
                    autostartItem.CheckState = CheckState.Unchecked;
                }
                
                reader.Close();
                
            }
            else
            {
                
                StreamWriter writer = new StreamWriter("config.altf4");
                writer.WriteLine("1");
                writer.Close();
                autostart = true;
                RegistryKey rk = Registry.CurrentUser.OpenSubKey
           ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                rk.SetValue("ForceAltF4", Application.ExecutablePath);
                autostartItem.Checked = true;
                autostartItem.CheckState = CheckState.Checked;

                notifyIcon.ShowBalloonTip(1000, "ForceAltF4", "App running in Background. Autostart set. Click on the Icon to disable it.", ToolTipIcon.Info);
                notifyIcon.ShowBalloonTip(2000, "ForceAltF4", "Press Ctrl + Alt + F4 to kill the current process.", ToolTipIcon.Info);
            }
        }

        private void kbPress(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F4 && (ModifierKeys & Keys.Control) == Keys.Control && (ModifierKeys & Keys.Alt) == Keys.Alt) && activeStripItem.Checked)
            {
                IntPtr hwnd = GetForegroundWindow();
                uint pid;
                GetWindowThreadProcessId(hwnd, out pid);
                Process p = Process.GetProcessById((int)pid);
                p.Kill();
                notifyIcon.ShowBalloonTip(500, "ForceAltF4", "Process Killed", ToolTipIcon.Info);



            }
        }
        Process GetActiveProcessFileName()
        {
            IntPtr hwnd = GetForegroundWindow();
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            Process p = Process.GetProcessById((int)pid);
            return p;
            
        }

        private void exitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.
            Opacity = 0;

            base.OnLoad(e);
        }

        private void autostartItem_Click(object sender, EventArgs e)
        {
            if (autostartItem.Checked && !autostart)
            {
                autostart = true;
                RegistryKey rk = Registry.CurrentUser.OpenSubKey
           ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                rk.SetValue("ForceAltF4", Application.ExecutablePath);
                File.Delete("config.altf4");
                StreamWriter writer = new StreamWriter("config.altf4");
                writer.WriteLine("1");
                writer.Close();
            }
            else if(!autostartItem.Checked)
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey
           ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                rk.DeleteValue("ForceAltF4", false);
                autostart = false;
                File.Delete("config.altf4");
                StreamWriter writer = new StreamWriter("config.altf4");
                writer.WriteLine("0");
                writer.Close();
            }
        }
    }
}
