using System;
using System.ComponentModel;

public class PlayerUIViewModel
{
    private int _health;
    public int Health
    {
        get => _health;
        set
        {
            if(value == _health)
            {
                return;
            }

            _health = value;
            OnPropertyChanedEvent(nameof(Health));
        }
    }

    private int _level;
    public int Level
    {
        get => _level;
        set
        {
            if(value == _level || value < 0)
            {
                return;
            }

            _level = value;
            OnPropertyChanedEvent(nameof(Level));
        }
    }

    private int _str;
    public int STR
    {
        get => _str;
        set
        {
            if (value == _str || value < 0)
            {
                return;
            }

            _str = value;
            OnPropertyChanedEvent(nameof(STR));
        }
    }

    private int _dex;
    public int DEX
    {
        get => _dex;
        set
        {
            if(value == _dex || value < 0)
            {
                return;
            }

            _dex = value;
            OnPropertyChanedEvent(nameof(DEX));
        }
    }

    private int _luk;
    public int LUK
    {
        get => _luk;
        set
        {
            if(value == _luk || value < 0)
            {
                return;
            }

            _luk = value;
            OnPropertyChanedEvent(nameof(LUK));
        }
    }

    private int _int;
    public int INT
    {
        get => _int;
        set
        {
            if(value == _int || value < 0)
            {
                return;
            }

            _int = value;
            OnPropertyChanedEvent(nameof(INT));
        }
    }

    public PropertyChangedEventHandler OnPropertyChanged;
    private void OnPropertyChanedEvent(string propertyName)
    {
        OnPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public static class PlayerUIViewModelExtention
{
    public static void RegisterOnAwake(this PlayerUIViewModel playerUIViewModel)
    {
        GameUIManager.RegisterModelAction<int>(TriggerType.MVVM_Health, playerUIViewModel.SetHealth);
        GameUIManager.RegisterModelAction<int>(TriggerType.MVVM_Level, playerUIViewModel.SetLevel);
        GameUIManager.RegisterModelAction<int>(TriggerType.MVVM_STR, playerUIViewModel.SetSTR);
        GameUIManager.RegisterModelAction<int>(TriggerType.MVVM_DEX, playerUIViewModel.SetDEX);
        GameUIManager.RegisterModelAction<int>(TriggerType.MVVM_LUK, playerUIViewModel.SetLUK);
        GameUIManager.RegisterModelAction<int>(TriggerType.MVVM_INT, playerUIViewModel.SetINT);
    }

    public static void UnRegisterOnDestroy(this PlayerUIViewModel playerUIViewModel)
    {
        GameUIManager.UnRegisterModelAction(TriggerType.MVVM_Health);
        GameUIManager.UnRegisterModelAction(TriggerType.MVVM_Level);
        GameUIManager.UnRegisterModelAction(TriggerType.MVVM_STR);
        GameUIManager.UnRegisterModelAction(TriggerType.MVVM_DEX);
        GameUIManager.UnRegisterModelAction(TriggerType.MVVM_LUK);
        GameUIManager.UnRegisterModelAction(TriggerType.MVVM_INT);
    }

    public static void SetHealth(this PlayerUIViewModel playerUIViewModel, int health)
    {
        playerUIViewModel.Health = health;
    }

    public static void SetLevel(this PlayerUIViewModel playerUIViewModel, int level)
    {
        playerUIViewModel.Level += level;
    }

    public static void SetSTR(this PlayerUIViewModel playerUIViewModel, int str)
    {
        playerUIViewModel.STR += str;
    }

    public static void SetDEX(this PlayerUIViewModel playerUIViewModel, int dex)
    {
        playerUIViewModel.DEX += dex;
    }

    public static void SetLUK(this PlayerUIViewModel playerUIViewModel, int luk)
    {
        playerUIViewModel.LUK += luk;
    }

    public static void SetINT(this PlayerUIViewModel playerUIViewModel, int intValue)
    {
        playerUIViewModel.INT += intValue;
    }
}
