using System.Collections;
using System.Collections.Generic;

public interface IView<T>
{
    public void UpdateUI(T value);
}

public interface IHealthView : IView<int> { }

