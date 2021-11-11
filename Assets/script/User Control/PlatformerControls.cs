using System.Collections.Generic;
using script.Level_Items_Script;
using script.Level_Layout_Script;
using UnityEngine;

namespace script.User_Control
{
    public static class PlatformerControls
    {
        public static KeyCode MouseClickDrag = KeyCode.Mouse0;
        public static KeyCode ControllerClickDrag = KeyCode.JoystickButton0;
        
        public static KeyCode MouseCamMoveDrag = KeyCode.Mouse1;
        public static KeyCode MouseCamMoveDragAlter = KeyCode.Mouse2;
        public static float MouseMoveMultiplier = 1f;
        
        public const string ControllerCamMoveAxisX = "JoyScreenMoveX";
        public const string ControllerCamMoveAxisY = "JoyScreenMoveY";
        public static float JoyScreenMoveMultiplier = 1f;
        
        public const string ControllerCursorMoveAxisX = "JoyCursorMoveX";
        public const string ControllerCursorMoveAxisY = "JoyCursorMoveY";
        public static float JoyScreenCursorMoveMultiplier = 1;
        
        

        public static float ScreenXDelta()
        {
            return Input.GetAxis(ControllerCamMoveAxisX) + Input.mousePosition.x;
        }

    }
}