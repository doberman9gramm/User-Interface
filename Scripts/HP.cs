using UnityEngine;
using System;

public class HP : MonoBehaviour
{
    public event Action<int> HPValueChanged;

    [SerializeField] private int _points = 800;
    [SerializeField] private int _maxPoints = 1000;

    private int _minPoints = 0;

    public float MaxPoints => _maxPoints;

    private void Start()
    {
        HPValueChanged?.Invoke(_points);
    }

    public void Heal(int points)
    {
        _points = Mathf.Clamp(_points + points, _minPoints, _maxPoints);
        HPValueChanged?.Invoke(_points);
    }

    public void Damage(int points)
    {
        _points = Mathf.Clamp(_points - points, _minPoints, _maxPoints);
        HPValueChanged?.Invoke(_points);
    }
}
