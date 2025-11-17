using UnityEngine;

public class DayNightCycle : MonoBehaviour
{

    public Light sunLight;
    public Light moonLight;

    public float dayDuration = 1140f;
    private float currentTime = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        currentTime += Time.deltaTime / dayDuration;
        if (currentTime >= 1f)
        {
            currentTime = -1f;
        }

        float rotationAngle = currentTime * 360;
        sunLight.transform.rotation = Quaternion.Euler(rotationAngle, 0f, 0f);
    }
}
