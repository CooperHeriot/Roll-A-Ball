using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paused : MonoBehaviour
{
    public GameObject pausPanel;
    bool ispaused = false;
    // Start is called before the first frame update
    private void Start()
    {
        pausPanel.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        ispaused = !ispaused;

        if (ispaused)
        {
            pausPanel.SetActive(true);
            Time.timeScale = 0;
        } else
        {
            pausPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
