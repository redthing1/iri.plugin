using System;
using System.Collections.Generic;
using System.Linq;

namespace Iri.IoC {
    /// <summary>
    /// IoC container
    /// </summary>
    public class CookieJar {
        private readonly Dictionary<Type, List<object>> _instanceRegistry = new Dictionary<Type, List<object>>();
        private readonly List<Tuple<Type, Type>> _factoryRegistry = new List<Tuple<Type, Type>>();
        private readonly Dictionary<Type, List<Type>> _typeRegistry = new Dictionary<Type, List<Type>>();

        public Type RegisterType<TRegistration>(Type type) {
            if (!typeof(TRegistration).IsAssignableFrom(type)) {
                throw new ArgumentOutOfRangeException(nameof(type),
                    "The type must be assignable to the registration type.");
            }
            if (!_typeRegistry.ContainsKey(typeof(TRegistration))) {
                _typeRegistry[typeof(TRegistration)] = new List<Type>();
            }

            _typeRegistry[typeof(TRegistration)].Add(type);
            return type;
        }

        public IEnumerable<Type> ResolveTypes<TRegistration>() {
            if (_typeRegistry.TryGetValue(typeof(TRegistration), out var types)) {
                return types;
            } else {
                return new Type[0];
            }
        }

        /// <summary>
        /// Register an instance into the container
        /// </summary>
        /// <typeparam name="T">The type to associate the instance with</typeparam>
        /// <param name="instance">The instance to register</param>
        /// <returns></returns>
        public T Register<T>(object instance) {
            // Register
            if (!_instanceRegistry.ContainsKey(typeof(T))) {
                _instanceRegistry[typeof(T)] = new List<object>();
            }

            _instanceRegistry[typeof(T)].Add(instance);
            return (T) instance;
        }

        public void RegisterFactory<TRegistration, TType>() {
            if (!typeof(TRegistration).IsAssignableFrom(typeof(TType))) {
                throw new ArgumentOutOfRangeException(nameof(TType),
                    "The target type must be assignable to the registration type.");
            }

            _factoryRegistry.Add(new Tuple<Type, Type>(typeof(TRegistration), typeof(TType)));
        }

        /// <summary>
        /// Retrieve all registered instances that can be assigned to the requested type
        /// </summary>
        /// <typeparam name="T">The requested type</typeparam>
        /// <returns></returns>
        public IEnumerable<T> ResolveAll<T>() {
            if (_instanceRegistry.TryGetValue(typeof(T), out var instances)) {
                return instances.Select(x => (T) x);
            } else {
                return new T[0];
            }
        }

        /// <summary>
        /// Retrieve the first registered instance that can be assigned to the requested type
        /// </summary>
        /// <typeparam name="T">The requested type</typeparam>
        /// <returns></returns>
        public T Resolve<T>() {
            return ResolveAll<T>().FirstOrDefault();
        }

        public T Create<T>() {
            var creationType = _factoryRegistry
                .Where(x => typeof(T).IsAssignableFrom(x.Item2))
                .Select(x => x.Item2)
                .FirstOrDefault();
            return (T) Activator.CreateInstance(creationType);
        }

        /// <summary>
        /// Retrieve the last registered instance that can be assigned to the requested type
        /// </summary>
        /// <typeparam name="T">The requested type</typeparam>
        /// <returns></returns>
        public T ResolveLast<T>() {
            return ResolveAll<T>().LastOrDefault();
        }
    }
}