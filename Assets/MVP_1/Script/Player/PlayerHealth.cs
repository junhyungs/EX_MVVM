using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerHitEffect _effect;

    private void Awake()
    {
        _effect = GetComponent<PlayerHitEffect>();
    }

    private void Start()
    {
        Health = 100;
    }

    private int _health;
    public int Health
    {
        get => _health;
        set
        {
            if(_health == value)
            {
                return;
            }

            _health = value;
            UpdatePlayerUI(TriggerType.HealthModel, _health);
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if(Health <= 0)
        {
            return;
        }

        _effect.StartHitCoroutine();
    }

    private void UpdatePlayerUI<T>(TriggerType type, T value) where T : struct
    {
        GameUIManager.Instance.UpdateUITrigger(type, value);
    }
}
