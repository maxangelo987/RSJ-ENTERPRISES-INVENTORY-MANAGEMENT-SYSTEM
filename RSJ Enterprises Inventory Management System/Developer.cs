using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management_System
{
    public partial class Developer : Form
    {
        public Developer()
        {
            InitializeComponent();
            //string WebPage = textBox1.Text.Trim();
            webBrowser1.Navigate("http://maxangelo987.github.io");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPanel wc = new LoginPanel();
            this.Hide();
            wc.Show();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
