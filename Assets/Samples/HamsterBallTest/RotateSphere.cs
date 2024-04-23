using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSphere : MonoBehaviour
{
    Vector3 CalculateRotationDirection() {
        Quaternion rotation = transform.rotation;
        return rotation * Vector3.forward;
    }
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (CalculateRotationDirection().x > 5f || CalculateRotationDirection().y < 5f) {
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.transform.Rotate(transform.eulerAngles.x + 1, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            if (CalculateRotationDirection().x < 5f || CalculateRotationDirection().y > 5f) {
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.transform.Rotate(transform.eulerAngles.x - 1, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
    }
}
