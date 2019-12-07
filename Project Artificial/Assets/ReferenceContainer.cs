﻿using UnityEngine;

public class ReferenceContainer : MonoBehaviour{
    public GameObject entities;
    public GameObject clients_container;
    public DayCycle day_cycle;
    public QueueController queue_controller;

    void Start()
    {
        References.data = this;
    }
}

public static class References
{
    public static ReferenceContainer data;
}