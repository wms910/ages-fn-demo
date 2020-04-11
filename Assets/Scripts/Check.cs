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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (objectToToggleA.activeSelf == true&& objectToToggleB.activeSelf == true && objectToToggleC.activeSelf == true&& objectToToggleD.activeSelf == true)
        {
            finalobject.SetActive(true);
        }
    }
}
