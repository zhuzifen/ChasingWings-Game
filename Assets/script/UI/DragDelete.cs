using script.Level_Items_Script;
using script.User_Control;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace script.UI
{
    public class DragDelete : Button
    {
        public UserControl UC;

        public BaseLevelItemScript Device;

        public AutoResetCounter MousePressedTimer = new AutoResetCounter(1.6f);
        public Image DeleteAllProgress;

        private bool isPressing;

        public Vector3 OrigPos;

        public float VibrateRatio = 10;

        protected override void Start()
        {
            base.Start();
            MousePressedTimer.MaxmizeTemp();
            if (UC == null)
            {
                UC = FindObjectOfType<UserControl>();
                if (UC == null)
                {
                    Debug.LogError("CANNOT FIND USER CONTROL!!!!!");
                }
            }

            OrigPos = this.transform.position;

            DeleteAllProgress = transform.GetChild(0).GetComponent<Image>();
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

            if (isPressing)
            {
                if (DeleteAllProgress != null)
                {
                    DeleteAllProgress.fillAmount = 1 - MousePressedTimer.Ratio();
                    this.transform.position = OrigPos + Random.insideUnitSphere * DeleteAllProgress.fillAmount * VibrateRatio;
                }

                if (MousePressedTimer.IsZeroReached(Time.fixedDeltaTime, false))
                {
                    BaseLevelItemScript[] BLIS = new BaseLevelItemScript[UC.LevelItemList.Count];
                    UC.LevelItemList.CopyTo(BLIS);
                    foreach (BaseLevelItemScript item in BLIS)
                    {
                        item.RemoveMe(UC);
                    }
                    isPressing = false;
                }
            }
            else
            {
                MousePressedTimer.Temp = Mathf.Lerp(MousePressedTimer.Temp, MousePressedTimer.Max + 0.1f, 0.2f);
                MousePressedTimer.Temp = Mathf.Clamp(MousePressedTimer.Temp, 0, MousePressedTimer.Max);
                DeleteAllProgress.fillAmount = 1 - MousePressedTimer.Ratio();
                this.transform.position = OrigPos;
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
            isPressing = false;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            isPressing = true;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            isPressing = false;
            if(!Device) return;
            Device.RemoveMe(UC);
            Device = null;
        }
    }
}