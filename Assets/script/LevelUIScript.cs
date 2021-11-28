using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace script
{
    public class LevelUIScript : MonoBehaviour
    {
        public List<Sprite> CompletionSpriteLoops;
        
        public List<Sprite> EnterCompleteSpriteLoops;
        
        public List<Sprite> InProgressSpriteLoops;

        private bool Collected;

        public Image DisplayImage;

        private void FixedUpdate()
        {
            GoThroughSprites();
        }
        
        // TODO:
        // When Collected is false, go through and loop the InProgressSpriteLoops in 60 fps and make sure it follows the actual game time
        // When it's true, go through EnterCompleteSpriteLoops once first and then loop with CompletionSpriteLoops
        // The target is DisplayImage.sprite
        // You can make any fields and methods as you want
        void GoThroughSprites()
        {

            
        }

        public void MarkCollected()
        {
            Collected = true;
        }
    }
}