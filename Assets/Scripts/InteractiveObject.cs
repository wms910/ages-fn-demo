using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
//[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
    [Tooltip("Text that will display in the UI when the player looks at this object in the world.")]
    [SerializeField]
    protected string displayText = nameof(InteractiveObject);

    public virtual string DisplayText => displayText;
    protected AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public virtual void InteractWith()
    {
        try
        {
            audioSource.Play();
        }
        catch (System.Exception)
        {

            throw new System.Exception("Missing AudioSource componet or audio clip: InteractiveObject requires an AudioSource component with an audio clip assigned.");
        }
        if (gameObject.name == "BlueMushroom")
        {
            SceneManager.LoadScene("Lose");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (gameObject.name == "RedMushroom")
        {
            SceneManager.LoadScene("Win");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Debug.Log($"Player just interacted with {gameObject.name}.");
        }
    }    
}