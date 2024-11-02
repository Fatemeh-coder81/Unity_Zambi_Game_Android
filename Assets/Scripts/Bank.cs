using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName ="Bank" , menuName = "Bank")]
public class Bank : ScriptableObject
{

    public float Coin;

    public void Deposit(float Ammount , TextMeshProUGUI Ui)
    {
        
        Coin += Ammount;
        Ui.text = Coin.ToString();  
    }

    public bool Withdraw(float Ammount, TextMeshProUGUI Ui)
    {
        if(Coin >= Ammount)
        {
            Coin -= Ammount;
            Ui.text = Coin.ToString();
            return true;
        }
        else
        {
            return false;
        }

    }


}
