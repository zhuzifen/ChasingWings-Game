using System;
using script.Level_Items_Script;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace script.User_Control
{
    public class DragDelete : Button
    {
        public UserControl UC;

        public BaseLevelItemScript Device;

        protected override void Start()
        {
            base.Start();
            if (UC == null)
            {
                UC = FindObjectOfType<UserControl>();
                if (UC == null)
                {
                    Debug.LogError("CANNOT FIND USER CONTROL!!!!!");
                }
            }
        }

        private void Update()
        {
            if(UC == null || UC.characterMove == null) return;
            if (Input.GetMouseButtonUp(0))
            {
                if(!Device) return;
                Device.RemoveMe(UC);
                Device = null;
            }
        }

        private void FixedUpdate()
        {
            if(UC == null || UC.characterMove == null) return;

            if (UC.characterMove.characterMode == CharaStates.Running)
            {
                this.image.color = Color.Lerp(this.image.color, new Color(1, 1, 1, 0), 0.2f);
            }
            else
            {
                this.image.color = Color.Lerp(this.image.color, new Color(1, 1, 1, 1), 0.2f);
            }
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            if (UC.nowSelected != null && UC.DPCursor.SelectPressed)
            {
                Device = UC.nowSelected;
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            Device = null;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            if(!Device) return;
            Device.RemoveMe(UC);
            Device = null;
        }
    }
}