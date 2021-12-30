using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int coins;
    public int spins;
    public int diamond3Wins;
    public int diamond2Wins;
    public int crown3Wins;
    public int crown2Wins;
    public int seven3Wins;
    public int seven2Wins;
    public bool IsWinRatioTooBig;
    public bool IsThatNewPlayer;

    public bool isWinRatioNormalized0;
    public bool isWinRatioNormalized1;
    public bool isWinRatioNormalized2;
    public bool newPlayerWinRatioActivated0;
    public bool newPlayerWinRatioActivated2;
    public int roundMax0;
    public int roundMax1;
    public int roundMax2;

    public string nickname;
    public bool isNicknameAccepted;
    public bool isThatFirstStart;
    public bool playerNeedTuto;

    public PlayerData (GameControl gameControl)
    {
        coins = gameControl.coins;
        spins = gameControl.spins;
        diamond3Wins = gameControl.diamond3Wins;
        diamond2Wins = gameControl.diamond2Wins;
        crown3Wins = gameControl.crown3Wins;
        crown2Wins = gameControl.crown2Wins;
        seven3Wins = gameControl.seven3Wins;
        seven2Wins = gameControl.seven2Wins;
        IsWinRatioTooBig = gameControl.IsWinRatioTooBig;
        IsThatNewPlayer = gameControl.IsThatNewPlayer;
        isWinRatioNormalized0 = gameControl.rows[0].isWinRatioNormalized;
        isWinRatioNormalized1 = gameControl.rows[1].isWinRatioNormalized;
        isWinRatioNormalized2 = gameControl.rows[2].isWinRatioNormalized;
        newPlayerWinRatioActivated0 = gameControl.rows[0].newPlayerWinRatioActivated;
        newPlayerWinRatioActivated2 = gameControl.rows[2].newPlayerWinRatioActivated;
        roundMax0 = gameControl.rows[0].roundMax;
        roundMax1 = gameControl.rows[1].roundMax;
        roundMax2 = gameControl.rows[2].roundMax;
        nickname = gameControl.nickName;
        isNicknameAccepted = gameControl.isNicknameAccepted;
        isThatFirstStart = gameControl.isThatFirstStart;
        playerNeedTuto = gameControl.playerNeedTuto;
    }
}
