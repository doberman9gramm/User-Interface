using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHP : MonoBehaviour
{
    [SerializeField] private HP _hp;
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _text;
    [SerializeField] private float _speed;

    private Coroutine _updateBar;

    private void Start()
    {
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
        if (_updateBar != null)
            StopCoroutine(_updateBar);

        _updateBar = StartCoroutine(UpdateBarValue(newHPValue)); 
    }

    private IEnumerator UpdateBarValue(float targetValue)
    {
        while (_slider.value != targetValue)
        {
            var value = Mathf.MoveTowards(_slider.value, targetValue, _speed * Time.deltaTime);
            _slider.value = value;
            _text.text = Mathf.Round(value).ToString();
            yield return null;
        }
    }
}
