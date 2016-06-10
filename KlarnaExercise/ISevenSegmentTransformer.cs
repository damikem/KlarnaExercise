using System.Collections.Generic;

namespace KlarnaExercise
{
    interface ISevenSegmentTransformer
    {
        string TransformAsciiToRepresentedString(IEnumerable<string> asciiText);
    }
}