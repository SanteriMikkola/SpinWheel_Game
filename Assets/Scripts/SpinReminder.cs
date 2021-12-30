using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SpinReminder : MonoBehaviour
{
    public float msToWait = 5000.0f;
    [SerializeField]
    private Text TimerText;

    private GameObject GameControlbutton;

    [HideInInspector]
    public Button gameCtrlButton;

    private ulong lastClick;

    private float secondsLeft;

    private string r;

    private SpinText spinText;

    private GameObject gameControll;

    private GameControl gameControl;

    private void Start()
    {
        gameControll = GameObject.Find("GameControll");

        gameControl = gameControll.GetComponent<GameControl>();

        spinText = GetComponent<SpinText>();

        GameControlbutton = GameObject.Find("GameControlsButton");

        gameCtrlButton = GameControlbutton.GetComponent<Button>();

        lastClick = ulong.Parse(PlayerPrefs.GetString("LastClick"));

        //spinText.SetActive();

        StartedGame();

        if (!IsChestReady())
        {
            gameCtrlButton.interactable = false;
            spinText.UnActive();
        }
    }

    private void Update()
    {
        if (!gameCtrlButton.IsInteractable())
        {
            if (IsChestReady())
            {
                spinText.SetActive();
                gameCtrlButton.interactable = true;
                return;
            }

            //Setup timer
            ulong diff = ((ulong)DateTime.Now.Ticks - lastClick);
            ulong m = diff / TimeSpan.TicksPerMillisecond;
            secondsLeft = (float)(msToWait - m) / 1000.0f;

            r = "";

            spinText.UnActive();

            //Hours
            r += ((int)secondsLeft / 3600).ToString() + "h ";
            secondsLeft -= ((int)secondsLeft / 3600) * 3600;
            //Minutes
            r += ((int)secondsLeft / 60).ToString("00") + "m ";
            //Seconds
            r += ((int)secondsLeft % 60).ToString("00") + "s ";
            TimerText.text = r;

            if (r == "0h 00m 20s " || r == "0h 00m 25s " || r == "0h 00m 30s " || r == "0h 00m 35s " || r == "0h 00m 40s " || r == "0h 00m 45s " || r == "0h 00m 50s " || r == "0h 00m 55s ")
            {
                msToWait -= 5000;
            }
        }
        /*if (gameCtrlButton.interactable == false)
        {
            spinText.SetActive();
        }
        if (gameCtrlButton.interactable == true)
        {
            spinText.UnActive();
        }*/
        //Debug.Log(r);
    }

    public void Click()
    {
        lastClick = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("LastClick", lastClick.ToString());
        gameCtrlButton.interactable = false;

        //Reward in here!!
        

        spinText.UnActive();
    }

    private bool IsChestReady()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastClick);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float secondsLeft = (float)(msToWait - m) / 1000.0f;

        spinText.SetActive();
        //Debug.Log(secondsLeft);

        if (secondsLeft < 0)
        {
            TimerText.text = "";
            return true;
        }
        return false;
    }

    public void StartedGame()
    {
        //Setup timer
        ulong diff = ((ulong)DateTime.Now.Ticks - lastClick);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float secondsLeft = (float)(msToWait - m) / 1000.0f;

        r = "";

        spinText.UnActive();

        //Hours
        r += ((int)secondsLeft / 3600).ToString() + "h ";
        secondsLeft -= ((int)secondsLeft / 3600) * 3600;
        //Minutes
        r += ((int)secondsLeft / 60).ToString("00") + "m ";
        //Seconds
        r += ((int)secondsLeft % 60).ToString("00") + "s ";
        TimerText.text = r;

        lastClick = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("LastClick", lastClick.ToString());
        gameCtrlButton.interactable = false;

        //Reward in here!!

        spinText.UnActive();
    }
}
