using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupGuideTrigger : MonoBehaviour
{
    public string Tutorialtext;
    public TextMeshProUGUI GuideText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GuideText.SetText(Tutorialtext);
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
