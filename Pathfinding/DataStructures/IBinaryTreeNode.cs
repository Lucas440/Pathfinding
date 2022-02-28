using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 27/02/22
/// </summary>
namespace Pathfinding.DataStructures
{
    /// <summary>
    /// An interface used to represent BinaryTreeNodes
    /// </summary>
    public interface IBinaryTreeNode: INode
    {
        /// <summary>
        /// A Property that gets and sets a binary tree.
        /// it will set the node that is stored on the left of the tree
        /// </summary>
        IBinaryTreeNode Left { get; set; }
        /// <summary>
        /// A Property that gets and sets a binary tree.
        /// it will set the node that is stored on the Right of the tree
        /// </summary>
        IBinaryTreeNode Right { get; set; }
    }
}
