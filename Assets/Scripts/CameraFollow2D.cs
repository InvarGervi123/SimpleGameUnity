using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;      // גרור לכאן את Player
    public Vector3 offset = Vector3.zero;
    public float smoothTime = 0.15f;

    Vector3 vel;

    void LateUpdate()
    {
        if (!target) return;
        var desired = new Vector3(target.position.x, target.position.y, transform.position.z) + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desired, ref vel, smoothTime);
    }
}
