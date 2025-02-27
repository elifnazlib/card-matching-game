using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CardController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    public void Clicked() {
        if(panel.activeSelf) {
            panel.SetActive(false);
        } else panel.SetActive(true);
    }
}
