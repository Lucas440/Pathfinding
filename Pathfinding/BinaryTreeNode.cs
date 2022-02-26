using System.Collections.Generic;
/// <summary>
/// AUTHOR Lucas Brennan
/// 
/// DATE: 22/02/22
/// </summary>
namespace Pathfinding
{
    /// <summary>
    /// A Node that can be stored inside of a binary tree
    /// </summary>
    public class BinaryTreeNode : Node
    {
        /// <summary>
        /// A Property that gets and sets a binary tree.
        /// it will set the node that is stored on the left of the tree
        /// </summary>
        public BinaryTreeNode Left { get => (BinaryTreeNode)_neighbours[0]; set { _neighbours[0] = (value); } }
        /// <summary>
        /// A Property that gets and sets a binary tree.
        /// it will set the node that is stored on the Right of the tree
        /// </summary>
        public BinaryTreeNode Right { get => (BinaryTreeNode)_neighbours[1]; set { _neighbours[1] = value; } }
        /// <summary>
        /// the Defualt constructor
        /// </summary>
        public BinaryTreeNode() : this(null) { }
        /// <summary>
        /// The recommended constructor for node
        /// </summary>
        /// <param name="pData">The Data that is stored within the node</param>
        public BinaryTreeNode(string pData) : this(pData, null, null) { }
        /// <summary>
        /// A Contructor which definines the nodes neighbous
        /// </summary>
        /// <param name="pData">The Data that is stored within the node</param>
        /// <param name="pLeft">The Neighbour to the left</param>
        /// <param name="pRight">The Neighbour to the Right</param>
        public BinaryTreeNode(string pData, BinaryTreeNode pLeft, BinaryTreeNode pRight) : base(pData, new List<Node> { pLeft, pRight })
        {

        }
    }
}
