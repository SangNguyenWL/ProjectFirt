using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirst
{
    public class MouseControl : MonoBehaviour
    {
        Ray ray;
        RaycastHit hit;
        public PlayableCharacterType selectedCharacterType;
        public CharacterSelect characterSelect;
        CharacterSelectLight characterSelectLight;
        CharacterHoverLight characterHoverLight;

        private void Awake()
        {
            characterSelect.playableCharacterType = PlayableCharacterType.NONE;
            characterSelectLight = GameObject.FindObjectOfType<CharacterSelectLight>();
            characterHoverLight = GameObject.FindObjectOfType<CharacterHoverLight>();
        }

        private void Update()
        {
            ray = CameraManager.Instance.MainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                CharacterControl control = hit.collider.gameObject.GetComponent<CharacterControl>();
                if(control != null)
                {
                    selectedCharacterType = control.playableCharacterType;
                }
                else
                {
                    selectedCharacterType = PlayableCharacterType.NONE;
                }
            }

            if(Input.GetMouseButtonDown(0))
            {
                if(selectedCharacterType != PlayableCharacterType.NONE)
                {
                    characterSelect.playableCharacterType = selectedCharacterType;
                    characterSelectLight.transform.position = characterHoverLight.transform.position;
                    characterSelectLight.light.enabled = true;
                }
                else
                {
                    characterSelect.playableCharacterType = PlayableCharacterType.NONE;
                    characterSelectLight.light.enabled = false;
                }
            }
        }
    }
}