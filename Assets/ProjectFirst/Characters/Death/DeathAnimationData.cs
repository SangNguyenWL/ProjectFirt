using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirst
{
    [CreateAssetMenu(fileName = "New ScriptableObject", menuName = "ProjectFirst/Death/DeathAnimationData")]
    public class DeathAnimationData : ScriptableObject
    {
        public List<GeneralBodyPart> GeneralBodyParts = new List<GeneralBodyPart>();
        public RuntimeAnimatorController Animator;
        public bool LaunchIntoAir;
        public bool IsFacingAttacker;
    }
}

