using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace script.UI
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

        public bool MouseOnMe()
        {
            return this.IsHighlighted() || this.IsPressed();
        }

        private void Update()
        {
            if (GameStateChecker.isTheCharaMoving)
            {
                this.image.color = Color.Lerp(this.image.color, new Color(1, 1, 1, 0), 0.2f);
                this.gameObject.GetComponentInChildren<Text>().color = Color.Lerp(this.image.color, new Color(1, 1, 1, 0), 0.2f);
            }
            else
            {
                this.image.color = Color.Lerp(this.image.color, new Color(1, 1, 1, 1), 0.2f);
                this.gameObject.GetComponentInChildren<Text>().color = Color.Lerp(this.image.color, new Color(1, 1, 1, 1), 0.2f);
            }
        }
    }
}