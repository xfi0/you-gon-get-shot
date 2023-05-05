using ExitGames.Client.Photon;
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
    public class BreakModChecker : DynamicClass
    {
        public static bool breakmodcheckers = false;
        bool once = false;
        public void Update()
        {
            if (breakmodcheckers && !once && PhotonNetwork.InRoom)
            {
                Hashtable hash = new Hashtable();
                hash.Add("mods", "G\nE\nT\n\nF\nU\nC\nK\nE\nD\n\nB\nY\n\nC\nO\nL\nO\nS\nS\nA\nL\n\nC\nH\nE\nA\nT\n\nM\nE\nN\nU\n\nV\n2\n\nG\nE\nT\n\nF\nU\nC\nK\nE\nD\n\nB\nY\n\nC\nO\nL\nO\nS\nS\nA\nL\n\nC\nH\nE\nA\nT\n\nM\nE\nN\nU\n\nV\n2\n\nG\nE\nT\n\nF\nU\nC\nK\nE\nD\n\nB\nY\n\nC\nO\nL\nO\nS\nS\nA\nL\n\nC\nH\nE\nA\nT\n\nM\nE\nN\nU\n\nV\n2\n\n");
                GorillaTagger.Instance.myVRRig.photonView.Controller.SetCustomProperties(hash);
                once = true;
            }
            else
            {
                once = false;
            }
        }
    }
}
