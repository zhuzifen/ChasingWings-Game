using System;
using UnityEngine;
using script.User_Control;

namespace script.Level_Items_Script
{
    public class BaseDirectionalBoard : BaseLevelItemScript
    {
        private bool Reverted = false;
        public AutoResetCounter ARC = new AutoResetCounter(1);
        
        
        protected override void Start()
        {
            base.Start();
            ARC.MaxmizeTemp();
        }

        public override void RemoveMe(UserControl uc)
        {
            uc.LevelItemList.Remove(this);
            uc.directionBoardCount -= 1;
            Destroy(this.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!GameStateChecker.isTheCharaMoving) return;
            if (Reverted) return;
            characterMove cm;
            charSimulate cs;
            if (other.TryGetComponent(out cm))
            {
                if(cm.characterMode != CharaStates.Running) return;
                cm.move *= -1;
                cm.transform.eulerAngles += Vector3.up * 180;
                Reverted = true;
            }
            if (other.TryGetComponent(out cs))
            {
                cs.move *= -1;
                cs.transform.eulerAngles += Vector3.up * 180;
                Reverted = true;
            }
        }
        private void FixedUpdate()
        {
            if (Reverted)
            {
                if (ARC.IsZeroReached(Time.fixedDeltaTime))
                {
                    Reverted = false;
                }
            }
        }
    }
}