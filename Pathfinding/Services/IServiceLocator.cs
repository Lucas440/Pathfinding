using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 27/02/22
/// </summary>
namespace Pathfinding.Services
{
    /// <summary>
    /// An interface used to store services
    /// </summary>
    public interface IServiceLocator
    {
        /// <summary>
        /// A Method that returns a service requeted
        /// </summary>
        /// <typeparam name="T">The Product of the service</typeparam>
        /// <returns>the Serivce that creates the Product</returns>
        public IService Get<T>();
    }
}
