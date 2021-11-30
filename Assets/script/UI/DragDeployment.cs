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
    }
}