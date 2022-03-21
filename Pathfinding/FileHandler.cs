using Microsoft.Xna.Framework;
using Pathfinding.DataStructures;
using Pathfinding.Services;
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

        Node[,] _nodeArray;

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

        IServiceLocator _serviceLocator;

        /// <summary>
        /// The Default Constructor
        /// </summary>
        public FileHandler() 
        {
        }

        public void Initalise(IServiceLocator pLocator) 
        {
            _serviceLocator = pLocator;
        }

        /// <summary>
        /// Reads the file which stores node locations
        /// </summary>
        /// <param name="pArrayHight">The hight of the array</param>
        public Node[,] ReadFile(int pArrayHight, int pArrayLength) 
        {

            _nodeArray = new Node[pArrayLength , pArrayHight];

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
                        for (int x = 0; x < pArrayLength; x++) 
                        {
                           char nodeIndex = line[x];

                            if (nodeIndex.ToString().ToUpper() == "S")
                            {
                                _startX = x;
                                _startY = y;
                                _nodeArray[x, y] = (Node)(_serviceLocator.Get<INode>() as IFactory<INode>).Get<Node>();
                                _nodeArray[x, y].Location = new Vector2(x * 100 , y * 100) ;
                            }
                            else if (nodeIndex.ToString().ToUpper() == "G")
                            {
                                _goalX = x;
                                _goalY = y;
                                _nodeArray[x, y] = (Node)(_serviceLocator.Get<INode>() as IFactory<INode>).Get<Node>();
                                _nodeArray[x, y].Location = new Vector2(x * 100, y * 100);
                            }
                            else if (nodeIndex.ToString().ToUpper() == "W")
                            {
                                _nodeArray[x, y] = (Node)(_serviceLocator.Get<Node>() as IFactory<Node>).Get<Wall>();
                                _nodeArray[x, y].Location = new Vector2(x * 100, y * 100);
                            }
                            else 
                            {
                                _nodeArray[x, y] = (Node)(_serviceLocator.Get<INode>() as IFactory<INode>).Get<Node>();
                                _nodeArray[x, y].Location = new Vector2(x * 100, y * 100);
                            }
                        }

                    }
                }

                return _nodeArray;
            }
        }
    }
}
