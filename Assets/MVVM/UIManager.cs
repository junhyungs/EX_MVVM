using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private static UIManager instance;

    private Action<string> _nameAction;
    private Action<Value ,float> _valueAction;

    public static UIManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new UIManager();
            }

            return instance;
        }
    }

    public void RequestLevelValue(Value valueType, float value)
    {
        _valueAction?.Invoke(valueType, value);
    }

    public void RequestNameValue(string name)
    {
        _nameAction?.Invoke(name);
    }


    public void RegisterValueAction(Action<Value, float> action, bool register)
    {
        if(register)
        {
            _valueAction += action;
        }
        else
        {
            _valueAction -= action;
        }
    }

    public void RegisterNameAction(Action<string> nameAction, bool register)
    {
        if(register)
        {
            _nameAction += nameAction;
        }
        else
        {
            _nameAction -= nameAction;
        }
    }
}
