using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using NUnit.Framework;

namespace KlarnaExercise
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly Dictionary<string, string> _asciiToValue = new Dictionary<string, string>
        {
            {" _ | ||_|", "0"},
            {"     |  |", "1"},
            {" _  _||_ ", "2"},
            {" _  _| _|", "3"},
            {"   |_|  |", "4"},
            {" _ |_  _|", "5"},
            {" _ |_ |_|", "6"},
            {" _   |  |", "7"},
            {" _ |_||_|", "8"},
            {" _ |_| _|", "9"},
        };

        private void SelectInvoice(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (!openFileDialog.ShowDialog().HasValue) return;
            var inputInvoiceFilePath = openFileDialog.FileName;
            var invoiceStreamReader = new StreamReader(inputInvoiceFilePath);

            string outpueNumbers = "";

            while (!invoiceStreamReader.EndOfStream)
            {
                IEnumerable<string> asciiNumber = ReadNextAsciiNumber(invoiceStreamReader);
                string nextNumber = "";
                for (int i = 0; i < 9; i++)
                {
                    IEnumerable<string> asciiDigit = ReadNextAsciiDigit(asciiNumber, i, 3);
                    var asciiRepresantation = ConvertAsciiToRepresentedString(asciiDigit);
                    string digitValue;
                    _asciiToValue.TryGetValue(asciiRepresantation, out digitValue);
                    nextNumber += digitValue;
                }

                outpueNumbers += nextNumber + Environment.NewLine;
            }

            WriteOutputFile(outpueNumbers);
        }

        private static void WriteOutputFile(string outpueNumbers)
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog().HasValue)
            {
                var streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.Write(outpueNumbers);
                streamWriter.Flush();
            }
        }

        private string ConvertAsciiToRepresentedString(IEnumerable<string> asciiDigit)
        {
            return string.Join(string.Empty, asciiDigit);
        }

        private IEnumerable<string> ReadNextAsciiDigit(IEnumerable<string> asciiNumber, int digitIndex, int digitSize)
        {
            return asciiNumber.Select(line => line.Substring(digitIndex*digitSize, digitSize));
        }

        private IEnumerable<string> ReadNextAsciiNumber(StreamReader invoiceStreamReader)
        {
            for (int i = 0; i < 3; i++)
            {
                yield return invoiceStreamReader.ReadLine();
            }

            // read blank line
            invoiceStreamReader.ReadLine();
        }
    }
}