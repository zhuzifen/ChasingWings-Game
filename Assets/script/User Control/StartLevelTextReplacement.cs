using System;
using UnityEngine;
using UnityEngine.UI;

namespace script.User_Control
{
    public class StartLevelTextReplacement : MonoBehaviour
    {
        public characterMove CM;
        public Text text;
        public string start = "RUN";
        public string end = "RESPAWN";
        private void Start()
        {
            if (CM == null)
            {
                CM = FindObjectOfType<characterMove>();
                if (CM == null)
                {
                    Debug.LogError("CharacterMove CANNOT BE FOUND!");
                }
            }
        }

        public void ToggleStart()
        {
            CM.TriggerStart();
            if (CM.characterMode == CharaStates.Running)
            {
                text.text = end;
            }
            else
            {
                text.text = start;
            }
        }
    }
}