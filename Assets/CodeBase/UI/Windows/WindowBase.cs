using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        private void Awake()
        {
            OnAwake();
        }

        private void OnAwake()
        {
            _closeButton.onClick.AddListener(() => Destroy(gameObject));
        }
    } 
}