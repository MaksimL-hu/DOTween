using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

[RequireComponent(typeof(TextMeshProUGUI))]
public sealed class SequentialTextAnimation : MonoBehaviour
{
    [SerializeField] private List<TextAnimationStep> _steps = new();

    private TextMeshProUGUI _text;
    private string _initialText;
    private Sequence _sequence;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _initialText = _text.text;
    }

    private void Start()
    {
        if (_steps == null || _steps.Count == 0)
            return;

        _sequence = DOTween.Sequence();

        string currentText = _initialText;

        foreach (TextAnimationStep step in _steps)
        {
            string targetText = step.GetTargetText(currentText);
            ScrambleMode scrambleMode = step.UseScramble
                ? ScrambleMode.All
                : ScrambleMode.None;

            _sequence.Append(
                DOTween.To(
                        () => _text.text,
                        value => _text.text = value,
                        targetText,
                        step.Duration
                    )
                    .SetOptions(true, scrambleMode)
                    .SetEase(Ease.Linear)
            );

            _sequence.AppendInterval(step.IntervalAfter);
            currentText = targetText;
        }

        _sequence.SetLoops(-1, LoopType.Restart);
    }
}