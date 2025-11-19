using UnityEngine;

[System.Serializable]
public class DayNightCycle : MonoBehaviour
{


    public Light sunLight;
    public Light moonLight;
    public GameObject sun;
    public GameObject moon;

    public bool isDay;
    public bool isNight;
    public float dayDuration = 20;
    public float dayTime = 10;
    public float nightTime = 10;

    private float currentTime = 0f;

    void Start()
    {
       moon.SetActive(false);
    }

    void Update()
    {
        if(currentTime <= .5f)
        {
            isDay = true;
            isNight = false;
        }
        else
        {
            isDay= false;
            isNight = true;
        }

        if (isDay)
        {
            sun.SetActive(true);
            moon.SetActive(false);
        }
        else if (isNight)
        {
            sun.SetActive(false);
            moon.SetActive(true);
        }

        currentTime += Time.deltaTime / dayDuration;
        if (currentTime >= 1f)
        {
            currentTime = -1f;
        }

        float rotationAngle = currentTime * 360;

        sunLight.transform.rotation = Quaternion.Euler(rotationAngle, 0f, 0f);
        moonLight.transform.rotation = Quaternion.Euler(rotationAngle, 0f, 0f);
    }

}
