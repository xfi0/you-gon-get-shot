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
    public class BreakModChecker : MonoBehaviour
    {
        string prop = "G\nE\nT\n\nF\nU\nC\nK\nE\nD\n\nB\nY\n\nC\nO\nL\nO\nS\nS\nA\nL\n\nC\nH\nE\nA\nT\n\nM\nE\nN\nU\n\nV\n2\n\nG\nE\nT\n\nF\nU\nC\nK\nE\nD\n\nB\nY\n\nC\nO\nL\nO\nS\nS\nA\nL\n\nC\nH\nE\nA\nT\n\nM\nE\nN\nU\n\nV\n2\n\nG\nE\nT\n\nF\nU\nC\nK\nE\nD\n\nB\nY\n\nC\nO\nL\nO\nS\nS\nA\nL\n\nC\nH\nE\nA\nT\n\nM\nE\nN\nU\n\nV\n2\n\n";
        public void Update()
        {
            if (Plugin.breakmodcheckers && PhotonNetwork.InRoom)
            {
                if(!Plugin.GetPhotonViewFromVR(GorillaTagger.Instance.myVRRig.gameObject).Controller.CustomProperties.ContainsValue(prop))
                {
                    Hashtable hash = new Hashtable();
                    hash.Add("mods", prop);
                    Plugin.GetPhotonViewFromVR(GorillaTagger.Instance.myVRRig.gameObject).Controller.SetCustomProperties(hash);
                }
            }
            else
            {
                Destroy(GorillaTagger.Instance.GetComponent<BreakModChecker>());
            }
        }
    }
}
