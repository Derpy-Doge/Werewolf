using System;
using System.Collections;
using UnityEngine;

// if days go from 7am to 8pm(or 20:00) itll be abt 6 and a half minutes

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
    public float dayDuration = 180; // minutes? idek atp...

    public bool isDay;
    public bool isNight;


    void Start()
    {
        Time.timeScale = 1f; // __ times faster than rl seconds... didnt end up using it cause like i cant do math :skull:

        globalLight.intensity = .75f;
        hours = 7;
        globalLight.colorTemperature = 2981f;
        globalLight.color = new Color(1f, 0.8039216f, 0.627451f); // sunset color...
        //start an hour after sunrise

        isDay = true;
        isNight = false;
    }

    void Update()
    {
        tempSeconds = Time.deltaTime + tempSeconds;
        if(tempSeconds >= .5f) // the seconds in each minute, resets each minute
        {
            minutes ++;
            tempSeconds = 0;
            Debug.Log ("holy gleebus it works"); // i didnt think I was allowed to put swears in here :skull:
        }

        OnMinuteChange(minutes);
        OnHourChange(hours);

        currentTime = Time.deltaTime + currentTime;

        float rotationAngle = ((currentTime / 720f) * 360f);

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
            StartCoroutine(LerpLight(gradientNightToSunrise, 5f));
            StartCoroutine(FadeLightIntesity(.75f, 2981f, 5f));
            isDay = true;
            isNight = false;
        }
        else if (value == 8) //day
        {
            StartCoroutine(LerpLight(gradientSunriseToDay, 5f));
            StartCoroutine(FadeLightIntesity(1f, 5000, 5f));
        }
        else if(value == 18) //sunset
        {
            StartCoroutine(LerpLight(gradientDayToSunset, 5f));
            StartCoroutine(FadeLightIntesity(.75f, 2981f, 5f));
        }
        else if(value == 20) //night
        {
            StartCoroutine(LerpLight(gradientSunsetToNight, 5f));
            StartCoroutine(FadeLightIntesity(.4f, 15000f, 5f));
            isDay = false;
            isNight = true;
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
