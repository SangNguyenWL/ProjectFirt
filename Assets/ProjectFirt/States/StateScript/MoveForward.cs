using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirt
{
    [CreateAssetMenu(fileName = "New State", menuName = "ProjectFirt/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        public bool Constant;
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

            if(Constant)
            {
                ConstantMove(p, animator, stateInfo);
            }
            else
            {
                ControllerMove(p,animator,stateInfo);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        private void ConstantMove(PlayerControler p, Animator animator, AnimatorStateInfo stateInfo)
        {
            if(!CheckFront(p))
            {
                p.MoveForward(Speed, SpeedGraph.Evaluate(stateInfo.normalizedTime));
            }
        }

        private void ControllerMove(PlayerControler p, Animator animator, AnimatorStateInfo stateInfo)
        {
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
                    p.MoveForward(Speed, SpeedGraph.Evaluate(stateInfo.normalizedTime));
                }
            }

            if (p.MoveLeft)
            {
                p.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                if (!CheckFront(p))
                {
                    p.MoveForward(Speed, SpeedGraph.Evaluate(stateInfo.normalizedTime));
                }
            }
        }

        bool CheckFront(PlayerControler control)
        {
            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.forward * 0.3f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, BlockDistance))
                {
                    if (!control.RagdollParts.Contains(hit.collider))
                    {
                        if (!IsBodyPart(hit.collider))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        bool IsBodyPart(Collider col)
        {
            PlayerControler control = col.transform.root.GetComponent<PlayerControler>();

            if (control == null)
            {
                return false;
            }

            if (control.gameObject == col.gameObject)
            {
                return false;
            }

            if (control.RagdollParts.Contains(col))
            {
                return true;
            }

            return false;
        }
    }
}