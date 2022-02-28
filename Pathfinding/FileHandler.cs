using System.IO;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 28/02/22
/// </summary>
namespace Pathfinding
{
    /// <summary>
    /// A Class used to read files
    /// </summary>
    public class FileHandler
    {
        //DECLARES a StreamReader called _reader
        private StreamReader _reader;
        //DECLARES a string called _fileName
        private string _fileName;

        //DECLARES a int called _goalX
        private int _goalX;
        //DECLARES a int called _goalY
        private int _goalY;
        //DECLARES a int called _startX
        private int _startX;
        //DECLARES a int called _startY
        private int _startY;

        /// <summary>
        /// A Property that gets GoalX
        /// </summary>
        public int GoalX { get => _goalX; }
        /// <summary>
        /// A Property that gets GoalY
        /// </summary>
        public int GoalY { get => _goalY; }
        /// <summary>
        /// A Property that gets StartX
        /// </summary>
        public int StartX { get => _startX; }
        /// <summary>
        /// A Property that gets StartY
        /// </summary>
        public int StartY { get => _startY; }
        /// <summary>
        /// Reads the file which stores node locations
        /// </summary>
        /// <param name="pArrayHight">The hight of the array</param>
        public void ReadFile(int pArrayHight) 
        {
            //Sets the file to the path
            _fileName = "..\\..\\..\\NodeSetUp.txt";

            //INTAILISES StreamReader
            using (_reader = new StreamReader(_fileName))
            {
                //DECLARE a string called line
                string line;
                //Loops over for the length of the array
                for (int y = 0; y < pArrayHight; y++)
                {
                    //If the line read is not null this is true
                    if ((line = _reader.ReadLine().ToUpper()) != null)
                    {
                        //If the line contains the letter G this is true
                        if (line.Contains("G"))
                        {
                            //Finds where G is and sets _goalX to it
                            _goalX = line.IndexOf("G");
                            //Sets _goalY to y
                            _goalY = y;
                        }
                        //If the line contains S this is true
                        if (line.Contains("S"))
                        {
                            //Finds where the S is and sets _startX to it
                            _startX = line.IndexOf("S");
                            //Sets _startY to y
                            _startY = y;
                        }

                    }
                }
            }
        }
    }
}
