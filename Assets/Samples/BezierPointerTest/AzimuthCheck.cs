using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AzimuthCheck : MonoBehaviour
{
    public GameObject controller;
    public static bool modifyAzimuth = false;
    private float initLen = 0f;
    private float initAzimuthAngle = 0f;
    private float initAltitudeAngle = 0f;
    private float curLen = 0f;
    private float curAzimuthAngle = 0f;
    private float curAltitudeAngle = 0f;
    private float maxAzimuthLen = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (controller == null) {
            controller = GameObject.FindGameObjectWithTag("Controller");
        }
        initLen = controller.GetComponent<InputActionProperty>().action.GetBindingIndex();
        initAzimuthAngle = gameObject.transform.rotation.x;
        initAltitudeAngle = gameObject.transform.rotation.z;
        maxAzimuthLen = initLen;
    }

    // Update is called once per frame
    void Update()
    {
        curAzimuthAngle = gameObject.transform.rotation.x;
        curAltitudeAngle = gameObject.transform.rotation.z;
        curLen = (float)Math.Cos(initLen * curAzimuthAngle) + (float)Math.Sin(initLen * curAltitudeAngle);

        if (curLen == initLen) { 
            return;
        }
        if (curAzimuthAngle > initAzimuthAngle) {
            if (curAltitudeAngle > initAltitudeAngle) {
                modifyAzimuth = true;
            }
            else {
                modifyAzimuth = false;
            }
        }
        else {
            if (curAltitudeAngle > initAltitudeAngle) {
                modifyAzimuth = false;
            }
            else {
                modifyAzimuth = true;
            }
        }
        if (curAltitudeAngle > initAltitudeAngle) {
            if (curAzimuthAngle > initAzimuthAngle) {
                modifyAzimuth = false;
            }
            else {
                modifyAzimuth = true;
            }
        }
        else {
            if (curAzimuthAngle > initAzimuthAngle) {
                modifyAzimuth = true;
            }
            else {
                modifyAzimuth = false;
            }
        }
    }

    void LateUpdate() {
        if (modifyAzimuth) {
            curLen /= (float)(Math.Sqrt(3) / 2);
        }
        controller.transform.position = new Vector3(controller.transform.position.x, controller.transform.position.y, controller.transform.position.z - curLen);
    }
}
