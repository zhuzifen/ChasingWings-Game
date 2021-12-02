using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace script.UI
{
    public class ShowHintsButton : Button
    {
        public GameObject HintGO;

        private float alpha = 0;

        private float SelfAlpha = 0;

        public Image thisImage;

        private bool isPointerInside = false;

        protected override void Start()
        {
            base.Start();
            if (thisImage == null)
            {
                thisImage = this.gameObject.GetComponent<Image>();
            }

            if (HintGO == null)
            {
                HintGO = GameObject.FindGameObjectWithTag("HINT");
            }
            thisImage.color = Color.Lerp(thisImage.color, new Color(1, 1, 1, SelfAlpha), 1);
        }

        private void Update()
        {
            if ((GameStateChecker.RespawnCount > 5))
            {
                SelfAlpha = 1;
            }
            thisImage.color = Color.Lerp(thisImage.color, new Color(1, 1, 1, SelfAlpha), 0.05f);
            
            alpha = Mathf.Lerp(alpha, alpha + (this.IsPressed() ? 1f : -1f), 0.2f);
            alpha = Mathf.Clamp01(alpha);
            if (HintGO == null)
            {
                Debug.LogError("HINT GAME OBJECT CANNOT BE FOUND! ASSIGN HINT TAG TO IT!");
            }
            foreach (Renderer rdr in HintGO.GetComponentsInChildren<Renderer>())
            {
                rdr.sharedMaterial.color = new Color(1.3f, 1.3f, 1.3f, alpha);
            }
        }
        
    }
}