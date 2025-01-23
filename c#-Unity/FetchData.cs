using System.Collections;
using System.Collections.Generic;
using Web3Unity.Scripts.Library.Web3Wallet;
using Web3Unity.Scripts.Library.Ethers.Contracts;
using Web3Unity.Scripts.Library.Ethers.Providers;
using UnityEngine;
using UnityEngine.UI;

public class FetchData : MonoBehaviour
{
    public Text ConnectedWallet;
    public Text datapro;
    // Start is called before the first frame update
    void Start()
    {
        ConnectedWallet.text = PlayerPrefs.GetString("Account");

        FetchENS(); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void FetchENS()
    {
        string method = "addresses";

        string address = PlayerPrefs.GetString("Account");

        var provider = new JsonRpcProvider(ContractManager.RPC);

        var contract = new Contract(ContractManager.TokenABI, ContractManager.TokenContract, provider);

        var data = await contract.Call(method, new object[]
        {
            address,
        });
        print(data[0].ToString());

        datapro.text = data[0].ToString();

    }
}
