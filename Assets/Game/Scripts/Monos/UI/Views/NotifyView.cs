using UnityEngine;
using TMPro;
using DG.Tweening;

public class NotifyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text; 
    [SerializeField] private CanvasGroup _canvasGroup;
    [Header("Animation parametrs")]
    [SerializeField] private float _timer = 4;

    public void Start()
    {
        DOTween.Sequence()
            .Append(_canvasGroup.DOFade(0f, _timer))
            .AppendCallback(() => Destroy(gameObject));
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
}
