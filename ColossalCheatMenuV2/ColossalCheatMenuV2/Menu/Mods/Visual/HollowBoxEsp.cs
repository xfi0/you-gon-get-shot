using Colossal.Mods;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.XR;
using Viveport;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class HollowBoxEsp : MonoBehaviour
    {
        public static float objectScale;

        public void Update()
        {
            if (Plugin.hollowboxesp && PhotonNetwork.InRoom)
            {
                foreach (VRRig vrrig in GameObject.Find("GorillaVRRigs").GetComponentsInChildren<VRRig>())
                {
                    if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer && !vrrig.photonView.IsMine)
                    {
                        if (!vrrig.gameObject.GetComponent<AddBoxHollow>())
                        {
                            vrrig.gameObject.AddComponent<AddBoxHollow>();
                        }
                        else
                        {
                            AddBoxHollow addbox = vrrig.GetComponent<AddBoxHollow>();

                            if (!GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().isCasual)
                            {
                                if (GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().currentInfectedArray.Contains(vrrig.photonView.Owner.ActorNumber))
                                {
                                    addbox.topSide.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f, 0.4f);
                                    addbox.bottomSide.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f, 0.4f);
                                    addbox.leftSide.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f, 0.4f);
                                    addbox.rightSide.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f, 0.4f);
                                }
                                if (!GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().currentInfectedArray.Contains(vrrig.photonView.Owner.ActorNumber))
                                {
                                    addbox.topSide.GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f, 0.4f);
                                    addbox.bottomSide.GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f, 0.4f);
                                    addbox.leftSide.GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f, 0.4f);
                                    addbox.rightSide.GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f, 0.4f);
                                }
                                if (!GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().currentInfectedArray.Contains(vrrig.photonView.Owner.ActorNumber) && vrrig.photonView.Controller.CustomProperties.ContainsValue("colossal"))
                                {
                                    addbox.topSide.GetComponent<Renderer>().material.color = new Color(0f, 0f, 1f, 0.4f);
                                    addbox.bottomSide.GetComponent<Renderer>().material.color = new Color(0f, 0f, 1f, 0.4f);
                                    addbox.leftSide.GetComponent<Renderer>().material.color = new Color(0f, 0f, 1f, 0.4f);
                                    addbox.rightSide.GetComponent<Renderer>().material.color = new Color(0f, 0f, 1f, 0.4f);
                                }
                                if (!GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().currentInfectedArray.Contains(vrrig.photonView.Owner.ActorNumber) && vrrig.photonView.Controller.CustomProperties.ContainsValue("colossaladmin"))
                                {
                                    addbox.topSide.GetComponent<Renderer>().material.color = ThisGuyIsUsingColossal.colour;
                                    addbox.bottomSide.GetComponent<Renderer>().material.color = ThisGuyIsUsingColossal.colour;
                                    addbox.leftSide.GetComponent<Renderer>().material.color = ThisGuyIsUsingColossal.colour;
                                    addbox.rightSide.GetComponent<Renderer>().material.color = ThisGuyIsUsingColossal.colour;
                                }
                                if (!GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().currentInfectedArray.Contains(vrrig.photonView.Owner.ActorNumber) && vrrig.photonView.Controller.IsMasterClient)
                                {
                                    addbox.topSide.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f, 0.4f);
                                    addbox.bottomSide.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f, 0.4f);
                                    addbox.leftSide.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f, 0.4f);
                                    addbox.rightSide.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f, 0.4f);
                                }
                            }
                            else
                            {
                                if (vrrig.mainSkin.material.name.Contains("fected"))
                                {
                                    addbox.topSide.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f, 0.4f);
                                    addbox.bottomSide.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f, 0.4f);
                                    addbox.leftSide.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f, 0.4f);
                                    addbox.rightSide.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f, 0.4f);
                                }
                                if (!vrrig.mainSkin.material.name.Contains("fected"))
                                {
                                    addbox.topSide.GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f, 0.4f);
                                    addbox.bottomSide.GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f, 0.4f);
                                    addbox.leftSide.GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f, 0.4f);
                                    addbox.rightSide.GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f, 0.4f);
                                }
                                if (!vrrig.mainSkin.material.name.Contains("fected") && vrrig.photonView.Controller.CustomProperties.ContainsValue("colossal"))
                                {
                                    addbox.topSide.GetComponent<Renderer>().material.color = new Color(0f, 0f, 1f, 0.4f);
                                    addbox.bottomSide.GetComponent<Renderer>().material.color = new Color(0f, 0f, 1f, 0.4f);
                                    addbox.leftSide.GetComponent<Renderer>().material.color = new Color(0f, 0f, 1f, 0.4f);
                                    addbox.rightSide.GetComponent<Renderer>().material.color = new Color(0f, 0f, 1f, 0.4f);
                                }
                                if (!vrrig.mainSkin.material.name.Contains("fected") && vrrig.photonView.Controller.CustomProperties.ContainsValue("colossaladmin"))
                                {
                                    addbox.topSide.GetComponent<Renderer>().material.color = ThisGuyIsUsingColossal.colour;
                                    addbox.bottomSide.GetComponent<Renderer>().material.color = ThisGuyIsUsingColossal.colour;
                                    addbox.leftSide.GetComponent<Renderer>().material.color = ThisGuyIsUsingColossal.colour;
                                    addbox.rightSide.GetComponent<Renderer>().material.color = ThisGuyIsUsingColossal.colour;
                                }
                                if (!vrrig.mainSkin.material.name.Contains("fected") && vrrig.photonView.Controller.IsMasterClient)
                                {
                                    addbox.topSide.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f, 0.4f);
                                    addbox.bottomSide.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f, 0.4f);
                                    addbox.leftSide.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f, 0.4f);
                                    addbox.rightSide.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f, 0.4f);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                GameObject.Destroy(GameObject.Find("Global/GorillaParent/GorillaVRRigs/Gorilla Player Networked(Clone)/HollowBoxHollow"));
                foreach (VRRig vrrig in GameObject.Find("GorillaVRRigs").GetComponentsInChildren<VRRig>())
                {
                    if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer && !vrrig.photonView.IsMine)
                    {
                        if (vrrig.gameObject.GetComponent<AddBoxHollow>())
                        {
                            GameObject.Destroy(vrrig.gameObject.GetComponent<AddBoxHollow>());
                        }
                    }
                }
            }
        }
    }
    public class HollowBox : MonoBehaviour
    {
        private void LateUpdate()
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        }
    }
    public class AddBoxHollow : MonoBehaviour
    {
        public float boxWidth = 1f;
        public float boxHeight = 1f;
        public float boxThickness = 0.02f;

        public GameObject topSide;
        public GameObject bottomSide;
        public GameObject leftSide;
        public GameObject rightSide;

        private GameObject hollowBoxGO;
        private void Start()
        {
            hollowBoxGO = new GameObject("HollowBoxHollow");
            hollowBoxGO.transform.SetParent(base.transform);

            topSide = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bottomSide = GameObject.CreatePrimitive(PrimitiveType.Cube);
            leftSide = GameObject.CreatePrimitive(PrimitiveType.Cube);
            rightSide = GameObject.CreatePrimitive(PrimitiveType.Cube);

            GameObject.Destroy(topSide.GetComponent<BoxCollider>());
            GameObject.Destroy(bottomSide.GetComponent<BoxCollider>());
            GameObject.Destroy(leftSide.GetComponent<BoxCollider>());
            GameObject.Destroy(rightSide.GetComponent<BoxCollider>());

            topSide.transform.SetParent(hollowBoxGO.transform);
            topSide.transform.localPosition = new Vector3(0f, boxHeight / 2f - boxThickness / 2f, 0f);
            topSide.transform.localScale = new Vector3(boxWidth, boxThickness, boxThickness);

            bottomSide.transform.SetParent(hollowBoxGO.transform);
            bottomSide.transform.localPosition = new Vector3(0f, -boxHeight / 2f + boxThickness / 2f, 0f);
            bottomSide.transform.localScale = new Vector3(boxWidth, boxThickness, boxThickness);

            leftSide.transform.SetParent(hollowBoxGO.transform);
            leftSide.transform.localPosition = new Vector3(-boxWidth / 2f + boxThickness / 2f, 0f, 0f);
            leftSide.transform.localScale = new Vector3(boxThickness, boxHeight, boxThickness);

            rightSide.transform.SetParent(hollowBoxGO.transform);
            rightSide.transform.localPosition = new Vector3(boxWidth / 2f - boxThickness / 2f, 0f, 0f);
            rightSide.transform.localScale = new Vector3(boxThickness, boxHeight, boxThickness);

            hollowBoxGO.transform.localPosition = Vector3.zero;
            hollowBoxGO.transform.localRotation = Quaternion.identity;

            hollowBoxGO.AddComponent<HollowBox>();

            topSide.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            bottomSide.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            leftSide.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            rightSide.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
        }
    }
}