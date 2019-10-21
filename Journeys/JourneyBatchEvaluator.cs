using System;
using System.Linq;
using static System.Console;

namespace Journeys
{
    public static class JourneyBatchEvaluator
    {
        public static void EvaluateJourneyBatch(JourneyBatch journeyBatch)
        {
            foreach(var journey in journeyBatch.Journeys)
            {
                EvaluateJourney(journey);
            }
        }

        public static void EvaluateJourney(Journey journey)
        {
            WriteLine();

            var finalPostion = journey.Commands
                .Select(DoCommand)
                .Aggregate(journey.StartPostion, (pos, cmd) => cmd(LogPostion(pos)));

            WriteLine(finalPostion);

            if(finalPostion.Equals(journey.EndPosition))
            {
                WriteLine("SUCCESS!");
            }
            else
            {
                WriteLine($"FAIL: End position did not match expected position: {journey.EndPosition}");
            }

            static Postion LogPostion(Postion postion)
            {
                WriteLine(postion);
                return postion;
            }
        }

        public static Func<Postion, Postion> DoCommand(Command command) =>
            command switch
            {
            Command.F => pos => new Postion(Move(pos), pos.Orientation),
            Command.L => pos => new Postion(pos.Location, pos.Orientation.Rotate(-1)),
            Command.R => pos => new Postion(pos.Location, pos.Orientation.Rotate(+1)),
            Command x => throw new InvalidOperationException($"Unexpected Command enum value: '{x}'")
            };

        public static (int, int) Move(Postion postion) =>
            postion switch
            {
            (Orientation.N, (int x, int y)) => (x, y + 1),
            (Orientation.E, (int x, int y)) => (x + 1, y),
            (Orientation.S, (int x, int y)) => (x, y - 1),
            (Orientation.W, (int x, int y)) => (x - 1, y),
            (Orientation x, _) => throw new InvalidOperationException($"Unexpected Orientation enum value: '{x}'")
            };

        public static Orientation Rotate(this Orientation initial, int rotation)
            => (Orientation)((4 + ((int)initial) + rotation) % 4);
    }
}
