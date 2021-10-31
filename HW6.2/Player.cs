using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _startHealth;

    public event UnityAction HealthHasChanged;

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
        if (Health > MinValue)
        {
            if (Health - damageValue >= 0)
            {
                Health -= damageValue;
                HealthHasChanged?.Invoke();
            }
            else
            {
                Health = 0;
                HealthHasChanged?.Invoke();
            }

            Debug.Log(Health.ToString());
        }
    }

    public void TakeHeal(float healValue)
    {
        if (Health < MaxValue)
        {
            if (Health + healValue <= 100)
            {
                Health += healValue;
                HealthHasChanged?.Invoke();
            }
            else
            {
                Health = 100;
                HealthHasChanged?.Invoke();
            }
            
            Debug.Log(Health.ToString());
        }
    }
}
