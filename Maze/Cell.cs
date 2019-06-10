using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    public sealed class Cell
    {
        public dynamic Content { get; set; }
        public Cell CellN { get; set; }
        public Cell CellS { get; set; }
        public Cell CellW { get; set; }
        public Cell CellE { get; set; }

        public Cell(Cell cellN, Cell cellS, Cell cellW, Cell cellE)
        {
            CellN = cellN;
            CellS = cellS;
            CellW = cellW;
            CellE = cellE;
        }

        public Cell()
        {
            CellN = null;
            CellS = null;
            CellW = null;
            CellE = null;
        }

        public void SetNeighbors(Cell cellN, Cell cellS, Cell cellW, Cell cellE)
        {
            CellN = cellN;
            CellS = cellS;
            CellW = cellW;
            CellE = cellE;
        }
    }
}
