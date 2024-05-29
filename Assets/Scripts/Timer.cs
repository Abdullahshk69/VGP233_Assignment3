using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float timer = 0.0f;
    TextMeshProUGUI timerText;
    void Start()
    {
        DontDestroyOnLoad(this);
        timerText.text = "Time: " + timer;
    }

    void OnEnable()
    {
        timerText = GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>();
        timerText.text = "Time: " + timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Win")
        {
            timer += Time.deltaTime;
            timerText.text = "Time: " + timer;
        }
    }
}
