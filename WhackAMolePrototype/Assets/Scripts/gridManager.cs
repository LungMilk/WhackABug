using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Events;
using System;
public class gridManager : MonoBehaviour
{
    //public PrintKeyPress inputManager;
    //gridmanager needs to read the input sof the input manager I can access it by making a delegate action tha tis the button called then if that is called assign it with whatever.

    public List<GameObject> gridObjects;
    public List<Transform> gridPositions;
    public GameObject prefabGridObject;
    public float maxNumOfActiveButtons;
    public List<Bug> bugs;

    //public Color axtiveButtonColor;
    public GridObject chosenObject;

    public float timeInterval = 1f;
    private float currentTime;

    public ItemCollection bugLibrary;

    private List<int> availableIndices = new List<int>();

    public static Action<bool> comboAction;

    private void Start()
    {
        //PrintKeyPress.OnKeyPressed.AddListener(InputFunctionality);
        PrintKeyPress.inputAction += InputFunctionality;
        SetGridPositions();
    }

    [ContextMenu("SetGridObjects")]
    void SetGridPositions()
    {
        ClearGridObjects();

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
    //[ContextMenu("GetRandomPosition")]
    void GetGridPosition()
    {
        //if (chosenObject != null)
        //{
        //    chosenObject.SetObjectStatus(false);
        //}

        int randomIndex = UnityEngine.Random.Range(0, gridObjects.Count);
        //do we want it to be able to select the same space?
        chosenObject = gridObjects[randomIndex].GetComponent<GridObject>();
        //print(chosenObject.name);
        //chosenObject.SetObjectStatus(true);
        //now I want some way on how toreset its status;
    }

    //i need to somehow have a bug exist on this grid space adn when teh button is pressed the bug is destroyed.
    void SpawnBug()
    {
        //I need to randomly check all of my grid positions and then check if that random ones grid object is not occupied

        //functionality for getting a random index
        //functionality for checking if this random index is occupied 
        //functionality of finding another index and checking again
        int index = GetRandomUnusedIndex();
        Bug freshBug = Instantiate(bugLibrary.SelectRandomItem(), gridObjects[index].transform).GetComponent<Bug>();
        bugs.Add(freshBug);
        //gridObjects[index].GetComponent<GridObject>().SetObjectStatus(true);
        gridObjects[index].GetComponent<GridObject>().bug = freshBug;
    }
    int GetRandomUnusedIndex()
    {
        if (availableIndices.Count == 0)
        {
            InitializeAvailableIndicies();
        }

        int randomIndex = UnityEngine.Random.Range(0, availableIndices.Count);
        int actualIndex = availableIndices[randomIndex];

        availableIndices.RemoveAt(randomIndex);
        return actualIndex;
    }

    void InitializeAvailableIndicies()
    {
        availableIndices = new List<int>();
        for (int i = 0; i < gridObjects.Count; i++)
        {
            //now what I am missing is if it is available being added back into the index
            if (!gridObjects[i].GetComponent<GridObject>().occupied)
            {
                availableIndices.Add(i);
            }
        }
    }

    private void Update()
    {
        InitializeAvailableIndicies();
        //all that needs to happen is I want a timer that every few seconds changes the active button.
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            currentTime = timeInterval;
            //SpawnBug();
            //GetGridPosition();
        }
        
    }

    public void InputFunctionality(int inputIndex)
    {
        //print(inputIndex.ToString())
        //print(DoesButtonContainBug(inputIndex));
        GridObject inputGridObject = gridObjects[inputIndex].GetComponent<GridObject>();
        //print(inputIndex);

        //comboAction.Invoke(DoesButtonContainBug(inputIndex));
        inputGridObject.ClearObjectsInSpace();
        //inputGridObject.StartCoroutine(inputGridObject.ChangeColors());
        ////gridObjects[inputIndex - 1 < 0 || inputIndex - 1 > gridObjects.Count ? 0 : inputIndex - 1].GetComponent<GridObject>().SetObjectStatus(false);
        //inputGridObject.SetObjectStatus(!inputGridObject.occupied);
        //inputGridObject.bug.Squashed();
        //bugs.RemoveAt(inputIndex - 1);
        inputGridObject.SetObjectStatus();
        inputGridObject.Invoke("SetObjectStatus", inputGridObject.feedbackColorLength);
    }

    public bool DoesButtonContainBug(int index)
    {
        GridObject pressedObject = gridObjects[index].GetComponent<GridObject>();
        if (pressedObject.occupied) {return true;}
        else {return false;}
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
