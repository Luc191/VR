using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    bool IsPressed;
    public GameObject Spindel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (IsPressed)
            Spindel.transform.Rotate(0, 3, 0);
    }
    public void ButtonIsPressed()
    {
        IsPressed = true;
    }
    public void ButtonIsUnpressed()
    {
        IsPressed = false;
    }
}
