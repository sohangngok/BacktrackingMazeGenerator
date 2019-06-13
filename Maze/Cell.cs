using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    public sealed class Cell
    {
        public dynamic Content { get; set; }
        public Dictionary<Direction, Cell> Neighbors { get; }

        public Cell()
        {
            Neighbors = new Dictionary<Direction, Cell>
            {
                { Direction.N, null },
                { Direction.S, null },
                { Direction.W, null },
                { Direction.E, null }
            };
        }
    }
}
