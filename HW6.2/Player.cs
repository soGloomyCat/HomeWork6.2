using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _startHealth;

    public event UnityAction ChangeHealthBarValue;

    public float Health { get; private set; }
    public int MinValue { get; private set; }
    public int MaxValue { get; private set; }

    private void Awake()
    {
        Health = _startHealth;
        MinValue = 0;
        MaxValue = 100;
    }

    public void TakeDamage(float damageValue)
    {
        if (Health > 0)
        {
            Health -= damageValue;
            ChangeHealthBarValue.Invoke();
            Debug.Log(Health.ToString());
        }
    }

    public void TakeHeal(float healValue)
    {
        if (Health < 100)
        {
            Health += healValue;
            ChangeHealthBarValue.Invoke();
            Debug.Log(Health.ToString());
        }
    }
}
