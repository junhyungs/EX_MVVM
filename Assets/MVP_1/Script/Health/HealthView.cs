using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour, IView<int>
{
    [Header("HealthVar"), SerializeField] private Image _filledImage;

    private HealthPresenter _presenter;

    void Start()
    {
        _presenter = new HealthPresenter(this);
    }

    public void UpdateUI(int value)
    {
        var persent = value / 100f;

        _filledImage.fillAmount = persent;
    }
}
