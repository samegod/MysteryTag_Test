using System;
using Additions.DataStructures;
using UnityEngine;

namespace MonoTimer
{
    public class Timer : MonoBehaviour
    {
        private float _timePassed;
        private bool _countTime;

        public float TimePassed => _timePassed;

        private void Update()
        {
            if (!_countTime)
                return;

            _timePassed += Time.unscaledDeltaTime;
        }

        public void StartCounting()
        {
            _countTime = true;
        }

        public void StopCounting()
        {
            _countTime = false;
        }

        public void ResetTime()
        {
            _timePassed = 0;
        }
    }
}