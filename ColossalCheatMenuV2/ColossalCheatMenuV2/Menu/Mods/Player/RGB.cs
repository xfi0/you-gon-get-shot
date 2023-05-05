using GorillaNetworking;
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
    public class RGB : DynamicClass
    {
        public static bool rbg = false;
        public float lastRequestTime;
        public float delayTime = 2f;
        private float colorTimer = 0f;
        private Color guiColor = Color.red;
        public void Update()
        {
            if (rbg)
            {
                GorillaNot.instance.rpcCallLimit = int.MaxValue;
                float r = Mathf.Lerp(0f, 1f, Mathf.Abs(Mathf.Sin(colorTimer * 0.4f)));
                float g = Mathf.Lerp(0f, 1f, Mathf.Abs(Mathf.Sin(colorTimer * 0.5f)));
                float b = Mathf.Lerp(0f, 1f, Mathf.Abs(Mathf.Sin(colorTimer * 0.6f)));
                guiColor = new Color(r, g, b);
                colorTimer += Time.deltaTime;

                bool done = Time.time - lastRequestTime < delayTime;
                if (!done && !GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId))
                {
                    if (!GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId))
                    {
                        GorillaTagger.Instance.myVRRig.enabled = false;
                        GorillaTagger.Instance.myVRRig.transform.position = new Vector3(-66.7547f, 11.7153f, -82.9372f);
                    }
                    else if (GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId))
                    {
                        GorillaTagger.Instance.UpdateColor(guiColor.r, guiColor.g, this.guiColor.b);
                        GorillaTagger.Instance.myVRRig.photonView.RPC("InitializeNoobMaterial", RpcTarget.All, new object[]
                        {
                            guiColor.r,
                            guiColor.g,
                            guiColor.b,
                            true
                        });
                        GorillaTagger.Instance.myVRRig.enabled = true;
                        lastRequestTime = Time.time;
                    }
                }
            }
        }
    }
}
