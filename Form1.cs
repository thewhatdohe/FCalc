using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Microsoft.Win32;

namespace calc_gui
{
    public partial class Form1 : Form
    {
        private double _firstOperand = 0;
        private string _operator = "";
        private bool _newInput = true;
        // -----------INITIALIZATION--------------------
        public Form1()
        {
            InitializeComponent(); // init
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                    ApplyRoundedCorners(btn, 10);
            }

            bool isFirstRun = false;

            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\FCalc");
            if (key == null)
            {
                isFirstRun = true;
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\FCalc");
                MessageBox.Show("Thanks for downloading FCalc, new features will be coming soon", "Hello!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ApplyRoundedCorners(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int r = radius;
            path.AddArc(0, 0, r, r, 180, 90);
            path.AddArc(btn.Width - r, 0, r, r, 270, 90);
            path.AddArc(btn.Width - r, btn.Height - r, r, r, 0, 90);
            path.AddArc(0, btn.Height - r, r, r, 90, 90);
            path.CloseFigure();
            btn.Region = new Region(path);
        }
        // -------------FUNCTIONALITY-------------------
        private void equal(object sender, EventArgs e)
        {
            double num1 = Convert.ToDouble(_firstOperand);
            double num2 = Convert.ToDouble(label2.Text);

            if (_operator == "+")
            {
                label2.Text = (num1 + num2).ToString(); // combine two lines to create more efficient approach
            }
            else if (_operator == "-")
            {
                label2.Text = (num1 - num2).ToString();
            }
            else if (_operator == "*")
            {
                label2.Text = (num1 * num2).ToString();
            }
            else if (_operator == "/" && num2 != 0)
            {
                label2.Text = (num1 / num2).ToString();
            }
            else if (_operator == "/" && num2 == 0)
            {
                MessageBox.Show("Cannot divide by zero.", "Math Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                label2.Text = "0";
            }
        }

        private void plus(object sender, EventArgs e)
        {
            _operator = "+";
            _newInput = true;
            _firstOperand = double.Parse(label2.Text);
        }

        private void minus(object sender, EventArgs e)
        {
            _operator = "-";
            _newInput = true;
            _firstOperand = double.Parse(label2.Text);
        }

        private void multiplication(object sender, EventArgs e)
        {
            _operator = "*";
            _newInput = true;
            _firstOperand = double.Parse(label2.Text);
        }

        private void division(object sender, EventArgs e)
        {
            _operator = "/";
            _newInput = true;
            _firstOperand = double.Parse(label2.Text);
        }

        private void delete(object sender, EventArgs e)
        {
            string s = label2.Text;

            if (s.Length > 1)
            {
                s = s.Substring(0, s.Length - 1); //decrease length by one char
            }
            else
            {
                // same logic as clear when character count reaches 0
                s = "0";
                _newInput = true;
                _operator = "";
                _firstOperand = 0;
            }
            label2.Text = s;
        }

        private void clear(object sender, EventArgs e)
        {
            label2.Text = "0";
            _newInput = true;
            _operator = "";
            _firstOperand = 0;
        }

        private void dec(object sender, EventArgs e)
        {
            if (!label2.Text.Contains("."))
            {
                label2.Text = label2.Text + ".";    // only add if no decimal already
            }
        }

        private void negate(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(label2.Text);
            x = -x;
            label2.Text = x.ToString();
        }

        private void zero(object sender, EventArgs e)
        {
            if (_newInput == true && label2.Text != "0")
            {
                label2.Text = "0";
                _newInput = false;
            }
            else if (_newInput == false && label2.Text != "0")
            {
                label2.Text = label2.Text + "0";
            }
        }

        private void one(object sender, EventArgs e)
        {
            if (_newInput == true)
            {
                label2.Text = "1";
                _newInput = false;
            }
            else
            {
                label2.Text = label2.Text + "1";
            }
        }

        private void two(object sender, EventArgs e)
        {
            if (_newInput == true)
            {
                label2.Text = "2";
                _newInput = false;
            }
            else
            {
                label2.Text = label2.Text + "2";
            }
        }

        private void three(object sender, EventArgs e)
        {
            if (_newInput == true)
            {
                label2.Text = "3";
                _newInput = false;
            }
            else
            {
                label2.Text = label2.Text + "3";
            }
        }

        private void four(object sender, EventArgs e)
        {
            if (_newInput == true)
            {
                label2.Text = "4";
                _newInput = false;
            }
            else
            {
                label2.Text = label2.Text + "4";
            }
        }

        private void five(object sender, EventArgs e)
        {
            if (_newInput == true)
            {
                label2.Text = "5";
                _newInput = false;
            }
            else
            {
                label2.Text = label2.Text + "5";
            }
        }

        private void six(object sender, EventArgs e)
        {
            if (_newInput == true)
            {
                label2.Text = "6";
                _newInput = false;
            }
            else
            {
                label2.Text = label2.Text + "6";
            }
        }

        private void seven(object sender, EventArgs e)
        {
            if (_newInput == true)
            {
                label2.Text = "7";
                _newInput = false;
            }
            else
            {
                label2.Text = label2.Text + "7";
            }
        }

        private void eight(object sender, EventArgs e)
        {
            if (_newInput == true)
            {
                label2.Text = "8";
                _newInput = false;
            }
            else
            {
                label2.Text = label2.Text + "8";
            }
        }

        private void nine(object sender, EventArgs e)
        {
            if (_newInput == true)
            {
                label2.Text = "9";
                _newInput = false;
            }
            else
            {
                label2.Text = label2.Text + "9";
            }
        }

        private void sqrt(object sender, EventArgs e)
        {
            double result = Math.Sqrt(double.Parse(label2.Text));
            label2.Text = result.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}