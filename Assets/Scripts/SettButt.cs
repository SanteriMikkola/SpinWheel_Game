using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettButt : MonoBehaviour
{
    /*[SerializeField]
    private Text settText;

    [SerializeField]
    private Text musicText;

    [SerializeField]
    private Text effectsText;*/

    public GameObject settingsPanel;
    /*private Image settingsPanelImage;
    private GameObject asetusPaneeli;
    private GameObject X_Button2;
    private Image asetusPaneeliImage;
    private Image X_Button2Image;*/

    void Start()
    {
        /*settingsPanel = GameObject.Find("SettingsPanelBackGround2");
        settingsPanelImage = settingsPanel.GetComponent<Image>();
        asetusPaneeli = GameObject.Find("SettingsPanel");
        X_Button2 = GameObject.Find("X_Button2");
        asetusPaneeliImage = asetusPaneeli.GetComponent<Image>();
        X_Button2Image = X_Button2.GetComponent<Image>();*/
    }

    public void OnMouseDown()
    {
        /*settingsPanelImage.enabled = true;
        asetusPaneeliImage.enabled = true;
        X_Button2Image.enabled = true;
        settText.enabled = true;
        musicText.enabled = true;
        effectsText.enabled = true;*/
        settingsPanel.SetActive(true);
    }
}
