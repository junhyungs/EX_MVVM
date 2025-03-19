using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIHealthView : PlayerUIView
{
    [Header("HealthBar"), SerializeField] private Image _filledImage;

    protected override void Awake()
    {
        base.Awake();
        _viewModel.OnPropertyChanged += OnUpdateUI;
    }

    protected override void OnDestroy()
    {
        _viewModel.OnPropertyChanged -= OnUpdateUI;
        base.OnDestroy();
    }

    protected override void OnUpdateUI(object sender, PropertyChangedEventArgs args)
    {
        if (args.PropertyName != nameof(_viewModel.Health))
            return;

        FilledHealthBar(_viewModel.Health);
    }

    private void FilledHealthBar(int health)
    {
        var persent = health / 100f;

        _filledImage.fillAmount = persent;
    }
}
