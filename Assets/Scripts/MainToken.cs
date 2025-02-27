using System.Collections;
using System.Collections.Generic;
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

    public void OnMouseDown()
    {
        if(matched == false) 
        {        
            if(spriteRenderer.sprite == back)
            {
                if(GameControl.TwoCardsUp() == false) 
                {
                    spriteRenderer.sprite = faces[faceIndex];
                    GameControl.AddVisibleFace(faceIndex);
                    matched = GameControl.CheckMatch();
                }
            }
            else 
            {
                spriteRenderer.sprite = back;
                GameControl.RemoveVisibleFace(faceIndex);
            }
        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
}
