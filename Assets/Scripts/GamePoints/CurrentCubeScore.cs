using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CurrentCubeScore : MonoBehaviour
{
    private int gainedMoney;
    private int currentMoney;
    public Text gameEndText;
    public Button restartButton;
    public Button nextButton;
    public Text moneyText;


    // Start is called before the first frame update
    void Start() {
        string[] textD = System.IO.File.ReadAllLines("Assets/Scripts/Database.txt");
        currentMoney = Convert.ToInt32(textD[0]);
        gainedMoney = 0;
        moneyText.text = "Total: " + currentMoney + "$";
    }

    public void updateMoney() {
        gainedMoney++;
        currentMoney++;
        moneyText.text = "Total: " + currentMoney + "$";
    }

    public void showWinScreen() {

        nextButton.gameObject.SetActive(true);
        gameEndText.gameObject.SetActive(true);
        int total = gainedMoney * CubesManager.Instance.cubeControllerList.Count;
        gameEndText.text = "You Won!\nTotal Gain: " + (total + gainedMoney) + "$";

        string[] textD = System.IO.File.ReadAllLines("Assets/Scripts/Database.txt");
        textD[0] = (currentMoney + total).ToString();
        textD[2] = SceneManager.GetActiveScene().name;
        System.IO.File.WriteAllLines("Assets/Scripts/Database.txt", textD);
    } 

    public void showEndScreen() {
        restartButton.gameObject.SetActive(true);
        gameEndText.gameObject.SetActive(true);
        gameEndText.text = "You Lost!\nTotal Gain: " + gainedMoney + "$";

        string[] textD = System.IO.File.ReadAllLines("Assets/Scripts/Database.txt");
        textD[0] = currentMoney.ToString();
        textD[2] = SceneManager.GetActiveScene().name;
        System.IO.File.WriteAllLines("Assets/Scripts/Database.txt", textD);
    }

    public void quitGame() {
        SceneManager.LoadScene("MenuScene");
    }

    public void proceedToNextLevel() {
        SceneManage.Instance.nextLevel();
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
