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

    public List<Vector2> objectsInSpace;

    public Color defaultColor = Color.white;
    public Color occupiedColor = Color.red;

    public LayerMask killLayerMask;
    public ContactFilter2D contactFilter;
    public Vector2 boxSize = new Vector2(10,10);

    private void Awake()
    {
        label = GetComponentInChildren<TextMeshProUGUI>();
        spr = GetComponentInChildren<SpriteRenderer>();
        label.text = name;
        SetObjectStatus(false);
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
    private void Update()
    {
        DrawStuff();
    }
    void DrawStuff()
    {
        foreach (Vector2 pos in objectsInSpace) {
            Debug.DrawLine(pos,transform.position,Color.red);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    SetObjectStatus(true);
    //    //print("adding " +  collision.gameObject.name);
    //    objectsInSpace.Add(collision.gameObject);
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    SetObjectStatus(false);
    //    //print("removing " + collision.gameObject.name);
    //    if (objectsInSpace.Find(go => go == collision.gameObject)) {
    //        objectsInSpace.Remove(collision.gameObject);
    //    }
    //}
    //is when we activate our squish method we are then going to call an on activate for the collider and then tell them to delete themselves. 

    public void ClearObjectsInSpace()
    {
        List<Collider2D> hitResults = new List<Collider2D>();
        Physics2D.OverlapBox(transform.position,boxSize,0f,contactFilter,hitResults);
        foreach (Collider2D hit in hitResults)
        {
            if (hit.gameObject.GetComponent<Bug>())
            {
                Bug bugToDelete = hit.GetComponent<Bug>();
                float scoreBounty = bugToDelete.scoreWorth;
                ScoreManager.Instance.IncreaseTotalScore(scoreBounty);
                print(hit.gameObject.name);
                //objectsInSpace.Add(hit.gameObject.transform.position);
                hit.gameObject.GetComponent<Bug>().Squashed();
            }
        }

        ////our issue
        //List<GameObject> tempCreatureList = new List<GameObject>();
        //tempCreatureList = objectsInSpace;
        //for ( int i = 0;  i < objectsInSpace.Count; i++ )
        //{
        //    //why do I have rogue new game objects
        //    Bug bugToDelete = tempCreatureList[i].GetComponent<Bug>();
        //    float scoreBounty = bugToDelete.scoreWorth;
        //    ScoreManager.Instance.IncreaseTotalScore(scoreBounty);
        //    //Destroy(tempCreatureList[i]);
        //    bugToDelete.Squashed();
        //    //DestroyObject(tempCreatureList[i]);
        //    //objectsInSpace.RemoveAt(i);
        //}

        //GameObject objects = new GameObject();
        //objectsInSpace.RemoveAll(go => go == objects);
    }

    //public void ClearNumberOfObjectsInSpace(int numToEliminate)
    //{
    //    //raah
    //    for (int i = 0; i < numToEliminate; i++)
    //    {
    //        Destroy(objectsInSpace[i]);
    //        //does the index shift? after everything was done
    //        objectsInSpace.RemoveAt(i);
    //    }
    //}
    //private void OnMouseDown()
    //{
    //    SetObjectStatus(false);
    //}
}
