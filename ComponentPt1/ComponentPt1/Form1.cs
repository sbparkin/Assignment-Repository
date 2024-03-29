﻿using System;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
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
        ///  Creates a loop that reads each line for the multi line command exectuion box
        /// it then calls the ShapeDrawing method, and passes userInput as an argument
        /// then ShapeDrawing. It also has a delay such that all drawings can be seen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button2_Click(object sender, EventArgs e)
        {
            foreach (string singleLine in richTextBox1.Lines)
            {
                string userInput = singleLine;

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    break;
                }

                ShapeDrawing(userInput);

                await Task.Delay(500);
            }
        }

        /// <summary>
        /// Creates an instance of a bitmap and sets is to the picture box, it then
        /// takes the userinput from either the single line and muti line text boxes
        /// and parses them through switch case, that work out what the user inputted
        /// and outputs the relevent drawing.
        /// </summary>
        /// <param name="userInput"></param>
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
                case "triangle":

                    if (command.Length < 2)
                    {
                        throw new ArgumentException("Error Invalid Size");
                    }
                    float size = float.Parse(command[1]);

                    switch (shapeType)
                    {
                        case "circle":
                            graphics.FillEllipse(Brushes.BurlyWood, 10, 10, size, size);
                            break;

                        case "square":
                            graphics.FillRectangle(Brushes.Turquoise, 10, 10, size, size);
                            break;

                        case "triangle":
                            Point[] trianglePoints = new Point[]
                            {
                                new Point(10+10),
                                new Point(10+ (int)(size/2), 10 + (int)size),
                                new Point(10 + (int)size, 10)
                            };
                            graphics.FillPolygon(Brushes.Chartreuse, trianglePoints);
                            break;
                    }
                    break;

                case "rectangle":
                case "moveto":
                case "drawto":
                    if (command.Length < 3)
                    {
                        throw new ArgumentException("Error, Invalid Size");
                    }
                    switch (command[0])
                    {
                        case "rectangle":
                            graphics.FillRectangle(Brushes.RoyalBlue, 10, 10, float.Parse(command[1]), float.Parse(command[2]));
                            break;

                        case "drawto":
                            graphics.DrawLine(Pens.Aqua, 10, 10, float.Parse(command[1]), float.Parse(command[2]));
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

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Saves the commands to a txt file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            string textFile = "../Saved.txt";
            foreach (string line in richTextBox1.Lines)
            {
                MessageBox.Show(line);
                using ( StreamWriter writer = new StreamWriter(textFile) ) 
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
