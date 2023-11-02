using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButton2 : MonoBehaviour
{
    private bool isLightOn = false;
    public GameObject lightObject;
    // Start is called before the first frame update
    void Start()
    {
        lightObject.SetActive(isLightOn);
        
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    public void ToggleLightSwitch()
    {
        isLightOn = !isLightOn; // Toggle the light state

        lightObject.SetActive(isLightOn); // Turn the light on/off

    }
}
