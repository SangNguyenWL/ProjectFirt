using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirt
{
    [CreateAssetMenu(fileName = "New State", menuName = "ProjectFirt/AbilityData/Jump")]
    public class Jump : StateData
    {
        public float JumpForce;
        public AnimationCurve Gravity;
        public AnimationCurve Pull;
         
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.GetPlayerControler(animator).Rigidbody.AddForce(Vector3.up * JumpForce);
            animator.SetBool(TransitionParameter.Grounded.ToString(), false);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerControler control = characterState.GetPlayerControler(animator);

            control.GravityMutiplier = Gravity.Evaluate(stateInfo.normalizedTime);
            control.PullMultiplier = Pull.Evaluate(stateInfo.normalizedTime);
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
