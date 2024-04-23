using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    public float speed = 20f;
    public bool debug = false;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody>() == null) {
            gameObject.AddComponent<Rigidbody>();
        }
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (debug) {
            if (Input.GetKeyDown(KeyCode.W)) {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z+1);
            }
            if (Input.GetKeyDown(KeyCode.A)) {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x-1, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.S)) {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z-1);
            }
            if (Input.GetKeyDown(KeyCode.D)) {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x+1, gameObject.transform.position.y, gameObject.transform.position.z);
            }
        }
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            rb.velocity = movement * speed;
        }
        else
        {
            // stop the ball when no movement indicated
            rb.velocity = Vector3.zero;
        }
    }
}
