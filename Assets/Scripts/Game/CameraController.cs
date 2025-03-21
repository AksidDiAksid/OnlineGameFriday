using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    private Transform _target;
    private Vector3 _velocity;
    [SerializeField] private float _smooth = 2.0f;
    [SerializeField] private Vector3 _offset = new Vector3(0f, 5f, -4f);
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    private void Update() // a yo pe pe poo poo check pe po pe po pooo oo oo pe poo poo poo oooo oo
    {
        Work();
    }
    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Work()
    {
        Vector3 newPosition = Vector3.SmoothDamp(transform.position, _target.position + _offset, ref _velocity, _smooth);
        transform.position = newPosition;
    }
}
