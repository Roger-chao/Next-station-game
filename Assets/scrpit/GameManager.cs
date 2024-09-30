using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;

public class GameManager : MonoBehaviour
{
    public GameObject PauseWindow;
    private bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }
    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPause = !isPause;
            if (isPause == true)
            {
                PauseWindow.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                PauseWindow.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
