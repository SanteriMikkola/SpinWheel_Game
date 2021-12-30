using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DailyGiftControl : MonoBehaviour
{
    [SerializeField]
    private Button DailyGift1;
    [SerializeField]
    private Button DailyGift2;

    public void SetDailyGift1Active()
    {
        DailyGift1.gameObject.SetActive(true);
        DailyGift2.gameObject.SetActive(false);
    }

    public void SetDailyGift2Active()
    {
        DailyGift1.gameObject.SetActive(false);
        DailyGift2.gameObject.SetActive(true);
    }
}