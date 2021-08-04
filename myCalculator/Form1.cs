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
        #region variable
        float result = 0;
        float _operand1 = 0;
        char _operator = ' ';
        int _intForTextbox1 = 0;
        bool chengeTheme = true;
        #endregion

        public Form1()
        {
            
            InitializeComponent();
            //toolStrip1.Renderer = new MySR();

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
            _intForTextbox1 = 0;
            textBox1.Text = "";
            _operand1 = 0;
            _operator = ' ';


        }

        #endregion



        #region click btn Operators
        private void btnSum_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (_operator != ' ')
                {
                    ifclickEnotherbtnEual();
                }
                else if (textBox2.Text != "+" & textBox2.Text != "-")
                {

                    _operand1 = float.Parse(textBox2.Text);
                    _operator = '+';
                    textBox2.Text = "";


                }


            }
            else
            {
                textBox2.Text = "+";
            }

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (_operator != ' ')
                {
                    ifclickEnotherbtnEual();
                }
                else if (textBox2.Text != "-" && textBox2.Text != "+")
                {


                    _operand1 = float.Parse(textBox2.Text);


                    _operator = '-';

                    textBox2.Text = "";
                }


            }
            else
            {
                textBox2.Text = "-";
            }


        }

        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            if (_operator != ' ')
            {
                ifclickEnotherbtnEual();
            }
            else
            {
                if (textBox2.Text != "")
                    _operand1 = float.Parse(textBox2.Text);


            }
            _operator = '*';
            textBox2.Text = "";
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            if (_operator != ' ')
            {
                ifclickEnotherbtnEual();
            }
            else
            {
                if (textBox2.Text != "")
                {
                    _operand1 = float.Parse(textBox2.Text);
                }



            }
            _operator = '/';
            textBox2.Text = "";
        }
        #endregion


        #region click btn equal
        private void btnEqual_Click(object sender, EventArgs e)
        {

            float _operand2 = 0;
            if (textBox2.Text == "" || textBox2.Text == "-" || textBox2.Text == "+")
            {
                textBox2.Text = "0";
                _operand2 = 0;

            }
            else
            {

                _operand2 = float.Parse(textBox2.Text);
            }


            switch (_operator)
            {
                case '+':
                    {
                        txtTextbox1();
                        result = _operand1 + _operand2;
                        break;
                    }

                case '-':
                    {
                        txtTextbox1();
                        result = _operand1 - _operand2;
                        break;
                    }
                case '*':
                    {
                        txtTextbox1();
                        result = _operand1 * _operand2;
                        break;
                    }
                case '/':
                    {
                        if (_operand2 != 0)
                        {
                            result = _operand1 / _operand2;
                            txtTextbox1();
                            textBox2.Text = result.ToString();
                            _operator = ' ';
                        }
                        else if (_operand2 == 0)
                        {
                            float x = _operand1;
                            MessageBox.Show("can not be divided by Zero", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox2.Text = "";
                            _operand1 = x;
                            _operator = '/';

                        }

                        break;

                    }

            }

            if (_operator != ' ' && _operator != '/')
            {
                textBox2.Text = result.ToString();
                _operator = ' ';
            }


            result = 0;

        }
        #endregion




        #region unable press somekeys
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) & !char.IsControl(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        #endregion



        #region help metods
        private void ifclickEnotherbtnEual()
        {
            if (textBox2.Text != "" && textBox2.Text != "+" && textBox2.Text != "-")
            {
                switch (_operator)
                {
                    case '+':
                        {
                            txtTextbox1();
                            _operand1 += float.Parse(textBox2.Text);
                            textBox2.Text = "";
                            //_operator = ' ';
                            break;
                        }
                    case '-':
                        {
                            txtTextbox1();
                            _operand1 -= float.Parse(textBox2.Text);
                            textBox2.Text = "";
                            //_operator = ' ';
                            break;
                        }
                    case '*':
                        {
                            txtTextbox1();
                            _operand1 *= float.Parse(textBox2.Text);
                            textBox2.Text = "";
                            //_operator = ' ';
                            break;
                        }
                    case '/':
                        {


                            if (float.Parse(textBox2.Text) != 0)
                            {
                                txtTextbox1();
                                _operand1 /= float.Parse(textBox2.Text);
                                textBox2.Text = "";
                                //_operator = ' ';
                            }



                            break;
                        }

                }
            }

        }

        private void txtTextbox1()
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = $"({textBox1.Text} {_operator} {textBox2.Text})";
            }
            else if (_intForTextbox1 == 0)
            {
                textBox1.Text = $"({_operand1} {_operator} {textBox2.Text})";
                _intForTextbox1 = 1;
            }
            else
            {
                textBox1.Text = $"({textBox1.Text} {_operator} {textBox2.Text})";
            }
        }

        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (chengeTheme == false)
            {

                this.BackColor = Color.FromName("Control");
                toolStrip1.BackColor = Color.FromName("Control");
                chengeTheme = true;
            }
            else if (chengeTheme == true)
            {
                
                this.BackColor = Color.FromName("WindowFrame");
                toolStrip1.BackColor = Color.FromName("WindowFrame");
                
                chengeTheme = false;
            }



        }
    }

    public class MySR : ToolStripSystemRenderer
    {
        public MySR() { }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBorder(e);
        }
    }
}
