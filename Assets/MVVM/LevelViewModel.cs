using System.ComponentModel;

public class LevelViewModel
{
    private string _name;
    private float _atk;
    private float _speed;
    private float _health;
    private float _mana;

    public string Name
    {
        get { return _name; }
        set
        {
            if(_name == value)
            {
                return;
            }

            _name = value;

            OnPropertyChanged(nameof(Name));
        }
    }

    public float ATK
    {
        get { return _atk; }
        set
        {
            //if(_atk == value)
            //{
            //    return;
            //}

            _atk += value;
            OnPropertyChanged(nameof(ATK));
        }
    }

    public float Speed
    {
        get { return _speed; }
        set
        {
            //if(_speed == value)
            //{
            //    return;
            //}

            _speed += value;
            OnPropertyChanged(nameof(Speed));
        }
    }

    public float Health
    {
        get { return _health; }
        set
        {
            //if(_health == value)
            //{
            //    return;
            //}

            _health += value;
            OnPropertyChanged(nameof(Health));
        }
    }

    public float Mana
    {
        get { return _mana; }
        set
        {
            //if(value == _mana)
            //{
            //    return;
            //}

            _mana += value;
            OnPropertyChanged(nameof(Mana));
        }
    }

    
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public static class LevelViewModelExtantion
{
    public static void InitializeLevelView(this LevelViewModel levelView, string name, float akt,
        float speed, float health, float mana)
    {
        levelView.Name = name;
        levelView.ATK = akt;
        levelView.Speed = speed;
        levelView.Health = health;
        levelView.Mana = mana;
    }

    public static void RegisterLevelViewOnEnable(this LevelViewModel levelView)
    {
        UIManager.Instance.RegisterValueAction(levelView.OnResponesLevelUp, true);

        UIManager.Instance.RegisterNameAction(levelView.OnResponeseNameChange, true);
    }

    public static void UnRegisterLevelViewOnDisable(this LevelViewModel levelView)
    {
        UIManager.Instance.RegisterValueAction(levelView.OnResponesLevelUp, false);

        UIManager.Instance.RegisterNameAction(levelView.OnResponeseNameChange, false);
    }

    public static void OnResponesLevelUp(this LevelViewModel levelView, Value type, float value)
    {
        switch (type)
        {
            case Value.Atk:
                levelView.ATK = value;
                break;
            case Value.Speed:
                levelView.Speed = value;
                break;
            case Value.HP:
                levelView.Health = value;
                break;
            case Value.MP:
                levelView.Mana = value;
                break;
        }
    }

    public static void OnResponeseNameChange(this LevelViewModel levelView, string name)
    {
        levelView.Name = name;
    }
}