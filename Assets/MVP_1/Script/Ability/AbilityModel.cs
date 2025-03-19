using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AbilityModel
{
    private int _level;
    public int Level
    {
        get => _level;
        set
        {
            if(value < 0)
            {
                return;
            }

            _level = value;
        }
    }
    private int _str;
    public int STR
    {
        get => _str;
        set
        {
            if(value < 0)
            {
                return;
            }

            _str = value;
        }
    }
    private int _dex;
    public int DEX
    {
        get => _dex;
        set
        {
            if(value < 0)
            {
                return;
            }

            _dex = value;
        }
    }
    private int _luk;
    public int LUK
    {
        get => _luk;
        set
        {
            if(value < 0)
            {
                return;
            }

            _luk = value;
        }
    }
    private int _int;
    public int INT
    {
        get => _int;
        set
        {
            if(value < 0)
            {
                return;
            }

            _int = value;
        }
    }

    public int GetAbility(Buttons buttons, int value)
    {
        switch (buttons)
        {
            case Buttons.Level:
                Level += value;
                return Level;
            case Buttons.STR:
                STR += value;
                return STR;
            case Buttons.DEX:
                DEX += value;
                return DEX;
            case Buttons.LUK:
                LUK += value;
                return LUK;
            case Buttons.INT:
                INT += value;
                return INT;
            default:
                throw new ArgumentException("잘못된 값");
        }
    }
}
