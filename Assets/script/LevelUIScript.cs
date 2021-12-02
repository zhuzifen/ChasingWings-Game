using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace script
{
    public class LevelUIScript : MonoBehaviour
    {
        public List<Sprite> CompletionSpriteLoops;
        
        public List<Sprite> EnterCompleteSpriteLoops;
        
        public List<Sprite> InProgressSpriteLoops;

        private bool Collected;

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
                } else
                {
                    spr = CompletionSpriteLoops[(currentSpriteIndex - EnterCompleteSpriteLoops.Count) % InProgressSpriteLoops.Count];
                }
            }
            DisplayImage.sprite = spr;
        }
        // You can modify this method if you want 
        public void MarkCollected()
        {
            Collected = true;
        }
    }
}