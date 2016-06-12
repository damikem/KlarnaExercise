using System.IO;
using KlarnaExercise;
using NUnit.Framework;

namespace KlarnaExerciseUnitTest
{
    [TestFixture]
    public class CompareOutputToExpectedOutputIntegrationTest
    {
        [Test]
        public void check_expected_output_story1()
        {
            //A
            string invoiceFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"input_user_story_1.txt");
            string expectedOutputPath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"output_user_story_1.txt");
            
            string expectedOutput = File.ReadAllText(expectedOutputPath);
            
            var asciiTranslator = new AsciiTranslator();
            
            //A
            var output = asciiTranslator.Translate(invoiceFilePath);

            //A
            Assert.AreEqual(output, expectedOutput, "Not expected output");
        }

        [Test]
        public void check_expected_output_story2()
        {
            //A
            string invoiceFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"input_user_story_2.txt");

            string expectedOutputPath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"output_user_story_2.txt");
            string expectedOutput = File.ReadAllText(expectedOutputPath);

            var asciiTranslator = new AsciiTranslator();

            //A
            var output = asciiTranslator.Translate(invoiceFilePath);

            //A
            Assert.AreEqual(output, expectedOutput, "Not expected output");
        }
    }
}