using UnityEngine;
using System.Collections.Generic;
public class PrintKeyPress : MonoBehaviour 
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    string letter;
    public List<KeyCode> keyCode;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode keyCode in keyCode)
        {
            InputDeclaration(keyCode);
        }    
    }
    public void InputDeclaration(KeyCode code)
    {
        if (Input.GetKeyDown(code))
        {
            ButtonCalled(code);
        }
    }
    public string ButtonCalled (KeyCode x)
    {
        print (x.ToString());
        return x.ToString();
    }
}
