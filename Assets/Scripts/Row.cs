using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private int RandomValue;

    public bool rowStopped;
    public string StoppedSlot;

    private float TimeInterval;

    private int randomSpinsD;
    private int randomSpinsC;
    private int randomSpinsS;
    private int randomSpinsM;
    private int randomSpinsL;
    private int randomSpinsCh;

    public bool isWinRatioNormalized = true;
    public bool newPlayerWinRatioActivated = false;

    private int rounds;
    public int roundMax = 0;

    private GameObject gameControll;

    private GameControl gameControl;

    void Start()
    {
        gameControll = GameObject.Find("GameControll");

        gameControl = gameControll.GetComponent<GameControl>();

        gameControl.LoadData();

        rowStopped = true;
        GameControl.GameStarted += StartRotating;
        gameControl.SaveData();
    }
    public void Update()
    {
        gameControl.LoadData();
        if (newPlayerWinRatioActivated == true)
        {
            isWinRatioNormalized = false;
        }
        if (isWinRatioNormalized == true)
        {
            newPlayerWinRatioActivated = false;
        }
        gameControl.SaveData();
        gameControl.LoadData();
    }

    

    private void StartRotating()
    {
        gameControl.LoadData();

        StoppedSlot = "";
        if (isWinRatioNormalized == true)
        {
            StartCoroutine("Rotate");
        }
        else if (isWinRatioNormalized == false && rounds <= roundMax && newPlayerWinRatioActivated == false)
        {
            StartCoroutine("WinRatioRotate");
        }
        else if (newPlayerWinRatioActivated == true)
        {
            StartCoroutine("GreaterChanceToWin");
        }
    }

    private IEnumerator Rotate()
    {
        rowStopped = false;
        TimeInterval = 0.025f;

        for (int i = 0; i < 30; i++)
        {
            if (transform.position.y <= -7.15f)
            {
                transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
            }

            transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);   //0.55f = ihan ok, jos ei parempaa löydy.

            yield return new WaitForSeconds(TimeInterval);
        }

        RandomValue = Random.Range(60, 100);

        switch(RandomValue % 3)
        {
            case 1:
                RandomValue += 2;
                break;
            case 2:
                RandomValue += 1;
                break;
        }

        for (int i = 0; i < RandomValue; i++)
        {
            if (transform.position.y <= -7.15f)
            {
                transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
            }

            transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);

            if (i > Mathf.RoundToInt(RandomValue * 0.55f))
            {
                TimeInterval = 0.05f;
            }
            if (i > Mathf.RoundToInt(RandomValue * 1f))
            {
                TimeInterval = 0.1f;
            }
            if (i > Mathf.RoundToInt(RandomValue * 1.25f))
            {
                TimeInterval = 0.15f;
            }
            if (i > Mathf.RoundToInt(RandomValue * 1.45f))
            {
                TimeInterval = 0.2f;
            }

            yield return new WaitForSeconds(TimeInterval);
        }

        if (transform.position.y == -7.450001f)
        {
            StoppedSlot = "Diamond";
        }
        else if (transform.position.y == -5.8f)
        {
            StoppedSlot = "Crown";
        }
        else if (transform.position.y == -4.15f || transform.position.y < -4.11f && transform.position.y > -5.7f)
        {
            StoppedSlot = "Melon"; //Rikki!
        }
        else if (transform.position.y == -2.5f || transform.position.y < -0.8499999f && transform.position.y > -4.10f)
        {
            StoppedSlot = "Bar";    //Rikki!
        }
        else if (transform.position.y == -0.8499999f)
        {
            StoppedSlot = "Seven";
        }
        else if (transform.position.y == 0.8000001f || transform.position.y > -0.8499999f && transform.position.y < 2.45f)
        {
            StoppedSlot = "Cherry"; //Rikki!
        }
        else if (transform.position.y == 2.45f)
        {
            StoppedSlot = "Lemon";
        }
        else if (transform.position.y == 4.1f)
        {
            StoppedSlot = "Diamond";
        }

        rowStopped = true;
    }

    public IEnumerator WinRatioRotate()
    {
        gameControl.LoadData();
        if (isWinRatioNormalized == false && gameControl.IsWinRatioTooBig == true)
        {
                rowStopped = false;
                TimeInterval = 0.025f;

                for (int i = 0; i < 30; i++)
                {
                    if (transform.position.y <= -7.15f)
                    {
                        transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                    }

                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);   //0.55f = ihan ok, jos ei parempaa löydy.

                    yield return new WaitForSeconds(TimeInterval);
                }

                RandomValue = Random.Range(60, 100);

                switch (RandomValue % 3)
                {
                    case 1:
                        RandomValue += 2;
                        break;
                    case 2:
                        RandomValue += 1;
                        break;
                }

                for (int i = 0; i < RandomValue; i++)
                {
                    if (transform.position.y <= -7.15f)
                    {
                        transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                    }

                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);

                    if (i > Mathf.RoundToInt(RandomValue * 0.55f))
                    {
                        TimeInterval = 0.05f;
                    }
                    if (i > Mathf.RoundToInt(RandomValue * 1f))
                    {
                        TimeInterval = 0.1f;
                    }
                    if (i > Mathf.RoundToInt(RandomValue * 1.25f))
                    {
                        TimeInterval = 0.15f;
                    }
                    if (i > Mathf.RoundToInt(RandomValue * 1.45f))
                    {
                        TimeInterval = 0.2f;
                    }

                    yield return new WaitForSeconds(TimeInterval);
                }

                randomSpinsD = Random.Range(1, 3);
                randomSpinsC = Random.Range(1, 3);
                randomSpinsS = Random.Range(1, 3);

                if (transform.position.y == -7.450001f)
                {
                    switch (randomSpinsD)
                    {
                        case 1:
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (transform.position.y <= -7.15f)
                                    {
                                        transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                    }

                                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                                }
                                StoppedSlot = "Lemon";
                            }
                            break;
                        case 2:
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    if (transform.position.y <= -7.15f)
                                    {
                                        transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                    }

                                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                                }
                                StoppedSlot = "Cherry";
                            }
                            break;
                        case 3:
                            {
                                for (int i = 0; i < 9; i++)
                                {
                                    if (transform.position.y <= -7.15f)
                                    {
                                        transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                    }

                                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                                }
                                StoppedSlot = "Seven";
                            }
                            break;
                    }
                }
                else if (transform.position.y == -5.8f)
                {
                    switch (randomSpinsC)
                    {
                        case 1:
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    if (transform.position.y <= -7.15f)
                                    {
                                        transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                    }

                                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                                }
                                StoppedSlot = "Lemon";
                            }
                            break;
                        case 2:
                            {
                                for (int i = 0; i < 9; i++)
                                {
                                    if (transform.position.y <= -7.15f)
                                    {
                                        transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                    }

                                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                                }
                                StoppedSlot = "Cherry";
                            }
                            break;
                        case 3:
                            {
                                for (int i = 0; i < 15; i++)
                                {
                                    if (transform.position.y <= -7.15f)
                                    {
                                        transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                    }

                                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                                }
                                StoppedSlot = "Bar";
                            }
                            break;
                    }
                }
                else if (transform.position.y == -4.15f || transform.position.y < -4.11f && transform.position.y > -5.7f)
                {
                    StoppedSlot = "Melon"; //Rikki!
                }
                else if (transform.position.y == -2.5f || transform.position.y < -0.8499999f && transform.position.y > -4.10f)
                {
                    StoppedSlot = "Bar";    //Rikki!
                }
                else if (transform.position.y == -0.8499999f)
                {
                    switch (randomSpinsS)
                    {
                        case 1:
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    if (transform.position.y <= -7.15f)
                                    {
                                        transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                    }

                                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                                }
                                StoppedSlot = "Melon";
                            }
                            break;
                        case 2:
                            {
                                for (int i = 0; i < 15; i++)
                                {
                                    if (transform.position.y <= -7.15f)
                                    {
                                        transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                    }

                                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                                }
                                StoppedSlot = "Lemon";
                            }
                            break;
                        case 3:
                            {
                                for (int i = 0; i < 18; i++)
                                {
                                    if (transform.position.y <= -7.15f)
                                    {
                                        transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                    }

                                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                                }
                                StoppedSlot = "Cherry";
                            }
                            break;
                    }
                }
                else if (transform.position.y == 0.8000001f || transform.position.y > -0.8499999f && transform.position.y < 2.45f)
                {
                    StoppedSlot = "Cherry"; //Rikki!
                }
                else if (transform.position.y == 2.45f)
                {
                    StoppedSlot = "Lemon";
                }
                else if (transform.position.y == 4.1f)
                {
                    StoppedSlot = "Diamond";
                }

                rowStopped = true;

            rounds++;

            if (rounds == roundMax)
            {
                gameControl.rows[0].isWinRatioNormalized = true;
                gameControl.rows[1].isWinRatioNormalized = true;
                gameControl.rows[2].isWinRatioNormalized = true;
                gameControl.IsWinRatioTooBig = false;
                gameControl.rows[0].rounds = 0;
                gameControl.rows[1].rounds = 0;
                gameControl.rows[2].rounds = 0;
                gameControl.rows[0].roundMax = 0;
                gameControl.rows[1].roundMax = 0;
                gameControl.rows[2].roundMax = 0;
                gameControl.SaveData();
                gameControl.LoadData();
            }
            gameControl.SaveData();
            gameControl.LoadData();
            Debug.Log("Rounds: " + rounds + " and roundMax: " + roundMax);
        }
    }
    public IEnumerator GreaterChanceToWin()
    {
        gameControl.LoadData();
        if (newPlayerWinRatioActivated == true && gameControl.IsThatNewPlayer == true)
        {
            rowStopped = false;
            TimeInterval = 0.025f;

            for (int i = 0; i < 30; i++)
            {
                if (transform.position.y <= -7.15f)
                {
                    transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                }

                transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);   //0.55f = ihan ok, jos ei parempaa löydy.

                yield return new WaitForSeconds(TimeInterval);
            }

            RandomValue = Random.Range(60, 100);

            switch (RandomValue % 3)
            {
                case 1:
                    RandomValue += 2;
                    break;
                case 2:
                    RandomValue += 1;
                    break;
            }

            for (int i = 0; i < RandomValue; i++)
            {
                if (transform.position.y <= -7.15f)
                {
                    transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                }

                transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);

                if (i > Mathf.RoundToInt(RandomValue * 0.55f))
                {
                    TimeInterval = 0.05f;
                }
                if (i > Mathf.RoundToInt(RandomValue * 1f))
                {
                    TimeInterval = 0.1f;
                }
                if (i > Mathf.RoundToInt(RandomValue * 1.25f))
                {
                    TimeInterval = 0.15f;
                }
                if (i > Mathf.RoundToInt(RandomValue * 1.45f))
                {
                    TimeInterval = 0.2f;
                }

                yield return new WaitForSeconds(TimeInterval);
            }

            randomSpinsM = Random.Range(1, 3);
            randomSpinsL = Random.Range(1, 3);
            randomSpinsCh = Random.Range(1, 3);

            if (transform.position.y == -7.450001f)
            {
                StoppedSlot = "Diamond";
            }
            else if (transform.position.y == -5.8f)
            {
                StoppedSlot = "Crown";
            }
            else if (transform.position.y == -4.15f || transform.position.y < -4.11f && transform.position.y > -5.7f)
            {
                switch (randomSpinsM)
                {
                    case 1:
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (transform.position.y <= -7.15f)
                                {
                                    transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                }

                                transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                            }
                            StoppedSlot = "Crown";
                        }
                        break;
                    case 2:
                        {
                            for (int i = 0; i < 15; i++)
                            {
                                if (transform.position.y <= -7.15f)
                                {
                                    transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                }

                                transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                            }
                            StoppedSlot = "Seven";
                        }
                        break;
                    case 3:
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                if (transform.position.y <= -7.15f)
                                {
                                    transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                }

                                transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                            }
                            StoppedSlot = "Cherry";
                        }
                        break;
                }
                //Debug.Log("Old Melon");
            }
            else if (transform.position.y == -2.5f || transform.position.y < -0.8499999f && transform.position.y > -4.10f)
            {
                StoppedSlot = "Bar";    //Rikki!
            }
            else if (transform.position.y == -0.8499999f)
            {
                StoppedSlot = "Seven";
            }
            else if (transform.position.y == 0.8000001f || transform.position.y > -0.8499999f && transform.position.y < 2.45f)
            {
                switch (randomSpinsCh)
                {
                    case 1:
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                if (transform.position.y <= -7.15f)
                                {
                                    transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                }

                                transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                            }
                            StoppedSlot = "Bar";
                        }
                        break;
                    case 2:
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                if (transform.position.y <= -7.15f)
                                {
                                    transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                }

                                transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                            }
                            StoppedSlot = "Melon";
                        }
                        break;
                    case 3:
                        {
                            /*for (int i = 0; i < 0; i++)
                            {
                                if (transform.position.y <= -7.15f)
                                {
                                    transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                }

                                transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                            }*/
                            StoppedSlot = "Cherry";
                        }
                        break;
                }
                //Debug.Log("Old Cherry");
            }
            else if (transform.position.y == 2.45f)
            {
                switch (randomSpinsL)
                {
                    case 1:
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                if (transform.position.y <= -7.15f)
                                {
                                    transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                }

                                transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                            }
                            StoppedSlot = "Bar";
                        }
                        break;
                    case 2:
                        {
                            for (int i = 0; i < 18; i++)
                            {
                                if (transform.position.y <= -7.15f)
                                {
                                    transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                }

                                transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                            }
                            StoppedSlot = "Diamond";
                        }
                        break;
                    case 3:
                        {
                            /*for (int i = 0; i < 15; i++)
                            {
                                if (transform.position.y <= -7.15f)
                                {
                                    transform.position = new Vector3(transform.position.x, 4.1f, -0.03f);
                                }

                                transform.position = new Vector3(transform.position.x, transform.position.y - 0.55f, -0.03f);
                            }*/
                            StoppedSlot = "Lemon";
                        }
                        break;
                }
                //Debug.Log("Old Lemon");
            }
            else if (transform.position.y == 4.1f)
            {
                StoppedSlot = "Diamond";
            }

            rowStopped = true;

            if (gameControl.spins == 20)
            {
                gameControl.rows[0].newPlayerWinRatioActivated = false;
                gameControl.rows[2].newPlayerWinRatioActivated = false;
                gameControl.rows[0].isWinRatioNormalized = true;
                gameControl.rows[2].isWinRatioNormalized = true;
                gameControl.IsThatNewPlayer = false;
                Debug.Log("New player winratio is off now.");
                gameControl.SaveData();
                gameControl.LoadData();
            }
            if (gameControl.spins == 125)
            {
                gameControl.rows[0].newPlayerWinRatioActivated = false;
                gameControl.rows[2].newPlayerWinRatioActivated = false;
                gameControl.rows[0].isWinRatioNormalized = true;
                gameControl.rows[2].isWinRatioNormalized = true;
                gameControl.IsThatNewPlayer = false;
                Debug.Log("New player winratio is off now.");
                gameControl.SaveData();
                gameControl.LoadData();
            }
            gameControl.SaveData();
            gameControl.LoadData();
        }
    }

    private void OnDestroy()
    {
        GameControl.GameStarted -= StartRotating;
    }
}
