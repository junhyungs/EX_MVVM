using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityView : MonoBehaviour, IAbilityView
{
    [Header("ValueText"), SerializeField] private Text[] _valueText;
    [Header("NameText"), SerializeField] private Text[] _nameText;

    private Dictionary<Buttons, Text> _textDictionary;
    private AbilityPresenter _presenter;

    private void Awake()
    {
        _presenter = new AbilityPresenter(this);
        BineDictionary();
    }

    private void OnDestroy()
    {
        _presenter.DestroyView();
    }

    private void BineDictionary()
    {
        _textDictionary = new Dictionary<Buttons, Text>();
        var enumValues = Enum.GetValues(typeof(Buttons));

        for(int i = 0; i < _valueText.Length; i++)
        {
            var key = (Buttons)enumValues.GetValue(i);
            _nameText[i].text = key.ToString();

            _textDictionary.Add(key, _valueText[i]);
        }
    }

    private Text GetTextComponent(Buttons key)
    {
        if (_textDictionary.TryGetValue(key, out Text component))
            return component;

        return null;
    }

    public void UpdateUI(Buttons type, int carculateValue)
    {
        var textComponent = GetTextComponent(type);

        if(textComponent != null)
        {
            textComponent.text = carculateValue.ToString();
        }
    }
}
