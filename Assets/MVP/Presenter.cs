using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PP
{
    public class Presenter
    {
        private IDataView _view;

        public Presenter(IDataView view)
        {
            _view = view;
        }

        public void TryData(string id)
        {
            Model.Instance.GetData(id, new DataCallBack(_view));
        }
    }
}

