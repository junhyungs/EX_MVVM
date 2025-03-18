using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private HealthModel _healthModel;
    private Material _material;

    private void Awake()
    {
        _healthModel = new HealthModel();
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(HitEffect());
        _healthModel.TakeDamage(damage);
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
