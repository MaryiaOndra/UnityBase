using UnityEngine;

namespace UnityBase.PyramidShooter
{
    public class SphereShooter : MonoBehaviour
    {
        [SerializeField] GameObject spherePrefab;
        [SerializeField] Transform spherePointTr;

        float power = 50f;
        float destroyDelay = 5;
        Rigidbody sphereRigidbody;
        GameObject activeSphere;

        void Start()
        {
            PrepareSphere();
        }

        void Update()
        {
            FollowPoint();
            ShootSphere();
        }

        void PrepareSphere()
        {
            activeSphere = Instantiate(spherePrefab);
            activeSphere.GetComponent<SphereBhv>().LifeTime = destroyDelay;
            sphereRigidbody = activeSphere.GetComponent<Rigidbody>();
            ChangeSphereState(true);
        }

        void FollowPoint()
        {
            activeSphere.transform.position = spherePointTr.position;
            activeSphere.transform.rotation = spherePointTr.rotation;
        }

        void ShootSphere()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
            {
                ChangeSphereState(false);
                activeSphere.GetComponent<SphereBhv>().Shoot();
                sphereRigidbody.AddForce(transform.forward * power, ForceMode.Impulse);
                PrepareSphere();
            }
        }

        void ChangeSphereState(bool state)
        {
            sphereRigidbody.isKinematic = state;
            sphereRigidbody.GetComponent<Collider>().isTrigger = state;
        }
    }
}
