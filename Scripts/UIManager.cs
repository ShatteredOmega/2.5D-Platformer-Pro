using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text coinDisplay;

    void Start()
    {
        coinDisplay = GameObject.Find("Coin_Display").GetComponent<Text>();
    }
    public void SetCoin(int coins)
    {
        coinDisplay.text = "Coins: " + coins;
    }
}
