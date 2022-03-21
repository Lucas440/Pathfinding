using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pathfinding.DataStructures;
using System.Collections.Generic;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 27/02/22
/// </summary>
namespace Pathfinding.Entities
{
    /// <summary>
    /// An interface that represents a player
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// A Property used to get and set the texture of the object
        /// </summary>
        Texture2D Texture { get; set; }
        /// <summary>
        /// A Propert used to get the location of the player
        /// </summary>
        Vector2 PlayerLocn { get; set; }
        /// <summary>
        /// Intalises Player class
        /// </summary>
        /// <param name="pList">A List of nodes which is the path inverted</param>
        void Initalise(IList<INode> pList);
        /// <summary>
        /// A method used to update the class
        /// </summary>
        void Update();
    }
}
