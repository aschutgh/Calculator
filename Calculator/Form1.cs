using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// Simple RPN Calculator
// Opdrachtenreeks rood
// Na invoeren van een getal altijd bevestigen met Enter

namespace Calculator
{
    public partial class Form1 : Form
    {
       
        Double Tval = 0;
        Double Xval = 0;
        Double Yval = 0;
        Double Zval = 0;
        bool PreviousPressWasEnter = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void pushup(ref Double under, ref Double above)
        {
            above = under;
        }

        private void pushdown(ref Double under, ref Double above)
        {
            under = above;
        }

        private void swap(ref Double Y, ref Double Z)
        {
            Double Temp = 0;
            // Y
            // Z
            Temp = Z;
            Z = Y;
            Y = Temp;
        }

        private void button_click(object sender, EventArgs e)
        {
            if (textBoxInput.Text == "0")
            {
                textBoxInput.Clear();
            }
            if (PreviousPressWasEnter == true)
            {
                textBoxInput.Clear();
                PreviousPressWasEnter = false;
            }
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if(!textBoxInput.Text.Contains("."))
                    textBoxInput.Text = textBoxInput.Text + button.Text;
            }
            else
            {
                textBoxInput.Text = textBoxInput.Text + button.Text;
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            //T
            //X
            //Y
            //Z
            String operation = "";
            Double Temp = 0;

            Button button = (Button)sender;
            operation = button.Text;
            switch(operation)
            {
                case "+":
                    // uitleg recept. voor *, - en / is het precies hetzelfde
                    // Sla Z op in Temp
                    Temp = Zval;
                    // Z wordt 0
                    Zval = 0;
                    // Voer een drop van de stack uit. 0 staat nu in T
                    buttonDrop.PerformClick();
                    // Y staat nu in Z
                    // Nieuwe waarde van Z: Y + Temp (Z)
                    Zval = Zval + Temp;
                    update_view();
                    break;
                case "*":
                    Temp = Zval;
                    Zval = 0;
                    buttonDrop.PerformClick();
                    Zval = Zval * Temp;
                    update_view();
                    break;
                case "-":
                    Temp = Zval;
                    Zval = 0;
                    buttonDrop.PerformClick();
                    Zval = Zval - Temp;
                    update_view();
                    break;
                case "/":
                    Temp = Zval;
                    Zval = 0;
                    buttonDrop.PerformClick();
                    Zval = Zval / Temp;
                    update_view();
                    break;
                case "Percentage":
                    // Percentage berekenen is makkelijk
                    // Laat waarde van Y in Y staan!
                    // Dit is makkelijk voor verdere berekeningen
                    Zval = (Zval / 100) * Yval;
                    update_view();
                    break;
                default:
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        //    textBoxZ.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
        //    textBoxZ.Text = "0";
        //    resultValue = 0;
        }

        private void button15_Click(object sender, EventArgs e)
        {
         
        }

        private void labelCurrentOperation_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void enter_click(object sender, EventArgs e)
        {
            PreviousPressWasEnter = true;
            // T
            // X
            // Y
            // Z
            pushup(ref Xval, ref Tval);
            pushup(ref Yval, ref Xval);
            pushup(ref Zval, ref Yval);
            Zval = Double.Parse(textBoxInput.Text);
            textBoxT.Text = Tval.ToString();
            textBoxY.Text = Yval.ToString();
            textBoxX.Text = Xval.ToString();
            textBoxZ.Text = Zval.ToString();
            textBoxInput.Clear();
        }

        private void swap_click(object sender, EventArgs e)
        {
            swap(ref Yval, ref Zval);
            textBoxY.Text = Yval.ToString();
            textBoxZ.Text = Zval.ToString();
        }

        private void update_view()
        {
            textBoxT.Text = Tval.ToString();
            textBoxX.Text = Xval.ToString();
            textBoxY.Text = Yval.ToString();
            textBoxZ.Text = Zval.ToString();
        }

        private void drop_click(object sender, EventArgs e)
        {
            // T
            // X
            // Y
            // Z
            Double Temp = 0;
            Temp = Zval;
            pushdown(ref Zval, ref Yval);
            pushdown(ref Yval, ref Xval);
            pushdown(ref Xval, ref Tval);
            Tval = Temp;
            update_view();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
