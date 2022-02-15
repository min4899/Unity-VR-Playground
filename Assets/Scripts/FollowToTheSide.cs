using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An inventory space that follows the player.
public class FollowToTheSide : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void FixedUpdate()
    {
        transform.position = target.position + Vector3.up * offset.y
            // Inventory space should remain horizontal even if player tilts headset side to side.
            + Vector3.ProjectOnPlane(target.right, Vector3.up).normalized * offset.x
            + Vector3.ProjectOnPlane(target.forward, Vector3.up).normalized * offset.z;

        // Inventory space follows headset when rotating.
        transform.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
    }
}
