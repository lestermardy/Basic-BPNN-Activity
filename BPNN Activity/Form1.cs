using Backprop;
using System.Xml;

namespace BPNN_Activity
{
    public partial class Form1 : Form
    {
        NeuralNet nn;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nn = new NeuralNet(4, 1, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] b = new int[4];
            for (int x = 0; x < 100; x++)
            {
                for (int i = 0; i < 16; i++)
                {
                    b = getBitConversion(4, i);
                    nn.setInputs(0, b[0]);
                    nn.setInputs(1, b[1]);
                    nn.setInputs(2, b[2]);
                    nn.setInputs(3, b[3]);
                    if (b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1)
                    {
                        nn.setDesiredOutput(0, 1);
                    }
                    else
                    {
                        nn.setDesiredOutput(0, 0);
                    }
                    nn.learn();
                }
            }
            
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            nn.setInputs(0, Convert.ToDouble(textBox1.Text));
            nn.setInputs(1, Convert.ToDouble(textBox2.Text));
            nn.setInputs(2, Convert.ToDouble(textBox3.Text));
            nn.setInputs(3, Convert.ToDouble(textBox5.Text));
            nn.run();
            textBox4.Text = "" + nn.getOuputData(0);
        }

        private int[] getBitConversion(int length, int n)
        {
            int[] output = new int[length];
            int index = length - 1; 

            while (n > 0 && index >= 0)
            {
                output[index] = n % 2; 
                n /= 2;                
                index--;
            }

            return output;
        }
    }
}
