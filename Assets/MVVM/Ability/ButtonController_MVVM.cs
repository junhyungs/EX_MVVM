using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController_MVVM : MonoBehaviour
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

        for (int i = 0; i < _buttons.Length; i++)
        {
            var textComponent = _buttons[i].GetComponentInChildren<Text>();
            var enumValue = (ButtonTypes)buttonTypes.GetValue(i);
            textComponent.text = enumValue.ToString();
        }
    }

    private void BindAction()
    {
        TriggerType[] triggerTypes = new TriggerType[]
        {
            TriggerType.MVVM_Level,
            TriggerType.MVVM_STR,
            TriggerType.MVVM_DEX,
            TriggerType.MVVM_LUK,
            TriggerType.MVVM_INT
        };

        var buttons = Enum.GetValues(typeof(Buttons));

        for (int i = 0; i < buttons.Length; i++)
        {
            var key = (Buttons)buttons.GetValue(i);
            var triggerType = triggerTypes[i];

            var callBack = GameUIManager.Instance.GetTrigger<int>(triggerType);
            _actionDictinary.Add(key, (int value) => callBack.Invoke(value));
        }
    }

    private void InvokeAction(Buttons buttons, int value)
    {
        var action = GetButtonAction(buttons);

        if (action != null)
        {
            action.Invoke(value);
        }
    }

    private Action<int> GetButtonAction(Buttons buttons)
    {
        if (_actionDictinary.TryGetValue(buttons, out Action<int> action))
            return action;

        return null;
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
