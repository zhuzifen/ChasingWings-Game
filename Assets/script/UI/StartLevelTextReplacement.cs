using System;
using UnityEngine;
using UnityEngine.UI;

namespace script.UI
{
    public class StartLevelTextReplacement : MonoBehaviour
    {
        public characterMove CM;
        public Text text;
        private string start = "RUN";
        private string end = "RESPAWN";
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
        }

        private void Update()
        {
            if (GameStateChecker.isTheCharaMoving)
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