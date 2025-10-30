using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ExponentialValueOverTime : MonoBehaviour
{
    //public AnimationCurve scalingOverTime;

    //public float scalingValue = 1f;
    //private float currentTime;

    public float initialValue = 1f;
    public float growthRate = 1.1f;
    private float currentValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //currentTime = 0;
        currentValue = initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        currentValue = initialValue * Mathf.Pow(growthRate, Time.time);
        //print("current value" + currentValue);

        //issue is animation curve is a value between 0 and 1
        //I want to normalize our scaling ot reach max scaling after 
        //currentTime += Time.deltaTime / minuteMilestones[minuteMilestones.Count -1];
        //scalingValue *= scalingOverTime.Evaluate(currentTime);
        //foreach (float milestone in minuteMilestones)
        //{
        //    if (currentTime < milestone)
        //    {
        //        //print(milestone);
        //    }
        //}
    }
    public float GetCurrentValue()
    {
        return currentValue;
    }
}
