using System;

public class HealthModel
{
    private int _health;
    public event Action<int> HealthEvent;

    public int Health
    {
        get => _health;
        private set
        {
            _health = value;
            HealthEvent.Invoke(_health);
        }
    }    

    public HealthModel()
    {
        GameUIManager.RegisterModelAction<int>(ModelType.HealthModel, SetHealth);
    }

    ~HealthModel()
    {
        GameUIManager.UnRegisterModelAction(ModelType.HealthModel);
    }

    public void SetHealth(int health)
    {
        Health = health;
    }
}
