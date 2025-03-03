using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MainToken : MonoBehaviour
{
    // GameControl gameControl;
    public static List <int> faceIndexes = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3, 4, 5, 6, 7};
    SpriteRenderer spriteRenderer;
    public Sprite [] faces;
    public Sprite back;
    public int faceIndex;
    public bool matched = false;
    public static bool active = true;


    public void OnMouseDown()
    {
        if(matched == false && active == true) 
        {        
            if(spriteRenderer.sprite == back)
            {
                if(GameControl.TwoCardsUp() == false) 
                {
                    spriteRenderer.sprite = faces[faceIndex];
                    GameControl.AddVisibleFace(faceIndex);
                    matched = GameControl.CheckMatch();
                    if(matched == true)
                    {
                        GameObject [] previousCard = GameObject.FindGameObjectsWithTag(faceIndex.ToString());
                        previousCard[0].GetComponent<MainToken>().matched = true;
                        previousCard[1].GetComponent<MainToken>().matched = true;
                    }
                }
            }
            // else 
            // {
            //     spriteRenderer.sprite = back;
            //     GameControl.RemoveVisibleFace(faceIndex);                
            // }
        }
    }

    private void OnMouseUpAsButton() {
        if (GameControl.TwoCardsUp() == true && matched == false)
        {
            StartCoroutine(WaitBeforeCardsGoBack());
        }
    }


    private void SecondMethod()
    {
        Debug.Log("first");
        if(GameControl.TwoCardsUp() == false); else {
            int index0 = GameControl.GetVisibleFaceIndexes().index0, index1 = GameControl.GetVisibleFaceIndexes().index1;
            Debug.Log($"indexes are: {index0}, {index1}");
            GameObject [] firstCard = GameObject.FindGameObjectsWithTag(index0.ToString());
            GameObject [] secondCard = GameObject.FindGameObjectsWithTag(index1.ToString());
            Debug.Log($"First and second cards are: {firstCard[0].tag}, {firstCard[1].tag},  {secondCard[0].tag},  {secondCard[1].tag}");
            firstCard[0].GetComponent<SpriteRenderer>().sprite = back;
            firstCard[1].GetComponent<SpriteRenderer>().sprite = back;
            secondCard[0].GetComponent<SpriteRenderer>().sprite = back;
            secondCard[1].GetComponent<SpriteRenderer>().sprite = back;
            GameControl.RemoveVisibleFace(index0);
            GameControl.RemoveVisibleFace(index1);
            Debug.Log("last");
            active = true;
        }
    }

    private IEnumerator WaitBeforeCardsGoBack() 
    {
        Thread.Sleep(1000);
        active = false;
        yield return new WaitForSeconds(1);
        SecondMethod();
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
