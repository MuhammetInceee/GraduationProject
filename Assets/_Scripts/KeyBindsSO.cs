using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyBinds
{
    [CreateAssetMenu(fileName = "KeyBinds", menuName = "KeyBinds/KeyBinds")]
    public class KeyBindsSO : ScriptableObject
    {
        public KeyCode[] jumpKeys;
    }
}
    
