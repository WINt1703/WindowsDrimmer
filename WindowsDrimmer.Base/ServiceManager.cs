using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsDimmer.Base
{
    public static class ServiceManager
    {
        private static Dictionary<Type, object> _services = new Dictionary<Type, object>();
        private static object _lockObject = new object();

        public static void SetService<T>(T service) where T : class
        {
            lock (_lockObject)
            {
                if (service != null)
                    _services[typeof(T)] = service;
            }
        }

        public static T GetService<T>() where T : class
        {
            lock (_lockObject)
            {
                _services.TryGetValue(typeof(T), out object service);
                return service as T;
            }
        }

        public static T GetService<T>(Func<T> initialize) where T : class
        {
            lock (_lockObject)
            {
                if (!_services.ContainsKey(typeof(T)))
                    SetService(initialize());

                return GetService<T>();
            }
        }
    }
}
