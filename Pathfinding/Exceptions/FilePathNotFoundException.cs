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
    /// An Exception used when a File cannot be found
    /// </summary>
    public class FilePathNotFoundException : Exception
    {
        /// <summary>
        /// The Default Constructor
        /// </summary>
        public FilePathNotFoundException() { }
        /// <summary>
        /// The Recommended constructor
        /// </summary>
        /// <param name="Message">The message shown to the user</param>
        public FilePathNotFoundException(string Message) : base(Message) { }
        /// <summary>
        /// A Constructor if other exceptions are queued
        /// </summary>
        /// <param name="Message">The message shown to the user</param>
        /// <param name="inner">Other Execeptions queued</param>
        public FilePathNotFoundException(string Message , Exception inner) : base(Message , inner) { }
    }
}
