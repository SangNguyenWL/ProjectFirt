using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirst
{
    public class AttackManager : Singleton<AttackManager>
    {
        public List<AttackInfo> CurrentAttacks = new List<AttackInfo>();
    }
}