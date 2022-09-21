using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirt
{
    public enum PoolObjectType
    {
        ATTACKINFO,
    }

    public class PoolObjectLoader : MonoBehaviour
    {
        public static GameObject InstantiatePrefab(PoolObjectType objType)
        {
            GameObject obj = null;

            switch(objType)
            {
                case PoolObjectType.ATTACKINFO:
                    {
                        obj = Instantiate(Resources.Load("AttackInfo") as GameObject);
                        break;
                    }
            }

            return obj;
        }
    }
}