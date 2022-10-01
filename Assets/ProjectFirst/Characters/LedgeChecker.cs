using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirst
{
    public class LedgeChecker : MonoBehaviour
    {
        public bool isGrabbingLedge;
        public Ledge GrabbedLedge;
        Ledge CheckLedge = null;

        private void OnTriggerEnter(Collider other)
        {
            CheckLedge = other.gameObject.GetComponent<Ledge>();
            if (CheckLedge != null)
            {
                isGrabbingLedge = true;
                GrabbedLedge = CheckLedge;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            CheckLedge = other.gameObject.GetComponent<Ledge>();
            if (CheckLedge != null)
            {
                isGrabbingLedge = false;
                //GrabbedLedge = null;
            }
        }
    }
}
