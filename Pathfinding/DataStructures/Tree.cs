/// <summary>
/// Author Lucas Brennan
/// 
/// Date 21/03/22
/// </summary>
namespace Pathfinding.DataStructures
{
    /// <summary>
    /// A Class that represents a Tree Data Structure
    /// </summary>
    public class Tree
    {
        //DECLARE a BinaryTreeNode variable called _root
        private INode _root;
        /// <summary>
        /// A Property that gets and sets the root of the tree
        /// </summary>
        public INode Root { get => _root; set { _root = value; } }
        /// <summary>
        /// The DEfault constructor for the tree
        /// </summary>
        public Tree()
        {
            //Sets _root to null
            _root = null;
        }
        /// <summary>
        /// A Method that clears the Root
        /// </summary>
        public void Clear()
        {
            //Sets _root to Null
            _root = null;
        }
    }
}
