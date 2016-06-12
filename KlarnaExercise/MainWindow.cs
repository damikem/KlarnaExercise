using System;
using System.Windows;

namespace KlarnaExercise
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectInvoice(object sender, RoutedEventArgs e)
        {
            var inputLoader = new InputLoader();
            var inputInvoiceFilePath = inputLoader.GetInputFileLocation();
            if (inputInvoiceFilePath == string.Empty)
            {
                return;
            }

            string output;
            try
            {
                var asciiTranslator = new AsciiTranslator();
                output = asciiTranslator.Translate(inputInvoiceFilePath);
            }
            catch (System.Exception)
            {
                MessageBox.Show("Error occured - make sure that the input is valid", "Error", MessageBoxButton.OK);
                return;
            }

            var outputWriter = new OutputWriter();
            outputWriter.SaveOutput(output);
        }
    }
}