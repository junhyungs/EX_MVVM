using System.Collections;
using System.Collections.Generic;

public class HealthPresenter
{
    private IHealthView _view;

    public HealthPresenter(IHealthView view)
    {
        _view = view;

        GameUIManager.RegisterModelAction<int>(TriggerType.HealthModel, UpdateHealthView);
    }

    public void UpdateHealthView(int damage)
    {
        _view.UpdateUI(damage);
    }

    public void DestroyView()
    {
        GameUIManager.UnRegisterModelAction(TriggerType.HealthModel);
    }
}
