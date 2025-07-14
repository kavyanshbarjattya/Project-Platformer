using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    public bool timerIsRunning = true;
    public float timeRemaining = 30f;  // set starting time in seconds
    public float _currentTime;

    private void Start()
    {
        _currentTime = timeRemaining;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (_currentTime > 0)
            {
                _currentTime -= Time.deltaTime;
                timerText.text = "Timer: " + Mathf.CeilToInt(_currentTime).ToString();
            }
            else
            {
                _currentTime = 0;
                timerIsRunning = false;
                timerText.text = "Timer: 0";
                OnTimerEnd();
            }
        }
    }

    void OnTimerEnd()
    {
        Debug.Log("Time's up!");
        // Game Over
    }
}
