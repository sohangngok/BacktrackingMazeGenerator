using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze
{
    public class RectangularMaze : IMaze
    {
        public int Width { get; }
        public int Height { get; }
        /// <summary>
        /// Grid on an (x, y) coordinate plane. Top left is the origin.
        /// x increases when heading east. y increases when heading south.
        /// </summary>
        public Cell[,] Cells { get; }

        private Dictionary<Direction, int> DirectionX = new Dictionary<Direction, int>
        {
            { Direction.N, 0 },
            { Direction.S, 0 },
            { Direction.E, 1 },
            { Direction.W, -1 }
        };

        private Dictionary<Direction, int> DirectionY = new Dictionary<Direction, int>
        {
            { Direction.N, -1 },
            { Direction.S, 1 },
            { Direction.E, 0 },
            { Direction.W, 0 }
        };

        private Dictionary<Direction, Direction> Opposite = new Dictionary<Direction, Direction>
        {
            { Direction.N, Direction.S },
            { Direction.S, Direction.N },
            { Direction.E, Direction.W },
            { Direction.W, Direction.E }
        };

        public RectangularMaze(int height, int width)
        {
            Width = width;
            Height = height;
            //init cells
            Cells = new Cell[Height, Width];
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Cells[row, col] = new Cell();
                }
            }
        }

        public IMaze Generate(int startX, int startY, Random random)
        {
            CarvePassagesFrom(startX, startY, random);
            
            return this;
        }

        public override string ToString()
        {
            string str = "";
            //Top line
            str += " ";
            for (int col = 0; col < Width; col++)
            {
                str += " _";
            }
            str += "\n";
            for (int row = 0; row < Height; row++)
            {
                str += " |";
                for (int col = 0; col < Width; col++)
                {
                    var s = Cells[row, col].Neighbors[Direction.S] == null ? "_" : " ";
                    str += s;

                    s = Cells[row, col].Neighbors[Direction.E] == null ? "|" : " ";
                    str += s;
                }
                str += "\n";
            }
            return str;
        }

        private void CarvePassagesFrom(int curX, int curY, Random random)
        {
            var direcitonList = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList<Direction>();
            var shuffleDirections = direcitonList.OrderBy(a => random.Next()).ToList();
            foreach (var dir in shuffleDirections)
            {
                var nextX = curX + DirectionX[dir];
                var nextY = curY + DirectionY[dir];

                //debug
                //Console.WriteLine("(" + curX + ", " + curY + ") to (" + nextX + ", " + nextY + ")");

                if (IsOutOfBounds(nextX, nextY))
                {
                    continue;
                }

                if (HasNeighbor(nextX, nextY))
                {
                    continue;
                }

                Cells[curY, curX].Neighbors[dir] = Cells[nextY, nextX];
                Cells[nextY, nextX].Neighbors[Opposite[dir]] = Cells[curY, curX];
                //debug //Console.WriteLine(this.ToString());
                CarvePassagesFrom(nextX, nextY, random);
            }
        }

        private bool IsOutOfBounds(int x, int y)
        {
            if (x < 0 || x >= Width)
                return true;

            if (y < 0 || y >= Height)
                return true;

            return false;
        }

        private bool HasNeighbor(int x, int y)
        {
            foreach (KeyValuePair<Direction, Cell> item in Cells[y, x].Neighbors)
            {
                if (item.Value != null) //has been visited
                {
                    return true;
                }
            }
            return false;
        }
    }
}
