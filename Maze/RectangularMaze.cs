using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    public class RectangularMaze : IMaze
    {
        public readonly int Width;
        public readonly int Height;
        /// <summary>
        /// Grid on an (x, y) coordinate plane. Top left is the origin.
        /// x is row. y is column.
        /// </summary>
        public Cell[,] Cells { get; }

        public RectangularMaze(int width, int height)
        {
            Width = width;
            Height = height;
            //init cells
            Cells = new Cell[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Cells[i, j] = new Cell();
                }
            }
            Cells[0, 0].SetNeighbors(null, Cells[1, 0], null, Cells[0, 1]);
            Cells[0, width - 1].SetNeighbors(null, Cells[1, width - 1], Cells[0, width - 2], null);
            Cells[height - 1, 0].SetNeighbors(Cells[height - 2, 0], null, null, Cells[height - 1, 1]);
            Cells[height - 1, width - 1].SetNeighbors(Cells[height - 2, width - 1], null, Cells[height - 1, width - 2], null);

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    Cells[row, col].CellN = row - 1 > 0 ? Cells[row - 1, col] : null;
                    //Cells[row, col].CellS = row + 1 <
                }
            }
        }

        public IMaze GenerateMaze(Random random)
        {
            throw new NotImplementedException();
        }
    }
}
