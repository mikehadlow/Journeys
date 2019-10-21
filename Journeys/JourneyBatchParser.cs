using System;
using Superpower;
using Superpower.Parsers;

namespace Journeys
{
    public static class JourneyBatchParser
    {
        static TextParser<Orientation> Orientation => 
            Character
            .In('N', 'S', 'E', 'W')
            .Select(c => Enum.Parse<Orientation>(c.ToString()));

        static TextParser<Command> Command => 
            Character
            .In('R', 'L', 'F')
            .Select(c => Enum.Parse<Command>(c.ToString()));

        static TextParser<(int, int)> Coordinate =>
            from x in Numerics.IntegerInt32
            from _ in Span.WhiteSpace
            from y in Numerics.IntegerInt32
            select (x, y);

        static TextParser<Postion> Postion =>
            from coordinate in Coordinate
            from _ in Span.WhiteSpace
            from orientation in Orientation
            select new Postion(coordinate, orientation);

        static TextParser<Journey> Journey =>
            from start in Postion
            from _ in Span.WhiteSpace
            from commands in Command.AtLeastOnce()
            from __ in Span.WhiteSpace
            from end in Postion
            select new Journey(start, commands, end);

        public static TextParser<JourneyBatch> JourneyBatch =>
            from journeys in Journey.AtLeastOnceDelimitedBy(Span.WhiteSpace)
            select new JourneyBatch(journeys);
    }
}
