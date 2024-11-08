using UnityEngine;

namespace Asteroids.Presentation
{
    public abstract class BasePreset<T> : ScriptableObject
    {
        public abstract T Create();
    }
}
