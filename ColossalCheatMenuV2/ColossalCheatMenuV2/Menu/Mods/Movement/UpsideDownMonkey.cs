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
    public class UpsideDownMonkey : MonoBehaviour
    {
        public void Update()
        {
            if (Plugin.upsidedownmonkey)
            {
                GorillaLocomotion.Player.Instance.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                try
                {
                    foreach (VRRig vrrig in Resources.FindObjectsOfTypeAll<VRRig>())
                    {
                        if (vrrig.photonView.IsMine)
                        {
                            vrrig.gameObject.transform.Find("gorilla").GetComponent<Renderer>().enabled = false;
                        }
                    }
                    try
                    {
                        foreach (VRRig vrrig2 in Resources.FindObjectsOfTypeAll<VRRig>())
                        {
                            if (vrrig2.photonView.IsMine)
                            {
                                UnityEngine.Object.FindObjectsOfType<VRRig>();
                            }
                        }
                        GorillaLocomotion.Player.Instance.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }
            }
            else
            {
                GorillaLocomotion.Player.Instance.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                try
                {
                    foreach (VRRig vrrig3 in Resources.FindObjectsOfTypeAll<VRRig>())
                    {
                        if (vrrig3.photonView.IsMine)
                        {
                            vrrig3.gameObject.transform.Find("gorilla").GetComponent<Renderer>().enabled = true;
                        }
                    }
                    try
                    {
                        foreach (VRRig vrrig4 in Resources.FindObjectsOfTypeAll<VRRig>())
                        {
                            if (vrrig4.photonView.IsMine)
                            {
                                UnityEngine.Object.FindObjectsOfType<VRRig>();
                            }
                        }
                        GorillaLocomotion.Player.Instance.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }


                Destroy(GorillaTagger.Instance.GetComponent<UpsideDownMonkey>());
            }
        }
    }
}
