using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    SpriteRenderer token;
    // List <int> faceIndexes = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3, 4, 5, 6, 7};

    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    public static int [] visibleFaces = {-1, -2};

    // Start is called before the first frame update
    void Start()
    {
        token = GetComponent<SpriteRenderer>();
        int originalLength = MainToken.faceIndexes.Count;
        shuffleNum = rnd.Next(0, MainToken.faceIndexes.Count);
        token.GetComponent<MainToken>().faceIndex = MainToken.faceIndexes[shuffleNum];
        MainToken.faceIndexes.Remove(MainToken.faceIndexes[shuffleNum]);
    }

    public static bool TwoCardsUp() 
    {
        bool cardsUp = false;
        if (visibleFaces[0] >= 0 && visibleFaces[1] >= 0)
        {
            cardsUp = true;
        }
        return cardsUp;
    }

    public static void AddVisibleFace(int index) 
    {
        if (visibleFaces[0] == -1)  // If first chosen tile is empty
        {
            visibleFaces[0] = index;
        }
        else if (visibleFaces[1] == -2) // If second chosen tile is empty
        {
            visibleFaces[1] = index;
        }
    }


    public static void RemoveVisibleFace(int index) 
    {
        if (visibleFaces[0] == index)  // If first chosen tile is empty
        {
            visibleFaces[0] = -1;
        }
        else if (visibleFaces[1] == index) // If second chosen tile is empty
        {
            visibleFaces[1] = -2;
        }
    }


    public static bool CheckMatch()
    {
        bool success = false;

        if (visibleFaces[0] == visibleFaces[1])
        {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            success = true;
        }
        
        return success;
    }

}
