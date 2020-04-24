using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AbstractEngine.Core.Base;

namespace AbstractEngine.Core
{
    public class Resources
    {
        private Dictionary<string, RenderObject> _data;
        public Resources() => _data = new Dictionary<string, RenderObject>();
        public void RegisterResource(string name, object resource) => _data.Add(name, new RenderObject(resource));

        public RenderObject this[string name]
        {
            get
            {
                if (_data.ContainsKey(name))
                    return _data[name];
                else
                {
                    throw new ResourceNotFound(name);
                }
            }
        }
    }
    
    
    public class ResourceNotFound : Exception
    {
        

        public ResourceNotFound()
        {
        }

        public ResourceNotFound(string res) : base($"Resource '{res}' not loaded. Fatal error")
        {
            
        }

        public ResourceNotFound(string res, Exception inner) : base($"Resource '{res}' not loaded. Fatal error", inner)
        {
        }
        
    }
}