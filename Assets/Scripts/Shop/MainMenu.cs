using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    private int gainedMoney;
    private int currentMoney;
    public Text moneyText;

    public void PlayGame() {
        
        string[] textD = System.IO.File.ReadAllLines("Assets/Scripts/Database.txt");
        string level = textD[2];

        SceneManager.LoadScene(level);
    }

    void Awake() {
        string[] textD = System.IO.File.ReadAllLines("Assets/Scripts/Database.txt");
        currentMoney = Convert.ToInt32(textD[0]);
        gainedMoney = 0;
        moneyText.text = "Total: " + currentMoney + "$";
    } 

    public void LoadShop() {
        SceneManager.LoadScene("ShopScene");
    }

}
