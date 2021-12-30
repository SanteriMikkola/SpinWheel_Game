using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static event Action GameStarted = delegate { };

    [SerializeField]
    private Text PText;

    [SerializeField]
    private Text coinText;

    [SerializeField]
    private Text betText;

    [SerializeField]
    private Text NickText;

    [SerializeField]
    private Text Text;

    [SerializeField]
    private Text AcceptButtonText;

    [SerializeField]
    private Text changeNNtext;
    
    [SerializeField]
    private GameObject tutoriaali;

    [SerializeField]
    private GameObject MainMenuPanel;

    [SerializeField]
    private GameObject PrizeText;

    [SerializeField]
    private GameObject Scrollbar;

    [SerializeField]
    private GameObject gameControll;

    [SerializeField]
    private GameObject row;

    [SerializeField]
    private GameObject row1;

    [SerializeField]
    private GameObject row2;

    [SerializeField]
    private GameObject BetSystem;

    [SerializeField]
    private GameObject MenuButt;

    [SerializeField]
    private BoxCollider gameControllCollider;

    [SerializeField]
    private BoxCollider betSystemCollider;

    [SerializeField]
    private Image ScrollbarImage;

    [SerializeField]
    private Image HandleImage;

    [SerializeField]
    private Animator TheLogoAnim;

    [SerializeField]
    private BoxCollider spinButt1;

    [SerializeField]
    private BoxCollider spinButt2;

    [SerializeField]
    private BoxCollider spinButt3;

    [SerializeField]
    private BoxCollider spinButt4;

    [SerializeField]
    private BoxCollider spinButt5;

    [SerializeField]
    private BoxCollider spinButt6;

    [SerializeField]
    private BoxCollider spinButt7;

    [SerializeField]
    private BoxCollider InventoryUP;

    [SerializeField]
    private Animator AccButtAnim;

    [SerializeField]
    private BoxCollider SettingsButtboxCollider;

    [SerializeField]
    private GameObject tutoriaali3or4;

    [SerializeField]
    private GameObject outOfCoinsPanel;

    public Row[] rows;

    private int CoinAdd = 1000;
    private int CoinsSubtracts = 1000;

    public bool AddCoins = false;
    public bool SubtractCoins = false;

    private bool ResultsChecked = false;
    private float prizeValue;
    public int spinPay = 100;

    public int coins = 2000;

    private float dividedPrize;

    private int newPrize;
    private float doubledPrize;

    public int spins;

    public int diamond3Wins;
    public int diamond2Wins;
    public int crown3Wins;
    public int crown2Wins;
    public int seven3Wins;
    public int seven2Wins;

    private float D3results;
    private float D2results;
    private float C3results;
    private float C2results;
    private float S3results;
    private float S2results;

    private bool WinRatioChecked = false;
    private bool NewPlayerCheckDone = false;
    private bool WinRatioChecking = false;
    private bool NewPlayerChecking = false;

    public bool IsWinRatioTooBig = false;
    public bool IsThatNewPlayer = false;

    private Scrollbar scrollbar;

    private Transform betSystem;

    private GameObject TheWheel;

    private WheelControl wheelControl;

    private GameObject SpinTExtParent;

    private SpinReminder spinReminder;

    private GameObject BackgroundPanel;
    private Image BackgroundPanelsImage;
    private GameObject ChooseNicknamePanel;
    private Image ChooseNicknamePanelImage;
    private GameObject InputNickname;
    private Image InputNicknameImage;
    private GameObject Placeholder;
    private Text PlaceholderText;
    private GameObject AcceptButtonBackG;
    private Image AcceptButtonBackGimage;
    private GameObject AcceptButton;
    private Image AcceptButtonImage;
    private Button AcceptButtonButton;

    public bool resetSpins = false;
    public bool resetWins = false;
    public bool RESETALL = false;

    private InputField inputField;

    private GameObject inputNickname;

    //[HideInInspector]
    public string nickName;

    public bool isNicknameAccepted = false;
    public bool isThatFirstStart = true;
    public bool playerNeedTuto = true;
    public bool isTutorialInProgress = false;

    [HideInInspector]
    public bool isButtonDown = false;

    private void Start()
    {
        //AllReset();
        LoadData();
        coinText.text = "" + coins;

        betText.text = "BET: " + spinPay;

        betSystem = GameObject.Find("Scrollbar").transform;

        scrollbar = betSystem.gameObject.GetComponent<Scrollbar>();

        TheWheel = GameObject.Find("TheWheel");

        wheelControl = TheWheel.GetComponent<WheelControl>();

        SpinTExtParent = GameObject.Find("SpiNTextParent");

        spinReminder = SpinTExtParent.GetComponent<SpinReminder>();

        inputNickname = GameObject.Find("InputNickname");
        
        inputField = inputNickname.GetComponent<InputField>();

        BackgroundPanel = GameObject.Find("BackgroundPanel");
        BackgroundPanelsImage = BackgroundPanel.GetComponent<Image>();
        ChooseNicknamePanel = GameObject.Find("ChooseNicknamePanel");
        ChooseNicknamePanelImage = ChooseNicknamePanel.GetComponent<Image>();
        InputNickname = GameObject.Find("InputNickname");
        InputNicknameImage = InputNickname.GetComponent<Image>();
        Placeholder = GameObject.Find("Placeholder");
        PlaceholderText = Placeholder.GetComponent<Text>();
        AcceptButtonBackG = GameObject.Find("AcceptButtonBackG");
        AcceptButtonBackGimage = AcceptButtonBackG.GetComponent<Image>();
        AcceptButton = GameObject.Find("AcceptButton");
        AcceptButtonImage = AcceptButton.GetComponent<Image>();
        AcceptButtonButton = AcceptButton.GetComponent<Button>();

        if (isThatFirstStart == true || playerNeedTuto == true)
        {
            NewPlayer();
        }

        if (coins >= 10000)
        {
            coinText.transform.position.Set(-470f, coinText.transform.position.y, coinText.transform.position.z);
        }
        if (coins < 10000)
        {
            coinText.transform.position.Set(-479f, coinText.transform.position.y, coinText.transform.position.z);
        }

        /*if (spins <= 20)
        {
            IsThatNewPlayer = true;
            rows[0].newPlayerWinRatioActivated = true;
            rows[2].newPlayerWinRatioActivated = true;
            SaveData();
            LoadData();
            
            
        }
        if (spins > 20 && spins < 110)
        {
            IsThatNewPlayer = false;
            rows[0].newPlayerWinRatioActivated = false;
            rows[2].newPlayerWinRatioActivated = false;
            SaveData();
            LoadData();
        }
        if (spins == 110)
        {
            IsThatNewPlayer = true;
            rows[0].newPlayerWinRatioActivated = true;
            rows[2].newPlayerWinRatioActivated = true;
            SaveData();
            LoadData();
            
        }*/
    }

    void Update()
    {
        if (!WinRatioChecking)
        {
            HugeWinRatioCheck();
        }
        if (!NewPlayerChecking)
        {
            NewPlayerWinRate();
        }
        prizeValue = 0;
        newPrize = 0;

        changeNNtext.text = nickName;
        /*if (spins <= 20)
        {
            IsThatNewPlayer = true;
            rows[0].newPlayerWinRatioActivated = true;
            rows[2].newPlayerWinRatioActivated = true;
            SaveData();
            LoadData();


        }
        if (spins > 20 && spins < 110)
        {
            IsThatNewPlayer = false;
            rows[0].newPlayerWinRatioActivated = false;
            rows[2].newPlayerWinRatioActivated = false;
            SaveData();
            LoadData();
        }
        if (spins == 110)
        {
            IsThatNewPlayer = true;
            rows[0].newPlayerWinRatioActivated = true;
            rows[2].newPlayerWinRatioActivated = true;
            SaveData();
            LoadData();

        }*/

        if (coins >= 10000)
        {
            coinText.transform.position.Set(-470f, coinText.transform.position.y, coinText.transform.position.z);
        }
        if (coins < 10000)
        {
            coinText.transform.position.Set(-479f, coinText.transform.position.y, coinText.transform.position.z);
        }

        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
        {
            prizeValue = 0;
            PText.enabled = false;
            ResultsChecked = false;
            scrollbar.enabled = false;
            WinRatioChecked = false;
            NewPlayerCheckDone = false;
        }

        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && !ResultsChecked && !WinRatioChecked && !NewPlayerCheckDone)
        {
            CheckResults();
            PText.enabled = true;
            scrollbar.enabled = true;
            PText.text = "Prize: " + newPrize;
            Debug.Log("Prize: " + newPrize);
            coinText.text = "" + coins;
            Debug.Log("Coins: " + coins);
            HugeWinRatioCheck();
            NewPlayerWinRate();
            SaveData();
            LoadData();
        }

        if (resetSpins == true)
        {
            SpinsReset();
        }
        if (AddCoins == true)
        {
            CoinsAddet();
        }
        if (SubtractCoins == true)
        {
            CoinsSubtracted();
        }
        if (resetWins == true)
        {
            WinsReset();
        }
        if (RESETALL == true)
        {
            AllReset();
        }
        SaveData();
        LoadData();
        
    }

    public void Bet1()
    {
        spinPay = 100;
    }
    public void Bet2()
    {
        spinPay = 500;  //old 250
    }
    public void Bet3()
    {
        spinPay = 2000;  //old 500
    }
    public void Bet4()
    {
        spinPay = 5000;  //old 1200
    }

    public void OnMouseDown()
    {
        Debug.Log("Click!");
        isButtonDown = true;
        if (coins < 5000 && coins > 2000 && scrollbar.value == 1f)
        {
            scrollbar.value = 0.75f;
            spinPay = 2000;
            betText.text = "BET: " + spinPay;
        }
        else if (coins < 2000 && coins > 500 && scrollbar.value == 0.75f || coins < 2000 && coins > 500 && scrollbar.value == 1f)
        {
            //if(coins < 500 && coins > 100 &&)
            scrollbar.value = 0.25f;
            spinPay = 500;
            betText.text = "BET: " + spinPay;
        }
        else if (coins < 500 && coins > 100 && scrollbar.value == 0.25f || coins < 500 && coins > 100 && scrollbar.value == 0.75f || coins < 500 && coins > 100 && scrollbar.value == 1f)
        {
            scrollbar.value = 0f;
            spinPay = 100;
            betText.text = "BET: " + spinPay;
        }
        if (coins < spinPay && rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
        {
            Debug.Log("You don't have enough coins!");
            outOfCoinsPanel.SetActive(true);
            betSystemCollider.enabled = false;
            gameControllCollider.enabled = false;
            spinButt1.enabled = false;
            spinButt2.enabled = false;
            spinButt3.enabled = false;
            spinButt4.enabled = false;
            spinButt5.enabled = false;
            spinButt6.enabled = false;
            spinButt7.enabled = false;
        }
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && coins >= spinPay)
        {
            StartCoroutine("ButtonDown");
            spinReminder.msToWait += 15000;
            spinReminder.gameCtrlButton.interactable = false;
        }
    }

    private IEnumerator ButtonDown()
    {
        GameStarted();
        isButtonDown = false;

        spins++;
        SaveData();
        Debug.Log("Spins: " + spins);

        wheelControl.StartSpinning();

        coins -= spinPay;
        SaveData();
        LoadData();
        coinText.text = "" + coins;
        Debug.Log("Coins: " + coins);

        yield return new WaitForSeconds(0.1f);
    }

    public void SaveData()
    {
        SaveSystem.SaveData(this);
    }

    public void LoadData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        coins = data.coins;
        spins = data.spins;
        diamond3Wins = data.diamond3Wins;
        diamond2Wins = data.diamond2Wins;
        crown3Wins = data.crown3Wins;
        crown2Wins = data.crown2Wins;
        seven3Wins = data.seven3Wins;
        seven2Wins = data.seven2Wins;
        IsWinRatioTooBig = data.IsWinRatioTooBig;
        IsThatNewPlayer = data.IsThatNewPlayer;
        rows[0].isWinRatioNormalized = data.isWinRatioNormalized0;
        rows[1].isWinRatioNormalized = data.isWinRatioNormalized1;
        rows[2].isWinRatioNormalized = data.isWinRatioNormalized2;
        rows[0].newPlayerWinRatioActivated = data.newPlayerWinRatioActivated0;
        rows[2].newPlayerWinRatioActivated = data.newPlayerWinRatioActivated2;
        rows[0].roundMax = data.roundMax0;
        rows[1].roundMax = data.roundMax1;
        rows[2].roundMax = data.roundMax2;
        nickName = data.nickname;
        isNicknameAccepted = data.isNicknameAccepted;
        isThatFirstStart = data.isThatFirstStart;
        playerNeedTuto = data.playerNeedTuto;
    }

    private void CheckResults()
    {
        switch (rows[0].StoppedSlot)
        {
            case "Diamond":
                {
                    if (rows[0].StoppedSlot == "Diamond" && rows[1].StoppedSlot == "Diamond" && rows[2].StoppedSlot == "Diamond")
                    {
                        FindObjectOfType<AudioManager>().Play("Win");
                        prizeValue = 4000;
                        if (scrollbar.value == 1f)
                        {
                            prizeValue = 6000;
                        }
                        //coins += prizeValue;
                        diamond3Wins++;
                        SaveData();
                        LoadData();
                    }
                    else if ((rows[0].StoppedSlot == rows[1].StoppedSlot) && (rows[0].StoppedSlot == "Diamond"))
                    {
                        FindObjectOfType<AudioManager>().Play("Win");
                        prizeValue = 3500;
                        //coins += prizeValue;
                        diamond2Wins++;
                        SaveData();
                        LoadData();
                    }
                }
                break;
            case "Crown":
                {
                    if (rows[0].StoppedSlot == "Crown" && rows[1].StoppedSlot == "Crown" && rows[2].StoppedSlot == "Crown")
                    {
                        FindObjectOfType<AudioManager>().Play("Win");
                        prizeValue = 3350;
                        if (scrollbar.value == 1f)
                        {
                            prizeValue = 4000;
                        }
                        //coins += prizeValue;
                        crown3Wins++;
                        SaveData();
                        LoadData();
                    }
                    else if ((rows[0].StoppedSlot == rows[1].StoppedSlot) && (rows[0].StoppedSlot == "Crown"))
                    {
                        FindObjectOfType<AudioManager>().Play("Win");
                        prizeValue = 2800;
                        //coins += prizeValue;
                        crown2Wins++;
                        SaveData();
                        LoadData();
                    }
                }
                break;
            case "Melon":
                {
                    if (rows[0].StoppedSlot == "Melon" && rows[1].StoppedSlot == "Melon" && rows[2].StoppedSlot == "Melon")
                    {
                        FindObjectOfType<AudioManager>().Play("Win");
                        prizeValue = 800;
                        //coins += prizeValue;
                        SaveData();
                        LoadData();
                    }
                    else if ((rows[0].StoppedSlot == rows[1].StoppedSlot) && (rows[0].StoppedSlot == "Melon"))
                    {
                        FindObjectOfType<AudioManager>().Play("Win");
                        prizeValue = 600;
                        if (scrollbar.value == 0f)
                        {
                            prizeValue = 450;
                        }
                        //coins += prizeValue;
                        SaveData();
                        LoadData();
                    }
                }
                break;
            case "Bar":
                {
                    if (rows[0].StoppedSlot == "Bar" && rows[1].StoppedSlot == "Bar" && rows[2].StoppedSlot == "Bar")
                    {
                        FindObjectOfType<AudioManager>().Play("Win");
                        prizeValue = 1850;
                        //coins += prizeValue;
                        SaveData();
                        LoadData();
                    }
                    else if ((rows[0].StoppedSlot == rows[1].StoppedSlot) && (rows[0].StoppedSlot == "Bar"))
                    {
                        FindObjectOfType<AudioManager>().Play("Win");
                        prizeValue = 1500;
                        //coins += prizeValue;
                        SaveData();
                        LoadData();
                    }
                }
                break;
            case "Seven":
                {
                    if (rows[0].StoppedSlot == "Seven" && rows[1].StoppedSlot == "Seven" && rows[2].StoppedSlot == "Seven")
                    {
                        FindObjectOfType<AudioManager>().Play("Win");
                        prizeValue = 2500;
                        //coins += prizeValue;
                        seven3Wins++;
                        SaveData();
                        LoadData();
                    }
                    else if ((rows[0].StoppedSlot == rows[1].StoppedSlot) && (rows[0].StoppedSlot == "Seven"))
                    {
                        FindObjectOfType<AudioManager>().Play("Win");
                        prizeValue = 2000;
                        //coins += prizeValue;
                        seven2Wins++;
                        SaveData();
                        LoadData();
                    }
                }
                break;
            case "Cherry":
                {
                    if (rows[0].StoppedSlot == "Cherry" && rows[1].StoppedSlot == "Cherry" && rows[2].StoppedSlot == "Cherry")
                    {
                        FindObjectOfType<AudioManager>().Play("Win");
                        prizeValue = 1200;
                        //coins += prizeValue;
                        SaveData();
                        LoadData();
                    }
                    else if ((rows[0].StoppedSlot == rows[1].StoppedSlot) && (rows[0].StoppedSlot == "Cherry"))
                    {
                        FindObjectOfType<AudioManager>().Play("Win");
                        prizeValue = 1000;
                        if (scrollbar.value == 0f)
                        {
                            prizeValue = 800;
                        }
                        //coins += prizeValue;
                        SaveData();
                        LoadData();
                    }
                }
                break;
            case "Lemon":
                {
                    if (rows[0].StoppedSlot == "Lemon" && rows[1].StoppedSlot == "Lemon" && rows[2].StoppedSlot == "Lemon")
                    {
                        FindObjectOfType<AudioManager>().Play("Win");
                        prizeValue = 1000;
                        //coins += prizeValue;
                        SaveData();
                        LoadData();
                    }
                    else if ((rows[0].StoppedSlot == rows[1].StoppedSlot) && (rows[0].StoppedSlot == "Lemon"))
                    {
                        FindObjectOfType<AudioManager>().Play("Win");
                        prizeValue = 800;
                        if (scrollbar.value == 0f)
                            {
                                prizeValue = 600;
                            }
                        //coins += prizeValue;
                        SaveData();
                        LoadData();
                    }
                }
                break;
        }

        if ((rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[1].StoppedSlot != rows[2].StoppedSlot) && rows[0].StoppedSlot != "Diamond" || (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[0].StoppedSlot != "Diamond") ||
            (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[1].StoppedSlot != rows[2].StoppedSlot) && rows[0].StoppedSlot != "Crown" || (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[0].StoppedSlot != "Crown") ||
            (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[1].StoppedSlot != rows[2].StoppedSlot) && rows[0].StoppedSlot != "Melon" || (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[0].StoppedSlot != "Melon") ||
            (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[1].StoppedSlot != rows[2].StoppedSlot) && rows[0].StoppedSlot != "Bar" || (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[0].StoppedSlot != "Bar") ||
            (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[1].StoppedSlot != rows[2].StoppedSlot) && rows[0].StoppedSlot != "Seven" || (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[0].StoppedSlot != "Seven") ||
            (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[1].StoppedSlot != rows[2].StoppedSlot) && rows[0].StoppedSlot != "Cherry" || (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[0].StoppedSlot != "Cherry") ||
            (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[1].StoppedSlot != rows[2].StoppedSlot) && rows[0].StoppedSlot != "Lemon" || (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[0].StoppedSlot != "Lemon"))
        {
            switch (rows[1].StoppedSlot)
            {
                case "Diamond":
                    {
                        if ((rows[1].StoppedSlot == rows[2].StoppedSlot) && (rows[1].StoppedSlot == "Diamond"))
                        {
                            FindObjectOfType<AudioManager>().Play("Win");
                            prizeValue = 3500;
                            //coins += prizeValue;
                            diamond2Wins++;
                            SaveData();
                            LoadData();
                        }
                    }
                    break;
                case "Crown":
                    {
                        if ((rows[1].StoppedSlot == rows[2].StoppedSlot) && (rows[1].StoppedSlot == "Crown"))
                        {
                            FindObjectOfType<AudioManager>().Play("Win");
                            prizeValue = 2800;
                            //coins += prizeValue;
                            crown2Wins++;
                            SaveData();
                            LoadData();
                        }
                    }
                    break;
                case "Melon":
                    {
                        if ((rows[1].StoppedSlot == rows[2].StoppedSlot) && (rows[1].StoppedSlot == "Melon"))
                        {
                            FindObjectOfType<AudioManager>().Play("Win");
                            prizeValue = 600;
                            if (scrollbar.value == 0f)
                            {
                                prizeValue = 450;
                            }
                            //coins += prizeValue;
                            SaveData();
                            LoadData();
                        }
                    }
                    break;
                case "Bar":
                    {
                        if ((rows[1].StoppedSlot == rows[2].StoppedSlot) && (rows[1].StoppedSlot == "Bar"))
                        {
                            FindObjectOfType<AudioManager>().Play("Win");
                            prizeValue = 1500;
                            //coins += prizeValue;
                            SaveData();
                            LoadData();
                        }
                    }
                    break;
                case "Seven":
                    {
                        if ((rows[1].StoppedSlot == rows[2].StoppedSlot) && (rows[1].StoppedSlot == "Seven"))
                        {
                            FindObjectOfType<AudioManager>().Play("Win");
                            prizeValue = 2000;
                            //coins += prizeValue;
                            seven2Wins++;
                            SaveData();
                            LoadData();
                        }
                    }
                    break;
                case "Cherry":
                    {
                        if ((rows[1].StoppedSlot == rows[2].StoppedSlot) && (rows[1].StoppedSlot == "Cherry"))
                        {
                            FindObjectOfType<AudioManager>().Play("Win");
                            prizeValue = 1000;
                            if (scrollbar.value == 0f)
                            {
                                prizeValue = 800;
                            }
                            //coins += prizeValue;
                            SaveData();
                            LoadData();
                        }
                    }
                    break;
                case "Lemon":
                    {
                        if ((rows[1].StoppedSlot == rows[2].StoppedSlot) && (rows[1].StoppedSlot == "Lemon"))   //Ehkä rikki!
                        {
                            FindObjectOfType<AudioManager>().Play("Win");
                            prizeValue = 800;
                            if (scrollbar.value == 0f)
                            {
                                prizeValue = 600;
                            }
                            //coins += prizeValue;
                            SaveData();
                            LoadData();
                        }
                    }
                    break;
            }
        }
        if ((rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[1].StoppedSlot != rows[2].StoppedSlot) && rows[0].StoppedSlot != "Diamond" || (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[0].StoppedSlot != "Diamond") || (rows[1].StoppedSlot != rows[2].StoppedSlot) && (rows[1].StoppedSlot != "Diamond") ||
            (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[1].StoppedSlot != rows[2].StoppedSlot) && rows[0].StoppedSlot != "Crown" || (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[0].StoppedSlot != "Crown") || (rows[1].StoppedSlot != rows[2].StoppedSlot) && (rows[1].StoppedSlot != "Crown") ||
            (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[1].StoppedSlot != rows[2].StoppedSlot) && rows[0].StoppedSlot != "Melon" || (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[0].StoppedSlot != "Melon") || (rows[1].StoppedSlot != rows[2].StoppedSlot) && (rows[1].StoppedSlot != "Melon") ||
            (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[1].StoppedSlot != rows[2].StoppedSlot) && rows[0].StoppedSlot != "Bar" || (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[0].StoppedSlot != "Bar") || (rows[1].StoppedSlot != rows[2].StoppedSlot) && (rows[1].StoppedSlot != "Bar") ||
            (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[1].StoppedSlot != rows[2].StoppedSlot) && rows[0].StoppedSlot != "Seven" || (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[0].StoppedSlot != "Seven") || (rows[1].StoppedSlot != rows[2].StoppedSlot) && (rows[1].StoppedSlot != "Seven") ||
            (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[1].StoppedSlot != rows[2].StoppedSlot) && rows[0].StoppedSlot != "Cherry" || (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[0].StoppedSlot != "Cherry") || (rows[1].StoppedSlot != rows[2].StoppedSlot) && (rows[1].StoppedSlot != "Cherry") ||
            (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[1].StoppedSlot != rows[2].StoppedSlot) && rows[0].StoppedSlot != "Lemon" || (rows[0].StoppedSlot != rows[1].StoppedSlot) && (rows[0].StoppedSlot != "Lemon") || (rows[1].StoppedSlot != rows[2].StoppedSlot) && (rows[1].StoppedSlot != "Lemon"))
        {
            switch (rows[2].StoppedSlot)
            {
                case "Diamond":
                    {
                        if ((rows[2].StoppedSlot == rows[0].StoppedSlot) && (rows[2].StoppedSlot == "Diamond"))
                        {
                            FindObjectOfType<AudioManager>().Play("Win");
                            prizeValue = 3500;
                            //coins += prizeValue;
                            diamond2Wins++;
                            SaveData();
                            LoadData();
                        }
                    }
                    break;
                case "Crown":
                    {
                        if ((rows[2].StoppedSlot == rows[0].StoppedSlot) && (rows[2].StoppedSlot == "Crown"))
                        {
                            FindObjectOfType<AudioManager>().Play("Win");
                            prizeValue = 2800;
                            //coins += prizeValue;
                            crown2Wins++;
                            SaveData();
                            LoadData();
                        }
                    }
                    break;
                case "Melon":
                    {
                        if ((rows[2].StoppedSlot == rows[0].StoppedSlot) && (rows[2].StoppedSlot == "Melon"))
                        {
                            FindObjectOfType<AudioManager>().Play("Win");
                            prizeValue = 600;
                            if (scrollbar.value == 0f)
                            {
                                prizeValue = 450;
                            }
                            //coins += prizeValue;
                            SaveData();
                            LoadData();
                        }
                    }
                    break;
                case "Bar":
                    {
                        if ((rows[2].StoppedSlot == rows[0].StoppedSlot) && (rows[2].StoppedSlot == "Bar"))
                        {
                            FindObjectOfType<AudioManager>().Play("Win");
                            prizeValue = 1500;
                            //coins += prizeValue;
                            SaveData();
                            LoadData();
                        }
                    }
                    break;
                case "Seven":
                    {
                        if ((rows[2].StoppedSlot == rows[0].StoppedSlot) && (rows[2].StoppedSlot == "Seven"))
                        {
                            FindObjectOfType<AudioManager>().Play("Win");
                            prizeValue = 2000;
                            //coins += prizeValue;
                            seven2Wins++;
                            SaveData();
                            LoadData();
                        }
                    }
                    break;
                case "Cherry":
                    {
                        if ((rows[2].StoppedSlot == rows[0].StoppedSlot) && (rows[2].StoppedSlot == "Cherry"))
                        {
                            FindObjectOfType<AudioManager>().Play("Win");
                            prizeValue = 1000;
                            if (scrollbar.value == 0f)
                            {
                                prizeValue = 800;
                            }
                            //coins += prizeValue;
                            SaveData();
                            LoadData();
                        }
                    }
                    break;
                case "Lemon":
                    {
                        if ((rows[2].StoppedSlot == rows[0].StoppedSlot) && (rows[2].StoppedSlot == "Lemon"))   //Ehkä rikki!
                        {
                            FindObjectOfType<AudioManager>().Play("Win");
                            prizeValue = 800;
                            if (scrollbar.value == 0f)
                            {
                                prizeValue = 600;
                            }
                            //coins += prizeValue;
                            SaveData();
                            LoadData();
                        }
                    }
                    break;
            }
        }

        if (prizeValue > 0)
        {
            switch (scrollbar.value)
            {
                case 0f:    //1500 mahdollisesti rikki
                    {
                        doubledPrize = prizeValue * 1f;
                        //Debug.Log("Doubled: " + doubledPrize);
                        dividedPrize = doubledPrize / 5;
                        newPrize = (int)Mathf.Round(dividedPrize);
                        if (newPrize == 162)
                        {
                            newPrize -= 2;
                        }
                        else if (newPrize == 462)
                        {
                            newPrize -= 2;
                        }
                        else if (newPrize == 838)
                        {
                            newPrize += 2;
                        }
                        //Debug.Log("NewPrize: " + newPrize);
                        coins += newPrize;
                        SaveData();
                        LoadData();
                    }
                    break;
                case 0.25f:
                    {
                        doubledPrize = prizeValue * 2.2f;
                        dividedPrize = doubledPrize / 3;
                        newPrize = (int)Mathf.Round(dividedPrize);
                        
                        if (newPrize == 282)
                        {
                            newPrize -= 2;
                        }
                        else if (newPrize == 347)
                        {
                            newPrize += 3;
                        }
                        else if (newPrize == 433)
                        {
                            newPrize += 2;
                        }
                        else if (newPrize == 587)
                        {
                            newPrize -= 2;
                        }
                        else if (newPrize == 733)
                        {
                            newPrize += 2;
                        }
                        else if (newPrize == 802)
                        {
                            newPrize -= 2;
                        }
                        else if (newPrize == 867)
                        {
                            newPrize -= 2;
                        }
                        else if (newPrize == 1083)
                        {
                            newPrize += 2;
                        }
                        else if (newPrize == 1213)
                        {
                            newPrize += 2;
                        }
                        else if (newPrize == 1218)
                        {
                            newPrize += 2;
                        }
                        else if (newPrize == 1467)
                        {
                            newPrize -= 2;
                        }
                        else if (newPrize == 1452)
                        {
                            newPrize -= 2;
                        }
                        else if (newPrize == 1517)
                        {
                            newPrize -= 17;
                        }
                        else if (newPrize == 1733)
                        {
                            newPrize += 17;
                        }
                        else if (newPrize == 2053)
                        {
                            newPrize -= 3;
                        }
                        //LastPrize = Convert.ToInt32(Mathf.Round(Convert.ToInt32(newPrize) / 10));
                        //Debug.Log(newPrize);
                        coins += newPrize;
                        SaveData();
                        LoadData();
                    }
                    break;
                case 0.75f:
                    {
                        doubledPrize = prizeValue * 4.5f;
                        dividedPrize = doubledPrize / 2;
                        newPrize = (int)Mathf.Round(dividedPrize);
                        if (newPrize == 488)
                        {
                            newPrize += 12;
                        }
                        else if (newPrize == 1388)
                        {
                            newPrize -= 3;
                        }
                        else if (newPrize == 2512)
                        {
                            newPrize += 3;
                        }

                        if (newPrize == 282)
                        {
                            newPrize -= 2;
                        }
                        else if (newPrize == 347)
                        {
                            newPrize += 3;
                        }
                        else if (newPrize == 433)
                        {
                            newPrize += 2;
                        }
                        else if (newPrize == 802)
                        {
                            newPrize -= 2;
                        }
                        else if (newPrize == 867)
                        {
                            newPrize -= 2;
                        }
                        else if (newPrize == 1083)
                        {
                            newPrize += 2;
                        }
                        else if (newPrize == 1213)
                        {
                            newPrize += 2;
                        }
                        else if (newPrize == 1218)
                        {
                            newPrize += 2;
                        }
                        else if (newPrize == 1452)
                        {
                            newPrize -= 2;
                        }
                        else if (newPrize == 1517)
                        {
                            newPrize -= 17;
                        }
                        else if (newPrize == 1733)
                        {
                            newPrize += 17;
                        }
                        else if (newPrize == 4162)
                        {
                            newPrize -= 2;
                        }
                        //Debug.Log(newPrize);
                        coins += newPrize;
                        SaveData();
                        LoadData();
                    }
                    break;
                case 1f:
                    {
                        doubledPrize = prizeValue * 5.7f;
                        dividedPrize = doubledPrize / 1;
                        newPrize = (int)Mathf.Round(dividedPrize);
                        if (newPrize == 488)
                        {
                            newPrize += 12;
                        }
                        else if (newPrize == 1388)
                        {
                            newPrize -= 3;
                        }
                        else if (newPrize == 2512)
                        {
                            newPrize += 3;
                        }

                        if (newPrize == 282)
                        {
                            newPrize -= 2;
                        }
                        else if (newPrize == 347)
                        {
                            newPrize += 3;
                        }
                        else if (newPrize == 433)
                        {
                            newPrize += 2;
                        }
                        else if (newPrize == 802)
                        {
                            newPrize -= 2;
                        }
                        else if (newPrize == 867)
                        {
                            newPrize -= 2;
                        }
                        else if (newPrize == 1083)
                        {
                            newPrize += 2;
                        }
                        else if (newPrize == 1213)
                        {
                            newPrize += 2;
                        }
                        else if (newPrize == 1218)
                        {
                            newPrize += 2;
                        }
                        else if (newPrize == 1452)
                        {
                            newPrize -= 2;
                        }
                        else if (newPrize == 1517)
                        {
                            newPrize -= 17;
                        }
                        else if (newPrize == 1733)
                        {
                            newPrize += 17;
                        }
                        else if (newPrize == 11400)
                        {
                            newPrize += 100;
                        }
                        else if (newPrize == 15960)
                        {
                            newPrize += 40;
                        }
                        else if (newPrize == 34200)
                        {
                            newPrize += 5800;
                        }
                        //Debug.Log(newPrize);
                        coins += newPrize;
                        SaveData();
                        LoadData();
                    }
                    break;
            }
        }
        
        ResultsChecked = true;
    }

    public void HugeWinRatioCheck()
    {
        
        LoadData();
        if (diamond3Wins >= 1 || diamond2Wins >= 1 || crown3Wins >= 1 || crown2Wins >= 1 || seven3Wins >= 1 || seven2Wins >= 1 || spins <= 20 || spins <= 125)
        {
            /*if (diamond3Wins >= 1)
            {
                D3results = spins / diamond3Wins;
            }
            if (diamond2Wins >= 2)
            {
                D2results = spins / diamond2Wins;
            }
            if (crown3Wins >= 1)
            {
                C3results = spins / crown3Wins;
            }
            if (crown2Wins >= 2)
            {
                C2results = spins / crown2Wins;
            }*/

            switch (spins)
            {
                case 0:
                    {
                        NewPlayerWinRate();
                    }
                    break;
                case 20:
                    {
                        IsThatNewPlayer = false;
                        rows[0].newPlayerWinRatioActivated = false;
                        rows[1].newPlayerWinRatioActivated = false;
                        rows[2].newPlayerWinRatioActivated = false;

                        IsWinRatioTooBig = false;
                        rows[0].isWinRatioNormalized = true;
                        rows[1].isWinRatioNormalized = true;
                        rows[2].isWinRatioNormalized = true;
                        SaveData();
                        LoadData();
                        
                    }
                    break;
                case 25:
                    {
                        if (diamond3Wins >= 1)
                        {
                            D3results = spins / diamond3Wins;
                            Debug.Log("D3results: " + D3results);
                            if (D3results <= 25f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = true;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (crown3Wins >= 1)
                        {
                            C3results = spins / crown3Wins;
                            Debug.Log("C3results: " + C3results);
                            if (C3results <= 25f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 8;
                                rows[1].roundMax += 8;
                                //rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (diamond2Wins >= 2)
                        {
                            D2results = spins / diamond2Wins;
                            Debug.Log("D2results: " + D2results);
                            if (D2results <= 13f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[0].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                //rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (crown2Wins >= 2)
                        {
                            C2results = spins / crown2Wins;
                            Debug.Log("C2results: " + C2results);
                            if (C2results <= 13f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (seven3Wins >= 1)
                        {
                            S3results = spins / seven3Wins;
                            Debug.Log("S3results: " + S3results);
                            if (S3results <= 25f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                //rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (seven2Wins >= 3)
                        {
                            S2results = spins / seven2Wins;
                            Debug.Log("S2results: " + S2results);
                            if (S2results <= 8f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                    }
                    break;
                case 35:    //Rikki!!
                    {
                        if (diamond3Wins >= 1)
                        {
                            D3results = spins / diamond3Wins;
                            Debug.Log("D3results: " + D3results);
                            if (D3results <= 35f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 10;
                                rows[1].roundMax += 10;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (crown3Wins >= 2)
                        {
                            C3results = spins / crown3Wins;
                            Debug.Log("C3results: " + C3results);
                            if (C3results <= 18f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 10;
                                rows[1].roundMax += 10;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (diamond2Wins >= 2)
                        {
                            D2results = spins / diamond2Wins;
                            Debug.Log("D2results: " + D2results);
                            if (D2results <= 18f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[0].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (crown2Wins >= 3)
                        {
                            C2results = spins / crown2Wins;
                            Debug.Log("C2results: " + C2results);
                            if (C2results <= 12f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (seven3Wins >= 2)
                        {
                            S3results = spins / seven3Wins;
                            Debug.Log("S3results: " + S3results);
                            if (S3results <= 18f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (seven2Wins >= 3)
                        {
                            S2results = spins / seven2Wins;
                            Debug.Log("S2results: " + S2results);
                            if (S2results <= 12f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                    }
                    break;
                case 45:
                    {
                        if (diamond3Wins >= 1)
                        {
                            D3results = spins / diamond3Wins;
                            Debug.Log("D3results: " + D3results);
                            if (D3results <= 45f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 10;
                                rows[1].roundMax += 10;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (crown3Wins >= 2)
                        {
                            C3results = spins / crown3Wins;
                            Debug.Log("C3results: " + C3results);
                            if (C3results <= 23f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 10;
                                rows[1].roundMax += 10;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (diamond2Wins >= 2)
                        {
                            D2results = spins / diamond2Wins;
                            Debug.Log("D2results: " + D2results);
                            if (D2results <= 23f)
                            {IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[0].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (crown2Wins >= 3)
                        {
                            C2results = spins / crown2Wins;
                            Debug.Log("C2results: " + C2results);
                            if (C2results <= 15f)
                            {IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (seven3Wins >= 2)
                        {
                            S3results = spins / seven3Wins;
                            Debug.Log("S3results: " + S3results);
                            if (S3results <= 23f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (seven2Wins >= 3)
                        {
                            S2results = spins / seven2Wins;
                            Debug.Log("S2results: " + S2results);
                            if (S2results <= 15f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                    }
                    break;
                case 50:
                    {
                        if (diamond3Wins >= 2)
                        {
                            D3results = spins / diamond3Wins;
                            Debug.Log("D3results: " + D3results);
                            if (D3results <= 25f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 10;
                                rows[1].roundMax += 10;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (crown3Wins >= 2)
                        {
                            C3results = spins / crown3Wins;
                            Debug.Log("C3results: " + C3results);
                            if (C3results <= 25f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 8;
                                rows[0].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (diamond2Wins >= 3)
                        {
                            D2results = spins / diamond2Wins;
                            Debug.Log("D2results: " + D2results);
                            if (D2results <= 17f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (crown2Wins >= 3)
                        {
                            C2results = spins / crown2Wins;
                            Debug.Log("C2results: " + C2results);
                            if (C2results <= 17f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (seven3Wins >= 2)
                        {
                            S3results = spins / seven3Wins;
                            Debug.Log("S3results: " + S3results);
                            if (S3results <= 25f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (seven2Wins >= 4)
                        {
                            S2results = spins / seven2Wins;
                            Debug.Log("S2results: " + S2results);
                            if (S2results <= 13f)
                            {IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                    }
                    break;
                case 65:
                    {
                        if (diamond3Wins >= 2)
                        {
                            D3results = spins / diamond3Wins;
                            Debug.Log("D3results: " + D3results);
                            if (D3results <= 33f)
                            {IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (crown3Wins >= 3)
                        {
                            C3results = spins / crown3Wins;
                            Debug.Log("C3results: " + C3results);
                            if (C3results <= 22f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (diamond2Wins >= 4)
                        {
                            D2results = spins / diamond2Wins;
                            Debug.Log("D2results: " + D2results);
                            if (D2results <= 16f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (crown2Wins >= 5)
                        {
                            C2results = spins / crown2Wins;
                            Debug.Log("C2results: " + C2results);
                            if (C2results <= 13f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (seven3Wins >= 3)
                        {
                            S3results = spins / seven3Wins;
                            Debug.Log("S3results: " + S3results);
                            if (S3results <= 22f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (seven2Wins >= 5)
                        {
                            S2results = spins / seven2Wins;
                            Debug.Log("S2results: " + S2results);
                            if (S2results <= 13f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                    }
                    break;
                case 80:
                    {
                        if (diamond3Wins >= 3)
                        {
                            D3results = spins / diamond3Wins;
                            Debug.Log("D3results: " + D3results);
                            if (D3results <= 27f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (crown3Wins >= 3)
                        {
                            C3results = spins / crown3Wins;
                            Debug.Log("C3results: " + C3results);
                            if (C3results <= 27f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (diamond2Wins >= 4)
                        {
                            D2results = spins / diamond2Wins;
                            Debug.Log("D2results: " + D2results);
                            if (D2results <= 20f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (crown2Wins >= 5)
                        {
                            C2results = spins / crown2Wins;
                            Debug.Log("C2results: " + C2results);
                            if (C2results <= 16f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (seven3Wins >= 3)
                        {
                            S3results = spins / seven3Wins;
                            Debug.Log("S3results: " + S3results);
                            if (S3results <= 27f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (seven2Wins >= 5)
                        {
                            S2results = spins / seven2Wins;
                            Debug.Log("S2results: " + S2results);
                            if (S2results <= 16f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                    }
                    break;
                case 100:
                    {
                        if (diamond3Wins >= 3)
                        {
                            D3results = spins / diamond3Wins;
                            Debug.Log("D3results: " + D3results);
                            if (D3results <= 33f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (crown3Wins >= 4)
                        {
                            C3results = spins / crown3Wins;
                            Debug.Log("C3results: " + C3results);
                            if (C3results <= 25f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (diamond2Wins >= 5)
                        {
                            D2results = spins / diamond2Wins;
                            Debug.Log("D2results: " + D2results);
                            if (D2results <= 20f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (crown2Wins >= 5)
                        {
                            C2results = spins / crown2Wins;
                            Debug.Log("C2results: " + C2results);
                            if (C2results <= 20f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (seven3Wins >= 4)
                        {
                            S3results = spins / seven3Wins;
                            Debug.Log("S3results: " + S3results);
                            if (S3results <= 25f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (seven2Wins >= 5)
                        {
                            S2results = spins / seven2Wins;
                            Debug.Log("S2results: " + S2results);
                            if (S2results <= 20f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                    }
                    break;
                case 110:
                    {
                        IsThatNewPlayer = true;
                        SaveData();
                        LoadData();
                        NewPlayerWinRate();
                    }
                    break;
                case 125:
                    {
                        IsThatNewPlayer = false;
                        rows[0].newPlayerWinRatioActivated = false;
                        rows[1].newPlayerWinRatioActivated = false;
                        rows[2].newPlayerWinRatioActivated = false;

                        IsWinRatioTooBig = false;
                        rows[0].isWinRatioNormalized = true;
                        rows[1].isWinRatioNormalized = true;
                        rows[2].isWinRatioNormalized = true;
                        SaveData();
                        LoadData();
                        
                        
                    }
                    break;
                case 130:
                    {
                        if (diamond3Wins >= 4)
                        {
                            D3results = spins / diamond3Wins;
                            Debug.Log("D3results: " + D3results);
                            if (D3results <= 33f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (crown3Wins >= 5)
                        {
                            C3results = spins / crown3Wins;
                            Debug.Log("C3results: " + C3results);
                            if (C3results <= 26f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (diamond2Wins >= 6)
                        {
                            D2results = spins / diamond2Wins;
                            Debug.Log("D2results: " + D2results);
                            if (D2results <= 22f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (crown2Wins >= 6)
                        {
                            C2results = spins / crown2Wins;
                            Debug.Log("C2results: " + C2results);
                            if (C2results <= 22f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (seven3Wins >= 5)
                        {
                            S3results = spins / seven3Wins;
                            Debug.Log("S3results: " + S3results);
                            if (S3results <= 26f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                        else if (seven2Wins >= 6)
                        {
                            S2results = spins / seven2Wins;
                            Debug.Log("S2results: " + S2results);
                            if (S2results <= 22f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();
                                
                                
                            }
                        }
                    }
                    break;
                case 160:
                    {
                        if (diamond3Wins >= 4)
                        {
                            D3results = spins / diamond3Wins;
                            Debug.Log("D3results: " + D3results);
                            if (D3results <= 40f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (crown3Wins >= 5)
                        {
                            C3results = spins / crown3Wins;
                            Debug.Log("C3results: " + C3results);
                            if (C3results <= 32f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (diamond2Wins >= 6)
                        {
                            D2results = spins / diamond2Wins;
                            Debug.Log("D2results: " + D2results);
                            if (D2results <= 27f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (crown2Wins >= 6)
                        {
                            C2results = spins / crown2Wins;
                            Debug.Log("C2results: " + C2results);
                            if (C2results <= 27f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (seven3Wins >= 5)
                        {
                            S3results = spins / seven3Wins;
                            Debug.Log("S3results: " + S3results);
                            if (S3results <= 32f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (seven2Wins >= 6)
                        {
                            S2results = spins / seven2Wins;
                            Debug.Log("S2results: " + S2results);
                            if (S2results <= 27f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                    }
                    break;
                case 200:
                    {
                        if (diamond3Wins >= 5)
                        {
                            D3results = spins / diamond3Wins;
                            Debug.Log("D3results: " + D3results);
                            if (D3results <= 40f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (crown3Wins >= 6)
                        {
                            C3results = spins / crown3Wins;
                            Debug.Log("C3results: " + C3results);
                            if (C3results <= 34f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (diamond2Wins >= 6)
                        {
                            D2results = spins / diamond2Wins;
                            Debug.Log("D2results: " + D2results);
                            if (D2results <= 34f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (crown2Wins >= 7)
                        {
                            C2results = spins / crown2Wins;
                            Debug.Log("C2results: " + C2results);
                            if (C2results <= 29f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (seven3Wins >= 6)
                        {
                            S3results = spins / seven3Wins;
                            Debug.Log("S3results: " + S3results);
                            if (S3results <= 34f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (seven2Wins >= 7)
                        {
                            S2results = spins / seven2Wins;
                            Debug.Log("S2results: " + S2results);
                            if (S2results <= 29f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                    }
                    break;
                case 250:
                    {
                        if (diamond3Wins >= 6)
                        {
                            D3results = spins / diamond3Wins;
                            Debug.Log("D3results: " + D3results);
                            if (D3results <= 42f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (crown3Wins >= 6)
                        {
                            C3results = spins / crown3Wins;
                            Debug.Log("C3results: " + C3results);
                            if (C3results <= 42f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (diamond2Wins >= 7)
                        {
                            D2results = spins / diamond2Wins;
                            Debug.Log("D2results: " + D2results);
                            if (D2results <= 36f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (crown2Wins >= 8)
                        {
                            C2results = spins / crown2Wins;
                            Debug.Log("C2results: " + C2results);
                            if (C2results <= 32f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (seven3Wins >= 6)
                        {
                            S3results = spins / seven3Wins;
                            Debug.Log("S3results: " + S3results);
                            if (S3results <= 42f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (seven2Wins >= 8)
                        {
                            S2results = spins / seven2Wins;
                            Debug.Log("S2results: " + S2results);
                            if (S2results <= 32f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                    }
                    break;
                case 300:
                    {
                        if (diamond3Wins >= 6)
                        {
                            D3results = spins / diamond3Wins;
                            Debug.Log("D3results: " + D3results);
                            if (D3results <= 50f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (crown3Wins >= 7)
                        {
                            C3results = spins / crown3Wins;
                            Debug.Log("C3results: " + C3results);
                            if (C3results <= 43f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 8;
                                rows[2].roundMax += 8;
                                rows[0].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (diamond2Wins >= 8)
                        {
                            D2results = spins / diamond2Wins;
                            Debug.Log("D2results: " + D2results);
                            if (D2results <= 38f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (crown2Wins >= 8)
                        {
                            C2results = spins / crown2Wins;
                            Debug.Log("C2results: " + C2results);
                            if (C2results <= 38f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (seven3Wins >= 7)
                        {
                            S3results = spins / seven3Wins;
                            Debug.Log("S3results: " + S3results);
                            if (S3results <= 43f)
                            {
                                IsWinRatioTooBig = true;
                                rows[0].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[0].isWinRatioNormalized = false;
                                rows[1].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                        else if (seven2Wins >= 9)
                        {
                            S2results = spins / seven2Wins;
                            Debug.Log("S2results: " + S2results);
                            if (S2results <= 34f)
                            {
                                IsWinRatioTooBig = true;
                                rows[2].roundMax += 5;
                                rows[1].roundMax += 5;
                                rows[1].isWinRatioNormalized = false;
                                rows[2].isWinRatioNormalized = false;
                                SaveData();
                                LoadData();


                            }
                        }
                    }
                    break;
            }
        }

        /*if (spins <= 20 && diamond3Wins >= 1)
        {
            StartCoroutine(rows[0].WinRatioRotate());
            StartCoroutine(rows[2].WinRatioRotate());
            IsWinRatioTooBig = true;
        }
        else if (spins <= 20 && crown3Wins >= 1)
        {
            StartCoroutine(rows[0].WinRatioRotate());
            StartCoroutine(rows[1].WinRatioRotate());
            IsWinRatioTooBig = true;
        }
        else if (spins <= 15 && diamond2Wins >= 2)
        {
            StartCoroutine(rows[0].WinRatioRotate());
            StartCoroutine(rows[1].WinRatioRotate());
            IsWinRatioTooBig = true;
        }
        else if (spins <= 10 && crown2Wins >= 2)
        {
            StartCoroutine(rows[1].WinRatioRotate());
            StartCoroutine(rows[2].WinRatioRotate());
            IsWinRatioTooBig = true;
        }*/
        if (WinRatioChecking == true)
        {
            WinRatioChecked = true;
        }

        WinRatioChecking = true;
    }

    private void SpinsReset()
    {
        spins = 0;
        resetSpins = false;
        SaveData();
        LoadData();
    }

    public void NewPlayerWinRate()
    {
        LoadData();
        if (IsThatNewPlayer == true)
        {
            switch (spins)
            {
                case 0:
                    {
                        IsThatNewPlayer = true;
                        rows[0].newPlayerWinRatioActivated = true;
                        rows[2].newPlayerWinRatioActivated = true;
                        rows[0].isWinRatioNormalized = false;
                        rows[2].isWinRatioNormalized = false;
                        SaveData();
                        LoadData();
                        
                        
                    }
                    break;
                case 20:
                    {
                        HugeWinRatioCheck();
                    }
                    break;
                case 110:
                    {
                        IsThatNewPlayer = true;
                        rows[0].newPlayerWinRatioActivated = true;
                        rows[2].newPlayerWinRatioActivated = true;
                        rows[0].isWinRatioNormalized = false;
                        rows[2].isWinRatioNormalized = false;
                        SaveData();
                        LoadData();
                        
                        
                    }
                    break;
                case 125:
                    {
                        HugeWinRatioCheck();
                    }
                    break;
            }

        }
        if (NewPlayerChecking == true)
        {
            NewPlayerCheckDone = true;
        }
        NewPlayerChecking = true;
    }
    public void CoinsAddet()
    {
        coins += CoinAdd;
        Debug.Log("Coins: " + coins);
        coinText.text = "" + coins;
        AddCoins = false;
        SaveData();
        LoadData();
    }
    private void CoinsSubtracted()
    {
        coins -= CoinsSubtracts;
        coinText.text = "" + coins;
        Debug.Log("Coins: " + coins);
        SubtractCoins = false;
        SaveData();
        LoadData();
    }
    private void WinsReset()
    {
        diamond3Wins = 0;
        diamond2Wins = 0;
        crown3Wins = 0;
        crown2Wins = 0;
        seven3Wins = 0;
        seven2Wins = 0;
        resetWins = false;
        SaveData();
        LoadData();
    }

    private void AllReset()
    {
        coins = 2000;
        spins = 0;
        diamond3Wins = 0;
        diamond2Wins = 0;
        crown3Wins = 0;
        crown2Wins = 0;
        seven3Wins = 0;
        seven2Wins = 0;
        IsWinRatioTooBig = false;
        IsThatNewPlayer = true;
        rows[0].newPlayerWinRatioActivated = true;
        rows[2].newPlayerWinRatioActivated = true;
        rows[1].isWinRatioNormalized = true;
        rows[0].isWinRatioNormalized = false;
        rows[2].isWinRatioNormalized = false;
        rows[1].newPlayerWinRatioActivated = false;
        rows[0].roundMax = 0;
        rows[1].roundMax = 0;
        rows[2].roundMax = 0;
        nickName = "";
        isNicknameAccepted = false;
        isThatFirstStart = true;
        RESETALL = false;
        playerNeedTuto = true;
        SaveData();
        LoadData();
        
        
    }

    public void SetNickname()
    {
        nickName = inputField.text;
        if (isNicknameAccepted == true)
        {
            nickName = inputField.text;
            changeNNtext.text = nickName;
            SaveData();
            LoadData();
        }
    }
    public void ChangeNickName()
    {
        changeNNtext.text = nickName;
        isThatFirstStart = true;
        isNicknameAccepted = false;
    }

    public void IsNickNameAccepted(bool booleani)
    {
        isNicknameAccepted = booleani;
        if (nickName == "" || nickName == "(KillYourself)" || nickName == "(Niger)" || nickName == "(Nigga)" || nickName == "KillYourSelf" || nickName == "KillyourSelf" || nickName == "Nigger" || nickName == "NIGER" || nickName == "Nigga" || nickName == "KillYourself" || nickName == "KILLYOURSELF" || nickName == "Killyourself" || nickName == "killYourSelf" || nickName == "killyourself" || nickName == "Hitler" || nickName == "HITLER" || nickName == "hitler" || nickName == "NOOB" || nickName == "Noob" || nickName == "AdolfHitler" || nickName == "Adolf Hitler" || nickName == "Niger" || nickName == "niger" || nickName == "FuckYou" || nickName == "Fuckyou" || nickName == "Fuck" || nickName == "fuck" || nickName == "dick" || nickName == "Dick" || nickName == "Pussy" || nickName == "pussy")
        {
            booleani = false;
            isNicknameAccepted = booleani;
            isThatFirstStart = true;
            nickName = "";
            inputField.text = "";
            NewPlayer();
            SaveData();
            LoadData();
        }
        SaveData();
        LoadData();
    }

    public void FirstStart(bool booli)
    {
        isThatFirstStart = booli;
        SaveData();
        LoadData();
    }

    public void NewPlayer()
    {
        if (isThatFirstStart == true)
        {
            BackgroundPanelsImage.enabled = true;
            ChooseNicknamePanelImage.enabled = true;
            InputNicknameImage.enabled = true;
            PlaceholderText.enabled = true;
            AcceptButtonBackGimage.enabled = true;
            AcceptButtonImage.enabled = true;
            NickText.enabled = true;
            Text.enabled = true;
            AcceptButtonText.enabled = true;
            AcceptButtonButton.enabled = true;
            inputField.enabled = true;
            inputField.text = nickName;

            if (playerNeedTuto == true)
            {
                tutoriaali.SetActive(true);
            }
            /*if (playerNeedTuto == false)
            {
                PlayerNeedTutorial(true);
            }*/

            SaveData();
            LoadData();
        }
    }
    
    public void PlayerNeedTutorial(bool booli)
    {
        playerNeedTuto = booli;
        SaveData();
        LoadData();
    }

    public void Play()
    {
        if (isTutorialInProgress == true)
        {
            MainMenuPanel.SetActive(false);
            PrizeText.SetActive(true);
            Scrollbar.SetActive(true);
            gameControll.SetActive(true);
            row.SetActive(true);
            row1.SetActive(true);
            row2.SetActive(true);
            BetSystem.SetActive(true);
            MenuButt.SetActive(true);
            gameControllCollider.enabled = false;
            betSystemCollider.enabled = false;
            ScrollbarImage.enabled = true;
            HandleImage.enabled = true;
            TheLogoAnim.SetTrigger("NewEntry");
            spinReminder.Click();
            spinReminder.StartedGame();
            spinButt1.enabled = false;
            spinButt2.enabled = false;
            spinButt3.enabled = false;
            spinButt4.enabled = false;
            spinButt5.enabled = false;
            spinButt6.enabled = false;
            spinButt7.enabled = false;
            InventoryUP.enabled = false;
            AccButtAnim.SetTrigger("RePress");
            SettingsButtboxCollider.enabled = false;
            tutoriaali3or4.SetActive(true);
            spinReminder.msToWait += 15000;
        }
        else
        {
            MainMenuPanel.SetActive(false);
            PrizeText.SetActive(true);
            Scrollbar.SetActive(true);
            gameControll.SetActive(true);
            row.SetActive(true);
            row1.SetActive(true);
            row2.SetActive(true);
            BetSystem.SetActive(true);
            MenuButt.SetActive(true);
            gameControllCollider.enabled = true;
            betSystemCollider.enabled = true;
            ScrollbarImage.enabled = true;
            HandleImage.enabled = true;
            TheLogoAnim.SetTrigger("NewEntry");
            spinReminder.Click();
            spinReminder.StartedGame();
            spinButt1.enabled = true;
            spinButt2.enabled = true;
            spinButt3.enabled = true;
            spinButt4.enabled = true;
            spinButt5.enabled = true;
            spinButt6.enabled = true;
            spinButt7.enabled = true;
            InventoryUP.enabled = false;
            AccButtAnim.SetTrigger("RePress");
            SettingsButtboxCollider.enabled = false;
            tutoriaali3or4.SetActive(false);
            spinReminder.msToWait += 15000;
        }
    }

    public void TutorialIsInProgress(bool boolean)
    {
        isTutorialInProgress = boolean;
    }
}
