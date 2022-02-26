/// <summary>
/// AUTHOR Lucas Brennan
/// 
/// DATE: 22/02/22
/// </summary>
namespace Pathfinding
{
    /// <summary>
    /// A Class used to represent a Binary Tree
    /// </summary>
    public class BinaryTree
    {
        //DECLARE a BinaryTreeNode variable called _root
        private BinaryTreeNode _root;
        /// <summary>
        /// A Property that gets and sets the root of the tree
        /// </summary>
        public BinaryTreeNode Root { get => _root; set { _root = value; } }
        /// <summary>
        /// The DEfault constructor for the tree
        /// </summary>
        public BinaryTree()
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
