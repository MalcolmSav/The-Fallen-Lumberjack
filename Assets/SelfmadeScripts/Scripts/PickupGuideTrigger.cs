using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupGuideTrigger : MonoBehaviour
{
    public TextMeshProUGUI GuideText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GuideText.SetText("Press 'F' to Pick Up the Wallbreaker!");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GuideText.SetText(" ");
        }
    }
}
