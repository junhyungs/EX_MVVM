using System.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIAbilityView : PlayerUIView
{
    [Header("ValueText"), SerializeField] private Text[] _valueTexts;
    [Header("NameText"), SerializeField] private Text[] _nameTexts;

    private Dictionary<Buttons, Text> _textDictionary
        = new Dictionary<Buttons, Text>();

    protected override void Awake()
    {
        base.Awake();

        _viewModel.OnPropertyChanged += OnUpdateUI;
        InitializeText();
    }

    protected override void OnDestroy()
    {
        _viewModel.OnPropertyChanged -= OnUpdateUI;

        base.OnDestroy();
    }

    private void InitializeText()
    {
        var enumValues = Enum.GetValues(typeof(Buttons));

        if (enumValues.Length != _valueTexts.Length ||
            enumValues.Length != _nameTexts.Length)
            return;

        for(int i = 0; i < enumValues.Length; i++)
        {
            var enumValue = (Buttons)enumValues.GetValue(i);

            _nameTexts[i].text = enumValue.ToString();
            _textDictionary.Add(enumValue, _valueTexts[i]);
        }
    }

    private Text GetText(Buttons buttons)
    {
        if (_textDictionary.TryGetValue(buttons, out Text text))
            return text;

        return null;
    }

    protected override void OnUpdateUI(object sender, PropertyChangedEventArgs args)
    {
        switch (args.PropertyName)
        {
            case nameof(_viewModel.Level):
                var levelText = GetText(Buttons.Level);
                levelText.text = _viewModel.Level.ToString();
                break;
            case nameof(_viewModel.STR):
                var strText = GetText(Buttons.STR);
                strText.text = _viewModel.STR.ToString();
                break;
            case nameof(_viewModel.DEX):
                var dexText = GetText(Buttons.DEX);
                dexText.text = _viewModel.DEX.ToString();
                break;
            case nameof(_viewModel.LUK):
                var lukText = GetText(Buttons.LUK);
                lukText.text = _viewModel.LUK.ToString();
                break;
            case nameof(_viewModel.INT):
                var intText = GetText(Buttons.INT);
                intText.text = _viewModel.INT.ToString();
                break;
        }
    }
}
