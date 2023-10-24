using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentPt1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image != null)
            {
                Bitmap pictureBox = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            }

            Graphics graphics = Graphics.FromImage(pictureBox);


            String userInput = singleLine.Text;
            String[] command = userInput.Split(' ');

            graphics.Clear(Color.White);


            if (command.Length > 1)
            {
                if ("circle".Equals(command[0]))
                {
                    graphics.FillEllipse(Brushes.DeepSkyBlue, 10, 10, float.Parse(command[1]), float.Parse(command[1]));
                }

                else if ("square".Equals(command[0]))
                {
                    graphics.FillRectangle(Brushes.Turquoise, 10, 10, float.Parse(command[1]), float.Parse(command[1]));
                }

                else if ("rectangle".Equals(command[0]))
                {
                    graphics.FillRectangle(Brushes.RoyalBlue, 10, 10, float.Parse(command[1]), float.Parse(command[2]));
                }

                else if ("moveTo".Equals(command[0]))
                {
                    throw new NotImplementedException();
                }

                else
                {
                    MessageBox.Show("Error Invlaid Shape");
                }
            }

            else
            {
                MessageBox.Show("Error, Invalid Shape");
            }
        }   
    }
}
