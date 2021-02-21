using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Tictactoe.Models
{
    public class DecisionTreeBoard : Board
    {
        private readonly Color[,] colors;

        public DecisionTreeBoard()
        {
            colors = new Color[Coordinate.DIMENSION, Coordinate.DIMENSION];
            Clear();
        }

        public override Color GetColor(Coordinate coordinate)
        {
            Debug.Assert(coordinate != null);
            return colors[coordinate.GetRow(), coordinate.GetColumn()];
        }

        public override bool Complete()
        {
            int contTokens = 0;
            for (int i = 0; i < Coordinate.DIMENSION; i++)
            {
                for (int j = 0; j < Coordinate.DIMENSION; j++)
                {
                    if (colors[i, j] != Color.NONE)
                    {
                        contTokens++;
                    }
                }
            }
            return contTokens == Coordinate.DIMENSION * 2;
        }

        public override bool ExistTicTacToe(Color color)
        {
            Debug.Assert(color != Color.NONE);
            if (colors[1, 1] == color)
            {
                if (colors[0, 0] == color)
                {
                    return colors[2, 2] == color;
                }
                if (colors[0, 2] == color)
                {
                    return colors[2, 0] == color;
                }
                if (colors[0, 1] == color)
                {
                    return colors[2, 1] == color;
                }
                if (colors[1, 0] == color)
                {
                    return colors[1, 2] == color;
                }
                return false;
            }
            if (colors[0, 0] == color)
            {
                if (colors[0, 1] == color)
                {
                    return colors[0, 2] == color;
                }
                if (colors[1, 0] == color)
                {
                    return colors[2, 0] == color;
                }
                return false;
            }
            if (colors[2, 2] == color)
            {
                if (colors[1, 2] == color)
                {
                    return colors[0, 2] == color;
                }
                if (colors[2, 1] == color)
                {
                    return colors[2, 0] == color;
                }
                return false;
            }
            return false;
        }

        public override bool Empty(Coordinate coordinate)
        {
            Debug.Assert(coordinate != null);
            return colors[coordinate.GetRow(), coordinate.GetColumn()] == Color.NONE;
        }

        public override void Put(Coordinate coordinate, Color color)
        {
            Debug.Assert(coordinate != null);
            Debug.Assert(color != null);
            Debug.Assert(color != Color.NONE);
            Debug.Assert(Empty(coordinate));
            Debug.Assert(!Complete());
            colors[coordinate.GetRow(), coordinate.GetColumn()] = color;
        }

        public override void Remove(Coordinate coordinate, Color color)
        {
            Debug.Assert(coordinate != null);
            Debug.Assert(color != null);
            Debug.Assert(color != Color.NONE);
            Debug.Assert(GetColor(coordinate) == color);
            colors[coordinate.GetRow(), coordinate.GetColumn()] = Color.NONE;
        }

        public override bool Full(Coordinate coordinate, Color color)
        {
            Debug.Assert(coordinate != null);
            Debug.Assert(color != Color.NONE);
            return colors[coordinate.GetRow(), coordinate.GetColumn()] == color;
        }

        public override void Clear()
        {
            for (int i = 0; i < Coordinate.DIMENSION; i++)
            {
                for (int j = 0; j < Coordinate.DIMENSION; j++)
                {
                    colors[i, j] = Color.NONE;
                }
            }
        }

        public override string ToString()
        {
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

        public void WriteFile(string name)
        {
            var lines = new List<string>();
            try
            {
                for (int i = 0; i < colors.Length; i++)
                {
                    for (int j = 0; j < colors.GetLength(i); j++)
                    {
                        lines.Add(colors[i, j] + " ");
                    }
                }
                File.WriteAllLines($"{name}.ttt", lines.ToArray());
            }
            catch (IOException ex)
            {
                Console.WriteLine("IOException al escribir:" + ex.Message);
            }
            finally
            {
            }
        }

        public void ReadFile(String name)
        {
            try
            {
                var lines = File.ReadAllLines($"{name}.ttt");
                for (int i = 0; i < colors.Length; i++)
                {
                    //Todo: When I get to this part of the course, I need to check this code
                    // String linea = in.readLine();
                    //Scanner scanner = new Scanner(linea);
                    //for (int j = 0; j < colors.Length; j++)
                    //{
                    //    colors[i,j] = Color.values()[scanner.nextInt()];
                    //}
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("IOException al leer: " + ex.Message);
            }
            finally
            {
            }
        }
    }
}