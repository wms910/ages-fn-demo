using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Tooltip("Assigning a key here will lock the door. If the player has the ekey in their inventory, they can open the locked door.")]
    [SerializeField]
    private InventoryObject key;

    [Tooltip("If this is checked, the associated key will be removed from the player's inventory when the door is unlocked.")]
    [SerializeField]
    private bool consumeKey;

    [Tooltip("The text that displays when the player looks at the door while it's locked.")]
    [SerializeField]
    private string lockedDisplayText = "Locked";

    [Tooltip("Play this audio clip when the player interactes with ta locked oor without owning the key.")]
    [SerializeField]
    private AudioClip lockedAudioClip;

    [Tooltip("Play this audio clip when the player opens the door.")]
    [SerializeField]
    private AudioClip openAudioClip;

    // public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;

    public override string DisplayText
    {
        get
        {
            string toReturn;

            if (isLocked)
                toReturn = HasKey ? $"Use {key.OjbectName}" : lockedDisplayText;
            else
                toReturn = base.DisplayText;

            return toReturn;
        }
    }

    private bool HasKey => PlayerInventory.InventoryObjects.Contains(key);
    private Animator animator;
    private bool isOpen = false;
    private bool isLocked;

    /// <summary>
    /// Using a constructor here to intitialize displayText in the editor.
    /// </summary>
    public Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        InitializeisLocked();
    }

    private void InitializeisLocked()
    {
        if (key != null)
            isLocked = true;
    }

    public override void InteractWith()
    {
        if (!isOpen)
        {
            if(isLocked && !HasKey)
            {
                audioSource.clip = lockedAudioClip;
            }
            else // if it's not locked, or if it's locked and we have the key
            {
                audioSource.clip = openAudioClip;
                animator.SetBool("shouldOpen", true);
                displayText = string.Empty;
                isOpen = true;
                UnlockDoor();
            }
            base.InteractWith();//This plays sound effect;
        }
    }

    private void UnlockDoor()
    {
        isLocked = false;
        if (key != null && consumeKey)
            PlayerInventory.InventoryObjects.Remove(key);
    }
}
