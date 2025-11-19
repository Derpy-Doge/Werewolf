using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public float movespeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            Vector3 newVelocity = myRigidbody.linearVelocity;
            newVelocity.x = -movespeed;

            myRigidbody.linearVelocity = newVelocity;
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            Vector3 newVelocity = myRigidbody.linearVelocity;
            newVelocity.x = movespeed;

            myRigidbody.linearVelocity = newVelocity;
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            Vector3 newVelocity = myRigidbody.linearVelocity;
            newVelocity.z = -movespeed;

            myRigidbody.linearVelocity = newVelocity;
        }
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            Vector3 newVelocity = myRigidbody.linearVelocity;
            newVelocity.z = movespeed;

            myRigidbody.linearVelocity = newVelocity;
        }

    }
}
