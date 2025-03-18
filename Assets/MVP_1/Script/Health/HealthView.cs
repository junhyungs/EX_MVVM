using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour, IHealthView
{
    [Header("HealthVar"), SerializeField] private Image _filledImage;

    private HealthPresenter _presenter;

    private void Awake()
    {
        _presenter = new HealthPresenter(this);
    }

    private void OnDestroy()
    {
        _presenter.DestroyView();
    }

    public void UpdateUI(int value)
    {
        var persent = value / 100f;

        _filledImage.fillAmount = persent;
    }
}
