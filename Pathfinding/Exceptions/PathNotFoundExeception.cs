using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 21/03/22
/// </summary>
namespace Pathfinding.Exceptions
{
    /// <summary>
    /// A Exception for when a path cannot be found
    /// </summary>
    public class PathNotFoundExeception : Exception
    {
        /// <summary>
        /// The Default Constructor
        /// </summary>
        public PathNotFoundExeception() { }
        /// <summary>
        /// The Recommended constructor
        /// </summary>
        /// <param name="Message">The message shown to the user</param>
        public PathNotFoundExeception(string Message) : base(Message) { }
        /// <summary>
        /// A Constructor if other exceptions are queued
        /// </summary>
        /// <param name="Message">The message shown to the user</param>
        /// <param name="inner">Other Execeptions queued</param>
        public PathNotFoundExeception(string Message, Exception inner) : base(Message, inner) { }
    }
}
