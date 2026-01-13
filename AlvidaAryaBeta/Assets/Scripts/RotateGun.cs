using UnityEngine;

public class RotateGun : MonoBehaviour
{
    [SerializeField] private GrapplingGun grapplingGun;

    private Quaternion desiredRotation;
    private float rotationSpeed = 10f;

    void Update()
    {
        if(!grapplingGun.IsGrappling()) {
            desiredRotation = transform.parent.rotation;
        }
        else {
            desiredRotation = Quaternion.LookRotation(grapplingGun.GetGrapplePoint() - transform.position);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }
}
