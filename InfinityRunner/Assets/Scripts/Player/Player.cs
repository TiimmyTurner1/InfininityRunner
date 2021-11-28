using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    
    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;
    public event UnityAction Paused;

    private void Start()
    {
        HealthChanged?.Invoke(_health);        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused?.Invoke();
        }
    }

    public void Heal(int value)
    {
        if (_health < 5)
        {
            _health += value;
            HealthChanged?.Invoke(_health);
        }        
    }

    public void ApplyDamage(int damage)
    {        
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
        else
        {
            HealthChanged?.Invoke(_health);
        }        
    }

    private void Die()
    {
        Died?.Invoke();        
    }
}
