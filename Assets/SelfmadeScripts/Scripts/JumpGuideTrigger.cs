using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpGuideTrigger : MonoBehaviour
{
    public TextMeshProUGUI GuideText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GuideText.SetText("Press 'Space' to jump");
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

