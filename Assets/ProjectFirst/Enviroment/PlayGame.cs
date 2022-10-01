using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirst
{
    public class PlayGame : MonoBehaviour
    {
        public CharacterSelect characterSelect;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (characterSelect.playableCharacterType != PlayableCharacterType.NONE)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(RBScenes.Level_1.ToString());
                }
                else
                {
                    Debug.Log("must select character first");
                }
            }
        }
    }
}
