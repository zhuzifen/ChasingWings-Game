using System;
using UnityEngine;

namespace script.Level_Items_Script.UglyStuff
{
    public class DynamicCopyPaster : MonoBehaviour
    {
        [HideInInspector]
        public bool ThisIsCopy = false;

        [HideInInspector] public DynamicCopyPaster Parent;
        

        private void Update()
        {
            if (ThisIsCopy)
            {
                if (!GameStateChecker.isTheCharaMoving)
                {
                    Parent.gameObject.SetActive(true);
                    Destroy(this.gameObject);
                }
            }
            else
            {
                if (GameStateChecker.isTheCharaMoving)
                {
                    GameObject newGo = GameObject.Instantiate(this.gameObject);
                    DynamicCopyPaster childDCP = newGo.GetComponent<DynamicCopyPaster>();
                    childDCP.Parent = this;
                    childDCP.transform.parent = this.transform.parent;
                    childDCP.ThisIsCopy = true;
                    this.gameObject.SetActive(false);
                }
            }
            
        }
    }
}