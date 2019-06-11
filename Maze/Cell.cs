using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    public sealed class RectangularCell
    {
        public dynamic Content { get; set; }
        public RectangularCell CellN { get; set; }
        public RectangularCell CellS { get; set; }
        public RectangularCell CellW { get; set; }
        public RectangularCell CellE { get; set; }

        public RectangularCell(RectangularCell cellN, RectangularCell cellS, RectangularCell cellW, RectangularCell cellE)
        {
            CellN = cellN;
            CellS = cellS;
            CellW = cellW;
            CellE = cellE;
        }

        public RectangularCell()
        {
            CellN = null;
            CellS = null;
            CellW = null;
            CellE = null;
        }

        public void SetNeighbors(RectangularCell cellN, RectangularCell cellS, RectangularCell cellW, RectangularCell cellE)
        {
            CellN = cellN;
            CellS = cellS;
            CellW = cellW;
            CellE = cellE;
        }
    }
}
