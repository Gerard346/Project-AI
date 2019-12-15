using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RatingShop : MonoBehaviour
{
    public GameObject container_stars;
    public Button target;
    int size = 0;
    // Start is called before the first frame update
    void Start()
    {
        size = container_stars.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTheyAreAllActive();
    }

    public void ActiveStars()
    {
        for(int i = 0; i < size; i++)
        {
            if (!container_stars.transform.GetChild(i).gameObject.activeSelf)
            {
                container_stars.transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
        }
    }

    public void DesactivateStars()
    {
        for (int i = size -1; i > 0; i--)
        {
            if (container_stars.transform.GetChild(i).gameObject.activeSelf)
            {
                container_stars.transform.GetChild(i).gameObject.SetActive(false);
                return;
            }
        }
        References.data.win_lose.LoseGame();
    }

    private void CheckIfTheyAreAllActive()
    {
        for (int i = 0; i < size; i++)
        {
            if (!container_stars.transform.GetChild(i).gameObject.activeSelf)
            {
                target.interactable = true;
                return;
            }
        }
        target.interactable = false;
    }
}
