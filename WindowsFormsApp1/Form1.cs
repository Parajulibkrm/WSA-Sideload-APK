using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox3.Text = Settings1.Default.Path_to_adb;
            textBox2.Text = Settings1.Default.ip_port;
        }
        OpenFileDialog odf = new OpenFileDialog();
        FolderBrowserDialog odf2 = new FolderBrowserDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            odf.Filter = "APK|*.apk";
            if(odf.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = odf.FileName;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
       
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/c cd " + textBox3.Text + "& adb connect" + textBox2.Text + "& adb -s \"" + textBox2.Text +"\" install " + textBox1.Text;
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            richTextBox1.Text = output;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (odf2.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = odf2.SelectedPath;
                Settings1.Default.Path_to_adb = odf2.SelectedPath;
                Settings1.Default.Save();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Settings1.Default.ip_port = textBox2.Text;
            Settings1.Default.Save();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.github.com/parajulibkrm");
        }
    }

}
