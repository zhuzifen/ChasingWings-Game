using System;
using UnityEngine;

namespace script.Level_Items_Script
{
    public class BaseDirectionalBoard : BaseLevelItemScript
    {
        private void OnTriggerEnter(Collider other)
        {
            characterMove cm;
            charSimulate cs;
            if (other.TryGetComponent(out cm))
            {
                cm.move *= -1;
                cm.transform.eulerAngles += Vector3.up * 180;
                Destroy(this);
            }
            if (other.TryGetComponent(out cs))
            {
                cs.move *= -1;
                cm.transform.eulerAngles += Vector3.up * 180;
                // cm.rb.AddForce(this.transform.up * ForceMultiplier, ForceMode.Impulse);
                Destroy(this);
            }
        }
    }
}