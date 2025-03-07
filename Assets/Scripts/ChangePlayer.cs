using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    static string turn;

    [SerializeField] private UnityEngine.UI.Image leftPanel;
    [SerializeField] private UnityEngine.UI.Image rightPanel;

    void Start()
    {
        turn = "left";
    }
    public string GetCurrentPlayer()
    {
        return turn;
    }

    public void ChangeCurrentPlayer()
    {
        var tempColorLeft = leftPanel.color;
        var tempColorRight = rightPanel.color;
        
        if(GetCurrentPlayer() == "left")
        {
            Debug.Log("Changed to right");
            
            tempColorLeft.a = 0.2f;
            leftPanel.color = tempColorLeft;
            
            tempColorRight.a = 0.5f;
            rightPanel.color = tempColorRight;
            
            turn = "right";
        } 
        else if(GetCurrentPlayer() == "right") 
        {
            Debug.Log("Changed to left");

            tempColorLeft.a = 0.5f;
            leftPanel.color = tempColorLeft;

            tempColorRight.a = 0.2f;
            rightPanel.color = tempColorRight;
            
            turn = "left";
        }
    }
}
