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
    private float _stepOfChange;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _player.Health;
        SubscribeEvent();
    }

    private void SubscribeEvent()
    {
        _player.Action += ChangeHP;
    }

    public void ChangeHP()
    {
        _coroutine = StartCoroutine(ChangeHealthBar());
    }

    private IEnumerator ChangeHealthBar()
    {
        var waiter = new WaitForSeconds(0.05f);
        _stepOfChange = _changeSpeed * Time.deltaTime;
        _targetValue = _player.Health;

        while (_slider.value != _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _stepOfChange);
            yield return waiter;
        }

        _player.Action -= ChangeHP;
        SubscribeEvent();
        StopCoroutine(_coroutine);
    }
}
