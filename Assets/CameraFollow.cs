using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -10);
    public float rotateSpeed = 5;

    private void LateUpdate()
    {
        Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed, Vector3.up);

        offset = camTurnAngle * offset;

        Vector3 newPos = target.position + offset;
        transform.position = Vector3.Slerp(transform.position, newPos, 0.1f);

        transform.LookAt(target);
    }
}