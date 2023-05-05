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
    public class AntiDestroyPlayerObjects : DynamicClass
    {
        public void Update()
        {
            if (PhotonNetwork.InRoom)
            {
                if(PhotonNetwork.LocalPlayer == null || GorillaTagger.Instance.myVRRig.photonView == null || GorillaTagger.Instance.myVRRig == null)
                {
                    PhotonNetwork.RegisterPhotonView(GorillaTagger.Instance.myVRRig.photonView);
                }
            }
        }
    }
}