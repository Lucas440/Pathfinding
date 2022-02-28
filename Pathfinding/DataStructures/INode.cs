using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 27/02/22
/// </summary>
namespace Pathfinding.DataStructures
{
    /// <summary>
    /// An interface used to represent nodes
    /// </summary>
    public interface INode
    {
        Vector2 Location { get; set; }
        /// <summary>
        /// A Property used to return and set a boolean called GoalNode
        /// </summary>
        bool GoalNode { get; set; }
        /// <summary>
        /// A Property used to retrun and get a Texture2D called Texture
        /// </summary>
        Texture2D Texture { get; set; }
        /// <summary>
        /// A Property used to return and get a bool called Visited
        /// </summary>
        bool Visited { get; set; }
        /// <summary>
        /// A Property used to return and get a string called Data
        /// </summary>
        string Data { get; set; }
        /// <summary>
        /// A Property used to return a List Of Nodes Called Neighbours
        /// </summary>
        IList<INode> Neighbours { get; }
    }
}
