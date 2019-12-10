using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantToCreateNewCars : MonoBehaviour
{
    public void ActivateSpawnCars()
    {
        if (!this.GetComponent<CreateNewParkingPlaces>().isActiveAndEnabled)
        {
            this.GetComponent<CreateNewParkingPlaces>().enabled = true;
        }
    }
}
