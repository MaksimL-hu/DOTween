using UnityEngine;
using TMPro;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

[RequireComponent(typeof(TextMeshPro))]
public class SequentialTextAnimation : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private string _replacementText = "Новый текст";
    [SerializeField] private string _additionalText = " + дополнение";
    [SerializeField] private string _scrambledText = "Финальный текст";

    [Header("Animation")]
    [SerializeField] private float _duration = 1f;
    [SerializeField] private float _interval = 0.3f;

    private TextMeshPro _text;
    private Sequence _sequence;

    private void Awake()
    {
        _text = GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        _sequence = DOTween.Sequence();

        _sequence.Append(CreateTextTween(_replacementText));
        _sequence.AppendInterval(_interval);

        _sequence.Append(CreateTextTween(_additionalText).SetRelative());
        _sequence.AppendInterval(_interval);

        _sequence.Append(CreateTextTween(_scrambledText).SetOptions(true,ScrambleMode.All));
        _sequence.AppendInterval(_interval);

        _sequence.SetLoops(-1, LoopType.Restart);
    }

    private TweenerCore<string, string, StringOptions> CreateTextTween(string value)
    {
        return DOTween.To(
            () => _text.text,
            newValue => _text.text = newValue,
            value,
            _duration
        ).SetEase(Ease.Linear);
    }
}