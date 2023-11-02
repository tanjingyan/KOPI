using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class DisplayTextOnHover : MonoBehaviour
{
    public Text hoverText;

    private void Start()
    {
        hoverText.gameObject.SetActive(false);
    }

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        hoverText.text = "Hovered Over!";
        hoverText.gameObject.SetActive(true);
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        hoverText.gameObject.SetActive(false);
    }
}