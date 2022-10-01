using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirst
{
    [CreateAssetMenu(fileName = "New State", menuName = "ProjectFirst/AbilityData/TeleportOnLedge")]
    public class TeleportOnLedge : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
           
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        private void ToggleBoxCol(CharacterControl control)
        {
            
        }
    }
}
