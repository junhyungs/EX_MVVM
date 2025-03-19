using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public abstract class PlayerUIView : MonoBehaviour
{
    protected static PlayerUIViewModel _viewModel;
    private static int _viewCount;

    protected virtual void Awake()
    {
        if (_viewModel == null)
        {
            _viewModel = new PlayerUIViewModel();
            _viewModel.RegisterOnAwake();
        }
            

        _viewCount++;
    }

    protected virtual void OnDestroy()
    {
        _viewCount--;

        if (_viewCount <= 0)
        {
            _viewModel.UnRegisterOnDestroy();
            _viewModel = null;
        }
            
    }

    protected abstract void OnUpdateUI(object sender, PropertyChangedEventArgs args);
}
