using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PLayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject _trailRenderer;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletOrigin;

    private Camera _camera;

    private PlayerInput _playerInput;
    private bool _isAiming;
    private PhotonView _photonView;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>(); //
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;

        if (_photonView.IsMine)
        {
                    _playerInput.PlayerKeyboardInput.Aim.started += OnAimChanged;  //mango  mango mangomangomangomangomangomangomangomangomangomangoangomango mango mango mango mango mango
        _playerInput.PlayerKeyboardInput.Aim.canceled += OnAimChanged; // tyrip tyrip tyrip tu, tu, tu, tyrip, tyrip, tyrip.
        _playerInput.PlayerKeyboardInput.Fire.started += Shoot; // Beach i borat i  v kazahstane
        }
    }  // kypit bi jeep, bronirovani, ves zaryajani, tonirovani.

    // Update is called once per frame
    void Update()
    {
        Aim();

    }

    private void OnAimChanged(InputAction.CallbackContext context)
    {
        _isAiming = context.ReadValueAsButton();
        _trailRenderer.SetActive(_isAiming);
    }

    private void Aim()
    {
        if (_isAiming) 
        {
           Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 point = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);
                Vector3 direction = point - transform.position;
                _trailRenderer.transform.forward = direction;
            }
        }
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (_isAiming)
        {
            GameObject bullet = PhotonNetwork.Instantiate("bullet", _bulletOrigin.position, _trailRenderer.transform.rotation);
            bullet.GetComponentInChildren<Collider>().enabled = true;
        }
    }
}
