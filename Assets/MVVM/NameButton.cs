using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameButton : MonoBehaviour
{
    [Header("NewName")]
    [SerializeField] private string _name;

    private Button _button;

    private void Awake()
    {
        _button  = gameObject.GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeName);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeName);
    }

    private void ChangeName()
    {
        if (string.IsNullOrWhiteSpace(_name))
        {
            return;
        }

        UIManager.Instance.RequestNameValue(_name);
    }
}
