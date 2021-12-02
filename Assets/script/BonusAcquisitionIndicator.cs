using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace script
{
    public class BonusAcquisitionIndicator : MonoBehaviour
    {
        public List<Sprite> CompletionSpriteLoops;
        
        public List<Sprite> EnterCompleteSpriteLoops;
        
        public List<Sprite> InProgressSpriteLoops;

        public bool Collected = false;

        public Image DisplayImage;

        private int currentSpriteIndex;

        private void Start()
        {
            currentSpriteIndex += Random.Range(0, InProgressSpriteLoops.Count);
        }

        private void FixedUpdate()
        {
            GoThroughSprites();
        }
        
        void GoThroughSprites()
        {
            currentSpriteIndex += (int)(Time.fixedDeltaTime * 60);
            Sprite spr;
            if (!Collected)
            {
                spr = InProgressSpriteLoops[currentSpriteIndex % InProgressSpriteLoops.Count];
            }
            else
            {
                if (currentSpriteIndex < EnterCompleteSpriteLoops.Count)
                {
                    spr = EnterCompleteSpriteLoops[currentSpriteIndex];
                } 
                else
                {
                    spr = CompletionSpriteLoops[(currentSpriteIndex - EnterCompleteSpriteLoops.Count) % CompletionSpriteLoops.Count];
                }
            }
            DisplayImage.sprite = spr;
        }
        // You can modify this method if you want 
        public void MarkCollected()
        {
            Collected = true;
            currentSpriteIndex = 0;
        }
    }
}