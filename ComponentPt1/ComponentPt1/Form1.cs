using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            Bitmap pictureBox = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = pictureBox;

            var graphics = Graphics.FromImage(pictureBox);
        }

        /// <summary>
        /// Gets the user input for single line commands and check for an input
        /// it does this by seeing if the textbox is empty or not, if it is then
        /// it throws and exception, however if there is an input it will call the
        /// shapeDrawring method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="ArgumentException"></exception>
        private void Button1_Click(object sender, EventArgs e)
        {
            String userInput = textBox1.Text;

            if (string.IsNullOrWhiteSpace(userInput))
            {
                throw new ArgumentException("Error, No Input");
            }

            else
            {
                ShapeDrawing(userInput);
            }
        }

        /// <summary>
        /// creates a loop that reads each line for the multi line command exectuion
        /// it then calls the ShapeDrawing method to run the commands through so that
        /// the input can be drawn.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            foreach (string singleLine in richTextBox1.Lines)
            {
                string userInput = singleLine;
                ShapeDrawing(userInput);
            }
        }

        /// <summary>
        /// Gets the input and splits it into the individual components and
        /// draws the corresponding shapes, it makes use of switch cases to
        /// help prevent the duplication of code thus making it cleaner.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public void ShapeDrawing(string userInput)
        {
            Bitmap pictureBox = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = pictureBox;

            var graphics = Graphics.FromImage(pictureBox);

            
            String[] command = userInput.Split(' ');

            string shapeType = command[0].ToLower();

            switch (shapeType)
            {
                case "clear":
                    pictureBox1.Image = null;
                    return;

                case "refresh":
                    graphics.Clear(Color.Transparent);
                    return;

                case "circle":
                case "square":

                    if (command.Length < 2)
                    {
                        throw new ArgumentException("Error Invalid Size");
                    }
                    float size = float.Parse(command[1]);

                    if (command[0] == "circle")
                    {
                        graphics.FillEllipse(Brushes.DeepSkyBlue, 10, 10, size, size);
                    }
                    else
                    {
                        graphics.FillRectangle(Brushes.Turquoise, 10, 10, size, size);

                    }
                    break;

                case "rectangle":
                case "moveto":
                case "drawto":
                    if (command.Length < 3)
                    {
                        throw new InvalidOperationException("Error, Invalid Size");
                    }
                    switch (command[0])
                    {
                        case "rectanlge":
                            graphics.FillRectangle(Brushes.RoyalBlue, 10, 10, float.Parse(command[1]), float.Parse(command[2]));
                            break;
                        
                        case "drawto":
                            graphics.DrawLine(Pens.Aqua, float.Parse(command[1]), float.Parse(command[2]), float.Parse(command[1]), float.Parse(command[2]));
                            break;
                        case "moveto":
                            graphics.TranslateTransform(float.Parse(command[1]) - 10, float.Parse(command[2]) - 10);
                            break;

                    }
                    break;

                default:
                    throw new ArgumentException($"{shapeType} is not supported.");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
