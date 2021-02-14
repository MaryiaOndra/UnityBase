using UnityEngine;

namespace UnityBase.PyramidShooter
{
    public class SphereBhv : MonoBehaviour
    {
        public void Shoot()
        {
            Destroy(gameObject, LifeTime);
        }
        public float LifeTime { get; set; }
    }
}
