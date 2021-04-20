using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        string Expretion = "";
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Expretion = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
