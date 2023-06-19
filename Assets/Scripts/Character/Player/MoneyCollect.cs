using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCollect : MonoBehaviour
{
    public static MoneyCollect instance;

    public Text moneyText;
    public int currentMoneyAmount = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        moneyText.text = currentMoneyAmount.ToString();
    }

    public void IncreaseMoney(int amount)
    {
        currentMoneyAmount += amount;
        moneyText.text = currentMoneyAmount.ToString();

    }
}
