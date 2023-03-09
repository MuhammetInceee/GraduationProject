using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace KeyBinds
{
    [CreateAssetMenu(fileName = "KeyBinds", menuName = "KeyBinds/KeyBinds")]
    public class KeyBindsSO : ScriptableObject
    {
        [SerializeField] private KeyCode[] jumpKeys;
        public KeyCode[] JumpKeys => jumpKeys;

        [SerializeField] private KeyCode[] crouchKeys;
        public KeyCode[] CrouchKeys => crouchKeys;

        [SerializeField] private KeyCode[] interactKey;
        public KeyCode[] InteractKeys => interactKey;

        [SerializeField] private KeyCode[] zoomKeys;
        public KeyCode[] ZoomKeys => zoomKeys;
    }
}
    
