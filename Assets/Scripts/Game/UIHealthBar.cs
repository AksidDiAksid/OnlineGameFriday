using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    private Slider _healthBar;
    // Start is called before the first frame update
    private void Start()
    {
        _healthBar = GetComponent<Slider>();
    }
    public void SetValue(int health)
    {
        _healthBar.value = health;
    }

    // Update is called once per frame
    public void SetMax(int maxHealth)
    {
        _healthBar.maxValue = maxHealth;
    }
}
