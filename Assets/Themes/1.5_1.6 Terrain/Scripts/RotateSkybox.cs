
using UnityEngine;

namespace UnityBase.Terrain
{
    namespace TerrainLightAudio
    {
        public class RotateSkybox : MonoBehaviour
        {
            [SerializeField] float rotationSpeed = 0.2f;

            void Update()
            {
                RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
            }
        }
    }
}
