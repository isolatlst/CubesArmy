using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private Coroutine _coroutineTimer;
    private CancellationTokenSource _cancellationTokenSource =  new CancellationTokenSource();
    private bool _isCoroutineRunning = false;
    private bool _isAsyncRunning = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _isCoroutineRunning = true;
            _coroutineTimer = StartCoroutine(TimerCoroutine());
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            CancellationToken cancellationToken = _cancellationTokenSource.Token;
            _isAsyncRunning = true;
            Task task = TimerTask(cancellationToken);
        }

        if (Input.GetKeyDown(KeyCode.S) && _isCoroutineRunning)
        {
            StopCoroutine(_coroutineTimer);
        }

        if (Input.GetKeyDown(KeyCode.S) && _isAsyncRunning)
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }
    }


    private IEnumerator TimerCoroutine()
    {
        while (_isCoroutineRunning)
        {
            yield return new WaitForSecondsRealtime(1f);
            Debug.Log("Синхронный таймер");
        }
    }

    private async Task TimerTask(CancellationToken cancellationToken)
    {
        while (_isAsyncRunning)
        {
            await Task.Delay(1000, cancellationToken);
            Debug.Log("Асинхронный таймер");
        }
    }
}