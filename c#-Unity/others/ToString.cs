using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongData : MonoBehaviour
{
    public Text Getbaly;
    async void Start()
    {
        string chain = "emerald";
        string network = "mainnet"; // mainnet goerli
        string account = PlayerPrefs.GetString("Account");
        string rpc = "https://testnet.emerald.oasis.dev/";

        string balance = await EVM.BalanceOf(chain, network, account, rpc);
        print(balance);
        int number = int.Parse(balance);
        int result = number / Convert.ToInt32(1000000000000000000);
        Getbaly.text = Convert.ToString(result) + "" +"Rose";
    }
}
