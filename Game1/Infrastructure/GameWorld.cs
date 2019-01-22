using System.Collections.Generic;

namespace Game1.Infrastructure
{
    public class GameWorld : IGameWorld
    {
        public IList<IGameObject> GameObjects { get; set; }

        public GameWorld()
        {
            GameObjects = new List<IGameObject>();
        }

        public void AddGameObject(IGameObject obj)
        {
            GameObjects.Add(obj);
        }
    }
}
