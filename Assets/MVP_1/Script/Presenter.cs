using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomPresenter
{
    public abstract class Presenter<T>
    {
        public Presenter(T view)
        {
            _view = view;
        }

        protected T _view;
        public abstract void DestroyView();
    }
}

