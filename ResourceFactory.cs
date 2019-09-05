using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace POSReader
{
    internal static class ResourceFactory
    {
        static readonly ConcurrentDictionary<ReaderPropertyAttribute, ScannerDevice> Manager 
            = new ConcurrentDictionary<ReaderPropertyAttribute, ScannerDevice>();
        static bool Loaded = false;
        internal static void LoadAssembly()
        {
            if (Loaded)
                return;
            var assembly = Assembly.GetExecutingAssembly();
            foreach(var type in assembly.GetTypes())
            {
                foreach(var property in type.GetProperties())
                {
                    if(property.GetCustomAttributes<ReaderPropertyAttribute>(false).Count() > 0)
                    {
                        var attribute = property.GetCustomAttribute<ReaderPropertyAttribute>(false);
                        Manager.TryAdd(attribute, new ScannerDevice(property, attribute));
                    }
                }
            }
        }
    }
}
