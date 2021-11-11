﻿using script.User_Control;
using UnityEngine;

namespace script.Level_Items_Script
{
    public class BaseSpringScript : BaseLevelItemScript
    {
        public override void RemoveMe(UserControl uc)
        {
            uc.LevelItemList.Remove(this);
            uc.springCount -= 1;
            Destroy(this.gameObject);
        }

        protected override void Update()
        {
            base.Update();
            this.transform.eulerAngles = Vector3.zero;
        }
    }
}