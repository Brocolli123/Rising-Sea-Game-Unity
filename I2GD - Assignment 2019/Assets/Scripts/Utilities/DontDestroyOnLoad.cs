using UnityEngine;

namespace Utilities
{
    public class DontDestroyOnLoad : MonoBehaviour
    {

        void Awake()
        {
            // Keeps the game gameobject persistant between scenes
            DontDestroyOnLoad(this);
        }

    }
}
