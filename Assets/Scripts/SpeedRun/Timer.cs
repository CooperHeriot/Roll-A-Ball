using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float currentTime = 0;
    float bestTime;
    bool timing = false;

    StartAndQuir startAndQuirt;

    [Header("UI Countdown Panel")]
    public GameObject countdownPanel;
    public Text countdownText;

    [Header("UI in Game Panel")]
    public Text timertext;

    [Header("UI Game over Panel")]
    public GameObject timesPanel;
    public Text myTimeResult;
    public Text BestTimeResult;

    // Start is called before the first frame update
    void Awake()
    {
        countdownPanel = GameObject.Find("CountDownpanel");
        countdownText = countdownPanel.GetComponentInChildren<Text>();

        timertext = GameObject.Find("Timertext").GetComponent<Text>();

        timesPanel = GameObject.Find("Times");
        myTimeResult = GameObject.Find("jaja").GetComponent<Text>();
        BestTimeResult = GameObject.Find("zaza").GetComponent<Text>();

        timesPanel.SetActive(false);
        countdownPanel.SetActive(false);
        timertext.text = "";
        startAndQuirt = FindObjectOfType<StartAndQuir>();
    }

    private void OnLevelWasLoaded(int level)
    {
        print("bruh");
        //GetThings();
    }

    // Update is called once per frame
    void Update()
    {
        if (timing)
        {
            currentTime += Time.deltaTime;
            timertext.text = currentTime.ToString("F3");
        }
    }

    public IEnumerator StartCountdown()
    {
        //GetThings();
        yield return new WaitForEndOfFrame();
        Debug.Log("Started Timer");
        bestTime = PlayerPrefs.GetFloat("BestTime" + startAndQuirt.GetSceneName());
        if (bestTime == 0f) bestTime = 680f;

        countdownPanel.SetActive(true);
        countdownText.text = ("3");
        yield return new WaitForSeconds(1);
        countdownText.text = ("2");
        yield return new WaitForSeconds(1);
        countdownText.text = ("1");
        yield return new WaitForSeconds(1);
        countdownText.text = ("GO");
        yield return new WaitForSeconds(1);
        StartTimer();
        countdownPanel.SetActive(false);
    }

    public void StartTimer()
    {
        currentTime = 0;
        timing = true;
    }

    public void StopTimer()
    {
        timing = false;
        timesPanel.SetActive(true);
        myTimeResult.text = currentTime.ToString("F3");
        BestTimeResult.text = bestTime.ToString("F3") + "!! NEW BEST !!";

        if (currentTime <= bestTime)
        {
            bestTime = currentTime;
            PlayerPrefs.SetFloat("BestTime" + startAndQuirt.GetSceneName(), bestTime);
            BestTimeResult.text = bestTime.ToString("F3") + "!! NEW BEST !!";
        }
    }

    public bool IsTiming()
    {
        return timing;
    }

    public void GetThings()
    {
        countdownPanel = GameObject.Find("CountDownpanel");
        countdownText = countdownPanel.GetComponentInChildren<Text>();

        timertext = GameObject.Find("Timertext").GetComponent<Text>();

        timesPanel = GameObject.Find("Times");
        myTimeResult = GameObject.Find("jaja").GetComponent<Text>();
        BestTimeResult = GameObject.Find("zaza").GetComponent<Text>();
    }
}
