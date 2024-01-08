using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComponentPt1;
using System;

namespace CommandTester
{
    /// <summary>
    /// Tests the ShapeDrawing method in the Form1 class
    /// </summary>
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Tests to make sure that the complete circle command works
        /// </summary>
        [TestMethod]
        public void CompleteCircle()
        {
            string userInput = "circle 50";


            Form1 parser = new Form1();
            parser.ShapeDrawing(userInput);

        }

        /// <summary>
        /// Tests to make sure that the complete square command works
        /// </summary>
        [TestMethod]
        public void CompleteSquare()
        {
            string userInput = "square 68";

            Form1 parser = new Form1();
            parser.ShapeDrawing(userInput);

        }

        /// <summary>
        /// Tests to make sure that the complete rectangle command works
        /// </summary>
        [TestMethod]
        public void CompleteRectangle()
        {
            string userInput = "rectangle 50 80";

            Form1 parser = new Form1();
            parser.ShapeDrawing(userInput);
        }

        /// <summary>
        /// Tests to make sure that the complete draw line command works
        /// </summary>
        [TestMethod]
        public void CompleteDrawTo()
        {
            string userInput = "drawto 50 80";

            Form1 parser = new Form1();
            parser.ShapeDrawing(userInput);
        }

        /// <summary>
        /// Tests to make sure that the complete move cursor command works
        /// </summary>
        [TestMethod]
        public void CompleteMoveTo()
        {
            string userInput = "moveto 50 80";

            Form1 parser = new Form1();
            parser.ShapeDrawing(userInput);
        }

        /// <summary>
        /// Tests to make sure that the complete clear command works
        /// </summary>
        [TestMethod]
        public void Clear()
        {
            string userInput = "clear";

            Form1 parser = new Form1();
            parser.ShapeDrawing(userInput);

            
        }

        /// <summary>
        /// Tests to make sure that the complete reset command works
        /// </summary>
        [TestMethod]
        public void Reset()
        {
            string userInput = "refresh";

            Form1 parser = new Form1();
            parser.ShapeDrawing(userInput);
        }
    }
}
