using Microsoft.Win32;

namespace KlarnaExercise
{
    public class InputLoader
    {
        public string GetInputFileLocation()
        {
            var openFileDialog = new OpenFileDialog();
            if (!openFileDialog.ShowDialog().HasValue) return string.Empty;
            var inputInvoiceFilePath = openFileDialog.FileName;
            return inputInvoiceFilePath;
        }
    }
}