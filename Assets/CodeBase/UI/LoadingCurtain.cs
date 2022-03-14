using DG.Tweening;
using UnityEngine;

namespace CodeBase.UI
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _cg;

        public void Show()
        {
            gameObject.SetActive(true);
            _cg.alpha = 1;
        }

        public void Hide()
        {
            _cg.DOFade(0, 0.5f).OnComplete(() => gameObject.SetActive(false));
        }
    }
}