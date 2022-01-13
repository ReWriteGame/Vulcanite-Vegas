using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameRules : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private ScoreCounter scoreCounter;

    public UnityEvent winBidEvent;
    public UnityEvent loseBidEvent;

    private Coroutine correntCor;
    public void StartGame()
    {
        timer.CurrentTime = 0;
        timer.StartTimer();
        StartLoseGameMachine();
    }




    public void StopGame()
    {
        timer.StopTimer();
        StopLoseGameMachine();
    }

    private void StartLoseGameMachine()
    {
        float randomTime = Random.Range(0, timer.MaxTime);
        correntCor = StartCoroutine(LoseGameCor(randomTime));
    }
    private void StopLoseGameMachine()
    {
        winBidEvent?.Invoke();
        StopCoroutine(correntCor);
    }

    private void CompareResults()
    {
        scoreCounter.add(timer.CurrentTime);
    }

    private IEnumerator LoseGameCor(float time)
    {
        yield return new WaitForSeconds(time);
        loseBidEvent?.Invoke();
        timer.StopTimer();
        yield break;
    }

    private void OnEnable()
    {
        timer.stopTimeEvent.AddListener(CompareResults);
    }
    private void OnDisable()
    {
        timer.stopTimeEvent.RemoveListener(CompareResults);
    }
}
