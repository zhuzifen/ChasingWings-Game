using System;
using UnityEngine;

namespace script.Chara
{
    public class CharaFootDetect : MonoBehaviour
    {
        public AutoResetCounter ARC = new AutoResetCounter(3);
        public bool IsTouchingGround = false;
        private void FixedUpdate()
        {
            IsTouchingGround = !ARC.IsZeroReached(1, false);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Running") || other.gameObject.CompareTag("Spring"))
            {
                ARC.MaxmizeTemp();
            }
        }
    }
}