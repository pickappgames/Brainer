using System;
using System.Collections.Generic;

namespace Assets {
    
    public class InstanceCache
    {
        static Dictionary<Type, object> instances = new Dictionary<Type, object>();

        static T Get<T>()
        {
            Type type = typeof(T);
            object singletonObj;

            if (instances.TryGetValue(type, out singletonObj))
                return (T)singletonObj;

            return default(T);
        }

        public static T GetOrInstanciate<T>(Func<object> instanciator)
        {
            object singletonObj = Get<T>();
            object nullValue = default(T);

            if (singletonObj != nullValue)
                return (T)singletonObj;
            
            return Instanciate<T>(instanciator);
        }

        public static T Instanciate<T>(Func<object> instanciator)
        {
            object singletonObj = instanciator();
            instances[typeof(T)] = singletonObj;
            return (T)singletonObj;
        }

        public static void Flush()
        {
            instances.Clear();
        }
    }

}