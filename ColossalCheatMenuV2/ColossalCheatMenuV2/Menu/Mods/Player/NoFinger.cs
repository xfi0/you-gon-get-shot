using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colossal.Mods
{
    class LiterallyJustForABool
    {
        public static bool nofinger = false;
    }

    [HarmonyPatch(typeof(VRMapIndex), "MapMyFinger", MethodType.Normal)]
    class FingerIndex
    {
        public static bool Prefix()
        {
            if (LiterallyJustForABool.nofinger)
            {
                return false;
            }
            return true;
        }
    }
    [HarmonyPatch(typeof(VRMapMiddle), "MapMyFinger", MethodType.Normal)]
    class MiddleIndex
    {
        public static bool Prefix()
        {
            if (LiterallyJustForABool.nofinger)
            {
                return false;
            }
            return true;
        }
    }
    [HarmonyPatch(typeof(VRMapThumb), "MapMyFinger", MethodType.Normal)]
    class ThumbIndex
    {
        public static bool Prefix()
        {
            if (LiterallyJustForABool.nofinger)
            {
                return false;
            }
            return true;
        }
    }
}
