using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;



public class Wheel : MonoBehaviour
{
    public GameObject Carriage;
    public GameObject _wheel;
    Vector3 buffer;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        buffer = Carriage.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        angle = _wheel.GetComponent<CircularDrive>().outAngle;
        Carriage.transform.position = buffer + new Vector3((float)0.09 * angle / 360, 0, 0) ;

    }
}
