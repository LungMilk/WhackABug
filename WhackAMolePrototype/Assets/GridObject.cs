using UnityEngine;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;
public class GridObject : MonoBehaviour
{
    public int position;
    public string name;
    public TextMeshProUGUI label;
    public Transform spawnPosition;
    private SpriteRenderer spr;
    public bool occupied;
    public Bug bug;

    public List<GameObject> objectsInSpace;

    public Color defaultColor = Color.white;
    public Color occupiedColor = Color.red;

    private void Awake()
    {
        label = GetComponentInChildren<TextMeshProUGUI>();
        spr = GetComponentInChildren<SpriteRenderer>();
        label.text = name;
    }

    public void SetObjectStatus(bool Occupied)
    {
        occupied = Occupied;
        if (Occupied) 
        {
            spr.color = occupiedColor;
        }else
        {
            spr.color=defaultColor;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetObjectStatus(true);
        print("adding " +  collision.gameObject.name);
        objectsInSpace.Add(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        SetObjectStatus(false);
        print("removing " + collision.gameObject.name);
        if (objectsInSpace.Find(go => go == collision.gameObject)) {
            objectsInSpace.Remove(collision.gameObject);
        }
    }

    public void ClearObjectsInSpace()
    {
        foreach (GameObject obj in objectsInSpace)
        {
            Destroy(obj);
            objectsInSpace.Remove(obj);
        }

    }

    public void ClearNumberOfObjectsInSpace(int numToEliminate)
    {
        //raah
        for (int i = 0; i < numToEliminate; i++)
        {
            Destroy(objectsInSpace[i]);
            //does the index shift? after everything was done
            objectsInSpace.RemoveAt(i);
        }
    }
    //private void OnMouseDown()
    //{
    //    SetObjectStatus(false);
    //}
}
