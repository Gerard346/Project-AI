using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinLoseCondition : MonoBehaviour
{
    public Text lose_game;
    public Text win_game;
    public Text score_text;
    public GameObject menu_end;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
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
        score_text.enabled = true;
        score_text.text = "Score: " + 0;
    }

    void WinGame()
    {
        menu_end.SetActive(true);
        win_game.enabled = true;
        score_text.enabled = true;
        score_text.text = "Score: " + References.data.manager_money.TotalMoney() + References.data.shop_rating.GetStars();

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
