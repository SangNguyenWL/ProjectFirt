using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirt
{
    [CreateAssetMenu(fileName = "New State", menuName = "ProjectFirt/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        public AnimationCurve SpeedGraph;
        public float Speed;
        public float BlockDistance;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator,AnimatorStateInfo stateInfo)
        {
            PlayerControler p = characterState.GetPlayerControler(animator);

            if(p.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }

            if (p.MoveRight && p.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (!p.MoveRight && !p.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (p.MoveRight)
            {
                p.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                if (!CheckFront(p))
                {
                    p.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                }
            }

            if (p.MoveLeft)
            {
                p.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                if (!CheckFront(p))
                {
                    p.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                }
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        bool CheckFront(PlayerControler control)
        {
            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.forward * 0.3f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, BlockDistance))
                {
                    return true;
                }
            }

            return false;
        }
    }
}