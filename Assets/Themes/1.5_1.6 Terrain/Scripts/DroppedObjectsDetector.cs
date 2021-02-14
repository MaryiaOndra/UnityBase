using UnityEngine;

namespace UnityBase.Terrain
{
    public class DroppedObjectsDetector : MonoBehaviour
    {
        DroppedObject[] objectsToDrop;
        int countDroppedObjects;

        public bool IsAllObjectsDropped { get; private set; }

        void Awake()
        {
            objectsToDrop = GetComponentsInChildren<DroppedObject>();
        }

        void Update()
        {
            if (!IsAllObjectsDropped)
            {
                foreach (var level in objectsToDrop)
                {
                    if (!level.IsDropped)
                    {
                        countDroppedObjects = 0;
                    }
                    else
                    {
                        countDroppedObjects++;

                        if (countDroppedObjects == objectsToDrop.Length)
                        {
                            IsAllObjectsDropped = true;
                            Debug.Log("Youre complete this level");
                        }
                    }
                }
            }
        }
    }
}
