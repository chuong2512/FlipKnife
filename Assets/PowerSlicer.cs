using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using ChuongCustom;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PowerSlicer : Singleton<PowerSlicer>
{
    public Image _bg;
    public Image _slider;

    public float Power => _slider.fillAmount;

    public void Start()
    {
        GameAction.OnStateChange -= OnStateChange;
        GameAction.OnStateChange += OnStateChange;

        OnStateChange(StateGame.Stop);
    }

    private void OnDestroy()
    {
        GameAction.OnStateChange -= OnStateChange;
    }

    private void OnStateChange(StateGame state)
    {
        switch (state)
        {
            case StateGame.Flipping:
                SetAlpha(true);
                break;
            case StateGame.Lose:
                SetAlpha(true);
                break;
            case StateGame.Stop:
                SetAlpha(true);
                break;
            case StateGame.Hold:
                _slider.DOFillAmount(1, 1f).From(0).SetEase(Ease.OutQuad)
                    .SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
                SetAlpha(false);
                break;
        }
    }

    private void SetAlpha(bool b)
    {
        var sliderColor = _slider.color;
        var _bgColor = _bg.color;
        sliderColor.a = b ? 0 : 255;
        _bgColor.a = b ? 0 : 255;
        _bg.color = _bgColor;
        _slider.color = sliderColor;
    }

    private void Update()
    {
    }
}