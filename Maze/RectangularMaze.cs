using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    public class RectangularMaze : IMaze
    {
        public readonly int Width;
        public readonly int Height;
        public Cell cells { get; }

        public RectangularMaze(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public IMaze GenerateMaze(Random random)
        {
            throw new NotImplementedException();
        }
    }
}
