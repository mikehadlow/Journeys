using System;
using System.Linq;

/// <summary>
/// This file contains the data structures that describe a journey batch.
/// </summary>
namespace Journeys
{
    public readonly struct JourneyBatch
    {
        public Journey[] Journeys { get; }

        public JourneyBatch(Journey[] journeys)
        {
            Journeys = journeys ?? throw new ArgumentNullException(nameof(journeys));
        }

        public override string ToString() => 
            $"{Journeys.Aggregate("", (txt, journey) => txt + journey.ToString() + "\r\n")}";
    }

    public readonly struct Journey
    {
        public Postion StartPostion { get; }
        public Command[] Commands { get; }
        public Postion EndPosition { get; }

        public Journey(Postion startPostion, Command[] commands, Postion endPosition)
        {
            StartPostion = startPostion;
            Commands = commands ?? throw new ArgumentNullException(nameof(commands));
            EndPosition = endPosition;
        }

        public override string ToString() => $"\r\n{StartPostion}\r\n{Commands.Aggregate("", (txt, cmd) => txt + cmd.ToString())}\r\n{EndPosition}";
    }

    public readonly struct Postion
    {
        public (int X, int Y) Location { get; }
        public Orientation Orientation { get; }

        public Postion((int X, int Y) location, Orientation orientation)
        {
            Location = location;
            Orientation = orientation;
        }

        public void Deconstruct(out Orientation orientation, out (int, int) location)
        {
            orientation = Orientation;
            location = Location;
        }

        public override string ToString() => $"{Location} {Orientation}";

        public override bool Equals(object otherPostion) =>
            otherPostion switch
            {
                Postion p => GetHashCode() == p.GetHashCode(),
                _ => throw new InvalidOperationException("argument must be another Postion")
            };

        public override int GetHashCode() => HashCode.Combine(Location, Orientation);
    }

    public enum Orientation
    {
        N = 0,
        E = 1,
        S = 2,
        W = 3
    }

    public enum Command
    {
        R = 0,
        L = 1,
        F = 2
    }
}
