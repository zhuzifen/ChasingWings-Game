using System;
using System.Collections.Generic;
using script.User_Control;
using UnityEngine;

namespace script.Level_Items_Script
{
    public class BaseLevelItemScript : MonoBehaviour
    {
        public bool MeTempRemoved = false;
        public Material normal;
        public Material outline;

        public List<Renderer> ToBeSwitchedRenderers;

        public UserControl control;

        public Vector3 TempLocalScale;

        /// <summary>
        /// This is for bound detection of the platforms for deployment.
        /// This collider can (and probably should) be disabled
        /// This collider should contain all part of the platform
        /// </summary>
        public Collider OuterFrame;

        public Vector3 targetLerpToPosition;


        private Vector3 tempPos = Vector3.one;

        private bool JustMoved = false;

        private float LerpMultiplier = 0.2f;
        

        protected virtual void Start()
        {
            TempLocalScale = this.transform.localScale;
            Debug.Assert(OuterFrame != null, $"THE OUTER FRAME IS NULL FOR {this.gameObject.name}");
            tempPos = this.transform.position;
            targetLerpToPosition = this.transform.position;
        }
        public virtual void SetControl(UserControl uc)
        {
            control = uc;
        }
        
        public virtual void HighlightMe()
        {
            foreach (Renderer rdr in ToBeSwitchedRenderers)
            {
                Material[] temp = new Material[2];
                temp[0] = normal;
                temp[1] = outline;
                rdr.materials = temp;
            }
        }
        
        public virtual void DisHighlightMe()
        {
            foreach (Renderer rdr in ToBeSwitchedRenderers)
            {
                Material[] temp = new Material[1];
                temp[0] = normal;
                rdr.materials = temp;
            }
        }

        public virtual void RemoveMe(UserControl uc)
        {
            uc.LevelItemList.Remove(this);
            Destroy(this.gameObject);
        }

        protected virtual void Update()
        {
            this.transform.position = Vector3.Lerp(this.transform.position, targetLerpToPosition, LerpMultiplier);
            if (control && control.characterMove.characterMode == CharaStates.Stop)
            {
                if (MeTempRemoved)
                {
                    MeTempRemoved = false;
                    foreach (Renderer rdr in this.gameObject.GetComponentsInChildren<Renderer>())
                    {
                        rdr.enabled = true;
                    }
                    foreach (Collider cldr in this.gameObject.GetComponentsInChildren<Collider>())
                    {
                        cldr.enabled = true;
                    }
                    this.transform.localScale = TempLocalScale;
                }
            }

            if (control && control.nowSelected != this)
            {
                this.DisHighlightMe();
            }
            
            CheckPositionAvailable();
        }

        protected virtual void CheckPositionAvailable()
        {
            if (JustMoved)
            {
                JustMoved = false;
            }
            else
            {
                foreach (var other in control.LevelItemList)
                {
                    if (this.OuterFrame.bounds.Intersects(other.OuterFrame.bounds) && (other.gameObject != this.gameObject))
                    {
                        targetLerpToPosition = this.tempPos;
                        JustMoved = true;
                        return;
                    }
                }

                this.tempPos = targetLerpToPosition;
            }
        }

        public virtual void RemoveMeInGame(UserControl uc)
        {
            MeTempRemoved = true;
            foreach (Renderer rdr in this.gameObject.GetComponentsInChildren<Renderer>())
            {
                rdr.enabled = false;
            }
            foreach (Collider cldr in this.gameObject.GetComponentsInChildren<Collider>())
            {
                cldr.enabled = false;
            }

            this.transform.localScale = Vector3.zero;
        }

        public virtual void SetMyPos(Vector3 pos)
        {
            if (JustMoved)
            {
                JustMoved = false;
            }
            else
            {
                targetLerpToPosition = new Vector3((int) pos.x, (int) pos.y, (int) pos.z);
                JustMoved = true;
            }
        }

        public virtual void RotateOnce()
        {
            transform.Rotate(new Vector3(-90f, 0f, 0f));
        }
    }
}