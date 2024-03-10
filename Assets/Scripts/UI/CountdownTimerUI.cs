using TMPro;
using UnityEngine;

public class CountdownTimerUI : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private float remainingTime;


    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SetTimer(float time)
    {
        remainingTime = time;
    }
}
