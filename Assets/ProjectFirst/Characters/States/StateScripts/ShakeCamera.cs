using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirst
{
    [CreateAssetMenu(fileName = "New State", menuName = "ProjectFirst/AbilityData/ShakeCamera")]
    public class ShakeCamera : StateData
    {
        [Range(0f, 0.99f)]
        public float ShakeTiming;
        private bool isShake = false;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if(ShakeTiming == 0f)
            {
                CameraManager.Instance.ShakeCamera(0.2f);
                isShake = true;
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (!isShake)
            {
                if(stateInfo.normalizedTime >= ShakeTiming)
                {
                    isShake = true;
                    CameraManager.Instance.ShakeCamera(0.2f);
                }
            }

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            isShake = false;
        }
    }
}
