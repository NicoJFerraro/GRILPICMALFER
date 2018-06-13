using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento{

    public int _activationCode;
    public bool _isActive;

    public Evento(int activationCode, bool v)
    {
        _activationCode = activationCode;
        this._isActive = v;
    }
    //   public int _switchType;


}
