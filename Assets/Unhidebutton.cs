using UnityEngine;

public class UnhideButton : MonoBehaviour
{
    public GameObject buttonOption;

    private void Update()
    {
        if (buttonOption.activeSelf)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}