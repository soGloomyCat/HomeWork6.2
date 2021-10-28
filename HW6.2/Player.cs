using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _startHealth;
    [SerializeField] private Button _damageButton;
    [SerializeField] private float _damage;
    [SerializeField] private Button _healingButton;
    [SerializeField] private float _heal;

    public event UnityAction Action;

    public float Health { get; private set; }
    public int MinValue { get; private set; }
    public int MaxValue { get; private set; }

    private void Awake()
    {
        Health = _startHealth;
        MinValue = 0;
        MaxValue = 100;
    }

    public void TakeDamage()
    {
        if (Health > 0)
        {
            Health -= _damage;
            Action.Invoke();
            Debug.Log(Health.ToString());
        }
    }

    public void TakeHeal()
    {
        if (Health < 100)
        {
            Health += _heal;
            Action.Invoke();
            Debug.Log(Health.ToString());
        }
    }
}
