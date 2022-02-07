using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayCircle : MonoBehaviour
{
    public float angle = 0.1f;
    // Took it from a video
    // https://www.youtube.com/watch?v=nUSakJCxigQ&ab_channel=AlexVoxel
    void Update()
    {
            transform.RotateAround(Vector3.zero, Vector3.right,angle * Time.deltaTime);
    }
}
