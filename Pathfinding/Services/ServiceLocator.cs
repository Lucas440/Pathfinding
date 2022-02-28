using System;
using System.Collections.Generic;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 27/02/22
/// </summary>
namespace Pathfinding.Services
{
    /// <summary>
    /// A Class used to create and store serivces 
    /// </summary>
    public class ServiceLocator : IServiceLocator
    {
        //DECLARE a new IDictionary called _serviceCollection
        IDictionary<Type, IService> _serviceCollection;
        //DECLARE a new IFactory called _serviceFactory
        IFactory<IService> _serviceFactory;
        /// <summary>
        /// The Default Constructor for ServiceLocator
        /// </summary>
        public ServiceLocator()
        {
            //INTALISE Class Variables
            //_serviceCollection
            _serviceCollection = new Dictionary<Type, IService>();
            //_serviceFactory
            _serviceFactory = new Factory<IService>();
        }
        /// <summary>
        /// A Mehtod that retruns a requested service of type T
        /// </summary>
        /// <typeparam name="T">The Product of the service</typeparam>
        /// <returns>The Service that creates the Product</returns>
        public IService Get<T>()
        {
            //If _serviceCollection does not contain a key of type T
            if (!_serviceCollection.ContainsKey(typeof(T)))
            {
                //Adds a new Factory that creates T to _serviceCollection
                _serviceCollection.Add(typeof(T), _serviceFactory.Get<Factory<T>>());
            }
            //Returns the Service stored with the key type T
            return _serviceCollection[typeof(T)];
        }
    }
}
