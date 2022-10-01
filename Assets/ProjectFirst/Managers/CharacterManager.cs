using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirst
{
    public class CharacterManager : Singleton<CharacterManager>
    {
        public List<CharacterControl> Character = new List<CharacterControl>();

        public CharacterControl GetCharacter(PlayableCharacterType playableCharacterType)
        {
            foreach(CharacterControl control in Character)
            {
                if(control.playableCharacterType == playableCharacterType)
                {
                    return control;
                }
            }

            return null;
        }
    }
}
