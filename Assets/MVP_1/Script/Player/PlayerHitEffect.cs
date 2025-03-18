using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitEffect : MonoBehaviour
{
    private Material _material;
    private WaitForSeconds _time;
    private Coroutine _effectCoroutine;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
        _time = new WaitForSeconds(0.1f);
    }

    public void StartHitCoroutine()
    {
        if(_effectCoroutine != null)
        {
            StopCoroutine(_effectCoroutine);

            _effectCoroutine = null;
        }

        _effectCoroutine = StartCoroutine(Effect());
    }

    private IEnumerator Effect()
    {
        var currentColor = _material.color;

        SetColor(Color.red);

        yield return _time;

        SetColor(currentColor);
    }

    private void SetColor(Color color)
    {
        _material.color = color;
    }
}
