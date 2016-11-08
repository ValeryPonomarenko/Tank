using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform FollowingObject;

    private void Update()
    {
        transform.position = FollowingObject.position;
        transform.rotation = FollowingObject.rotation;
    }
}