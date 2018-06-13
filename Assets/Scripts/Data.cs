using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public static int _high;
    public static int _width;
    public static int _bigHigh;
    public static int _bigWidth;

    public static bool Rpg;
    public static bool Platform;
    public static bool Blank;

    public static int _platformSize;

    public static Dictionary<string, Evento> _events = new Dictionary<string, Evento>();
}
