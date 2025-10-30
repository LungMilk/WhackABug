using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
public class GoalManager : MonoBehaviour
{
    public List<GameObject> goalList;
    public float numberOfGoals;
    public int deathThreshold;
    private int lossCondition;
    private void Start()
    {
        numberOfGoals = goalList.Count;
    }
    //we are assuming our goals deletethemselves
    private void Update()
    {
        if(deathThreshold == lossCondition)
        {
            End();
        }

        for (int i = 0; i < goalList.Count; i++)
        {
            if (goalList[i] == null)
            {
                deathThreshold++;
                goalList.RemoveAt(i);
            }
        }
    }

    private void End()
    {

    }
}
