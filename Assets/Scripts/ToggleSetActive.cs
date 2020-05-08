using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject
{
    [Tooltip("The GameObject to toggle.")]
    [SerializeField]
    private GameObject objectToToggleA;

    [SerializeField]
    private GameObject objectToToggleB;

    [SerializeField]
    private GameObject objectToToggleC;

    [Tooltip("Can the player interact with this more than once?")]
    [SerializeField]
    private bool isReusable = true;

    private bool hasBeenUsed = false;

    /// <summary>
    /// Toggles the activeSelf value for the objectToToggle when the player interacts with this object.
    /// </summary>
    public override void InteractWith()
    {
        if (isReusable || !hasBeenUsed)
        {
            base.InteractWith();
            objectToToggleA.SetActive(!objectToToggleA.activeSelf);
            objectToToggleB.SetActive(!objectToToggleB.activeSelf);
            objectToToggleC.SetActive(!objectToToggleC.activeSelf);
            hasBeenUsed = true;
            if (!isReusable) displayText = string.Empty;
        }
        
    }
}
