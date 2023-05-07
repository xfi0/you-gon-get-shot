using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class FPSBooster : MonoBehaviour
    {
        public void Update()
        {
            if (Plugin.fpsbooster)
            {
                ParticleSystem[] particleSystems = GameObject.FindObjectsOfType<ParticleSystem>();
                foreach (ParticleSystem system in particleSystems)
                {
                    system.Stop();
                    system.gameObject.SetActive(false);
                }
                Renderer[] renderers = GameObject.FindObjectsOfType<Renderer>();
                foreach (Renderer renderer in renderers)
                {
                    renderer.shadowCastingMode = ShadowCastingMode.Off;
                }
                QualitySettings.masterTextureLimit = 10;
            }
            else
            {
                ParticleSystem[] particleSystems = GameObject.FindObjectsOfType<ParticleSystem>();
                foreach (ParticleSystem system in particleSystems)
                {
                    system.gameObject.SetActive(true);
                }
                Renderer[] renderers = GameObject.FindObjectsOfType<Renderer>();
                foreach (Renderer renderer in renderers)
                {
                    renderer.shadowCastingMode = ShadowCastingMode.On;
                }
                QualitySettings.masterTextureLimit = 0;

                Destroy(Plugin.hud.GetComponent<FPSBooster>());
            }
        }
    }
}
