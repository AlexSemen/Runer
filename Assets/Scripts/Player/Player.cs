using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private int _maxHealth;

    private void Awake()
    {
        _maxHealth = 5;
    }

    private void Start()
    {
        HealthChanged.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if ( _health <= 0)
        {
            Die();
        }

        HealthChanged.Invoke(_health);
    }

    public void Heal()
    {
        if( _health < _maxHealth) 
        {
            _health += 1;
            HealthChanged.Invoke(_health);
        }
    }

    private void Die() 
    {
        Died.Invoke();
    }
}
