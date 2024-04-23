using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform ball;
    public Vector3 offset = new Vector3(0f, 0f, 0f);
    public float camSpeed = 0.25f;

    void LateUpdate()
    {
        if (ball != null && transform.position.x < 100f && transform.position.y > 50f)
        {
            Vector3 desiredPosition = ball.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, camSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(ball);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != ball.transform.position) {
            transform.position = ball.transform.position;
        }
    }
}
