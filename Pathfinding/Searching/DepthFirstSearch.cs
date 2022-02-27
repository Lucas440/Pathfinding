using System.Collections.Generic;
using System.Diagnostics;
using Pathfinding.DataStructures;
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
    public class DepthFirstSearch
    {
        //DECLARE a string called _data
        private string _data;
        //DECLARE a BinaryTree called _binaryTree
        private BinaryTree _binaryTree;
        //DECLARE a Queue of nodes called _nodes
        Queue<Node> _nodes;
        //DECLARE a stack of nodes called _pathStack
        Stack<Node> _pathStack;
        //DECLARE a dictionary With nodes as a key and Nodes as data called _cameFrom
        IDictionary<Node, Node> _cameFrom;
        //DECLARE a List of Nodes called _path
        IList<Node> _path;
        /// <summary>
        /// A Property that gets a List of Nodes called path
        /// </summary>
        public IList<Node> Path { get => _path; }
        /// <summary>
        /// Intalises the DepthFirstSearch Class
        /// </summary>
        /// <param name="pData">The data of the class</param>
        /// <param name="pBinaryTree">The Tree that will be searched</param>
        public void Intialise(string pData, BinaryTree pBinaryTree)
        {
            //INTALISE Variables
            //_data
            _data = pData;
            //_binaryTree
            _binaryTree = pBinaryTree;
            //_nodes
            _nodes = new Queue<Node>();
            //_pathStack
            _pathStack = new Stack<Node>();
            //_cameFrom
            _cameFrom = new Dictionary<Node, Node>();
            //_path
            _path = new List<Node>();
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
                        if (((BinaryTreeNode)_nodes.Peek()).Left != null)
                        {
                            //Enqueues the Left Node
                            _nodes.Enqueue(((BinaryTreeNode)_nodes.Peek()).Left);
                            //If the node is not in _cameFrom this is true
                            if (!_cameFrom.ContainsKey(((BinaryTreeNode)_nodes.Peek()).Left))
                            {
                                //Adds the Left Node as a key and the current node as data to _cameFrom
                                _cameFrom.Add(((BinaryTreeNode)_nodes.Peek()).Left, _nodes.Peek());
                            }
                        }
                        //If the Right Node is not null this is true
                        if (((BinaryTreeNode)_nodes.Peek()).Right != null)
                        {
                            //Enqueues the Right Node
                            _nodes.Enqueue(((BinaryTreeNode)_nodes.Peek()).Right);
                            //If the node is not in _cameFrom this is true
                            if (!_cameFrom.ContainsKey(((BinaryTreeNode)_nodes.Peek()).Right))
                            {
                                //Adds the Right Node as a key and the current node as data to _cameFrom
                                _cameFrom.Add(((BinaryTreeNode)_nodes.Peek()).Right, _nodes.Peek());
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
            Node Current = _nodes.Peek();
            //While Current is not the Root of _binaryTree this loops
            while (Current != _binaryTree.Root)
            {
                //Adds curret to _path
                _path.Add(Current);
                //Current is set to the data with the key Current
                Current = _cameFrom[Current];
            }
        }
    }
}
