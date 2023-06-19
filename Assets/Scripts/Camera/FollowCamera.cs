using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform cam;

    private void LateUpdate()
    {
        transform.LookAt(cam);
    }
}
