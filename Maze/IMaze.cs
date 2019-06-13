using System;

namespace Maze
{
    public interface IMaze
    {
        int Width { get; }
        int Height { get; }
        Cell[,] Cells { get; }
        IMaze Generate(int startRow, int startCol, Random random);
    }
}
