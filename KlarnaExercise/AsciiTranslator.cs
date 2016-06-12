using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace KlarnaExercise
{
    public class AsciiTranslator : IAsciiTranslator
    {
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

        private const int DigitSize = 3;

        private const int DigitsPerLine = 9;

        public string Translate(string inputInvoiceFilePath)
        {
            var invoiceStreamReader = new StreamReader(inputInvoiceFilePath);

            string outpueNumbers = "";

            while (!invoiceStreamReader.EndOfStream)
            {
                IEnumerable<string> asciiNumber = ReadNextAsciiNumber(invoiceStreamReader);
                string nextNumber = "";
                bool currentNumberInvalid = false;
                for (int i = 0; i < DigitsPerLine; i++)
                {
                    IEnumerable<string> asciiDigit = ReadNextAsciiDigit(asciiNumber, i, DigitSize);
                    var asciiRepresantation = ConvertAsciiToRepresentedString(asciiDigit);
                    string digitValue;
                    var currentDigitValid = _asciiToValue.TryGetValue(asciiRepresantation, out digitValue);

                    if (currentDigitValid)
                    {
                        nextNumber += digitValue;
                    }
                    else
                    {
                        nextNumber += "?";
                        currentNumberInvalid = true;
                    }
                }

                outpueNumbers += nextNumber;
                if (currentNumberInvalid)
                {
                    outpueNumbers += " ILLEGAL";
                }
                outpueNumbers += "\n";
            }

            return outpueNumbers;
        }

        private ICollection<string> ReadNextAsciiNumber(StreamReader invoiceStreamReader)
        {
            var number = new List<string>();
            for (int i = 0; i < DigitSize; i++)
            {
                number.Add(invoiceStreamReader.ReadLine());
            }

            // read blank line
            invoiceStreamReader.ReadLine();
            return number;
        }

        private IEnumerable<string> ReadNextAsciiDigit(IEnumerable<string> asciiNumber, int digitIndex, int digitSize)
        {
            return asciiNumber.Select(line => line.Substring(digitIndex * digitSize, digitSize));
        }

        private string ConvertAsciiToRepresentedString(IEnumerable<string> asciiDigit)
        {
            return string.Join(string.Empty, asciiDigit);
        }
    }
}