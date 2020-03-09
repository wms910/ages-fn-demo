﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects interactive elements the player is looking at.
/// 
/// </summary>
public class DetectLookedAtInteractive : MonoBehaviour
{
    [Tooltip("Starting point of raycast used to detect interactives.")]
    [SerializeField]
    private Transform raycastOrigin;

    [Tooltip("How far from the racastOrigin we will search for interactive elements.")]
    [SerializeField]
    private float maxRange = 2.5f;

    public IInteractive LookedAtInteractive
    {
        get { return lookedAtInteractive; }
        private set { lookedAtInteractive = value; }
    }

    private IInteractive lookedAtInteractive;

    private void FixedUpdate()
    {
        Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, maxRange);
        RaycastHit hitInfo;
        bool objectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange);

        IInteractive interactive = null;

        LookedAtInteractive = interactive;

        if (objectWasDetected)
        {
            //Debug.Log("Player is looking at: " + hitInfo.collider.gameObject.name);
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }

        if (interactive != null)
            lookedAtInteractive = interactive;
    }
}
