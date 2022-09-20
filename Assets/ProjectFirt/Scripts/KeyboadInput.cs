using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirt
{
    public class KeyboadInput : MonoBehaviour
    {
        void Update()
        {
            if(Input.GetKey(KeyCode.D))
            {
                VirtualInputManger.Instace.MoveRight = true;
            }
            else
            {
                VirtualInputManger.Instace.MoveRight = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                VirtualInputManger.Instace.MoveLeft = true;
            }
            else
            {
                VirtualInputManger.Instace.MoveLeft = false;
            }

            if(Input.GetKey(KeyCode.Space))
            {
                VirtualInputManger.Instace.Jump = true;
            }
            else
            {
                VirtualInputManger.Instace.Jump = false;
            }
        }
    }
}


