using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _changeSpeed;

    private Slider _slider;
    private Coroutine _coroutine;
    private float _targetValue;

    private void OnEnable()
    {
        _player.ChangeHealthBarValue += ChangeHP;
    }

    private void OnDisable()
    {
        _player.ChangeHealthBarValue -= ChangeHP;
    }

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _player.Health;
        _slider.maxValue = _player.MaxValue;
    }

    private void StopRoutine()
    {
        StopCoroutine(_coroutine);
    }

    public void ChangeHP()
    {
        _coroutine = StartCoroutine(ChangeHealthBar());
    }

    private IEnumerator ChangeHealthBar()
    {
        var waiter = new WaitForSeconds(0.05f);
        _targetValue = _player.Health;

        while (_slider.value != _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _changeSpeed * Time.deltaTime);
            yield return waiter;
        }

        StopRoutine();
    }
}
