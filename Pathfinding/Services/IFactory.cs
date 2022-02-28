/// <summary>
/// Author Lucas Brennan
/// 
/// Date 27/02/22
/// </summary>
namespace Pathfinding.Services
{
    /// <summary>
    /// An interface used to create objectes of Type T
    /// </summary>
    /// <typeparam name="T">The type defined on Intailsation</typeparam>
    public interface IFactory<T> : IService
    {
        /// <summary>
        /// A Mehtod that returns a new object of type T
        /// </summary>
        /// <typeparam name="C">A Class defined when the method is called</typeparam>
        /// <returns>an object of type T</returns>
        T Get<C>() where C : T, new();
    }
}
