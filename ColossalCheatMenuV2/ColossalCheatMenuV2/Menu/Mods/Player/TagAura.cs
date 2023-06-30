using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods {
    public class TagAura : MonoBehaviour {
        private LineRenderer radiusLine;
        private Material lineMaterial;
        public void Update() {
            if (Plugin.tagauracolossal && PhotonNetwork.InRoom) {
                foreach (VRRig vrrig in GameObject.Find("GorillaVRRigs").GetComponentsInChildren<VRRig>()) {
                    if (!vrrig.isMyPlayer) {
                        float distance = Vector3.Distance(GorillaTagger.Instance.myVRRig.transform.position, vrrig.transform.position);
                        if (distance < GorillaGameManager.instance.tagDistanceThreshold / 3 && !GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().currentInfectedArray.Contains(vrrig.myPlayer.ActorNumber)) {
                            if (GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().currentInfectedArray.Contains(Plugin.GetPhotonViewFromVR(GorillaTagger.Instance.myVRRig.gameObject).Owner.ActorNumber)) {
                                if (radiusLine == null) {
                                    lineMaterial = new Material(Shader.Find("Sprites/Default"));
                                    lineMaterial.color = new Color(0.6f, 0f, 0.8f, 0.5f);

                                    GameObject lineObject = new GameObject("RadiusLine");
                                    lineObject.transform.parent = vrrig.transform;
                                    radiusLine = lineObject.AddComponent<LineRenderer>();
                                    radiusLine.positionCount = 2;
                                    radiusLine.startWidth = 0.05f;
                                    radiusLine.endWidth = 0.05f;
                                    radiusLine.material = lineMaterial;
                                }
                                GorillaLocomotion.Player.Instance.rightControllerTransform.position = vrrig.transform.position;
                                radiusLine.SetPosition(0, vrrig.transform.position);
                                radiusLine.SetPosition(1, GorillaTagger.Instance.transform.position);
                                if (radiusLine.GetPosition(0) == null) {
                                    if (radiusLine != null) {
                                        Destroy(radiusLine);
                                        radiusLine = null;
                                    }
                                }
                            }
                        }
                    }
                }
            } else if(!Plugin.tagauraghost && !Plugin.tagaurablatant) {
                Destroy(GorillaTagger.Instance.GetComponent<TagAura>());
                if (radiusLine != null) {
                    Destroy(radiusLine.gameObject);
                    radiusLine = null;
                }
            }

            if (Plugin.tagauraghost && PhotonNetwork.InRoom) {
                foreach (VRRig vrrig in GameObject.Find("GorillaVRRigs").GetComponentsInChildren<VRRig>()) {
                    if (!vrrig.isMyPlayer) {
                        float distance = Vector3.Distance(GorillaTagger.Instance.myVRRig.transform.position, vrrig.transform.position);
                        if (distance < GorillaGameManager.instance.tagDistanceThreshold / 2 && !GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().currentInfectedArray.Contains(vrrig.myPlayer.ActorNumber)) {
                            if (GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().currentInfectedArray.Contains(Plugin.GetPhotonViewFromVR(GorillaTagger.Instance.myVRRig.gameObject).Owner.ActorNumber)) {
                                if (radiusLine == null) {
                                    lineMaterial = new Material(Shader.Find("Sprites/Default"));
                                    lineMaterial.color = new Color(0.6f, 0f, 0.8f, 0.5f);

                                    GameObject lineObject = new GameObject("RadiusLine");
                                    lineObject.transform.parent = vrrig.transform;
                                    radiusLine = lineObject.AddComponent<LineRenderer>();
                                    radiusLine.positionCount = 2;
                                    radiusLine.startWidth = 0.05f;
                                    radiusLine.endWidth = 0.05f;
                                    radiusLine.material = lineMaterial;
                                }
                                GorillaLocomotion.Player.Instance.rightControllerTransform.position = vrrig.transform.position;
                                radiusLine.SetPosition(0, vrrig.transform.position);
                                radiusLine.SetPosition(1, GorillaTagger.Instance.transform.position);
                                if (radiusLine.GetPosition(0) == null) {
                                    if (radiusLine != null) {
                                        Destroy(radiusLine);
                                        radiusLine = null;
                                    }
                                }
                            }
                        }
                    }
                }
            } else if(!Plugin.tagaurablatant && !Plugin.tagauracolossal) {
                Destroy(GorillaTagger.Instance.GetComponent<TagAura>());
                if (radiusLine != null) {
                    Destroy(radiusLine.gameObject);
                    radiusLine = null;
                }
            }

            if (Plugin.tagaurablatant && PhotonNetwork.InRoom) {
                foreach (VRRig vrrig in GameObject.Find("GorillaVRRigs").GetComponentsInChildren<VRRig>()) {
                    if (!vrrig.isMyPlayer) {
                        float distance = Vector3.Distance(GorillaTagger.Instance.myVRRig.transform.position, vrrig.transform.position);
                        if (distance < GorillaGameManager.instance.tagDistanceThreshold && !GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().currentInfectedArray.Contains(vrrig.myPlayer.ActorNumber)) {
                            if (GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().currentInfectedArray.Contains(Plugin.GetPhotonViewFromVR(GorillaTagger.Instance.myVRRig.gameObject).Owner.ActorNumber)) {
                                if (radiusLine == null) {
                                    lineMaterial = new Material(Shader.Find("Sprites/Default"));
                                    lineMaterial.color = new Color(0.6f, 0f, 0.8f, 0.5f);

                                    GameObject lineObject = new GameObject("RadiusLine");
                                    lineObject.transform.parent = vrrig.transform;
                                    radiusLine = lineObject.AddComponent<LineRenderer>();
                                    radiusLine.positionCount = 2;
                                    radiusLine.startWidth = 0.05f;
                                    radiusLine.endWidth = 0.05f;
                                    radiusLine.material = lineMaterial;
                                }
                                GorillaLocomotion.Player.Instance.rightControllerTransform.position = vrrig.transform.position;
                                radiusLine.SetPosition(0, vrrig.transform.position);
                                radiusLine.SetPosition(1, GorillaTagger.Instance.transform.position);
                                if (radiusLine.GetPosition(0) == null) {
                                    if (radiusLine != null) {
                                        Destroy(radiusLine);
                                        radiusLine = null;
                                    }
                                }
                            }
                        }
                    }
                }
            } else if(!Plugin.tagauracolossal && !Plugin.tagauraghost) {
                Destroy(GorillaTagger.Instance.GetComponent<TagAura>());
                if (radiusLine != null) {
                    Destroy(radiusLine.gameObject);
                    radiusLine = null;
                }
            }
        }
    }
}
