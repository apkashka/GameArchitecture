using System;
using UniRx;
using UnityEngine;

namespace CodeBase.SimpleInput
{
    public class TempInput : MonoBehaviour
    {
        public static event Action ScreenTouched;

        private void Awake()
        {
            DontDestroyOnLoad(this);

            Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0))
                .Subscribe(_ => ScreenTouched?.Invoke());
        }
    }
}   