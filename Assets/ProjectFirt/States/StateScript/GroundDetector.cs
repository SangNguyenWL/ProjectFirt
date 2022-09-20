using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirt
{
    [CreateAssetMenu(fileName = "New State", menuName = "ProjectFirt/AbilityData/GroundDetector")]
    public class GroundDetector : StateData
    {
        [Range(0.01f,1f)]
        public float CheckTime;
        public float Distance;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerControler control = characterState.GetPlayerControler(animator);

            if(stateInfo.normalizedTime >= CheckTime)
            {
                if (IsGrounded(control))
                {
                    animator.SetBool(TransitionParameter.Grounded.ToString(), true);
                }
                else
                {
                    animator.SetBool(TransitionParameter.Grounded.ToString(), false);
                }
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool IsGrounded(PlayerControler control)
        {
            if(control.Rigidbody.velocity.y > -0.001f && control.Rigidbody.velocity.y <= 0f)
            {
                return true;
            }

            if(control.Rigidbody.velocity.y < 0f)
            {
                foreach (GameObject o in control.BottomSpheres)
                {
                    Debug.DrawRay(o.transform.position, -Vector3.up * 0.7f, Color.yellow);
                    RaycastHit hit;
                    if (Physics.Raycast(o.transform.position, -Vector3.up, out hit, Distance))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
