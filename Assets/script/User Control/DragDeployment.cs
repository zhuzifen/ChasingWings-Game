using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace script.User_Control
{
    public class DragDeployment : Button
    {
        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            return;
        }
    }
}