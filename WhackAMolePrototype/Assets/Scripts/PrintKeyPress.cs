using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
public class PrintKeyPress : MonoBehaviour 
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    string letter;
    public List<KeyCode> keyCodes;
    //public UnityEvent<int> OnKeyPressed;
    public static Action<int> inputAction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode keyCode in keyCodes)
        {
            InputDeclaration(keyCode);
        }
    }
    public bool InputDeclaration(KeyCode code)
    {
        if (Input.GetKeyDown(code))
        {
            //print($"{ButtonCalled(code)} at index of: {ReturnIndexOfKeyPressed(code)}");
            //OnKeyPressed.Invoke(ReturnIndexOfKeyPressed(code));
            inputAction.Invoke(ReturnIndexOfKeyPressed(code));
            ButtonCalled(code);
            ReturnIndexOfKeyPressed(code);
        }
        return Input.GetKeyDown(code);
    }
    public string ButtonCalled (KeyCode x)
    {
        return x.ToString();
    }

    public int ReturnIndexOfKeyPressed(KeyCode code)
    {
        return keyCodes.FindIndex(go => go == code);
    }

    //the input manager needs to communicate and command the gridmanager to do the associated grid things.
}
