using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssRlink
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            string str = rtb.Text;
            if (str.IndexOf("MAX") < 5 && str.IndexOf("MAX") != -1)
                rtb.Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
            else
            {
                rtb.Text = Encoding.UTF8.GetString(Convert.FromBase64String(str));
            }
        }
    }
}
