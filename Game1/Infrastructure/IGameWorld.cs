using System.Collections.Generic;

namespace Game1.Infrastructure
{
    public interface IGameWorld
    {
        IList<IGameObject> GameObjects { get; set; }

        void AddGameObject(IGameObject obj);
    }
}
