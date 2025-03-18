using System.Collections;
using System.Collections.Generic;

public class HealthPresenter
{
    private IView<int> _view;
    private HealthModel _model;

    public HealthPresenter(IView<int> view)
    {
        _view = view;

        var modelManager = ModelManager.Instance;

        _model = modelManager.GetModel<HealthModel>(ModelType.HealthModel);

        _model._healthEvent += UpdateHealthView;
    }

    public void UpdateHealthView(int damage)
    {
        _view.UpdateUI(damage);
    }
}
