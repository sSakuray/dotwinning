using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimerController : MonoBehaviour
{
    public float timerDuration = 10f; 
    public Slider progressBar;
    public Text timerText; 

    private void Start()
    {
        StartTimer();
    }

    void StartTimer()
    {
        progressBar.value = 0f;
        progressBar.maxValue = 1f;
        DOTween.To(() => progressBar.value, x => progressBar.value = x, 1f, timerDuration)
            .SetEase(Ease.Linear)
            .OnUpdate(UpdateTimerText) 
            .OnComplete(OnTimerComplete);
    }

    void UpdateTimerText()
    {
        float remainingTime = timerDuration * (1f - progressBar.value);
        timerText.text = Mathf.CeilToInt(remainingTime).ToString();
    }

    void OnTimerComplete()
    {
        timerText.text = "Таймер Умер";
    }
}
