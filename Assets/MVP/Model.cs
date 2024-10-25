using UnityEngine;

public class Model
{
    private static Model _instance;

    public static Model Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new Model();
            }

            return _instance;
        }
    }

    public void GetData(string id, IDataCallBack callBack)
    {
        if(id == "A101")
        {
            callBack.Success();
        }
        else
        {
            callBack.Fail();
        }
    }
}

public class DataCallBack : IDataCallBack
{
    private IDataView _view;

    private const string _successMessage = "성공";
    private const string _failMessage = "실패";

    public DataCallBack(IDataView view)
    {
        _view = view;
    }

    public void Fail()
    {
        _view.ShowFail(_failMessage);
    }

    public void Success()
    {
        _view.ShowSuccess(_successMessage);
    }
}

public interface IDataCallBack
{
    public void Success();
    public void Fail();
}

public interface IDataView
{
    public void ShowSuccess(string message);
    public void ShowFail(string message); 
}