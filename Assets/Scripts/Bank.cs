using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//Manage and shows player's economy;
public class Bank : MonoBehaviour
{
    [SerializeField] int currentBalance;
    [SerializeField] int startingBalance = 150;

    [SerializeField] TextMeshProUGUI displayBalance;
    public int CurrentBalance { get { return currentBalance; } }

    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
        
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}