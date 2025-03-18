using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ModelClass;
using System;

public class HealthModel : Model
{
    private int _health;
    public event Action<int> _healthEvent;

    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            _healthEvent.Invoke(_health);
        }
    }

    public HealthModel()
    {
        ModelManager.RegisterModel(ModelType.HealthModel, this);

        _health = 100;
    }

    public void RemoveModel()
    {
        ModelManager.UnRegisterModel(ModelType.HealthModel);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
