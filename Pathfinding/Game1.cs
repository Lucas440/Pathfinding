using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pathfinding.DataStructures;
using Pathfinding.Searching;
using Pathfinding.Entities;
using Pathfinding.Services;
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
        //DECLARE a new Texture2D variable called _circleTest
        private Texture2D _circleTest;
        //DECLARE a new Player variable called _player
        private IPlayer _player;
        //DECLARE a new BinaryTree varible called _binaryTree
        private IBinaryTree _binaryTree;
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
        private int  _startNodeY;
        // DECLARE a int called _arrayLength
        private int _arrayLength;
        // DECLARE a int called _arrayHeight
        private int _arrayHeight;

        //DECLARE a IServiceLocator called _serviceLocator
        IServiceLocator _serviceLocator;

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
            //_startNodeX
            _startNodeX = 0;
            //_startNodeY
            _startNodeY = 5;
            //_goalNodeX
            _goalNodeX = 7;
            //_goalNodeY
            _goalNodeY = 0;
            //_arrayLength
            _arrayLength = 8;
            //_arrayHeight
            _arrayHeight = 6;

            //_timer
            _timer = 60;
            //_binaryTree
            _binaryTree = (_serviceLocator.Get<BinaryTree>() as IFactory<BinaryTree>).Get<BinaryTree>();

            //_nodeArray
            _nodeArray = new Node[_arrayLength, _arrayHeight];

            //A variable used to determain nodes appart
            int count = 0;

            // Loops over the arrays length
            for (int i = 0; i < _arrayLength; i++)
            {
                //Loops over the arrays Hight
                for (int j = 0; j < _arrayHeight; j++)
                {
                    //INTALISES a new BinaryTreeNode and stores it in _nodeArray
                    _nodeArray[i, j] = (_serviceLocator.Get<IBinaryTreeNode>() as IFactory<IBinaryTreeNode>).Get<BinaryTreeNode>();
                    //Increments count
                    count++;
                    //INTALISES A new Vector2 called tempLocn
                    Vector2 tempLocn = new Vector2();

                    //Sets the X and Y of TempLocn to 100 times i and j
                    tempLocn.X = i * 100;
                    tempLocn.Y = j * 100;

                    //Sets the location of the current node to tempLocn
                    _nodeArray[i, j].Location = tempLocn;

                }
            }
            //sets the node at _goalNodeX and _goalNodeY in the array to the goal node
            _nodeArray[_goalNodeX, _goalNodeY].GoalNode = true;
            //sets the Root of the tree to the node stored at _startNodeX , _startNodeY

            _binaryTree.Root = (BinaryTreeNode)_nodeArray[_startNodeX, _startNodeY];

            //Calls the method Arrange tree
            ArrangeTree();

            //INTALISES a new DepthFirstSearch 
            _depthFirst = (_serviceLocator.Get<IDepthFirstSearch>() as IFactory<IDepthFirstSearch>).Get<DepthFirstSearch>();
            _depthFirst.Intialise("", _binaryTree);

            //Calls the search Method in _depthFirst Search
            _depthFirst.Search();

            //INTALISES a new player
            _player = (_serviceLocator.Get<IPlayer>() as IFactory<IPlayer>).Get<Player>();
            _player.Initalise(_depthFirst.Path);
        }
        /// <summary>
        /// A method used to Arrange the tree depending on where the start and goal nodes are
        /// </summary>
        private void ArrangeTree()
        {
            //If the _goalNodeX is Greater Than or Equal to _startNodeX 
            //AND _goalNodeY is Greater than or Equal to _startNodeY
            if (_goalNodeX >= _startNodeX && _goalNodeY >= _startNodeY)
            {
                /* Down Right */
                // Loops over the arrays length
                for (int x = 0; x < _arrayLength; x++)
                {
                    //Loops over the arrays Hight
                    for (int y = 0; y < _arrayHeight; y++)
                    {
                        //If x +1 is LESS than _arrayLength this is true
                        if (x + 1 < _arrayLength)
                        {
                            ((BinaryTreeNode)_nodeArray[x, y]).Right = (BinaryTreeNode)_nodeArray[x + 1, y];
                        }
                        //If y + 1 LESS than _arrayHeight this is true
                        if (y + 1 < _arrayHeight)
                        {
                            ((BinaryTreeNode)_nodeArray[x, y]).Left = (BinaryTreeNode)_nodeArray[x, y + 1];
                        }
                    }

                }
            }
            //If the _goalNodeX is LESS Than or Equal to _startNodeX 
            //AND _goalNodeY is LESS than or Equal to _startNodeY
            else if (_goalNodeX <= _startNodeX && _goalNodeY <= _startNodeY) 
            {
                /* Up Left */
                // Loops over the arrays length
                for (int x = 0; x < _arrayLength; x++)
                {
                    //Loops over the arrays Hight
                    for (int y = 0; y < _arrayHeight; y++)
                    {
                        //If X - 1 is GREATER than -1 this is true
                        if (x - 1 > -1)
                        {
                            ((BinaryTreeNode)_nodeArray[x, y]).Right = (BinaryTreeNode)_nodeArray[x - 1, y];
                        }
                        //If y - 1 is GREATER than -1 this is true
                        if (y - 1 > -1)
                        {
                            ((BinaryTreeNode)_nodeArray[x, y]).Left = (BinaryTreeNode)_nodeArray[x, y - 1];
                        }
                    }
                }
            }
            //If the _goalNodeX is LESS Than or Equal to _startNodeX 
            //AND _goalNodeY is GREATER than or Equal to _startNodeY
            else if (_goalNodeX <= _startNodeX && _goalNodeY >= _startNodeY)
            {
                /* Down Left */
                // Loops over the arrays length
                for (int x = 0; x < _arrayLength; x++)
                {
                    //Loops over the arrays Hight
                    for (int y = 0; y < _arrayHeight; y++)
                    {
                        //If X - 1 is GREATER than -1 this is true
                        if (x - 1 > -1)
                        {
                            ((BinaryTreeNode)_nodeArray[x, y]).Right = (BinaryTreeNode)_nodeArray[x - 1, y];
                        }
                        //If y + 1 LESS than _arrayHeight this is true
                        if (y + 1 < _arrayHeight)
                        {
                            ((BinaryTreeNode)_nodeArray[x, y]).Left = (BinaryTreeNode)_nodeArray[x, y + 1];
                        }
                    }
                }
            }
            //If the _goalNodeX is GREATER Than or Equal to _startNodeX 
            //AND _goalNodeY is LESS than or Equal to _startNodeY
            if (_goalNodeX >= _startNodeX && _goalNodeY <= _startNodeY) 
            {
                /* Up Right */
                // Loops over the arrays length
                for (int x = 0; x < _arrayLength; x++)
                {
                    //Loops over the arrays Hight
                    for (int y = 0; y < _arrayHeight; y++)
                    {
                        //If x +1 is LESS than _arrayLength this is true
                        if (x + 1 < _arrayLength)
                        {
                            ((BinaryTreeNode)_nodeArray[x, y]).Right = (BinaryTreeNode)_nodeArray[x + 1, y];
                        }
                        //If y - 1 is GREATER than -1 this is true
                        if (y - 1 > -1)
                        {
                            ((BinaryTreeNode)_nodeArray[x, y]).Left = (BinaryTreeNode)_nodeArray[x, y - 1];
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

            // TODO: use this.Content to load your game content here
            _circleTest = this.Content.Load<Texture2D>("CircleTest");

            _player.Texture = _circleTest;
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
            //Sets the background of the screen to Blue
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            // Allows _spriteBatch to start Drawing
            _spriteBatch.Begin();
            //Draws the player object on the screen
            _spriteBatch.Draw(_player.Texture, _player.PlayerLocn, Color.AntiqueWhite);

            //Stops _spriteBatch from drawing
            _spriteBatch.End();
            //Calls Draw in the parent class
            base.Draw(gameTime);
        }
    }
}
