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

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Bitmap pictureBox = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = pictureBox;

            var graphics = Graphics.FromImage(pictureBox);

            String userInput = textBox1.Text;
            String[] command = userInput.Split(' ');

            graphics.Clear(Color.White);

            if (string.IsNullOrWhiteSpace(userInput))
            {
                throw new ArgumentException("Error, No Input");
            }
            
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
            }

            else
            {
                throw new ArgumentException("Error, Missing Size data");
            }


            pictureBox1.Refresh();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
