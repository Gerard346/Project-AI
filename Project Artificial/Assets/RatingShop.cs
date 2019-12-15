using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RatingShop : MonoBehaviour
{
    public GameObject container_stars;
    public Button target;
    int size = 0;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        size = container_stars.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(References.data.manager_money.TotalMoney() > 200)
        {
            return;
        }
        CheckIfTheyAreAllActive();
    }

    public void ActiveStars()
    {
        for(int i = 0; i < size; i++)
        {
            if (!container_stars.transform.GetChild(i).gameObject.activeSelf)
            {
                References.data.manager_money.AddMoney(-200);
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
                return;
            }
        }
        if (target.IsInteractable())
        {
            target.interactable = false;
        }
    }

    public int GetStars()
    {
        for (int i = 0; i < size; i++)
        {
            if (container_stars.transform.GetChild(i).gameObject.activeSelf)
            {
                count++;
            }
        }
        return count;
    }
}
