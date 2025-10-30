using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class SpawnerManager : MonoBehaviour
{
    public List<Spawner> spawners;
    public ExponentialValueOverTime rateIncreaseObject;

    private void Update()
    {
        foreach (Spawner spawner in spawners)
        {
            spawner.spawnRate = rateIncreaseObject.GetCurrentValue();
        }
    }
}
