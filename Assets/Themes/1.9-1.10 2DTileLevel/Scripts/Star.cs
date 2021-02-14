using UnityEngine;

namespace UnityBase.TileLevel
{
    public class Star : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(gameObject);
        }
    }
}
