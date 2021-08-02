using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myCalculator
{
    public partial class Form1 : Form
    {
        float result = 0;
        float _operand1 = 0;
        char _operator = ' ';
        public Form1()
        {
            InitializeComponent();
        }
        #region click btn number code


        private void btn1_Click(object sender, EventArgs e)
        {
            textBox2.Text += btn1.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            textBox2.Text += btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            textBox2.Text += btn3.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            textBox2.Text += btn6.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            textBox2.Text += btn5.Text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            textBox2.Text += btn4.Text;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            textBox2.Text += btn7.Text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            textBox2.Text += btn8.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            textBox2.Text += btn9.Text;

        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            textBox2.Text += btnZero.Text;

        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            string txt = textBox2.Text;
            bool allow = true;
            foreach (char t in txt)
            {
                if (t == '.')
                {
                    allow = false;
                }

            }
            if (allow)
            {
                if (txt != "")
                {
                    textBox2.Text += btnDat.Text;
                }
                else
                {
                    textBox2.Text += ("0" + btnDat.Text);
                }

            }


        }
        #endregion

        #region click btn cleans
        private void btnClean_Click(object sender, EventArgs e)
        {
            string txt = textBox2.Text;
            if (txt != "")
            {
                txt = txt.Remove(txt.Length - 1, 1);
                textBox2.Text = txt;
            }


        }
        private void btnCleanAll_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        #endregion



        #region click btn Operators
        private void btnSum_Click(object sender, EventArgs e)
        {
            _operand1 = float.Parse(textBox2.Text);
            textBox2.Text = "";
            _operator = '+';
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            _operand1 = float.Parse(textBox2.Text);
            textBox2.Text = "";
            _operator = '-';
        }

        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            _operand1 = float.Parse(textBox2.Text);
            textBox2.Text = "";
            _operator = '*';
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            _operand1 = float.Parse(textBox2.Text);
            textBox2.Text = "";
            _operator = '/';
        }
        #endregion

        private void btnEqual_Click(object sender, EventArgs e)
        {   
            float _operand2 = 0;
            if (textBox2.Text== "")
            {
                _operand2 = 0;
               
            }
            else
            {
                _operand2 = float.Parse(textBox2.Text);
            }
           

            switch (_operator)
            {
                case '+':
                    result = _operand1 + _operand2;
                    break;
                case '-':
                    result = _operand1 - _operand2;
                    break;
                case '*':
                    result = _operand1 * _operand2;
                    break;
                case '/':
                    {
                        if(_operand2!= 0)
                        {
                            result = _operand1 / _operand2;
                        }
                        else
                        {
                            MessageBox.Show("", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                        break;

                    }
              
               }

            if(_operator!=' ')
            {
                textBox2.Text = result.ToString();
            }
           
           
            result = 0;
            _operator = ' ';
        }
    }
}
