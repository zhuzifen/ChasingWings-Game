using System;
using System.Collections.Generic;
using script.User_Control;
using UnityEngine;

namespace script.Level_Items_Script
{
    public class BaseFanScript : BaseLevelItemScript
    {
        public float ForceStrength = 10;
        public Vector3 ManualGravity = new Vector3(0, -2, 0); 
        public float ManualDrag = 0.995f;
        public Dictionary<Rigidbody, Vector3> EnterDirections = new Dictionary<Rigidbody, Vector3>();
        public override void RemoveMe(UserControl uc)
        {
            uc.LevelItemList.Remove(this);
            uc.fanCount -= 1;
            Destroy(this.gameObject);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.attachedRigidbody != null)
            {
                if (!EnterDirections.ContainsKey(other.attachedRigidbody))
                {
                    EnterDirections.Add(other.attachedRigidbody, other.attachedRigidbody.velocity.normalized);
                }
                other.attachedRigidbody.useGravity = false;
                other.attachedRigidbody.AddForce(this.transform.up * ForceStrength);

                other.attachedRigidbody.velocity = other.attachedRigidbody.velocity * ManualDrag;
                other.attachedRigidbody.AddForce(ManualGravity);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody != null)
            {
                other.attachedRigidbody.useGravity = true;
            }
        }
        
        /// <summary>
        /// 计算点到线段的最短线(相对于点point)
        /// </summary>
        /// <param name="point"></param>
        /// <param name="lineStart"></param>
        /// <param name="lineEnd"></param>
        /// <returns></returns>
        public static Vector3 DistancePointLine(Vector3 point, Vector3 lineStart, Vector3 lineEnd)
        {
            Vector3 rhs = point - lineStart;
            Vector3 vector3 = lineEnd - lineStart;
            float magnitude = vector3.magnitude;
            Vector3 lhs = vector3;
            if ((double) magnitude > 9.99999997475243E-07)
                lhs /= magnitude;
            float num = Mathf.Clamp(Vector3.Dot(lhs, rhs), 0.0f, magnitude);
            Vector3 v3 = lineStart + lhs * num;
            return v3 - point;
        }
    }
}