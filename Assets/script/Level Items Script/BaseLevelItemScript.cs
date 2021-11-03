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

        protected virtual void Start()
        {
            TempLocalScale = this.transform.localScale;
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
            this.transform.position = new Vector3((int) pos.x, (int) pos.y, (int) pos.z);
        }

        public virtual void RotateOnce()
        {
            transform.Rotate(new Vector3(-90f, 0f, 0f));
        }
    }
}