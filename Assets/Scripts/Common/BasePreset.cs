using UnityEngine;

namespace Asteroids.Common
{
    public abstract class BasePreset<T> : ScriptableObject
    {
        public abstract T Create();
    }
}
