/// <summary>
/// Author Lucas Brennan
/// 
/// Date 27/02/22
/// </summary>
namespace Pathfinding.Services
{
    /// <summary>
    /// A class used to create new objects of type T
    /// </summary>
    /// <typeparam name="T">The type defined on intitalisation</typeparam>
    public class Factory<T> : IFactory<T>
    {
        /// <summary>
        /// A method that Creates a new object of type T
        /// </summary>
        /// <typeparam name="C">A Class defined on method call</typeparam>
        /// <returns>An object of type T</returns>
        public T Get<C>() where C : T, new()
        {
            //Returns a new object
            return new C();
        }
    }
}
