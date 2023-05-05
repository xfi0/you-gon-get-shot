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
    public class FPSBooster : DynamicClass
    {
        public static bool fpsbooster = false;
        public void Update()
        {
            if (fpsbooster)
            {
                ParticleSystem[] particleSystems = GameObject.FindObjectsOfType<ParticleSystem>();
                foreach (ParticleSystem system in particleSystems)
                {
                    system.Stop();
                    system.gameObject.SetActive(false);
                }
                QualitySettings.masterTextureLimit = 5;
            }
            else
            {
                ParticleSystem[] particleSystems = GameObject.FindObjectsOfType<ParticleSystem>();
                foreach (ParticleSystem system in particleSystems)
                {
                    system.gameObject.SetActive(true);
                }
                QualitySettings.masterTextureLimit = 0;
            }
        }
    }
}
