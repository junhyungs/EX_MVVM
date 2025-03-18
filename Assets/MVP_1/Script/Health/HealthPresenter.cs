using System.Collections;
using System.Collections.Generic;

public class HealthPresenter
{
    private IHealthView _view;
    private HealthModel _model;

    public HealthPresenter(IHealthView view)
    {
        _view = view;

        _model = new HealthModel();
        _model.HealthEvent += UpdateHealthView;
    }

    public void UpdateHealthView(int damage)
    {
        _view.UpdateUI(damage);
    }

    public void DestroyView()
    {
        _model.HealthEvent -= UpdateHealthView;
    }
}
