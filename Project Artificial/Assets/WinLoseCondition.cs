using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinLoseCondition : MonoBehaviour
{
    public Text lose_game;
    public Text win_game;
    public GameObject menu_end;
    int ClientsUnHappy;
    // Start is called before the first frame update
    void Start()
    {
        ClientsUnHappy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(int.Parse(References.data.day_cycle.current_day.TotalDays.ToString()) > 2)
        {
            WinGame();
        }
    }

    public void LoseGame()
    {
        menu_end.SetActive(true);
        lose_game.enabled = true;
        Time.timeScale = 0;
    }

    void WinGame()
    {
        menu_end.SetActive(true);
        win_game.enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
