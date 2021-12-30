using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpinText : MonoBehaviour
{
    [SerializeField]
    private GameObject spinText;
    [SerializeField]
    private GameObject spinTextBackGround;

    public void SetActive()
    {
        spinText.gameObject.SetActive(true);
        spinTextBackGround.gameObject.SetActive(true);
    }

    public void UnActive()
    {
        spinText.gameObject.SetActive(false);
        spinTextBackGround.gameObject.SetActive(false);
    }
}
