using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze
{
    public class RectangularMaze : IMaze
    {
        public readonly int Width;
        public readonly int Height;
        /// <summary>
        /// Grid on an (x, y) coordinate plane. Top left is the origin.
        /// x increases when heading east. y increases when heading south.
        /// </summary>
        public RectangularCell[,] Cells { get; }

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
            Cells = new RectangularCell[Height, Width];
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Cells[row, col] = new RectangularCell();
                }
            }
            //Cells[0, 0].SetNeighbors(null, Cells[1, 0], null, Cells[0, 1]);
            //Cells[0, width - 1].SetNeighbors(null, Cells[1, width - 1], Cells[0, width - 2], null);
            //Cells[height - 1, 0].SetNeighbors(Cells[height - 2, 0], null, null, Cells[height - 1, 1]);
            //Cells[height - 1, width - 1].SetNeighbors(Cells[height - 2, width - 1], null, Cells[height - 1, width - 2], null);

            //for (int row = 0; row < height; row++)
            //{
            //    for (int col = 0; col < width; col++)
            //    {
            //        cells[row, col].celln = row - 1 >= 0 ? cells[row - 1, col] : null;
            //        cells[row, col].cells = row + 1 < height ? cells[row + 1, col] : null;
            //        cells[row, col].cellw = col - 1 >= 0 ? cells[row, col - 1] : null;
            //        cells[row, col].celle = col + 1 < row ? cells[row, col + 1] : null;
            //    }
            //}
        }

        public IMaze Generate(int startX, int startY, Random random)
        {
            carvePassagesFrom(startX, startY, random);
            
            return null;
        }

        public override string ToString()
        {
            string str = "";
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    str += "(";
                    str += Cells[y, x].CellN != null ? "N" : " ";
                    str += Cells[y, x].CellS != null ? "S" : " ";
                    str += Cells[y, x].CellW != null ? "W" : " ";
                    str += Cells[y, x].CellE != null ? "E" : " ";
                    str += ")";
                }
                str += "\n";
            }
            return str;
        }

        private void carvePassagesFrom(int curX, int curY, Random random)
        {
            var direcitonList = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList<Direction>();
            var shuffleDirections = direcitonList.OrderBy(a => random.Next()).ToList();
            foreach (var dir in shuffleDirections)
            {
                var nextX = curX + DirectionX[dir];
                var nextY = curY + DirectionY[dir];

                if (IsOutOfBounds(nextX, nextY))
                {
                    continue;
                }

                //if ()
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
    }
}
