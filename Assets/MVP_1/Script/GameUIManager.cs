using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameUIManager : SingletonMonobehaviour<GameUIManager>
{
    private static Dictionary<ModelType, Delegate> _modelActionDictionary
        = new Dictionary<ModelType, Delegate>();

    public static void RegisterModelAction(ModelType type, Action action)
    {
        if (!_modelActionDictionary.ContainsKey(type))
        {
            _modelActionDictionary.Add(type, action);
        }
    }

    public static void UnRegisterModelAction(ModelType type)
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

    public void ModelTrigger(ModelType modelType)
    {
        if(_modelActionDictionary.TryGetValue(modelType, out Delegate value))
        {
            (value as Action).Invoke();
        }
    }
}
