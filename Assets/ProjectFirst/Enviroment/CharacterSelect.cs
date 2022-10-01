using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirst
{
    public enum PlayableCharacterType
    {
        NONE,
        YELLOW,
        RED,
        GREEN,
    }

    [CreateAssetMenu(fileName = "characterSelect",menuName = "ProjectFirst/CharacterSelect/CharacterSelect")]
    public class CharacterSelect : ScriptableObject
    {
        public PlayableCharacterType playableCharacterType;
    }
}
