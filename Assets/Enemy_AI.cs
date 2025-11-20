using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public GameObject player;
    public float movespeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < 0)
        {
            Vector3 newVelocity = myRigidbody.linearVelocity;
            newVelocity.z = -movespeed;
        }
    }
}
