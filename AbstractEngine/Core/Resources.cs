using System;
using System.Collections.Generic;
using AbstractEngine.Core.Base;

namespace AbstractEngine.Core
{
    public class Resources
    {
        private readonly Dictionary<string, RenderObject> _data;

        public Resources()
        {
            _data = new Dictionary<string, RenderObject>();
        }

        public RenderObject this[string name]
        {
            get
            {
                if (_data.ContainsKey(name))
                    return _data[name];
                throw new ResourceNotFound(name);
            }
        }

        public void RegisterResource(string name, object resource)
        {
            _data.Add(name, new RenderObject(resource));
        }
    }


    public class ResourceNotFound : Exception
    {
        public ResourceNotFound(string res) : base($"Resource '{res}' not loaded. Fatal error")
        {
        }
    }
}