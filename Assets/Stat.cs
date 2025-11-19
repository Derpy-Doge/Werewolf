using UnityEngine;

public class HealthStat : MonoBehaviour
{
    public float health;
    public float speed;
    public float attack;
    public float defense;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 100;
        speed = 10; 
        attack = 15;
        defense = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
