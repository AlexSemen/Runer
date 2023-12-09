using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor.VersionControl;

[RequireComponent(typeof(Image))]
public class HeartUI : MonoBehaviour
{
    [SerializeField] private float _timeChange;

    private Image _image;
    private float _maxFillAmount;
    private float _minFillAmount;

    private void Awake()
    {
        _maxFillAmount = 1;
        _minFillAmount = 0;
        _image = GetComponent<Image>();
        _image.fillAmount = 0;
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }

    public void Fill()
    {
        SetFillAmount(_maxFillAmount);
    }

    public void Empty()
    {
        SetFillAmount(_minFillAmount);
    }

    private void SetFillAmount(float amount)
    {
        _image.DOFillAmount(amount, _timeChange);
    }
}
