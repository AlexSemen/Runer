using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private HeartUI[] _hearts;
    private int _currentHealth;

    private void Awake()
    {
        _hearts = GetComponentsInChildren<HeartUI>();
        _currentHealth = 0;
    }

    private void OnEnable()
    {
        _player.HealthChanged += HealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= HealthChanged;
    }

    private void HealthChanged(int value)
    {
        if(_currentHealth < value && _hearts.Length >= value)
        {
            for(int i = _currentHealth; i < value; i++)
            {
                _hearts[i].Fill();
            }
        }

        if(_currentHealth > value && value >= 0)
        {
            for (int i = value; i < _currentHealth; i++)
            {
                _hearts[i].Empty();
            }
        }

        _currentHealth = value;
    }
}
