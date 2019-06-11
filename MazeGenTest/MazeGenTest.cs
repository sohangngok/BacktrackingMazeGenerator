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
            Assert.AreEqual("(    )(    )(    )(    )\n" +
                "(    )(    )(    )(    )\n" +
                "(    )(    )(    )(    )\n" +
                "(    )(    )(    )(    )\n" +
                "(    )(    )(    )(    )\n", 
                maze.ToString());
        }

        [TestMethod]
        public void GenMazeTest()
        {
            IMaze maze = new RectangularMaze(4, 5);
            maze.Generate(0, 0, new System.Random());
            System.Console.WriteLine(maze.ToString());
        }
    }
}
