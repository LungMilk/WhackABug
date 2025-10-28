using UnityEngine;


[CreateAssetMenu(fileName = "NewBugSO.asset", menuName = "Data/Bug Scriptable Object")]
[System.Serializable]
public class BugSO : ScriptableObject
{
    public string displayName;
    public Sprite displayImage;
    //[CustomPreview(Mesh.AcquireReadOnlyMeshData())] hopefully something works
    public GameObject objectPrefab;
}
