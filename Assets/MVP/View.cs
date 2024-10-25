using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class View : MonoBehaviour, IDataView
{
    [Header("ID")]
    [SerializeField] private string _id;

    [Header("Button")]
    [SerializeField] private Button _button;

    [Header("ShowText")]
    [SerializeField] private TextMeshProUGUI _showMessage;


    private void OnEnable()
    {
        _button.onClick.AddListener(TryData);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TryData);
    }

    public void ShowFail(string message)
    {
        ResetText(message);
    }

    public void ShowSuccess(string message)
    {
        ResetText(message);
    }

    private void ResetText(string text)
    {
        _showMessage.text = string.Empty;

        _showMessage.text = text;
    }

    private void TryData()
    {
        var presenter = new Presenter(this);

        presenter.TryData(_id);
    }
}
