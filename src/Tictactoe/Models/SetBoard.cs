using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Tictactoe.Utils;

namespace Tictactoe.Models
{
    public class SetBoard : Board
    {
        private IDictionary<Color, ISet<Coordinate>> coordinates;

        public SetBoard()
        {
            coordinates = new Dictionary<Color, ISet<Coordinate>>();
            for (int i = 0; i < Enum.GetValues(typeof(Color)).Length - 1; i++)
            {
                coordinates[(Color)i] = new HashSet<Coordinate>();
            }
        }

        public override Color GetColor(Coordinate coordinate)
        {
            Debug.Assert(coordinate != null);
            foreach (Color color in coordinates.Keys)
            {
                if (coordinates[color].Contains(coordinate))
                {
                    return color;
                }
            }
            return Color.NONE;
        }

        public override bool Complete()
        {
            int contTokens = 0;
            foreach (Color color in coordinates.Keys)
            {
                contTokens += coordinates[color].Count;
            }
            return contTokens == Coordinate.DIMENSION * coordinates.Keys.Count;
        }

        public override bool ExistTicTacToe(Color color)
        {
            Debug.Assert(color != Color.NONE);
            ISet<Coordinate> coordinateSet = coordinates[color];
            if (coordinateSet.Count != Coordinate.DIMENSION)
            {
                return false;
            }
            Coordinate[] coordinateArray = coordinateSet.ToArray();
            Direction direction = coordinateArray[0].Direction(coordinateArray[1]);
            if (direction == Direction.NON_EXISTENT)
            {
                return false;
            }
            for (int i = 1; i < Coordinate.DIMENSION - 1; i++)
            {
                if (coordinateArray[i].Direction(coordinateArray[i + 1]) != direction)
                {
                    return false;
                }
            }
            return true;
        }

        public override bool Empty(Coordinate coordinate)
        {
            Debug.Assert(coordinate != null);
            return !Full(coordinate, Color.XS)
                    && !Full(coordinate, Color.OS);
        }

        public override void Put(Coordinate coordinate, Color color)
        {
            Debug.Assert(coordinate != null);
            Debug.Assert(color != null);
            Debug.Assert(color != Color.NONE);
            Debug.Assert(Empty(coordinate));
            Debug.Assert(!Complete());
            coordinates[color].Add(coordinate.Clone());
        }

        public override void Remove(Coordinate coordinate, Color color)
        {
            Debug.Assert(coordinate != null);
            Debug.Assert(color != null);
            Debug.Assert(color != Color.NONE);
            Debug.Assert(GetColor(coordinate) == color);
            coordinates[color].Remove(coordinate);
        }

        public override bool Full(Coordinate coordinate, Color color)
        {
            Debug.Assert(coordinate != null);
            Debug.Assert(color != Color.NONE);
            return coordinates[color].Contains(coordinate);
        }

        public override void Clear()
        {
            foreach (Color color in coordinates.Keys)
            {
                coordinates[color].Clear();
            }
        }

        public override string ToString()
        {
            Color[,] colors = new Color[3, 3];
            foreach (Color color in coordinates.Keys)
            {
                foreach (Coordinate coordinate in coordinates[color])
                {
                    colors[coordinate.GetRow(), coordinate.GetColumn()] = GetColor(coordinate);
                }
            }
            string result = "";
            for (int i = 0; i < colors.Length; i++)
            {
                for (int j = 0; j < colors.GetLength(i); j++)
                {
                    char color = '.';
                    if (colors[i, j] != null)
                    {
                        color = colors[i, j].ToString()[0];
                    }
                    result += color + " ";
                }
                result += " \n";
            }
            return result;
        }
    }
}