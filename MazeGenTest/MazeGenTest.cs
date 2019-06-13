using Maze;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeGenTest
{
    [TestClass]
    public class MazeGenTest
    {
        [TestMethod]
        public void InitMazeTest()
        {
            IMaze maze = new RectangularMaze(4, 5);
            System.Console.WriteLine(maze.ToString());
            Assert.AreEqual("  _ _ _ _ _\n" +
                " |_|_|_|_|_|\n" +
                " |_|_|_|_|_|\n" +
                " |_|_|_|_|_|\n" +
                " |_|_|_|_|_|\n", 
                maze.ToString());
        }

        [TestMethod]
        public void GenMazeTest()
        {
            IMaze maze = new RectangularMaze(4, 5);
            maze.Generate(0, 0, new System.Random());
            System.Console.WriteLine(maze.ToString());

            IMaze maze2 = new RectangularMaze(8, 10);
            maze2.Generate(9, 7, new System.Random());
            System.Console.WriteLine(maze2.ToString());

            IMaze maze3 = new RectangularMaze(10, 15);
            maze3.Generate(0, 0, new System.Random());
            System.Console.WriteLine(maze3.ToString());
        }

        [TestMethod]
        public void NeighborKnowsItHasANeighborTooTest()
        {
            IMaze maze = new RectangularMaze(10, 15);
            System.Console.WriteLine(maze.ToString());
            bool pass = true;
            string str = "";
            //Top line
            str += " ";
            for (int col = 0; col < maze.Width; col++)
            {
                str += " _";
            }
            str += "\n";
            for (int row = 0; row < maze.Height; row++)
            {
                str += " |";
                for (int col = 0; col < maze.Width; col++)
                {
                    var s = maze.Cells[row, col].Neighbors[Direction.S] == null ? "_" : " ";
                    if (maze.Cells[row, col].Neighbors[Direction.S] != null)
                    {
                        if (maze.Cells[row, col].Neighbors[Direction.S].Neighbors[Direction.N] != maze.Cells[row, col])
                        {
                            s = "e";
                            pass = false;
                        }
                    }
                    str += s;


                    s = maze.Cells[row, col].Neighbors[Direction.E] == null ? "|" : " ";

                    if (maze.Cells[row, col].Neighbors[Direction.E] != null)
                    {
                        if (maze.Cells[row, col].Neighbors[Direction.E].Neighbors[Direction.W] != maze.Cells[row, col])
                        {
                            s = "e";
                            pass = false;
                        }
                    }
                    str += s;

                }
                str += "\n";
            }
            System.Console.WriteLine(str);
            Assert.IsTrue(pass);
        }
    }
}
