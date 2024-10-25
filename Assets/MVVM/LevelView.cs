using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.ComponentModel;
public enum Value
{
    Name,
    Atk,
    Speed,
    HP,
    MP
}

public class LevelView : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI[] _valueTexts;
    private Dictionary<Value, TextMeshProUGUI> _textDictionary;

    private LevelViewModel _viewModel;

    private void Awake()
    {
        _textDictionary = new Dictionary<Value, TextMeshProUGUI> ();

        BindDictionary();
    }

    private void OnEnable()
    {
        OnEnableLevelView();
    }

    private void BindDictionary()
    {
        Array enumArray = Enum.GetValues(typeof(Value));

        for(int i = 0; i < enumArray.Length; i++)
        {
            var value = (Value)enumArray.GetValue(i);

            _textDictionary.Add(value, _valueTexts[i]);
        }
    }

    private TextMeshProUGUI GetUGUI(Value type)
    {
        if (!_textDictionary.ContainsKey(type))
        {
            Debug.Log("UGUI가 없음");
            return null;
        }

        return _textDictionary[type];
    }

    private void OnEnableLevelView()
    {
        if(_viewModel == null)
        {
            _viewModel = new LevelViewModel ();

            _viewModel.PropertyChanged += RefreshView;

            _viewModel.RegisterLevelViewOnEnable();

            _viewModel.InitializeLevelView("메로나", 10f, 5f, 100f, 50f);
        }
    }

    private void RefreshView(object sender, PropertyChangedEventArgs args)
    {
        switch(args.PropertyName)
        {
            case nameof(_viewModel.Name):
                var nameUGUI = GetUGUI(Value.Name);
                nameUGUI.text = _viewModel.Name;
                break;
            case nameof(_viewModel.ATK):
                var atkUGUI = GetUGUI(Value.Atk);
                atkUGUI.text = _viewModel.ATK.ToString();
                break;
            case nameof(_viewModel.Speed):
                var speedUGUI = GetUGUI(Value.Speed);
                speedUGUI.text = _viewModel.Speed.ToString();
                break;
            case nameof(_viewModel.Health):
                var hpUGUI = GetUGUI(Value.HP);
                hpUGUI.text= _viewModel.Health.ToString();
                break;
            case nameof(_viewModel.Mana):
                var manaUGUI = GetUGUI(Value.MP);
                manaUGUI.text = _viewModel.Mana.ToString();
                break;
        }
    }
}
