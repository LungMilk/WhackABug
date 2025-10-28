using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "BugCollection.Asset", menuName = "Data/Bug Collection")]
public class ItemCollection : ScriptableObject
{
    public List<BugSO> Items;
    public Object SelectRandomItem()
    {
        int index = Random.Range(0, Items.Count);
        return Items[index].objectPrefab;
    }
}
