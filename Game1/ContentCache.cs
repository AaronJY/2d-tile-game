using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Game1
{
    public class ContentCache
    {
        private ContentManager _contentManager;
        private IDictionary<string, GraphicsResource> _resources;

        public ContentCache(ContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public void Load(string path = "")
        {
            _resources = new Dictionary<string, GraphicsResource>();

            var filePath = Path.Combine(_contentManager.RootDirectory, path);
            var files = Directory.GetFiles(filePath, "*.*", SearchOption.AllDirectories);


        }

        public T GetContent<T>(string resourceName) where T : GraphicsResource
        {
            if (!_resources.ContainsKey(resourceName))
                return null;

            return (T)_resources[resourceName];
        }
    }
}
