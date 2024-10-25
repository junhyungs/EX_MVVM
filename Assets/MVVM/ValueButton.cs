using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueButton : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private float _value;

    [Header("Type")]
    [SerializeField] private Value _type;

    private Button _button;

    private void Awake()
    {
        _button = gameObject.GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeValue);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeValue);
    }

    private void ChangeValue()
    {
        UIManager.Instance.RequestLevelValue(_type, _value);
    }
}
