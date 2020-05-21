using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork19._05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            double A = 0;
        string Calc = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            btn0.Click += AddNumber_Click;
            btn1.Click += AddNumber_Click;
            btn2.Click += AddNumber_Click;
            btn3.Click += AddNumber_Click;
            btn4.Click += AddNumber_Click;
            btn5.Click += AddNumber_Click;
            btn6.Click += AddNumber_Click;
            btn7.Click += AddNumber_Click;
            btn8.Click += AddNumber_Click;
            btn9.Click += AddNumber_Click;
            btnDot.Click += AddNumber_Click;
            btnPlus.Click += Calculate_Click;
            btnMin.Click += Calculate_Click;
            btnDel.Click += Calculate_Click;
            btnUm.Click += Calculate_Click;
            btnProc.Click += Calculate_Click;
            btnC.Click += (s, a) => { txbRes.Text = ""; };
            btnBack.Click += (s, a) =>
            {
                txbRes.Text = (!string.IsNullOrEmpty(txbRes.Text)) ? txbRes.Text.Substring(0, txbRes.Text.Length - 1) : "";

            };
            btnSqt.Click += (s, a) =>
            {
                txbRes.Text = (!string.IsNullOrEmpty(txbRes.Text)) ? Math.Sqrt(double.Parse(txbRes.Text)).ToString() : "";
            };
            btnMS.Click += (s, a) =>
            {
                if (double.TryParse(txbRes.Text, out A))
                    txbMem.Text = txbRes.Text;
            };
            btnMC.Click += (s, a) => {txbMem.Text = ""; };
            btnMR.Click += (s, a) =>
            {
                txbRes.Text = (!string.IsNullOrEmpty(txbMem.Text))?txbMem.Text
                :txbRes.Text;
            };
            btnMPlus.Click += (s, a) =>
            {
                if(!string.IsNullOrEmpty(txbRes.Text))
                txbMem.Text = (!string.IsNullOrEmpty(txbMem.Text))?(double.Parse(txbMem.Text) + double.Parse(txbRes.Text)).ToString()
                    :txbRes.Text;
            };
            btnPlusMinus.Click += AddNumber_Click;
            btnRes.Click += (s, a) =>
            {
                txbRes.Text = (Calc == "+") ? (B + A).ToString() 
                : (Calc == "-")? (B - A).ToString()
                :(Calc == "*")?(B*A).ToString()
                :(Calc == "/")?(A != 0)?(B/A).ToString():"На ноль делить нельзя!"
                :(Calc == "%") ? (A != 0) ? (B % A).ToString() : "На ноль делить нельзя!" 
                : txbRes.Text;
            };
            btnCE.Click += (s, a) =>
            {
                Calc = "";
                txbRes.Text = "";
            };
            txbRes.TextChanged += (s, a) =>
            {
                if(double.TryParse(txbRes.Text,out A))
                A = double.Parse(txbRes.Text);
            };
            btn1DelX.Click += (s, a) =>
            {
                if (txbRes.Text != "0")
                    txbRes.Text = (1 / double.Parse(txbRes.Text)).ToString();
            };
        }
        double B = 0;
        private void Calculate_Click(object sender, EventArgs e)
        {
            B = A;
            txbRes.Text = "";
            Calc = (sender as Button).Text;
        }
        private void AddNumber_Click(object sender, EventArgs e)
        {
            var a = sender as Button;
            char[] numbers = txbRes.Text.ToCharArray();
            if (!(double.TryParse(txbRes.Text, out A)) || (txbRes.Text == "0" && a.Text != ","))
            {
                txbRes.Text = "";
            }
            if (a.Text == ",")
            {
                if (!numbers.Contains(','))
                    txbRes.Text = $"{txbRes.Text},";
            }
            else if (a.Text == "+/-")
            {
                if (!numbers.Contains('-'))
                {
                    txbRes.Text = $"-{txbRes.Text}";
                }
                else
                    txbRes.Text = string.Join("", numbers.Skip(1).Select(x=>x));
            }
            else
            {
                txbRes.Text = txbRes.Text + a.Text;
            }
        }
    }
}
