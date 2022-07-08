using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform right;
    public Transform down;
    public Transform left;
    public Transform up;

    private bool inside = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        { 
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A)) { 
            transform.Rotate(0, -0.5f, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0.5f, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        if(right.position.x > transform.position.x && down.position.z < transform.position.z && left.position.x < transform.position.x && up.position.z > transform.position.z )
        {
            inside = true;
        }
        else {
            if(inside && up.position.z < transform.position.z) {
                Debug.Log("finish");
            }
            inside = false;
        }



    }
}
