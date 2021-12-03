using System;
using UnityEngine;
using UnityEngine.UI;

namespace script.UI
{
    public class StonePosIndicator : MonoBehaviour
    {
        public Image StoneIndicator;
        public Sprite CheckImage;
        public Sprite StoneImage;
        public GameObject ActualStone;

        public Bounds PositionBound;
        
        public bool chekk = false;

        private void Start()
        {
            if (PositionBound.center == Vector3.zero && PositionBound.extents == Vector3.zero)
            {
                PositionBound.center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                PositionBound.extents = new Vector3(Screen.width / 2, Screen.height / 2, 9999) * 0.6f;
            }
        }

        private void Update()
        {
            if (ActualStone == null || !ActualStone.activeInHierarchy)
            {
                foreach (var VARIABLE in GameObject.FindGameObjectsWithTag("Stone"))
                {
                    if (VARIABLE.activeInHierarchy)
                    {
                        ActualStone = VARIABLE;
                    }
                }
            }
            Vector3 onScreenPos = Camera.main.WorldToScreenPoint(ActualStone.transform.position);
            onScreenPos.z = 0;
            if (PositionBound.Contains(onScreenPos))
            {
                this.transform.position = new Vector3(Screen.width * 999, Screen.height * 999, 999);
            }
            else
            {
                this.transform.position = PositionBound.ClosestPoint(onScreenPos);
                Vector3 diff = onScreenPos - this.transform.position;
                this.transform.eulerAngles = Vector3.forward * (Mathf.Rad2Deg * (Mathf.Atan2(-diff.x, diff.y)));
            }

            if (StoneIndicator != null)
            {
                Vector3 rolled = StoneIndicator.transform.eulerAngles - Vector3.forward * (ActualStone.GetComponent<Rigidbody>().angularVelocity.magnitude);
                StoneIndicator.transform.eulerAngles = chekk?Vector3.zero:rolled;
                StoneIndicator.sprite = chekk ? CheckImage : StoneImage;
            }

            chekk = GameStateChecker.isTheCharaMoving && chekk;
            
            
        }

        public void Check()
        {
            chekk = true;
            print("CHEQUE!");
        }
    }
}