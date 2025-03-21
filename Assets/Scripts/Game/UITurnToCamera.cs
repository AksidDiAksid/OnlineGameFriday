using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITurnToCamera : MonoBehaviour
{
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main; //sidim ne ripaemsya
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Work();
    }

    private void Work() //arbitraj
    {
        transform.forward = _camera.transform.forward;  
    }
}
