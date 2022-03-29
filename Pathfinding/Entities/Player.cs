using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pathfinding.DataStructures;
using System.Collections.Generic;
using System.Diagnostics;
/// <summary>
/// AUTHOR Lucas Brennan
/// 
/// DATE: 22/02/22
/// </summary>
namespace Pathfinding.Entities
{
    /// <summary>
    /// A Class that is used to show the path in action
    /// </summary>
    public class Player : IPlayer
    {
        //DECLARE a new Stack of Nodes called _pathStack
        private Stack<INode> _pathStack;
        /// <summary>
        /// A Property used to get and set the texture of the object
        /// </summary>
        public Texture2D Texture { get; set; }
        /// <summary>
        /// A Propert used to get the location of the player
        /// </summary>
        public Vector2 PlayerLocn { get => _location; set { _location = value; } }
        // DECLAERE a new Vector2 called _location
        private Vector2 _location;
        /// <summary>
        /// Intalises Player class
        /// </summary>
        /// <param name="pList">A List of nodes which is the path inverted</param>
        public void Initalise(IList<INode> pList)
        {
            //INTALISES _pathStack
            _pathStack = new Stack<INode>();
            //For each item in the List
            foreach (INode n in pList)
            {
                //Pushes it on the Stack
                _pathStack.Push(n);
            }
            //Set the location to the first item on the Stack
            _location = _pathStack.Peek().Location;
        }

        /// <summary>
        /// A method used to update the class
        /// </summary>
        public void Update()
        {
            //If _pathStack is not null this is true
            if (_pathStack != null)
            {
                //if _pathStack has objects in it this is true
                if (_pathStack.Count != 0)
                {
                    //Sets the PlayerVisited Property to true
                    _pathStack.Peek().PlayerVisited = true;

                    //Sets the Location to the item ontop of the Stacks Location
                    _location = _pathStack.Peek().Location;
                    //Writes the Location to the debugger
                    Debug.WriteLine("Player Locn  is: " + _location.X + " " + _location.Y);
                    

                    //If the itemPoped from the stacked is the goal node
                    if (_pathStack.Pop().GoalNode)
                    {
                        //Clears the Stack
                        _pathStack.Clear();
                        //Writes the goal was found to the debugger
                        Debug.WriteLine("Goal Found at " + _location.X + " " + _location.Y);
                    }
                }
            }
        }

    }
}
