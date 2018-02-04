using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    private int _points = 0;

    public void addPoint()
    {
        _points++;
    }

    public int getPoints()
    {
        return _points;
    }

    public void subtract5Points ()
    {
        _points -= 5;
        if (_points < 0)
        {
            _points = 0;
        }
    }
}
