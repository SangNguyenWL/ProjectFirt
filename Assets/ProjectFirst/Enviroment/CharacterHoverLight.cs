using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirst
{
    public class CharacterHoverLight : MonoBehaviour
    {
        public Vector3 Offset = new Vector3();

        CharacterControl HoverSeclectedCharacter;
        MouseControl mouseHoverSeclect;
        Vector3 TargetPos = new Vector3();
        Light light;

        private void Start()
        {
            mouseHoverSeclect = GameObject.FindObjectOfType<MouseControl>();
            light = GetComponent<Light>();
        }

        private void Update()
        {
            if(mouseHoverSeclect.selectedCharacterType == PlayableCharacterType.NONE)
            {
                HoverSeclectedCharacter = null;
                light.enabled = false;
            }
            else
            {
                light.enabled = true;
                LightUpSelectedCharacter();
            }
        }

        private void LightUpSelectedCharacter()
        {
            if(HoverSeclectedCharacter == null)
            {
                HoverSeclectedCharacter = CharacterManager.Instance.GetCharacter(mouseHoverSeclect.selectedCharacterType);
                this.transform.position = HoverSeclectedCharacter.transform.position + HoverSeclectedCharacter.transform.TransformDirection(Offset);
            }
        }
    }
}
