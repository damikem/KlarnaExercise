using System.IO;
using Microsoft.Win32;

namespace KlarnaExercise
{
    public class OutputWriter
    {
        public void SaveOutput(string output)
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog().HasValue)
            {
                var streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.Write(output);
                streamWriter.Flush();
            }
        }
    }
}