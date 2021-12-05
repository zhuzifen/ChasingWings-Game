using System.Collections.Generic;
using script.Level_Layout_Script;
using script.User_Control;
using UnityEngine;

namespace script.UI
{
    public class DualPurposeCursor : MonoBehaviour
    {
        private Vector3 _prevFrameMousePos;
        public float joystickRatio = 1;
        public bool DPadUpPressed;
        public bool DPadDownPressed;
        public bool DPadLeftPressed;
        public bool DPadRightPressed;

        private Dictionary<DeviceEnum, bool> StateRecorder = new Dictionary<DeviceEnum, bool>();

        public UserControl UC;

        public bool DeletePressed = false;
        public bool RotatePressed = false;
        public bool StartPressed = false;
        public bool SelectPressed = false;
        
        private void Start()
        {
            StateRecorder.Add(DeviceEnum.Fan, false);
            StateRecorder.Add(DeviceEnum.Spring, false);
            StateRecorder.Add(DeviceEnum.DirectionBoard, false);
            StateRecorder.Add(DeviceEnum.PlaceHolder, false);

            if (UC == null)
            {
                Debug.LogError("The UserControl Has Not Been Assigned For Cursor!");
            }
        }

        private void Update()
        {
            Vector3 MousePos = Input.mousePosition;
            Vector3 XZeroCursorPos = GetXZeroMousePos();
            if (MousePos != _prevFrameMousePos)
            {
                this.transform.position = MousePos;
                _prevFrameMousePos = MousePos;
            }
            else
            {
                this.transform.position += new Vector3(Input.GetAxis("HorizontalAlter") * joystickRatio, Input.GetAxis("VerticalAlter") * -joystickRatio, 0);
            }

            this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, 0, Screen.width), Mathf.Clamp(this.transform.position.y, 0, Screen
                .height), 0);
            XYABPressCheck();
            DPadPressCheck();
            DeviceDeployment(XZeroCursorPos);
        }

        void XYABPressCheck()
        {
            this.DeletePressed = Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Q)|| Input.GetKeyDown(KeyCode.X);
            this.RotatePressed = Input.GetKey(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.R) || Input.GetMouseButton(1);
            this.StartPressed = Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space);
            this.SelectPressed = Input.GetKey(KeyCode.Joystick1Button0) || Input.GetMouseButton(0);
        }
        
        private void DPadPressCheck()
        {
            if (Input.GetAxis("DPadLR") < 0)
            {
                DPadLeftPressed = true;
            }
            else if (Input.GetAxis("DPadLR") > 0)
            {
                DPadRightPressed = true;
            }
            else
            {
                DPadLeftPressed = false;
                DPadRightPressed = false;
            }

            if (Input.GetAxis("DPadUD") < 0)
            {
                DPadDownPressed = true;
            }
            else if (Input.GetAxis("DPadUD") > 0)
            {
                DPadUpPressed = true;
            }
            else
            {
                DPadDownPressed = false;
                DPadUpPressed = false;
            }
        }

        private void DeviceDeployment(Vector3 XZeroCursorPos)
        {
            if (StateRecorder[DeviceEnum.Fan] != DPadLeftPressed)
            {
                StateRecorder[DeviceEnum.Fan] = DPadLeftPressed;
                if (DPadLeftPressed == false) return;
                    UC.SpawnFan();
                    var fan = UC.nowSelected;
                if (fan != null)
                {
                    fan.transform.position = XZeroCursorPos;
                }
            }

            if (StateRecorder[DeviceEnum.Spring] != DPadRightPressed)
            {
                StateRecorder[DeviceEnum.Spring] = DPadRightPressed;
                if (DPadRightPressed == false) return;
                UC.SpawnSpringPlatform();
                var spring = UC.nowSelected;
                if (spring != null)
                {
                    spring.transform.position = XZeroCursorPos;
                }
            }

            if (StateRecorder[DeviceEnum.DirectionBoard] != DPadUpPressed)
            {
                StateRecorder[DeviceEnum.DirectionBoard] = DPadUpPressed;
                if (DPadUpPressed == false) return;
                // TODO
            }

            if (StateRecorder[DeviceEnum.PlaceHolder] != DPadDownPressed)
            {
                StateRecorder[DeviceEnum.PlaceHolder] = DPadDownPressed;
                if (DPadDownPressed == false) return;
                // TODO
            }
        }

        public Vector3 GetXZeroMousePos()
        {
            var MouseWorldPosOnXZero = Vector3.zero;
            Ray ray = Camera.main.ScreenPointToRay(this.transform.position);
            foreach (RaycastHit hitt in Physics.RaycastAll(ray, 1500))
            {
                BaseXZero XZero = hitt.collider.gameObject.GetComponent<BaseXZero>();
                if (XZero != null)
                {
                    MouseWorldPosOnXZero = hitt.point;
                }
            }

            return MouseWorldPosOnXZero;
        }


        public enum DeviceEnum
        {
            Fan,
            Spring,
            DirectionBoard,
            PlaceHolder
        }
    }
}