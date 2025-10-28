using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
public class gridManager : MonoBehaviour
{
    public List<GameObject> gridObjects;
    public List<Transform> gridPositions;
    public GameObject prefabGridObject;
    public float maxNumOfActiveButtons;
    //public Color axtiveButtonColor;
    public GridObject chosenObject;

    public float timeInterval = 1f;
    private float currentTime;

    [ContextMenu("SetGridObjects")]
    void SetGridPositions()
    {
        //ClearGridObjects();

        foreach (Transform transform in gridPositions)
        {
            gridObjects.Add(Instantiate(prefabGridObject,transform));
        }

        for (int i = 0; i < gridPositions.Count; i++)
        {
            //gridObjects[i].transform.position = gridPositions[i].position;
            GridObject chosenObject = gridObjects[i].GetComponent<GridObject>();
            chosenObject.name = (i +1).ToString();
        }
    }
    [ContextMenu("ClearGridObjects")]
    void ClearGridObjects()
    {
        for (int i = 0; i < gridObjects.Count; i++)
        {
            //gridObjects[i].transform.position = gridPositions[i].position;
            print("destroying " + i.ToString() + gridObjects[i].gameObject.name);
            DestroyImmediate(gridObjects[i]);
        }
        gridObjects.Clear();
    }
    [ContextMenu("GetRandomPosition")]
    void GetGridPosition()
    {
        if (chosenObject != null)
        {
            chosenObject.SetObjectStatus(false);
        }

        int randomIndex = Random.Range(0, gridObjects.Count);
        //do we want it to be able to select the same space?
        chosenObject = gridObjects[randomIndex].GetComponent<GridObject>();
        print(chosenObject.name);
        chosenObject.SetObjectStatus(true);
        //now I want some way on how toreset its status;
    }

    private void Update()
    {
        //all that needs to happen is I want a timer that every few seconds changes the active button.
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            currentTime = timeInterval;
            GetGridPosition();
        }
        if (Input.anyKey)
        {
            gridObjects[ReadKeypadInput() > gridObjects.Count ? 0:ReadKeypadInput() -1].GetComponent<GridObject>().SetObjectStatus(false);
            print(ReadKeypadInput());
        }
    }

    int ReadKeypadInput()
    {
        if (Input.GetKeyDown("[0]"))
        {
            return 0;
        }
        if (Input.GetKeyDown("[1]"))
        {
            return 1;
        }
        if (Input.GetKeyDown("[2]"))
        {
            return 2;
        }
        if (Input.GetKeyDown("[3]"))
        {
            return 3;
        }
        if (Input.GetKeyDown("[4]"))
        {
            return 4;
        }
        if (Input.GetKeyDown("[5]"))
        {
            return 5;
        }
        if (Input.GetKeyDown("[6]"))
        {
            return 6;
        }
        if (Input.GetKeyDown("[7]"))
        {
            return 7;
        }
        if (Input.GetKeyDown("[8]"))
        {
            return 8;
        }
        if (Input.GetKeyDown("[9]"))
        {
            return 9;
        }
        else return 0;
    }
}
