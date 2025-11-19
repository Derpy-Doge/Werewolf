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

    

    void Start()
    {
        
    }

    void Update()
    {
        tempSeconds = Time.deltaTime;
        if(tempSeconds >= 1)
        {
            minutes += 1;
            tempSeconds = 0;
        }
    }

    private void OnMinuteChange(int value)
    {
        globalLight.transform.Rotate(Vector3.up, (1f / 720) * 360f, Space.World);
        if(value >= 60)
        {
            hours++;
            minutes = 0;
        }
        if(hours >= 24)
        {
            days++;
            hours = 0;
        }
    }

    private void OnHourChange(int value)
    {
        if( value == 6)
        {
            StartCoroutine(LerpLight(gradientNightToSunrise, 10f));
        }
        else if (value == 8) 
        {
            StartCoroutine(LerpLight(gradientSunriseToDay, 10f));
        }
        else if(value == 18)
        {
            StartCoroutine(LerpLight(gradientDayToSunset, 10f));
        }
        else if(value == 22)
        {
            StartCoroutine(LerpLight(gradientSunsetToNight, 10f));
        }
    }

    private IEnumerator LerpLight(Gradient lightGradient , float time)
    {
        for (float i = 0; i < time; i += Time.deltaTime)
        {
            globalLight.color = lightGradient.Evaluate(i / time);
            yield return null;
        }
    }
}
