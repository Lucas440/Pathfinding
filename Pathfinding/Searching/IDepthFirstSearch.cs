using Pathfinding.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 27/02/22
/// </summary>
namespace Pathfinding.Searching
{
    /// <summary>
    /// An interface that represents DepthFirstSearch
    /// </summary>
    public interface IDepthFirstSearch
    {
        /// <summary>
        /// A Property that gets a List of Nodes called path
        /// </summary>
        IList<INode> Path { get; }
        /// <summary>
        /// Intalises the DepthFirstSearch Class
        /// </summary>
        /// <param name="pData">The data of the class</param>
        /// <param name="pBinaryTree">The Tree that will be searched</param>
        void Intialise(string pData, IBinaryTree pBinaryTree);
        /// <summary>
        /// A Method used to search a binary tree
        /// </summary>
        void Search();
    }
}
