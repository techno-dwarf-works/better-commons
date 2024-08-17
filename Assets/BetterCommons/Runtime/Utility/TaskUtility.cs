using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Better.Commons.Runtime.Utility
{
    public static class TaskUtility
    {
        public static async Task WaitForSeconds(float seconds, CancellationToken cancellationToken = default)
        {
            if (seconds <= 0 || cancellationToken.IsCancellationRequested)
            {
                return;
            }

            while (seconds > 0 && !cancellationToken.IsCancellationRequested)
            {
                await Task.Yield();
                seconds -= Time.unscaledDeltaTime;
            }
        }

        public static Task Delay(float seconds, CancellationToken cancellationToken = default)
        {
            if (seconds <= 0 || cancellationToken.IsCancellationRequested)
            {
                return Task.CompletedTask;
            }

            var millisecondsDelay = TimeUtility.SecondsToMilliseconds(seconds);
            return Task.Delay(millisecondsDelay, cancellationToken);
        }

        public static async Task WaitWhile(Func<bool> condition, CancellationToken cancellationToken = default)
        {
            if (condition == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(condition));
                return;
            }

            while (!cancellationToken.IsCancellationRequested && condition.Invoke())
            {
                await Task.Yield();
            }
        }

        public static async Task WaitUntil(Func<bool> condition, CancellationToken cancellationToken = default)
        {
            if (condition == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(condition));
                return;
            }

            while (!cancellationToken.IsCancellationRequested && !condition.Invoke())
            {
                await Task.Yield();
            }
        }

        public static async Task WaitFrame(int count, CancellationToken cancellationToken = default)
        {
            if (count <= 0 || cancellationToken.IsCancellationRequested)
            {
                return;
            }

            for (int i = 0; i < count; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                await Task.Yield();
            }
        }
    }
}