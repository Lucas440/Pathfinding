using Microsoft.Xna.Framework;
using Pathfinding.DataStructures;
using Pathfinding.Exceptions;
using Pathfinding.Services;
using System;
using System.IO;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 28/02/22
/// </summary>
namespace Pathfinding.FileHandling
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

            _nodeArray = new Node[pArrayLength, pArrayHight];

            //Sets the file to the path
            _fileName = "..\\..\\..\\FileHandling\\NodeSetUp.txt";
            //trys the following
            try
            {
                //INTAILISES StreamReader
                using (_reader = new StreamReader(_fileName))
                {
                    //DECLARE a string called line
                    string line;
                    //Loops over for the Hight of the array
                    for (int y = 0; y < pArrayHight; y++)
                    {
                        //If the line read is not null this is true
                        if ((line = _reader.ReadLine().ToUpper()) != null)
                        {
                            //Loops over the length of the array
                            for (int x = 0; x < pArrayLength; x++)
                            {
                                //DECLARE a char and set it to the data in position X in the line
                                char nodeIndex = line[x];
                                //if nodeIndex is S this is true
                                if (nodeIndex.ToString().ToUpper() == "S")
                                {
                                    //Sets start X and Y to x and y in the loop
                                    _startX = x;
                                    _startY = y;
                                    //Creates a new Node and stores it at x and y 
                                    _nodeArray[x, y] = (Node)(_serviceLocator.Get<INode>() as IFactory<INode>).Get<Node>();
                                    //Sets the location to 100 times x and y in the loop
                                    _nodeArray[x, y].Location = new Vector2(x * 100, y * 100);
                                }
                                //if nodeIndex is G this is true
                                else if (nodeIndex.ToString().ToUpper() == "G")
                                {
                                    //Sets goal X and Y to x and y in the loop
                                    _goalX = x;
                                    _goalY = y;
                                    //Creates a new Node and stores it at x and y 
                                    _nodeArray[x, y] = (Node)(_serviceLocator.Get<INode>() as IFactory<INode>).Get<Node>();
                                    //Sets the location to 100 times x and y in the loop
                                    _nodeArray[x, y].Location = new Vector2(x * 100, y * 100);
                                }
                                //if nodeIndex is W this is true
                                else if (nodeIndex.ToString().ToUpper() == "W")
                                {
                                    //Creates a new Wall and stores it at x and y 
                                    _nodeArray[x, y] = (Node)(_serviceLocator.Get<Node>() as IFactory<Node>).Get<Wall>();
                                    //Sets the location to 100 times x and y in the loop
                                    _nodeArray[x, y].Location = new Vector2(x * 100, y * 100);
                                }
                                else
                                {
                                    //Creates a new Node and stores it at x and y 
                                    _nodeArray[x, y] = (Node)(_serviceLocator.Get<INode>() as IFactory<INode>).Get<Node>();
                                    //Sets the location to 100 times x and y in the loop
                                    _nodeArray[x, y].Location = new Vector2(x * 100, y * 100);
                                }
                            }

                        }
                    }
                }
            }
            //Catches the Exception
            catch (Exception)
            {
                //Throws a new Exeception
                throw new FilePathNotFoundException("he Path To The File Could Not Be Found");
            }
                //Returns _nodeArray
                return _nodeArray;
            }
        }
    }
