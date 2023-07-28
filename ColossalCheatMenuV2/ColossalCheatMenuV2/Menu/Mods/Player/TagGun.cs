using Photon.Pun;
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
    public class TagGun : MonoBehaviour
    {
        private GameObject pointer;
        private LineRenderer radiusLine;
        private Material lineMaterial;
        public void Update()
        {
            if (Plugin.taggun && PhotonNetwork.InRoom)
            {
                if(pointer == null) {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Destroy(pointer.GetComponent<Rigidbody>());
                    Destroy(pointer.GetComponent<SphereCollider>());
                    pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    pointer.GetComponent<Renderer>().material = boardmat;
                }
                RaycastHit info;
                Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position - GorillaTagger.Instance.rightHandTransform.up, -GorillaTagger.Instance.rightHandTransform.up, out info);
                pointer.transform.position = info.point;

                bool shoot = false;
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out shoot);
                RaycastHit raycastHit;
                Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit);
                if (shoot)
                {
                    if (radiusLine == null) {
                        lineMaterial = new Material(Shader.Find("Sprites/Default"));
                        lineMaterial.color = new Color(0.6f, 0f, 0.8f, 0.5f);

                        GameObject lineObject = new GameObject("RadiusLine");
                        lineObject.transform.parent = pointer.transform;
                        radiusLine = lineObject.AddComponent<LineRenderer>();
                        radiusLine.positionCount = 2;
                        radiusLine.startWidth = 0.05f;
                        radiusLine.endWidth = 0.05f;
                        radiusLine.material = lineMaterial;
                    }
                    radiusLine.SetPosition(0, raycastHit.point);
                    radiusLine.SetPosition(1, GorillaLocomotion.Player.Instance.rightControllerTransform.position);
                    if (radiusLine.GetPosition(0) == null) {
                        if (radiusLine != null) {
                            Destroy(radiusLine);
                            radiusLine = null;
                        }
                    }

                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = raycastHit.point;
                    GorillaLocomotion.Player.Instance.rightControllerTransform.position = raycastHit.point;
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    if (radiusLine != null) {
                        Destroy(radiusLine);
                        radiusLine = null;
                    }
                }
            }
            else
            {
                Destroy(GorillaTagger.Instance.GetComponent<TagGun>());
                if (pointer != null)
                    Destroy(pointer);
            }
        }
    }
}
