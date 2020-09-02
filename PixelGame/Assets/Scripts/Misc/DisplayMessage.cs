using Assets.Scripts.Misc;
using Assets.Scripts.Player;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayMessage : MonoBehaviour
{
    public GameObject message;
    public GameObject winMessage;
    public GameObject loseMessage;


    private void Start()
    {
        StartCoroutine(Hide());
    }
    public void WinMessage()
    {
        winMessage.SetActive(true);
    }

    public void LoseMessage()
    {
        loseMessage.SetActive(true);
    }

    private IEnumerator Hide()
    {
        yield return new WaitForSeconds(1.75f);
        message.SetActive(false);
    }

    public void Replay()
    {
        PlayerStats.playerLives = 5;
        GlobalVariables.CollectedFruits = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
