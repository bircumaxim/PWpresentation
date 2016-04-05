using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applications
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser.ProgressChanged += delegate (object o, WebBrowserProgressChangedEventArgs args)
            {
                if (args.MaximumProgress > 0)
                {
                    int current = (int)(args.CurrentProgress * progressBar1.Maximum / args.MaximumProgress);
                    if (current <= 100 && current >= 0)
                    {
                        progressBar1.Value = current;
                    }
                }
            };
            webBrowser.Navigating += new WebBrowserNavigatingEventHandler(navigating);
        }

        private void navigating(object sender,WebBrowserNavigatingEventArgs e)
        {
            url.Text = e.Url.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser.Url = new Uri(url.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser.Url = new Uri("https://msdn.microsoft.com");
        }
    }
}
