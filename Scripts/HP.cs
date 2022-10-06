using UnityEngine;
using System;

public class HP : MonoBehaviour
{
    public Action<int> HPValueChanged;

    [SerializeField] private int _points = 800;
    [SerializeField] private int _MaxPoints = 1000;

    public float MaxPoints => _MaxPoints;

    private void Start()
    {
        HPValueChanged?.Invoke(_points);
    }

    public void AddHPPoints(int points)
    {
        _points += points;

        if (_points > _MaxPoints)
            _points = _MaxPoints;

        HPValueChanged?.Invoke(_points);
    }

    public void RemoveHPPoints(int points)
    {
        _points -= points;

        if (_points < 0)
            _points = 0;

        HPValueChanged?.Invoke(_points);
    }
}
