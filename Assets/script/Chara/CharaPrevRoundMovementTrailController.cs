using System;
using System.Collections.Generic;
using UnityEngine;

namespace script.Chara
{
    /// <summary>
    /// Controls the trail (in LineRenderer) of the character to show the movement during last round of simulation.
    /// </summary>
    public class CharaPrevRoundMovementTrailController : MonoBehaviour
    {
        public LineRenderer LR;
        public characterMove CM;
        
        public float GoesBackRatio = 0.03f;
        private Queue<Vector3> Recording = new Queue<Vector3>();
        private CharaStates PrevFrameMode;

        public AutoResetCounter PerRecordFrame = new AutoResetCounter(10);

        public Vector3 RecordPosOffset = Vector3.up * 0.3f;

        private void FixedUpdate()
        {
            if (LR == null || CM == null)
            {
                Destroy(this);
            }

            if (CM.characterMode == CharaStates.Stop)
            {
                PrevFrameMode = CM.characterMode;
                int count = Mathf.Max(1, (int) Mathf.Floor(Recording.Count * GoesBackRatio));
                while (count > 0)
                {
                    if(Recording.Count == 0){break;}
                    count -= 1;
                    LR.positionCount = LR.positionCount + 1;
                    LR.SetPosition(LR.positionCount-1, Recording.Dequeue());
                }
            }
            else if (CM.characterMode == CharaStates.Running)
            {
                // Only clear on the frame that started simulation.
                if (PrevFrameMode != CM.characterMode)
                {
                    LR.positionCount = 0;
                    Recording.Clear();
                    PrevFrameMode = CM.characterMode;
                }
                
                if(PerRecordFrame.IsZeroReached(1))
                {
                    Recording.Enqueue(CM.transform.position + RecordPosOffset);
                }
            }
        }
    }
}