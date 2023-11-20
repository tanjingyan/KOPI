using UnityEngine;

public class colourcontroller : MonoBehaviour
{
    public GameObject wall; // Reference to the wall object
    public Material desiredColorMaterial; // Reference to the material with the desired color

    public void OnObjectClicked()
    {
        // Change the wall's material to the desired color material
        wall.GetComponent<Renderer>().material = desiredColorMaterial;

        Debug.Log("Wall color changed!");
    }
}