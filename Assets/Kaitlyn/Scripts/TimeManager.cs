using System;
using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int minutes;
    public int Minutes
    {
        get { return minutes; } 
        set { minutes = value; OnMinuteChange(value); }
    }

    private int hours;
    public int Hours
    {
        get { return hours; }
        set { hours = value; OnHourChange(value); }
    }

    private int days;
    public int Days
    {
        get { return days; }
        set { days = value; }
    }

    private float tempSeconds;

    public Gradient gradientNightToSunrise;
    public Gradient gradientSunriseToDay;
    public Gradient gradientDayToSunset;
    public Gradient gradientSunsetToNight;
    public Light globalLight;

    private float currentTime;
    public float dayDuration = 180; // real seconds...


    void Start()
    {
        Time.timeScale = 100f; // __ times faster than rl seconds

        globalLight.intensity = .75f;
        hours = 7;
        globalLight.colorTemperature = 2981f;
        globalLight.color = new Color(1f, 0.8039216f, 0.627451f); // sunset color...
        //start an hour after sunrise


    }

    void Update()
    {
        tempSeconds = Time.deltaTime + tempSeconds;
        if(tempSeconds >= 60) // the seconds in each minute, resets each minute
        {
            minutes += 1;
            tempSeconds = 0;
            Debug.Log ("holy gleebus it works"); // i didnt think I was allowed to put swears in here :skull:
        }

        OnMinuteChange(minutes);
        OnHourChange(hours);

        currentTime = Time.deltaTime + currentTime;

        float rotationAngle = ((currentTime / 86400f) * 360f);

        globalLight.transform.rotation = Quaternion.Euler(50f, rotationAngle, 0f);
    }

    private void OnMinuteChange(int value)
    {
        globalLight.transform.Rotate(Vector3.up, (1f / dayDuration) * 1f, Space.World);
        if(value >= 60) //after 60 minutes add 1 hour and reset minutes after 24 hours add 1 day and reset hours, days never reset
        {
            hours++;
            minutes = 0;
        }
        if(hours >= 24)
        {
            days++;
            hours = 0;
            currentTime = 0;
        }
    }

    private void OnHourChange(int value)
    {
        if( value == 6) //sunrise
        {
            StartCoroutine(LerpLight(gradientNightToSunrise, 2f));
            StartCoroutine(FadeLightIntesity(.75f, 2981f, 2f));
        }
        else if (value == 8) //day
        {
            StartCoroutine(LerpLight(gradientSunriseToDay, 2f));
            StartCoroutine(FadeLightIntesity(1f, 5000, 2f));
        }
        else if(value == 18) //sunset
        {
            StartCoroutine(LerpLight(gradientDayToSunset, 2f));
            StartCoroutine(FadeLightIntesity(.75f, 2981f, 2f));
        }
        else if(value == 22) //night
        {
            StartCoroutine(LerpLight(gradientSunsetToNight, 2f));
            StartCoroutine(FadeLightIntesity(.4f, 15000f, 2f));
        }
    }

    private IEnumerator LerpLight(Gradient lightGradient , float time) //fade light
    {
        for (float i = 0; i < time; i += Time.deltaTime)
        {
            globalLight.color = lightGradient.Evaluate(i / time);
            yield return null;
        }
    }

    private IEnumerator FadeLightIntesity(float endIntensity, float endTemp,  float duration) //name says it all :man_juggling:
    {
        float timer = 0f;
        float startIntensity =  globalLight.intensity;
        float startTemp = globalLight.colorTemperature;

        while(timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            globalLight.intensity = Mathf.Lerp(startIntensity, endIntensity, t);
            globalLight.colorTemperature = Mathf.Lerp(startTemp, endTemp, t);
            yield return null;
        }
        globalLight.intensity = endIntensity;
        globalLight.colorTemperature = endTemp;
    }
}
