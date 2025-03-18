using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Material _material;
    private int _health;

    private void Awake()
    {
        _health = 100;

        _material = GetComponent<MeshRenderer>().materials[0];
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        StartCoroutine(HitEffect());

        GameUIManager.Instance.ModelTrigger(ModelType.HealthModel, _health);
    }

    private IEnumerator HitEffect()
    {
        var color = _material.color;
        SetColor(Color.red);
        yield return new WaitForSeconds(0.1f);
        SetColor(color);
    }

    private void SetColor(Color color)
    {
        _material.color = color;
    }
}
