using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(HP))]
public class UIHP : MonoBehaviour
{
    [SerializeField] private HP _hp;
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _text;
    [SerializeField] private float _speed;

    private float _targetValue;

    private void Start()
    {
        _hp = GetComponent<HP>();
        _slider.maxValue = _hp.MaxPoints;
    }

    private void OnEnable()
    {
        _hp.HPValueChanged += SetValue;
    }

    private void OnDisable()
    {
        _hp.HPValueChanged -= SetValue;
    }

    private void SetValue(int newHPValue)
    {
        _targetValue = newHPValue;
        StartCoroutine(UpdateBarValue()); 
    }

    private IEnumerator UpdateBarValue()
    {
        while (_slider.value != _targetValue)
        {
            var value = Mathf.MoveTowards(_slider.value, _targetValue, _speed * Time.deltaTime);
            _slider.value = value; 
            _text.text = Mathf.Round(value).ToString();
            yield return null;
        }
    }
}
