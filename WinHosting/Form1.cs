using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfServiceLib;

namespace WinHosting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Windows 窗体应用宿主";
        }

        private ServiceHost host = null;
        
        private void button1_Click(object sender, EventArgs e)
        {
             host = new ServiceHost(typeof(Service1));
            host.Opened+= delegate { label1.Text = "Service1已启动宿主"; };
            host.Open();
            button1.Enabled = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            host.Close();
            label1.Text = "已停止";
            
        }
    }
}
