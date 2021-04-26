using System;
using System.Data;
using System.Windows.Forms;
using Analizer;

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


        public static double Evaluate(string expression)
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }

        public double LastAns { get; private set; }
        string GetRandomNums(double Ans)
        {
            string tmp = "";
            Random ran = new Random();
            for (int i = 0; i < Ans.ToString().Length; i++)
            {
                tmp += ran.Next(0,10);
            }
            return tmp;
        }

        string Expretion;
        private void CancelButton_Click(object sender, EventArgs e)
        {
            lblExpression.Text = Expretion = "";
            lblAnswer.Text = "0";
        }

        int i = 0;
        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            if (i<10)
            {
                lblAnswer.Text = GetRandomNums(this.LastAns.ToString().Length);
                i++;
            }
            else
            {
                i = 0;
                lblAnswer.Text = LastAns.ToString();
                timerAnimation.Stop();
            }
        }

        private void btNum_Click(object sender, EventArgs e)
        {
            lblAnswer.Text = 0.ToString();
            lblExpression.Text = (Expretion+=((Control)sender).Tag.ToString());
        }

        private void bunifuImageButton20_Click(object sender, EventArgs e)
        {
            try
            {
                lblExpression.Text = Expretion = Expretion.Substring(0, Expretion.Length - 1);
            }
            catch (Exception)
            {
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                Analizer.AnalizerEx ex = new AnalizerEx(Expretion);
                LastAns = ex.Evaluate;
                timerAnimation.Start();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }

    }
}
