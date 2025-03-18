using System.Collections;
using System.Collections.Generic;
using ModelClass;

public class ModelManager : Singleton<ModelManager>
{
    private static Dictionary<ModelType, Model> _modelDictionary = new Dictionary<ModelType, Model>();

    public static void RegisterModel(ModelType modelType, Model model)
    {
        if (!_modelDictionary.ContainsKey(modelType))
            _modelDictionary.Add(modelType, model);
    }

    public static void UnRegisterModel(ModelType modelType)
    {
        if (_modelDictionary.ContainsKey(modelType))
            _modelDictionary.Remove(modelType);
    }

    public T GetModel<T>(ModelType modelType) where T : class
    {
        return TryGetModel<T>(modelType);
    }

    private T TryGetModel<T>(ModelType modelType) where T : class
    {
        if(_modelDictionary.TryGetValue(modelType, out Model model))
        {
            return model as T;
        }

        return null;
    }
}

namespace ModelClass
{
    public class Model { }
}

public enum ModelType
{
    HealthModel
}
