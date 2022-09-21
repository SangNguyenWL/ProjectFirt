using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectfirt
{
    public class ManualInput : MonoBehaviour
    {
        private PlayerControler playerControler;

        private void Awake()
        {
            playerControler = this.gameObject.GetComponent<PlayerControler>();
        }

        // Update is called once per frame
        void Update()
        {
            if(VirtualInputManger.Instace.MoveRight)
            {
                playerControler.MoveRight = true;
            }
            else
            {
                playerControler.MoveRight = false;
            }

            if (VirtualInputManger.Instace.MoveLeft)
            {
                playerControler.MoveLeft = true;
            }
            else
            {
                playerControler.MoveLeft = false;
            }

            if(VirtualInputManger.Instace.Jump)
            {
                playerControler.Jump = true;
            }
            else
            {
                playerControler.Jump = false;
            }

            if(VirtualInputManger.Instace.Attack)
            {
                playerControler.Attack = true;
            }
            else
            {
                playerControler.Attack = false;
            }
        }
    }
}
