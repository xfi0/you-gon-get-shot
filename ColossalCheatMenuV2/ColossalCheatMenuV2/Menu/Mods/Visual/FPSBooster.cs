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
            if (Plugin.fpsbooster) {
                ParticleSystem[] particleSystems = GameObject.FindObjectsOfType<ParticleSystem>();
                foreach (ParticleSystem system in particleSystems) {
                    system.Stop();
                    if (system.gameObject.active) {
                        system.gameObject.SetActive(false);
                    }
                }
                Renderer[] renderers = GameObject.FindObjectsOfType<Renderer>();
                foreach (Renderer renderer in renderers) {
                    if (renderer.shadowCastingMode == ShadowCastingMode.On) {
                        renderer.shadowCastingMode = ShadowCastingMode.Off;
                    }
                }
                if (QualitySettings.masterTextureLimit == 0) {
                    QualitySettings.masterTextureLimit = 10;
                }
            } else {
                ParticleSystem[] particleSystems = GameObject.FindObjectsOfType<ParticleSystem>();
                foreach (ParticleSystem system in particleSystems) {
                    if (!system.gameObject.active) {
                        system.gameObject.SetActive(true);
                    }
                }
                Renderer[] renderers = GameObject.FindObjectsOfType<Renderer>();
                foreach (Renderer renderer in renderers) {
                    if (renderer.shadowCastingMode != ShadowCastingMode.Off) {
                        renderer.shadowCastingMode = ShadowCastingMode.On;
                    }
                }
                if (QualitySettings.masterTextureLimit == 10) {
                    QualitySettings.masterTextureLimit = 0;
                }

                Destroy(GorillaTagger.Instance.GetComponent<FPSBooster>());
            }
        }
    }
}
