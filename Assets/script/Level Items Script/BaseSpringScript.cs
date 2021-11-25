using System;
using script.User_Control;
using UnityEngine;

namespace script.Level_Items_Script
{
    public class BaseSpringScript : BaseLevelItemScript
    {
        public float ForceMultiplier = 10;
        public bool Bounced = false;
        
        public GameObject Spring;
        public Vector3 SpringTargetPos;
        public Vector3 SpringTargetScale = Vector3.one;
        private Vector3 SpringOrigPos;
        private Vector3 SpringOrigScale = Vector3.one;
        public GameObject Platform;
        public Vector3 PlatformTargetPos;
        public Vector3 PlatformTargetScale = Vector3.one;
        private Vector3 PlatformOrigPos;
        private Vector3 PlatformOrigScale = Vector3.one;
        public AutoResetCounter ARC = new AutoResetCounter(1);

        public AudioSource springSound;
        
        
        protected override void Start()
        {
            base.Start();
            springSound = GetComponents<AudioSource>()[1];
            SpringOrigPos = Spring.transform.localPosition;
            SpringOrigScale = Spring.transform.localScale;
            PlatformOrigPos = Platform.transform.localPosition;
            PlatformOrigScale = Platform.transform.localScale;
            ARC.MaxmizeTemp();
        }
        
        


        protected override void Update()
        {
            base.Update();
            // this.transform.eulerAngles = Vector3.zero;
        }

        private void FixedUpdate()
        {
            float mul = 0.2f;
            if (Bounced)
            {
                Spring.transform.localPosition = Vector3.Lerp(Spring.transform.localPosition, SpringTargetPos, mul);
                Spring.transform.localScale = Vector3.Lerp(Spring.transform.localScale, SpringTargetScale, mul);
                
                Platform.transform.localPosition = Vector3.Lerp(Platform.transform.localPosition, PlatformTargetPos, mul);
                Platform.transform.localScale = Vector3.Lerp(Platform.transform.localScale, PlatformTargetScale, mul);
                if (ARC.IsZeroReached(Time.fixedDeltaTime))
                {
                    Bounced = false;
                }
            }
            else
            {
                Spring.transform.localPosition = Vector3.Lerp(Spring.transform.localPosition, SpringOrigPos, mul);
                Spring.transform.localScale = Vector3.Lerp(Spring.transform.localScale, SpringOrigScale, mul);
                
                Platform.transform.localPosition = Vector3.Lerp(Platform.transform.localPosition, PlatformOrigPos, mul);
                Platform.transform.localScale = Vector3.Lerp(Platform.transform.localScale, PlatformOrigScale, mul);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!GameStateChecker.isTheCharaMoving) return;
            if (Bounced) return;
            characterMove cm;
            charSimulate cs;
            if (other.TryGetComponent(out cm))
            {
                var ITfD = this.transform.InverseTransformDirection(cm.rb.velocity);
                var Changed = this.transform.TransformDirection(ITfD.x, ForceMultiplier, ITfD.z);
                cm.rb.velocity = Changed;
                // cm.rb.AddForce(this.transform.up * ForceMultiplier, ForceMode.Impulse);
                cm.footStep.enabled = false;
                Bounced = true;

                springSound.enabled = true;
                springSound.Play();
            }
            if (other.TryGetComponent(out cs))
            {
                var ITfD = this.transform.InverseTransformDirection(cs.rb.velocity);
                var Changed = this.transform.TransformDirection(ITfD.x, ForceMultiplier, ITfD.z);
                cs.rb.velocity = Changed;
                // cm.rb.AddForce(this.transform.up * ForceMultiplier, ForceMode.Impulse);
                Bounced = true;
            }
        }

        public override void RemoveMe(UserControl uc)
        {
            uc.LevelItemList.Remove(this);
            uc.springCount -= 1;
            Destroy(this.gameObject);
        }

    }
}