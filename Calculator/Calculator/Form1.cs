using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class CalculatorForm : Form
    {
        private double _firstNumber = 0;
        private double _secondNumber = 0;
        private double _originalFirstNumber = 0; // ����������ԭʼ�ĵ�һ����
        private string _operation = "";
        private bool _isNewNumber = true;
        private bool _operationPerformed = false;

        public CalculatorForm()
        {
            InitializeComponent();
            this.Text = "������";
            this.ClientSize = new Size(300, 400);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (_isNewNumber || txtDisplay.Text == "0")
            {
                txtDisplay.Text = button.Text;
                _isNewNumber = false;
            }
            else
            {
                txtDisplay.Text += button.Text;
            }

            _operationPerformed = false;
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!_isNewNumber && !_operationPerformed)
            {
                if (_operation != "")
                {
                    CalculateResult(showFullEquation: false);
                }

                _firstNumber = double.Parse(txtDisplay.Text);
                _originalFirstNumber = _firstNumber; // ����ԭʼ�ĵ�һ����
                _operation = button.Text;
                _isNewNumber = true;
                _operationPerformed = true;
                lblHistory.Text = $"{_firstNumber} {_operation}";
            }
            else if (_operationPerformed)
            {
                _operation = button.Text;
                lblHistory.Text = $"{_originalFirstNumber} {_operation}";
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (!_isNewNumber && _operation != "")
            {
                CalculateResult(showFullEquation: true);
                _operation = "";
            }
        }

        private void CalculateResult(bool showFullEquation)
        {
            _secondNumber = double.Parse(txtDisplay.Text);

            try
            {
                decimal result = 0;
                decimal first = Convert.ToDecimal(_firstNumber);
                decimal second = Convert.ToDecimal(_secondNumber);

                switch (_operation)
                {
                    case "+":
                        result = first + second;
                        break;
                    case "-":
                        result = first - second;
                        break;
                    case "��":
                        result = first * second;
                        break;
                    case "��":
                        if (second != 0)
                            result = first / second;
                        else
                        {
                            txtDisplay.Text = "Error";
                            ResetCalculator();
                            return;
                        }
                        break;
                }

                string resultStr = result.ToString();
                if (resultStr.Contains("."))
                {
                    resultStr = resultStr.TrimEnd('0').TrimEnd('.');
                }

                txtDisplay.Text = resultStr;

                if (showFullEquation)
                {
                    // ��ʾ�����ļ�����̣���һ���� ����� �ڶ����� = ���
                    lblHistory.Text = $"{_originalFirstNumber} {_operation} {_secondNumber} = {resultStr}";
                }
                else
                {
                    // ��������ʱֻ��ʾ�м���
                    lblHistory.Text = $"{resultStr} {_operation}";
                }

                _firstNumber = (double)result;
                _isNewNumber = true;
                _operationPerformed = true;
            }
            catch (Exception)
            {
                txtDisplay.Text = "Error";
                ResetCalculator();
            }
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            _isNewNumber = true;
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (_isNewNumber)
            {
                txtDisplay.Text = "0.";
                _isNewNumber = false;
            }
            else if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 1)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
            else
            {
                txtDisplay.Text = "0";
                _isNewNumber = true;
            }
        }

        private void ResetCalculator()
        {
            _firstNumber = 0;
            _secondNumber = 0;
            _originalFirstNumber = 0;
            _operation = "";
            _isNewNumber = true;
            _operationPerformed = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.D0:
                case Keys.NumPad0:
                    btn0.PerformClick();
                    return true;
                case Keys.D1:
                case Keys.NumPad1:
                    btn1.PerformClick();
                    return true;
                case Keys.D2:
                case Keys.NumPad2:
                    btn2.PerformClick();
                    return true;
                case Keys.D3:
                case Keys.NumPad3:
                    btn3.PerformClick();
                    return true;
                case Keys.D4:
                case Keys.NumPad4:
                    btn4.PerformClick();
                    return true;
                case Keys.D5:
                case Keys.NumPad5:
                    btn5.PerformClick();
                    return true;
                case Keys.D6:
                case Keys.NumPad6:
                    btn6.PerformClick();
                    return true;
                case Keys.D7:
                case Keys.NumPad7:
                    btn7.PerformClick();
                    return true;
                case Keys.D8:
                case Keys.NumPad8:
                    btn8.PerformClick();
                    return true;
                case Keys.D9:
                case Keys.NumPad9:
                    btn9.PerformClick();
                    return true;
                case Keys.Add:
                    btnAdd.PerformClick();
                    return true;
                case Keys.Subtract:
                    btnSubtract.PerformClick();
                    return true;
                case Keys.Multiply:
                    btnMultiply.PerformClick();
                    return true;
                case Keys.Divide:
                    btnDivide.PerformClick();
                    return true;
                case Keys.Enter:
                    btnEquals.PerformClick();
                    return true;
                case Keys.Escape:
                    btnClearEntry.PerformClick();
                    return true;
                case Keys.Back:
                    btnBackspace.PerformClick();
                    return true;
                case Keys.Decimal:
                    btnDecimal.PerformClick();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}