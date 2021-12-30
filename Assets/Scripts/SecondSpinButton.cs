using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSpinButton : MonoBehaviour
{
    private GameObject gameControll;

    private GameControl gameControl;

    private GameObject SpinTExtParent;

    private SpinReminder spinReminder;

    private void Start()
    {
        gameControll = GameObject.Find("GameControll");

        gameControl = gameControll.GetComponent<GameControl>();

        SpinTExtParent = GameObject.Find("SpiNTextParent");

        spinReminder = SpinTExtParent.GetComponent<SpinReminder>();
    }

    private void OnMouseDown()
    {
        gameControl.OnMouseDown();
        spinReminder.msToWait += 15000;
        spinReminder.gameCtrlButton.interactable = false;
    }
}
