using System.IO;
using static System.Console;

namespace Journeys
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                WriteLine("Usage Journeys.exe <input file>");
                return;
            }

            var inputFileName = args[0];
            if(!File.Exists(inputFileName))
            {
                WriteLine($"Input file {inputFileName}, does not exist");
                return;
            }

            var batchText = File.ReadAllText(inputFileName);

            var journeyBatch = JourneyBatchParser.JourneyBatch(new Superpower.Model.TextSpan(batchText));
            if(journeyBatch.HasValue)
            {
                WriteLine(journeyBatch.Value.ToString());
                JourneyBatchEvaluator.EvaluateJourneyBatch(journeyBatch.Value);
            }
            else
            {
                WriteLine($"Parser error: '{journeyBatch.ErrorMessage}' at {journeyBatch.ErrorPosition}");
            }
        }
    }
}
