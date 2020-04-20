using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Tooltip("Check this box to lock the door.")]
    [SerializeField]
    private bool isLocked;

    [Tooltip("The text that displays when the player looks at the door while it's locked.")]
    [SerializeField]
    private string lockedDisplayText = "Locked";

    [Tooltip("Play this audio clip when the player interactes with ta locked oor without owning the key.")]
    [SerializeField]
    private AudioClip lockedAudioClip;

    [Tooltip("Play this audio clip when the player opens the door.")]
    [SerializeField]
    private AudioClip openAudioClip;

    public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;

    private Animator animator;
    private bool isOpen = false;

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
    }

    public override void InteractWith()
    {
        if (!isOpen)
        {
            if (!isLocked)
            {
            audioSource.clip = openAudioClip;
            animator.SetBool("shouldOpen", true);
            displayText = string.Empty;
            isOpen = true;
            }
            else//if the door is locked
            {
                audioSource.clip = lockedAudioClip;
            }
            base.InteractWith();//This plays sound effect;
        }
    }
}
