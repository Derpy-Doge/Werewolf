using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public GameObject player;
    public float movespeed = 10f;
    public float xfollow;
    public float zfollow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Sqrt((player.transform.position.x - transform.position.x) * (player.transform.position.x - transform.position.x) + (player.transform.position.z - transform.position.z) * (player.transform.position.z - transform.position.z)) <= 5)
        {
            Vector3 newVelocity = new (xfollow, 0, zfollow);
            newVelocity.x = movespeed;
            newVelocity.z = movespeed;
            myRigidbody.linearVelocity = newVelocity;
        }
        
    }
    void FixedUpdate()
    {
        xfollow = (player.transform.position.x - transform.position.x);
        zfollow = (player.transform.position.z - transform.position.z);
    }
}
