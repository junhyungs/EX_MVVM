using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomPresenter;

public class AbilityPresenter : Presenter<IAbilityView>
{
    private AbilityModel _model;

    public AbilityPresenter(IAbilityView view) : base(view)
    {
        _view = view;
        _model = new AbilityModel();

        GameUIManager.RegisterModelAction<(Buttons, int)>
            (TriggerType.AbilityModel, UpDateAbilityView);
    }

    public void UpDateAbilityView((Buttons, int)value)
    {
        var buttonType = value.Item1;
       
        var carculateValue = _model.GetAbility(buttonType, value.Item2);
        _view.UpdateUI(buttonType, carculateValue);
    }

    public override void DestroyView()
    {
        GameUIManager.UnRegisterModelAction(TriggerType.AbilityModel);
    }
}
