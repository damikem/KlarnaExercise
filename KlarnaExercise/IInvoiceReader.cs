using System.Collections.Generic;

namespace KlarnaExercise
{
    interface IInvoiceReader
    {
        IEnumerable<string> ReadInvoiceNumber();
    }
}