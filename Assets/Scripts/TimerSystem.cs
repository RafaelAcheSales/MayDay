using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimerSystem : MonoBehaviour
{
    public Text timerText;
    public float timeLeft = 250.0f; //seconds
    
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = "Time Left: " + SecondsToMinSecString(timeLeft);
        TimerCheck();
    }
    public string SecondsToMinSecString(float seconds) {
        int minutes = Mathf.FloorToInt(seconds / 60);
        int secondsRemaining = Mathf.RoundToInt(seconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, secondsRemaining);
    }
    public void TimerCheck() {
        if (timeLeft <= 0) {
            Debug.Log("Time is up!");
            SceneManager.LoadSceneAsync("GameOver");
            gameObject.SetActive(false);
        }
    }
}
