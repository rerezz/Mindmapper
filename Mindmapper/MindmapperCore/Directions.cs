using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore
{
    internal static class ConnectionDirections
    {
        /// <summary>
        /// Enum for directions on the mindmap
        /// </summary>
        public enum Direction : int
        {
            North, South, East, West, NorthEast, SouthEast, NorthWest, SouthWest, None
        }

        /// <summary>
        /// Gets the opposit direction
        /// </summary>
        /// <param name="direction">direction</param>
        /// <returns></returns>
        public static Direction GetOppositeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return Direction.South;
                case Direction.South:
                    return Direction.North;
                case Direction.East:
                    return Direction.West;
                case Direction.West:
                    return Direction.East;
                case Direction.NorthEast:
                    return Direction.SouthWest;
                case Direction.SouthEast:
                    return Direction.NorthWest;
                case Direction.NorthWest:
                    return Direction.SouthEast;
                case Direction.SouthWest:
                    return Direction.NorthEast;
                default:
                    return Direction.None;
            }
        }
    }
}