using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccButtonUP : MonoBehaviour
{
    private GameObject AccButton;
    private Button AccButtonButton;
    private Animator AccButtonAnimator;
    private GameObject SettButton;
    private BoxCollider SettButtonBoxCol;
    private BoxCollider BoxCol;

    void Start()
    {
        AccButton = GameObject.Find("AccountButton");
        AccButtonButton = AccButton.GetComponent<Button>();
        AccButtonAnimator = AccButton.GetComponent<Animator>();
        SettButton = GameObject.Find("settingsBoxCol");
        SettButtonBoxCol = SettButton.GetComponent<BoxCollider>();
        BoxCol = GetComponent<BoxCollider>();
    }

    public void OnMouseDown()
    {
        AccButtonButton.interactable = true;
        AccButtonAnimator.SetTrigger("RePress");
        SettButtonBoxCol.enabled = false;
        BoxCol.enabled = false;
    }
}
