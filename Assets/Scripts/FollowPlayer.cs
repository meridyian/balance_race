using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;

    void FixedUpdate()
    {
        Vector3 newPosition = target.position;
        // added to pull camera back to see
        newPosition.z = -10;

        transform.position = newPosition;
    }
}
