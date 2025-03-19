using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonController_MVP : MonoBehaviour
{
    [Header("Buttons"), SerializeField] private Button[] _buttons;

    private Dictionary<Buttons, Action<int>> _actionDictinary
        = new Dictionary<Buttons, Action<int>>();

    private void Awake()
    {
        InitializeButtons();
    }

    private void Start()
    {
        BindAction();
    }

    private void InitializeButtons()
    {
        var buttonTypes = Enum.GetValues(typeof(ButtonTypes));
        
        for(int i = 0; i < _buttons.Length; i++)
        {
            var textComponent = _buttons[i].GetComponentInChildren<Text>();
            var enumValue = (ButtonTypes)buttonTypes.GetValue(i);
            textComponent.text = enumValue.ToString();
        }
    }

    private void BindAction()
    {
        var buttons = Enum.GetValues(typeof(Buttons));
        var callBack = GameUIManager.Instance.GetTrigger<(Buttons, int)>(TriggerType.AbilityModel);

        for(int i = 0; i < buttons.Length; i++)
        {
            var key = (Buttons)buttons.GetValue(i);

            _actionDictinary.Add(key, (int value) => callBack.Invoke((key, value)));
        }
    }

    private Action<int> GetButtonAction(Buttons buttons)
    {
        if (_actionDictinary.TryGetValue(buttons, out Action<int> action))
            return action;

        return null;
    }

    private void InvokeAction(Buttons buttons, int value)
    {
        var action = GetButtonAction(buttons);

        if(action != null)
        {
            action.Invoke(value);
        }
    }

    public void OnClickUp(int enumIndex)
    {
        InvokeAction((Buttons)enumIndex, 1);
    }

    public void OnClickDown(int enumIndex)
    {
        InvokeAction((Buttons)enumIndex, -1);
    }
}

public enum Buttons
{
    Level,
    STR,
    DEX,
    LUK,
    INT
}

public enum ButtonTypes
{
    LevelUp,
    STRUp,
    DEXUp,
    LUKUp,
    INTUp,
    LevelDown,
    STRDown,
    DEXDown,
    LUKDown,
    INTDown
}