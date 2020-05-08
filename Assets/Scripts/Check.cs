using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToToggleA;

    [SerializeField]
    private GameObject objectToToggleB;

    [SerializeField]
    private GameObject objectToToggleC;

    [SerializeField]
    private GameObject objectToToggleD;

    [SerializeField]
    private GameObject finalobject;

    [SerializeField]
    private GameObject teleport;

    [SerializeField]
    private GameObject redmushroom;

    // Update is called once per frame
    void Update()
    {
       if (objectToToggleA.activeSelf == true && objectToToggleB.activeSelf == true && objectToToggleC.activeSelf == true && objectToToggleD.activeSelf == true)
        {
            finalobject.SetActive(true);
            teleport.SetActive(true);
            redmushroom.SetActive(true);
        }
        else
        {
            finalobject.SetActive(false);
            teleport.SetActive(false);
            redmushroom.SetActive(false);
        }
    }
}
