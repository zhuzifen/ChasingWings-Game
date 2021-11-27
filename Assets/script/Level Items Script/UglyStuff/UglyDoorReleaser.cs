using System;
using UnityEngine;

namespace script.Level_Items_Script.UglyStuff
{
    public class UglyDoorReleaser : MonoBehaviour
    {
        public Animation TheAnimation;
        public GameObject TargetGameObject;

        private void OnTriggerEnter(Collider other)
        {
            if(!GameStateChecker.isTheCharaMoving) return;
            if (other.gameObject == TargetGameObject)
            {
                TheAnimation.Play();
            }
        }
    }
}