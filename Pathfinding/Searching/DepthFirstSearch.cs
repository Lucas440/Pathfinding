using Pathfinding.DataStructures;
using System.Collections.Generic;
using System.Diagnostics;
/// <summary>
/// AUTHOR Lucas Brennan
/// 
/// DATE: 22/02/22
/// </summary>
namespace Pathfinding.Searching
{
    /// <summary>
    /// A Class that searchs a tree using depth first search
    /// </summary>
    public class DepthFirstSearch : IDepthFirstSearch
    {
        //DECLARE a string called _data
        private string _data;
        //DECLARE a BinaryTree called _binaryTree
        private IBinaryTree _binaryTree;
        //DECLARE a Queue of nodes called _nodes
        Queue<INode> _nodes;
        //DECLARE a stack of nodes called _pathStack
        Stack<INode> _pathStack;
        //DECLARE a dictionary With nodes as a key and Nodes as data called _cameFrom
        IDictionary<INode, INode> _cameFrom;
        //DECLARE a List of Nodes called _path
        IList<INode> _path;
        /// <summary>
        /// A Property that gets a List of Nodes called path
        /// </summary>
        public IList<INode> Path { get => _path; }
        /// <summary>
        /// Intalises the DepthFirstSearch Class
        /// </summary>
        /// <param name="pData">The data of the class</param>
        /// <param name="pBinaryTree">The Tree that will be searched</param>
        public void Intialise(string pData, IBinaryTree pBinaryTree)
        {
            //INTALISE Variables
            //_data
            _data = pData;
            //_binaryTree
            _binaryTree = pBinaryTree;
            //_nodes
            _nodes = new Queue<INode>();
            //_pathStack
            _pathStack = new Stack<INode>();
            //_cameFrom
            _cameFrom = new Dictionary<INode, INode>();
            //_path
            _path = new List<INode>();
            //enqueues the Root of _binaryTree
            _nodes.Enqueue(_binaryTree.Root);
            //pushes the root of _binaryTree
            _pathStack.Push(_binaryTree.Root);


        }
        /// <summary>
        /// A Method used to search a binary tree
        /// </summary>
        public void Search()
        {
            //While _nodes are not empty this will loop
            while (_nodes.Count != 0)
            {
                //If the item in the queue has been visited this is true
                if (_nodes.Peek().Visited)
                {
                    //Dequeues the queue
                    _nodes.Dequeue();
                }
                else
                {
                    //Writes to the dbugger whats being peeked at
                    Debug.WriteLine("Peeked at : " + _nodes.Peek().Data);
                    //IF the current node Has Neighbours this is true
                    if (_nodes.Peek().Neighbours != null)
                    {
                        //pushes the current node onto the pathStack
                        _pathStack.Push(_nodes.Peek());
                        //sets visited to true
                        _nodes.Peek().Visited = true;
                        //If the Left Node is not null this is true
                        if (((IBinaryTreeNode)_nodes.Peek()).Left != null)
                        {
                            //Enqueues the Left Node
                            _nodes.Enqueue(((IBinaryTreeNode)_nodes.Peek()).Left);
                            //If the node is not in _cameFrom this is true
                            if (!_cameFrom.ContainsKey(((IBinaryTreeNode)_nodes.Peek()).Left))
                            {
                                //Adds the Left Node as a key and the current node as data to _cameFrom
                                _cameFrom.Add(((IBinaryTreeNode)_nodes.Peek()).Left, _nodes.Peek());
                            }
                        }
                        //If the Right Node is not null this is true
                        if (((IBinaryTreeNode)_nodes.Peek()).Right != null)
                        {
                            //Enqueues the Right Node
                            _nodes.Enqueue(((IBinaryTreeNode)_nodes.Peek()).Right);
                            //If the node is not in _cameFrom this is true
                            if (!_cameFrom.ContainsKey(((IBinaryTreeNode)_nodes.Peek()).Right))
                            {
                                //Adds the Right Node as a key and the current node as data to _cameFrom
                                _cameFrom.Add(((IBinaryTreeNode)_nodes.Peek()).Right, _nodes.Peek());
                            }
                        }

                    }
                    //If the Current node is the Goal Node
                    if (_nodes.Peek().GoalNode)
                    {
                        //Stopps the while loop
                        break;
                    }
                }
            }
            //DECLARE a new node Current and set it to the item at the top of _nodes
            INode Current = _nodes.Peek();
            //While Current is not the Root of _binaryTree this loops
            while (true)
            {
                //Adds curret to _path
                _path.Add(Current);
                //Current is set to the data with the key Current
                Current = _cameFrom[Current];
                //If current is the Root this is true
                if (Current == _binaryTree.Root)
                {
                    //Adds curret to _path
                    _path.Add(Current);
                    //breaks out of the loop
                    break;
                }
            }
        }
    }
}
