using ComponentPt1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Complete_Circle_Test()
        {
            Form1 testForm = new Form1();

            
            testForm.textBox1.Text = "circle 50";
            testForm.Button1_Click();
        }
    }
}