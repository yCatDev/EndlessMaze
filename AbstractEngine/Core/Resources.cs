using System.Collections.Generic;
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
            get => _data[name];
        }
    }
}