using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heald : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealt = 100;
    private int _healt;
    private int Healt {  get { return _healt; } set {  _healt = value; _healthBar.SetValue(value);  } }
    private UIHealthBar _healthBar;
    private PhotonView _photonView;
    // Start is called before the first frame update

    public void TakeDamage(int damage)
    {
        _photonView.RPC("RemoteDamage", RpcTarget.All, damage);
    }
    [PunRPC]
    public void RemoteDamage(int damage)
    {
        Healt -= damage;
    }

    // Update is called once per frame
    private void Start()
    {
        _healthBar = GetComponent<UIHealthBar>();
        _healthBar.SetMax(_maxHealt);
        Healt = _maxHealt;
    }
}
