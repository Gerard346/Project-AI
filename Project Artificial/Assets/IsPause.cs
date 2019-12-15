using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsPause : MonoBehaviour
{
    public GameObject Pause;
    bool is_paused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Paused()
    {
        if (is_paused)
        {
            Time.timeScale = 1;
            is_paused = false;
            Pause.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            is_paused = true;
            Pause.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Paused();
    }

    public void Restart()
    {
        Paused();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
