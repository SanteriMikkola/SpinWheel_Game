using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BetScript : MonoBehaviour
{
    
    private Transform scrollBar;

    private Scrollbar scrollbar;

    [SerializeField]
    private Text betText;

    private float plus = 0f;
    private float miinus = 0.75f;
    private float plus2 = 1f;
    private float miinus2 = 0.25f;

    private bool IsThatPlus;

    [SerializeField]
    private Row[] rows;

    private GameObject gameControll;

    private GameControl gameControl;

    private void Start()
    {
        gameControll = GameObject.Find("GameControll");

        gameControl = gameControll.GetComponent<GameControl>();

        scrollBar = GameObject.Find("Scrollbar").transform;

        scrollbar = scrollBar.gameObject.GetComponent<Scrollbar>();

        scrollbar.value = 0f;

    }

    public void OnMouseDown()
    {
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
        {
            if (scrollbar.value == 0f)
            {
                StartCoroutine("ButtonMiinus2");
                IsThatPlus = true;
                gameControl.Bet2();
                betText.text = "BET: " + gameControl.spinPay;
                Debug.Log("Bet2");
            }
            else if (scrollbar.value == 0.25f)
            {
                if (IsThatPlus == true)
                {
                    StartCoroutine("ButtonMiinus1");
                    IsThatPlus = true;
                    gameControl.Bet3();
                    betText.text = "BET: " + gameControl.spinPay;
                    Debug.Log("Bet3");
                }
                else if (IsThatPlus == false)
                {
                    StartCoroutine("ButtonPlus1");
                    IsThatPlus = false;
                    gameControl.Bet1();
                    betText.text = "BET: " + gameControl.spinPay;
                    Debug.Log("Bet1");
                }
            }
            else if (scrollbar.value == 0.75f)
            {
                if (IsThatPlus == true)
                {
                    StartCoroutine("ButtonPlus2");
                    IsThatPlus = true;
                    gameControl.Bet4();
                    betText.text = "BET: " + gameControl.spinPay;
                    Debug.Log("Bet4");
                }
                else if (IsThatPlus == false)
                {
                    StartCoroutine("ButtonMiinus2");
                    IsThatPlus = false;
                    gameControl.Bet2();
                    betText.text = "BET: " + gameControl.spinPay;
                    Debug.Log("Bet2");
                }
            }
            else if (scrollbar.value == 1f)
            {
                StartCoroutine("ButtonMiinus1");
                IsThatPlus = false;
                gameControl.Bet3();
                betText.text = "BET: " + gameControl.spinPay;
                Debug.Log("Bet3");
            }
        }



        /*if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
        {
            if (scrollbar.value <= 0f)
            {
                StartCoroutine("ButtonPlus1");
                IsThatPlus = true;
                gameControl.Bet2();
                Debug.Log("Bet2");
            }
            else if (scrollbar.value == 0.5f)
            {
                if (IsThatPlus == true)
                {
                    StartCoroutine("ButtonPlus2");
                    IsThatPlus = false;
                    gameControl.Bet3();
                    Debug.Log("Bet3");
                }
                else if (IsThatPlus == false)
                {
                    StartCoroutine("ButtonMiinus1");
                    IsThatPlus = true;
                    gameControl.Bet1();
                    Debug.Log("Bet1");
                }
            }
            else if (scrollbar.value == 1f)
            {
                StartCoroutine("ButtonMiinus2");
                IsThatPlus = false;
                gameControl.Bet2();
                Debug.Log("Bet2");
            }
        }*/
    }

    private IEnumerator ButtonPlus1()
    {
        scrollbar.SetValueWithoutNotify(plus);

        yield return new WaitForSeconds(0.1f);
    }
    private IEnumerator ButtonPlus2()
    {
        scrollbar.SetValueWithoutNotify(plus2);

        yield return new WaitForSeconds(0.1f);
    }
    private IEnumerator ButtonMiinus1()
    {
        scrollbar.SetValueWithoutNotify(miinus);

        yield return new WaitForSeconds(0.1f);
    }
    private IEnumerator ButtonMiinus2()
    {
        scrollbar.SetValueWithoutNotify(miinus2);

        yield return new WaitForSeconds(0.1f);
    }

    /*public void BetControlForSliding()
    {
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
        {
            if (scrollbar.value <= 0.16f)
            {
                StartCoroutine("ButtonMiinus2");
                IsThatPlus = true;
                gameControl.Bet2();
                Debug.Log("Bet2");
            }
            else if (scrollbar.value == 0.25f)
            {
                if (IsThatPlus == true)
                {
                    StartCoroutine("ButtonMiinus1");
                    IsThatPlus = true;
                    gameControl.Bet3();
                    Debug.Log("Bet3");
                }
                else if (IsThatPlus == false)
                {
                    StartCoroutine("ButtonPlus1");
                    IsThatPlus = false;
                    gameControl.Bet1();
                    Debug.Log("Bet1");
                }
            }
            else if (scrollbar.value == 0.75)
            {
                if (IsThatPlus == true)
                {
                    StartCoroutine("ButtonPlus2");
                    IsThatPlus = true;
                    gameControl.Bet4();
                    Debug.Log("Bet4");
                }
                else if (IsThatPlus == false)
                {
                    StartCoroutine("ButtonMiinus2");
                    IsThatPlus = false;
                    gameControl.Bet2();
                    Debug.Log("Bet2");
                }
            }
            else if (scrollbar.value == 1f)
            {
                StartCoroutine("ButtonMiinus1");
                IsThatPlus = false;
                gameControl.Bet3();
                Debug.Log("Bet3");
            }
        }
    }*/
}
