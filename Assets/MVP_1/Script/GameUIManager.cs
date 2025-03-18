using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameUIManager : SingletonMonobehaviour<GameUIManager>
{
    private static Dictionary<TriggerType, Delegate> _modelActionDictionary
        = new Dictionary<TriggerType, Delegate>();

    public static void RegisterModelAction<T>(TriggerType type, Action<T> action)
    {
        if (!_modelActionDictionary.ContainsKey(type))
        {
            _modelActionDictionary.Add(type, action);
        }
    }

    public static void UnRegisterModelAction(TriggerType type)
    {
        if (_modelActionDictionary.TryGetValue(type, out Delegate value))
        {
            var delegateChain = Delegate.Remove(_modelActionDictionary[type], value);

            if(delegateChain == null ||
                delegateChain.GetInvocationList().Length == 0)
            {
                _modelActionDictionary.Remove(type);
            }
        }
    }

    //초기 상태: _modelActionDictionary
    //+----------------------+
    //| ModelType  | Delegate(Action) |
    //+----------------------+
    //| TypeA      | Action1 + Action2 |
    //| TypeB      | Action3           |
    //+----------------------+
    //Delegate.Remove 실행 ▼

    //delegateChain = (Action1 + Action2) - (Action1 + Action2) = null (모든 Delegate 제거됨)
    //최종 상태:
    //+----------------------+
    //| ModelType  | Delegate(Action) |
    //+----------------------+
    //| TypeB      | Action3           |
    //+----------------------+

    public void UpdateUITrigger<T>(TriggerType modelType, T value)
    {
        if(_modelActionDictionary.TryGetValue(modelType, out Delegate callBack))
        {
            (callBack as Action<T>).Invoke(value);
        }
    }
}

public enum TriggerType
{
    HealthModel
}
