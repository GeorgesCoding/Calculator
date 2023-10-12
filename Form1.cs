/* Calculator app with basic mathemtical functions
 * with an interactive interface and features included
 * to prevent unaccepted user input from crashing the app
 * George C.
 * Start Date: 01/12/2023
 * Finish Date: 01/13/2023, 
 */
//i made a change


using System;
using System.Windows.Forms;

namespace Calculator_App
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        //variable declaration
        float number = 0, num2;
        public static float answer = 0;
        double roundedNum, root;
        int operation = 0, indexNum = 0, indexOp = 0, preop = 0;
        float[] numArr = new float[100];
        int[] opArr = new int[100];

        //Loads the calculator app window 
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        //Changes the Display text
        private void Display_TextChanged(object sender, EventArgs e)
        {
        }

        //buttons that adds the number to the display
        private void one_Click(object sender, EventArgs e)
        {
            showNum("1");
        }

        private void two_Click(object sender, EventArgs e)
        {
            showNum("2");
        }

        private void three_Click(object sender, EventArgs e)
        {
            showNum("3");
        }

        private void four_Click(object sender, EventArgs e)
        {
            showNum("4");
        }

        private void five_Click(object sender, EventArgs e)
        {
            showNum("5");
        }

        private void six_Click(object sender, EventArgs e)
        {
            showNum("6");
        }

        private void seven_Click(object sender, EventArgs e)
        {
            showNum("7");
        }

        private void eight_Click(object sender, EventArgs e)
        {
            showNum("8");
        }

        private void nine_Click(object sender, EventArgs e)
        {
            showNum("9");
        }

        private void zero_Click(object sender, EventArgs e)
        {
            showNum("0");
        }

        private void doublezero_Click(object sender, EventArgs e)
        {
            showNum("00");
        }

        //button to display a decimal
        private void dot_Click(object sender, EventArgs e)
        {
            if (Display.Text == "" || int.TryParse(Display.Text, out int j))
            {
                showNum(".");
            }
        }

        //addition operation
        private void plus_Click(object sender, EventArgs e)
        {
            removeEqual();
            check(" + ", 1);
        }

        //subtraction operation
        private void minus_Click(object sender, EventArgs e)
        {
            removeEqual();
            check(" - ", 2);

            if (display2.Text == "")
            {
                Display.Text = Display.Text + "-";
                display2.Text = display2.Text + "-";
            }
        }

        //multiplication operation
        private void multiply_Click(object sender, EventArgs e)
        {
            removeEqual();
            check(" x ", 3);

        }

        //division operation
        private void divide_Click(object sender, EventArgs e)
        {
            removeEqual();
            check(" ÷ ", 4);
        }

        //previous answer 
        private void pre_Click(object sender, EventArgs e)
        {
            display2.Text = display2.Text + answer.ToString();

            if (Display.Text == "")
            {
                Display.Text = answer.ToString();
            }
        }

        public void showNum(string num)
        {
            Display.Text = Display.Text + num;
            display2.Text = display2.Text + num;
        }

        public void storeNum(float numStored)
        {
            numArr[indexNum] = numStored;
            indexNum++;
        }

        public void storeOp(int opStored)
        {
            opArr[indexOp] = opStored;
            indexOp++;
        }

        public void removeEqual()
        {
            if (display2.Text.Contains("="))
            {
                string displayTwo = display2.Text;
                display2.Text = displayTwo.Remove(displayTwo.Length - 2);
            }
        }

        public void check(string sign, int op)
        {
            storeNum(float.Parse(Display.Text));

            if (int.TryParse(Display.Text, out int j) || float.TryParse(Display.Text, out float k))
            {
                number = float.Parse(Display.Text);
                Display.Clear();
                Display.Focus();
                display2.Text = display2.Text + sign;
                storeOp(op);
            }
        }

        public void compute()
        {
            storeNum(float.Parse(Display.Text));

            switch (opArr[0])
            {
                case 1:
                    answer = numArr[0] + numArr[1];
                    display2.Text = display2.Text + " =";
                    preop = 1;
                    break;

                case 2:
                    answer = numArr[0] - numArr[1];
                    display2.Text = display2.Text + " =";
                    preop = 2;
                    break;

                case 3:
                    answer = numArr[0] * numArr[1];
                    display2.Text = display2.Text + " =";
                    preop = 3;
                    break;

                case 4:
                    answer = numArr[0] / numArr[1];
                    display2.Text = display2.Text + " =";
                    preop = 4;
                    break;

                default:
                    break;
            }

            if (indexOp > 1)
            {
                for (int i = 1; i < indexOp; i++)
                {
                    removeEqual();
                    switch (opArr[i])
                    {
                        case 1:
                            answer = answer + numArr[i + 1];
                            display2.Text = display2.Text + " =";
                            preop = 1;
                            break;

                        case 2:
                            answer = answer - numArr[i + 1];
                            display2.Text = display2.Text + " =";
                            preop = 2;
                            break;

                        case 3:
                            answer = answer * numArr[i + 1];
                            display2.Text = display2.Text + " =";
                            preop = 3;
                            break;

                        case 4:
                            answer = answer / numArr[i + 1];
                            display2.Text = display2.Text + " =";
                            preop = 4;
                            break;

                        default:
                            break;
                    }
                }
            }
            return;
        }

        //computing the answer (equal sign button)
        private void equal_Click(object sender, EventArgs e)
        {
            compute();
            Display.Text = answer.ToString();
        }

        private void button1_Click(object sender, EventArgs e) //log
        {

        }

        //delete function
        private void delete_Click(object sender, EventArgs e)
        {
            Display.Text = Display.Text.Remove(Display.Text.Length - 1);
            display2.Text = display2.Text.Remove(display2.Text.Length - 1);
        }

        private void button10_Click(object sender, EventArgs e) //cos
        {

        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            if (Display.Text != "")
            {
                display2.Text = "";
                display2.Text = "√" + Display.Text;
                root = double.Parse(Display.Text);
                Display.Text = Math.Sqrt(root).ToString();
            }

            else
            {
                operation = 6;
                display2.Text = display2.Text + "√";
            }
        }

        private void absolute_Click(object sender, EventArgs e)
        {

        }

        //rounding function
        private void round_Click(object sender, EventArgs e)
        {
            roundedNum = double.Parse(Display.Text);
            operation = 5;
            Display.Clear();
            Display.Focus();
        }

        //square a number
        private void squared_Click(object sender, EventArgs e)
        {
            float num2;
            if (int.TryParse(Display.Text, out int j))
            {
                num2 = float.Parse(Display.Text);
                num2 = num2 * num2;
                Display.Text = num2.ToString();
                display2.Text = display2.Text + "² ";
            }
            else if (float.TryParse(Display.Text, out float k))
            {
                num2 = float.Parse(Display.Text);
                num2 = num2 * num2;
                Display.Text = num2.ToString();
                display2.Text = display2.Text + "² ";
            }
            operation = preop;
            preop = 99;
        }

        //cube a number
        private void cube_Click(object sender, EventArgs e)
        {
            float num2;
            if (int.TryParse(Display.Text, out int j))
            {
                num2 = float.Parse(Display.Text);
                num2 = num2 * num2 * num2;
                Display.Text = num2.ToString();

                display2.Text = display2.Text + "² ";
            }
            else if (float.TryParse(Display.Text, out float k))
            {
                num2 = float.Parse(Display.Text);
                num2 = num2 * num2 * num2;
                Display.Text = num2.ToString();
                display2.Text = display2.Text + "² ";
            }
            operation = preop;
            preop = 99;
        }

        private void exponent_Click(object sender, EventArgs e)
        {

        }

        private void sin_Click(object sender, EventArgs e)
        {

        }

        private void Asin_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e) //sinh
        {

        }

        private void Acos_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e) //cosh
        {

        }

        private void tan_Click(object sender, EventArgs e)
        {

        }

        private void Atan_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e) //tanh
        {

        }

        private void pi_Click(object sender, EventArgs e)
        {
            if (Display.Text == "")
            {
                Display.Text = Display.Text + Math.PI;
                display2.Text = display2.Text + "π";
            }
        }

        private void display2_TextChanged(object sender, EventArgs e)
        {
        }

        //clear entires and values of variables and ArrayLists (C button)
        private void clear_Click(object sender, EventArgs e)
        {
            Display.Clear();
            display2.Clear();
            num2 = number = answer = 0;
            roundedNum = root = 0;
            operation = preop = 0;
            indexNum = 0;
            indexOp = 0;
            Array.Clear(numArr, 0, 100);
            Array.Clear(opArr, 0, 100);
        }
    }
}