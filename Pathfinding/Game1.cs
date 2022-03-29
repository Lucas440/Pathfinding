using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pathfinding.DataStructures;
using Pathfinding.Entities;
using Pathfinding.Exceptions;
using Pathfinding.FileHandling;
using Pathfinding.Searching;
using Pathfinding.Services;
using System;
using System.Diagnostics;
/// <summary>
/// AUTHOR Lucas Brennan
/// 
/// DATE: 22/02/22
/// </summary>
namespace Pathfinding
{
    /// <summary>
    /// A Class used to update the objects in the program
    /// </summary>
    public class Game1 : Game
    {
        //DECLARES a GraphicsDeviceManager called _graphics
        private GraphicsDeviceManager _graphics;
        //DECLARE A new SpriteBatch variable called _spriteBatch
        private SpriteBatch _spriteBatch;
        //DECLARE a new Player variable called _player
        private IPlayer _player;
        //DECLARE a Node Array called _nodeArray
        private INode[,] _nodeArray;
        //DECLARE a int called _timer
        private int _timer;
        //DECLARE a DepthFirstSearch called _depthFirst
        private IDepthFirstSearch _depthFirst;
        // DECLARE a int called _goalNodeX
        private int _goalNodeX;
        // DECLARE a int called _goalNodeY
        private int _goalNodeY;
        // DECLARE a int called _startNodeX
        private int _startNodeX;
        // DECLARE a int called _startNodeY
        private int _startNodeY;
        // DECLARE a int called _arrayLength
        private int _arrayLength;
        // DECLARE a int called _arrayHeight
        private int _arrayHeight;

        //DECLARE a IServiceLocator called _serviceLocator
        IServiceLocator _serviceLocator;
        //DECLARE a FileHandler called _fileHandler
        FileHandler _fileHandler;
        //DECLARE a Tree called _tree
        Tree _tree;

        /// <summary>
        /// The Default constructor for Game1
        /// </summary>
        public Game1(IServiceLocator pLocator)
        {
            //INTALISE VARIABLES
            //_serviceLocator
            _serviceLocator = pLocator;

            //_graphics
            _graphics = new GraphicsDeviceManager(this);
            //Sets Contents Directory
            Content.RootDirectory = "Content";
            //Allows the mouse to be seen
            IsMouseVisible = true;
            //_arrayLength
            _arrayLength = 8;
            //_arrayHeight
            _arrayHeight = 5;

            //_timer
            _timer = 60;
            //_tree
            _tree = (_serviceLocator.Get<Tree>() as IFactory<Tree>).Get<Tree>();

            //_nodeArray
            _nodeArray = new Node[_arrayLength, _arrayHeight];

            //Intialises _fileHandler
            _fileHandler = (_serviceLocator.Get<FileHandler>() as IFactory<FileHandler>).Get<FileHandler>();
            //Calls Initalise on filehanlder
            _fileHandler.Initalise(_serviceLocator);

            //Trys the do the following code
            try
            {
                //Calls ReadFile passing _arrayHeight
                _nodeArray = _fileHandler.ReadFile(_arrayHeight, _arrayLength);

                //INTALISES _player
                _player = (_serviceLocator.Get<IPlayer>() as IFactory<IPlayer>).Get<Player>();
                //_startNodeX
                _startNodeX = _fileHandler.StartX;
                //_startNodeY
                _startNodeY = _fileHandler.StartY;
                //_goalNodeX
                _goalNodeX = _fileHandler.GoalX;
                //_goalNodeY
                _goalNodeY = _fileHandler.GoalY;

            }
            //Catches the Exception
            catch (FilePathNotFoundException e) 
            {
                Debug.WriteLine(e.Message);
            }
            //sets GoalNode to the node stored at GoalX and GoalY stored in _fileHandler
            _nodeArray[_goalNodeX, _goalNodeY].GoalNode = true;
            //sets the Root of the tree to the node stored at StartX and StartY stored in _fileHandler
            _tree.Root = _nodeArray[_startNodeX, _startNodeY];

            //Sets the Player Location to the Root of the tree
            _player.PlayerLocn = _tree.Root.Location;

            //Calls the method Arrange tree
            ArrangeTree();

            try
            {
                //INTALISES a new DepthFirstSearch 
                _depthFirst = (_serviceLocator.Get<IDepthFirstSearch>() as IFactory<IDepthFirstSearch>).Get<DepthFirstSearch>();
                _depthFirst.Intialise("", _tree);

                //Calls the search Method in _depthFirst Search
                _depthFirst.Search();
                //Calls Initalise on _player
                _player.Initalise(_depthFirst.Path);
            }
            //Catches the Exception
            catch (PathNotFoundExeception e) 
            {
                Debug.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// A method used to Arrange the tree depending on where the start and goal nodes are
        /// </summary>
        private void ArrangeTree()
        {
            // Loops over the arrays length
            for (int x = 0; x < _arrayLength; x++)
            {
                //Loops over the arrays Hight
                for (int y = 0; y < _arrayHeight; y++)
                {
                    //If x +1 is LESS than _arrayLength this is true
                    if (x + 1 < _arrayLength)
                    {
                        // If the current node AND the next node are not walls this is true
                        if (!(_nodeArray[x + 1, y] is Wall) && !(_nodeArray[x, y] is Wall))
                        {
                            //Adds the node to the Neighbours
                            _nodeArray[x, y].Neighbours.Add(_nodeArray[x + 1, y]);
                        }
                    }
                    //If y + 1 LESS than _arrayHeight this is true
                    if (y + 1 < _arrayHeight)
                    {
                        // If the current node AND the next node are not walls this is true
                        if (!(_nodeArray[x, y + 1] is Wall) && !(_nodeArray[x, y] is Wall))
                        {
                            //Adds the node to the Neighbours
                            _nodeArray[x, y].Neighbours.Add(_nodeArray[x, y + 1]);
                        }
                    }
                    //If X - 1 is GREATER than -1 this is true
                    if (x - 1 > -1)
                    {
                        // If the current node AND the next node are not walls this is true
                        if (!(_nodeArray[x - 1, y] is Wall) && !(_nodeArray[x, y] is Wall))
                        {
                            //Adds the node to the Neighbours
                            _nodeArray[x, y].Neighbours.Add(_nodeArray[x - 1, y]);
                        }
                    }
                    //If y - 1 is GREATER than -1 this is true
                    if (y - 1 > -1)
                    {
                        // If the current node AND the next node are not walls this is true
                        if (!(_nodeArray[x, y - 1] is Wall) && !(_nodeArray[x, y] is Wall))
                        {
                            //Adds the node to the Neighbours
                            _nodeArray[x, y].Neighbours.Add(_nodeArray[x, y - 1]);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// A method used to Initialize the class
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        /// <summary>
        /// A Method used to LoadContent into the class
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //DECLARE a new Texture2D variable called entityTexture and loads "CircleTest"
            Texture2D entityTexture = this.Content.Load<Texture2D>("New Project");
            //DECLARE a new Texture2D variable called goalTexture and loads "Goal"
            Texture2D goalTexture = this.Content.Load<Texture2D>("Goal");
            //DECLARE a new Texture2D variable called startTexture and loads "Start"
            Texture2D startTexture = this.Content.Load<Texture2D>("Start");
            //DECLARE a new Texture2D variable called wallTexture and loads "Wall"
            Texture2D wallTexture = this.Content.Load<Texture2D>("Wall");

            // TODO: use this.Content to load your game content here
            //Sets the players texture to entityTexture
            _player.Texture = entityTexture;
            //Loads the "Grid" textue into entityTexture
            entityTexture = this.Content.Load<Texture2D>("Grid");
            //loops over each item in _nodeArray
            foreach (INode n in _nodeArray)
            {
                //If n is the GoalNode this is true
                if (n.GoalNode)
                {
                    //Sets n texture to goalTexture
                    n.Texture = goalTexture;
                }
                //If n is the _binaryTrees Root this is true
                else if (n == _tree.Root)
                {
                    //Sets n texture to startTexture
                    n.Texture = startTexture;
                }
                else if (n is Wall)
                {
                    n.Texture = wallTexture;
                }
                else
                {
                    //Sets n texture to entityTexture
                    n.Texture = entityTexture;
                }
            }
        }
        /// <summary>
        /// A Method used to Update the class
        /// </summary>
        /// <param name="gameTime">A variable which stores how much time has passed in the game</param>
        protected override void Update(GameTime gameTime)
        {
            //If back on a GamePad or Escape on a keyboard has been pressed this is true
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                //Exits the program
                Exit();
            //Minues 1 from _timer
            _timer--;
            //If _timer is LESS than or Equal to 0 this is true
            if (_timer <= 0)
            {
                // TODO: Add your update logic here
                //Calls Update on _player
                _player.Update();
                //Sets _timer to 60
                _timer = 60;
            }
            //Calls update on the parent class
            base.Update(gameTime);
        }
        /// <summary>
        /// A Method used to Draw Objects onto the Screen
        /// </summary>
        /// <param name="gameTime">A variable which stores how much time has passed in the game</param>
        protected override void Draw(GameTime gameTime)
        {
            //DECLARE a new Texture2D variable called wallTexture and loads "Wall"
            Texture2D vistedTexture = this.Content.Load<Texture2D>("Visited");

            //Sets the background of the screen to Blue
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            // Allows _spriteBatch to start Drawing
            _spriteBatch.Begin();
            //Draws the player object on the screen
            _spriteBatch.Draw(_player.Texture, new Vector2(_player.PlayerLocn.X + 25, _player.PlayerLocn.Y + 25), Color.AntiqueWhite);

            //Loops over each node
            foreach (INode n in _nodeArray)
            {
                //If the player has visited this node this is true
                if (n.PlayerVisited) 
                {
                    //Changes the texture to visitedTexture
                    n.Texture = vistedTexture;
                }
                //Draws the node
                _spriteBatch.Draw(n.Texture, n.Location, Color.AntiqueWhite);
            }
            //Stops _spriteBatch from drawing
            _spriteBatch.End();
            //Calls Draw in the parent class
            base.Draw(gameTime);
        }
    }
}
