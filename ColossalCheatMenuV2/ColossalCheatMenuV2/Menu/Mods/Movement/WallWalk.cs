using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class WallWalk : MonoBehaviour
    {
        private Vector3 normal2;
        private Vector3 vel1;
        private Vector3 vel2;
        private float dist2;
        private int layers;
        private bool LeftClose2;
        private bool DoOnce2;
        private float maxD2;
        public void Update()
        {
            if (Plugin.wallwalk)
            {
                bool wallwalkActiveR;
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out wallwalkActiveR);
                if (wallwalkActiveR)
                {
                    if (!DoOnce2)
                    {
                        maxD2 = 1f;
                        layers = 512;
                        DoOnce2 = true;
                    }
                    RaycastHit raycastHit3;
                    Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, -GorillaTagger.Instance.rightHandTransform.right, out raycastHit3, 1, layers);
                    RaycastHit raycastHit4;
                    Physics.Raycast(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.right, out raycastHit4, 1, layers);
                    if (raycastHit4.distance > raycastHit3.distance)
                    {
                        normal2 = raycastHit3.normal;
                        dist2 = raycastHit3.distance;
                    }
                    else
                    {
                        normal2 = raycastHit4.normal;
                        dist2 = raycastHit4.distance;
                        LeftClose2 = true;
                    }
                    if (dist2 < maxD2)
                    {
                        vel2 = normal2 * (9.8f * Time.deltaTime);
                        GorillaTagger.Instance.bodyCollider.attachedRigidbody.velocity -= vel2;
                    }
                    else
                    {
                        GorillaTagger.Instance.bodyCollider.attachedRigidbody.useGravity = true;
                    }
                }
                else
                {
                    GorillaTagger.Instance.bodyCollider.attachedRigidbody.useGravity = true;
                }
            }
            else
            {
                Destroy(GorillaTagger.Instance.GetComponent<WallWalk>());
            }
        }
    }
}
