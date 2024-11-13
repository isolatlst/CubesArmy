using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Combine : MonoBehaviour
{
    private CancellationTokenSource _cancellationTokenSource;
    private bool _isTimerRunning = true;

    private void Start()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;
        StartCoroutine(CoroutineTimer(cancellationToken));
    }

    private IEnumerator CoroutineTimer(CancellationToken cancellationToken)
    {
        while (_isTimerRunning)
        {
            yield return new WaitForSeconds(0.5f);
            yield return TaskTimer(cancellationToken);
            Debug.Log("Combine coroutine with tasks");
        }
    }

    private async Task TaskTimer(CancellationToken cancellationToken)
    {
        await Task.Delay(500, cancellationToken);
    }
    
    /* Таска с корутиной внутри 
     private void Start()
    {
        // var cancellationTokenSource = new CancellationTokenSource();
        // var cancellationToken = cancellationTokenSource.Token;
        // Task task = TaskTimer(cancellationToken);
    }
    
    private IEnumerator CoroutineTimer()
    {
        yield return new WaitForSeconds(0.5f);
    }

    private async Task TaskTimer(CancellationToken cancellationToken)
    {
        while (_isTimerRunning)
        {
            await Task.Delay(500, cancellationToken);
            await Task.Run(CoroutineTimer);
            Debug.Log("Combine task with coroutine");
        }
    }
    */
}