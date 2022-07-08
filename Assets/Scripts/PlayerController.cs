using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform right;
    public Transform down;
    public Transform left;
    public Transform up;
    public Text timer;
    
    public GameOverScreen GameOverScreen;

    private bool inside = false;
    private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        timer.text = "0";

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

        if(inside) {
            time += Time.deltaTime;
            int seconds =  (int)(time % 60);
            timer.text = seconds + "";
        }
        else {
            timer.text = "0";
            time = 0;
        }

        if(right.position.x > transform.position.x && down.position.z < transform.position.z && left.position.x < transform.position.x && up.position.z > transform.position.z )
        {
            Debug.Log("start");
            inside = true;
        }
        else {
            if(inside && up.position.z < transform.position.z) {
                Debug.Log("game over");
                GameOver();
            }
            inside = false;
            time = 0;
        }
    }

    public void GameOver() {
        GameOverScreen.Setup((int)time);
    }
}
