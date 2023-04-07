using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calc : Form
    {
        double x, Result;
        int math;
        bool use=false;
        public Calc()
        {
            InitializeComponent();
            btnTheme.Text = "🌙";
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Calc_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void btnNum_Click(object sender, EventArgs e)
        {
            Button Num = sender as Button;
            if (Num != null) txtResult1.Text += Num.Text;
         
        }
        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (txtResult1.Text.Length < 1) txtResult1.Text += "0,";
            if (!txtResult1.Text.Contains(',')) txtResult1.Text += ",";
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtResult1.Text.Length > 0) txtResult1.Text = txtResult1.Text.Substring(0, txtResult1.Text.Length - 1);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult1.Clear();
            txtResult2.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (use == true)
                {
                    txtResult2.Text = txtResult2.Text.Substring(0, txtResult2.Text.Length - 1);
                    x = double.Parse(txtResult2.Text);
                    txtResult2.Text = x.ToString() + "+";
                    math = 1;

                }
                else
                {
                    x = double.Parse(txtResult1.Text);
                    txtResult1.Clear();
                    txtResult2.Text = x.ToString() + "+";
                    math = 1;
                    use = true;
                }
            }
            catch {  }
            
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            try
            {
                if (use == true)
                {
                    txtResult2.Text = txtResult2.Text.Substring(0, txtResult2.Text.Length - 1);
                    x = double.Parse(txtResult2.Text);
                    txtResult2.Text = x.ToString() + "-";
                    math = 2;

                }
                else
                {
                    x = double.Parse(txtResult1.Text);
                    txtResult1.Clear();
                    txtResult2.Text = x.ToString() + "+";
                    math = 2;
                    use = true;
                }
            }
            catch {  }
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            try
            {
                if (use == true)
                {
                    txtResult2.Text = txtResult2.Text.Substring(0, txtResult2.Text.Length - 1);
                    x = double.Parse(txtResult2.Text);
                    txtResult2.Text = x.ToString() + "×";
                    math = 3;

                }
                else
                {
                    x = double.Parse(txtResult1.Text);
                    txtResult1.Clear();
                    txtResult2.Text = x.ToString() + "×";
                    math = 3;
                    use = true;
                }
            }
            catch { }
            
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            try
            {
                if (use == true)
                {
                    txtResult2.Text = txtResult2.Text.Substring(0, txtResult2.Text.Length - 1);
                    x = double.Parse(txtResult2.Text);
                    txtResult2.Text = x.ToString() + "÷";
                    math = 4;

                }
                else
                {
                    x = double.Parse(txtResult1.Text);
                    txtResult1.Clear();
                    txtResult2.Text = x.ToString() + "÷";
                    math = 4;
                    use = true;
                }
            }
            catch {  }
            
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (!txtResult2.Text.Contains('='))
                {
                    switch (math)
                    {
                        case 1: Result = x + double.Parse(txtResult1.Text); break;
                        case 2: Result = x - double.Parse(txtResult1.Text); break;
                        case 3: Result = x * double.Parse(txtResult1.Text); break;
                        case 4: Result = x / double.Parse(txtResult1.Text); break;
                    }
                    txtResult2.Text += txtResult1.Text + "=" + Result;
                }
                else
                {
                    txtResult2.Text = "";
                    if(math==1||math==2 ) x = 0;
                    if(math==3||math==4 ) x = 1;
                }
                txtResult1.Text = Result.ToString();
                use = false;
            }
            catch { txtResult1.Text = "ERROR!"; }
            
        }

        private void Calc_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            if (btnTheme.Text == "💡")
            {
                btnTheme.Text = "🌙";
                btnTheme.ForeColor = Color.Black;
                pnlForm.BackColor = Color.White;
                pnlCalc.BackColor = Color.White;
                txtResult1.BackColor = txtResult2.BackColor = pnlCalc.BackColor;
                pnlCalc.ForeColor = Color.Black;
                txtResult1.ForeColor = txtResult2.ForeColor = pnlCalc.ForeColor;
            }
            else if (btnTheme.Text == "🌙")
            {
                btnTheme.Text = "💡";
                btnTheme.ForeColor = Color.White;
                pnlForm.BackColor = Color.FromArgb(50, 50, 50);
                pnlCalc.BackColor = Color.FromArgb(50, 50, 50);
                txtResult1.BackColor = txtResult2.BackColor = pnlCalc.BackColor;
                pnlCalc.ForeColor = Color.White;
                txtResult1.ForeColor = txtResult2.ForeColor = pnlCalc.ForeColor;
               
            }
        }
    }
}
