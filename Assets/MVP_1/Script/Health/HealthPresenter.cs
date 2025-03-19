using System.Collections;
using System.Collections.Generic;
using CustomPresenter;

public class HealthPresenter : Presenter<IHealthView>
{
    public HealthPresenter(IHealthView view) : base(view)
    {
        _view = view;

        GameUIManager.RegisterModelAction<int>
            (TriggerType.HealthModel, UpdateHealthView);
    }

    public void UpdateHealthView(int damage)
    {
        _view.UpdateUI(damage);
    }

    public override void DestroyView()
    {
        GameUIManager.UnRegisterModelAction(TriggerType.HealthModel);
    }
}
