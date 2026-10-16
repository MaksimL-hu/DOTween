using DG.Tweening;
using UnityEngine;

public class LoopedScaler : MonoBehaviour
{
    [SerializeField] private Vector3 _endScale;
    [SerializeField] private float _duration = 3f;

    private void Start()
    {
        transform.DOScale(_endScale, _duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}