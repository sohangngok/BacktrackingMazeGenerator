using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    public interface IMaze
    {
        IMaze Generate(int startRow, int startCol, Random random);
    }
}
