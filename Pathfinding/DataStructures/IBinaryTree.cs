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
    /// An Interface used to represent a Binary Tree
    /// </summary>
    public interface IBinaryTree
    {
        /// <summary>
        /// A Property that gets and sets the root of the tree
        /// </summary>
        IBinaryTreeNode Root { get; set; }
        /// <summary>
        /// A Method that clears the Root
        /// </summary>
        void Clear();
    }
}
