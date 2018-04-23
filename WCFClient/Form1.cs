using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using WCFClient.ServiceReference1;

namespace WCFClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out var i))
            {
                //调用WCF服务
                var svc = new ServiceReference1.Service1Client();
                var output = svc.GetData(i);
                txOutp.Text += output+ "\r\n"; 
                //复合数据调用
                var output2 = svc.GetDataUsingDataContract(new CompositeType
                {
                    BoolValue = true,
                    StringValue = $"Current Time Is {DateTime.Now:hh:mm:ss}"
                });
                txOutp.Text += JsonConvert.SerializeObject(output2) + "\r\n";
            }

            
           
        }
    }
}
