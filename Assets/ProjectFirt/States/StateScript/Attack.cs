using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirt
{
    [CreateAssetMenu(fileName = "New State", menuName = "ProjectFirt/AbilityData/Attack")]
    public class Attack : StateData
    {
        public float StartAttackTime;
        public float EndAttackTime;
        public List<string> ColliderNames = new List<string>();
        public bool MustCollide;
        public bool MustFaceAttacker;
        public float LethalRange;
        public int MaxHits;
        public List<RuntimeAnimatorController> DeathAnimators = new List<RuntimeAnimatorController>();

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Attack.ToString(), false);

            GameObject obj = Instantiate(Resources.Load("AttackInfo", typeof(GameObject))) as GameObject;
            AttackInfo info = obj.GetComponent<AttackInfo>();

            info.ResetInfo(this, characterState.GetPlayerControler(animator));

            if(!AttackManager.Instace.CurrentAttacks.Contains(info))
            {
                AttackManager.Instace.CurrentAttacks.Add(info);
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            RegisterAttack(characterState, animator, stateInfo);
            DeregisterAttack(characterState, animator, stateInfo);
        }

        public void RegisterAttack(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if(StartAttackTime <= stateInfo.normalizedTime && EndAttackTime > stateInfo.normalizedTime)
            {
                foreach(AttackInfo info in AttackManager.Instace.CurrentAttacks)
                {
                    if(info == null)
                    {
                        continue;
                    }

                    if(!info.isRegisterd && info.AttackAbility == this)
                    {
                        info.Register(this);
                    }
                }
            }
        }

        public void DeregisterAttack(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if(stateInfo.normalizedTime >= EndAttackTime)
            {
                foreach(AttackInfo info in AttackManager.Instace.CurrentAttacks)
                {
                    if(info == null)
                    {
                        continue;
                    }

                    if(info.AttackAbility == this && !info.isFinshed)
                    {
                        info.isFinshed = true;
                        Destroy(info.gameObject);
                    }

                }
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            ClearAttack();
        }

        public void ClearAttack()
        { 
            for(int i = 0; i < AttackManager.Instace.CurrentAttacks.Count; i++)
            {
                if(AttackManager.Instace.CurrentAttacks[i] == null || AttackManager.Instace.CurrentAttacks[i].isFinshed)
                {
                    AttackManager.Instace.CurrentAttacks.RemoveAt(i);
                }
            }
        }
    }
}