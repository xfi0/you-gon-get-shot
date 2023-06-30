using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colossal.Mods
{
    [HarmonyPatch(typeof(VRMapIndex), "MapMyFinger", MethodType.Normal)]
    class FingerIndex
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            if (Plugin.nofinger)
            {
                return false;
            }
            return true;
        }
    }
    [HarmonyPatch(typeof(VRMapMiddle), "MapMyFinger", MethodType.Normal)]
    class MiddleIndex
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            if (Plugin.nofinger)
            {
                return false;
            }
            return true;
        }
    }
    [HarmonyPatch(typeof(VRMapThumb), "MapMyFinger", MethodType.Normal)]
    class ThumbIndex
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            if (Plugin.nofinger)
            {
                return false;
            }
            return true;
        }
    }
}
