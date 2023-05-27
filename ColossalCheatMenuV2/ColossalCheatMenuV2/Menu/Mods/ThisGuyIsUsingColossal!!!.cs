using ExitGames.Client.Photon;
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
    public class ThisGuyIsUsingColossal : MonoBehaviour
    {
        private float colorTimer = 0f;
        public static Color colour = Color.red;
        public void Update()
        {
            if (PhotonNetwork.InRoom) {
                float r = Mathf.Lerp(0f, 1f, Mathf.Abs(Mathf.Sin(colorTimer * 0.4f)));
                float g = Mathf.Lerp(0f, 1f, Mathf.Abs(Mathf.Sin(colorTimer * 0.5f)));
                float b = Mathf.Lerp(0f, 1f, Mathf.Abs(Mathf.Sin(colorTimer * 0.6f)));
                colour = new Color(r, g, b);
                colorTimer += Time.deltaTime * 2;

                if (!GorillaTagger.Instance.myVRRig.photonView.Controller.CustomProperties.ContainsValue("colossal")) {
                    Hashtable hash = new Hashtable
                    {
                            { "colossal", "colossal" }
                    };
                    GorillaTagger.Instance.myVRRig.photonView.Controller.SetCustomProperties(hash);
                }
                foreach (VRRig vrrig in GameObject.Find("GorillaVRRigs").GetComponentsInChildren<VRRig>()) {
                    if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer && !vrrig.photonView.IsMine) {
                        if (vrrig.photonView.Controller.CustomProperties.ContainsValue("colossal")) {
                            if (!GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().isCasual) {
                                if (!GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().currentInfectedArray.Contains(vrrig.photonView.Owner.ActorNumber)) {
                                    vrrig.mainSkin.material.color = colour;
                                    vrrig.mainSkin.material.SetFloat("_Metallic", 1f);
                                    vrrig.mainSkin.material.SetFloat("_Glossiness", 1f);
                                }
                            }
                            vrrig.playerText.color = Color.magenta;
                        }
                    }
                }
            }
        }
    }
}
