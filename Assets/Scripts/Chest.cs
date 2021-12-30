using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public float msToWait = 5000.0f;
    [SerializeField]
    private Text TimerText;

    private GameObject RewardButt;

    private Button chestButton;

    private ulong lastOpen;

    private DailyGiftControl dailyGifts;

    private GameObject DailyRewardPanel;

    private GameObject gameControll;

    private GameControl gameControl;

    private GameObject rewardText;

    private GameObject coinIcon;

    private void Start()
    {
        gameControll = GameObject.Find("GameControll");

        rewardText = GameObject.Find("RewardText");
        coinIcon = GameObject.Find("CoinIcon2");

        gameControl = gameControll.GetComponent<GameControl>();

        dailyGifts = GetComponent<DailyGiftControl>();

        RewardButt = GameObject.Find("RewardButton");

        chestButton = RewardButt.GetComponent<Button>();

        lastOpen = ulong.Parse(PlayerPrefs.GetString("LastOpen"));

        DailyRewardPanel = GameObject.Find("DailyRewardPanelBackGround");

        if (DailyRewardPanel.activeSelf == true)
        {
            DailyRewardPanel.SetActive(false);
        }

        dailyGifts.SetDailyGift2Active();
        coinIcon.SetActive(true);
        rewardText.SetActive(true);

        if (!IsChestReady())
        {
            chestButton.interactable = false;
            dailyGifts.SetDailyGift1Active();
            coinIcon.SetActive(false);
            rewardText.SetActive(false);
        }
    }

    private void Update()
    {
        if (!chestButton.IsInteractable())
        {
            if (IsChestReady())
            {
                dailyGifts.SetDailyGift2Active();
                chestButton.interactable = true;
                return;
            }

            //Setup timer
            ulong diff = ((ulong)DateTime.Now.Ticks - lastOpen);
            ulong m = diff / TimeSpan.TicksPerMillisecond;
            float secondsLeft = (float)(msToWait - m) / 1000.0f;

            string r = "";

            dailyGifts.SetDailyGift1Active();

            //Hours
            r += ((int)secondsLeft / 3600).ToString() + "h ";
            secondsLeft -= ((int)secondsLeft / 3600) * 3600;
            //Minutes
            r += ((int)secondsLeft / 60).ToString("00") + "m ";
            //Seconds
            r += ((int)secondsLeft % 60).ToString("00") + "s ";
            TimerText.text = r;
        }
        if (chestButton.interactable == false)
        {
            dailyGifts.SetDailyGift1Active();
            
        }
        if (chestButton.interactable == true)
        {
            dailyGifts.SetDailyGift2Active();
            
        }
    }

    public void Click()
    {
        lastOpen = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("LastOpen", lastOpen.ToString());
        chestButton.interactable = false;

        //Reward in here!!
        gameControl.CoinsAddet();

        coinIcon.SetActive(false);
        rewardText.SetActive(false);

        dailyGifts.SetDailyGift1Active();
    }

    private bool IsChestReady()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastOpen);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float secondsLeft = (float)(msToWait - m) / 1000.0f;

        dailyGifts.SetDailyGift2Active();
        //Debug.Log(secondsLeft);

        if (secondsLeft < 0)
        {
            TimerText.text = "";
            coinIcon.SetActive(true);
            rewardText.SetActive(true);
            return true;
        }
        return false;
    }
}
