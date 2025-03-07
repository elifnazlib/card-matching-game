using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainToken : MonoBehaviour
{    
    private Score score;
    private MultiplayerScore multiplayerScore;
    private Timer timer;
    private ChangePlayer _playerScript;
    private GameOver _gameOverScript;
    public static List <int> faceIndexes = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3, 4, 5, 6, 7};
    SpriteRenderer spriteRenderer;
    public Sprite [] faces;
    public Sprite back;
    public int faceIndex;
    public bool matched = false;
    public static bool active = true;
    Scene scene;
    public bool isMultiplayer;
    public static int cardCount;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        cardCount = 0;
        scene = SceneManager.GetActiveScene();

        if(scene.name == "Multiplayer")
        {
            isMultiplayer = true;
            multiplayerScore = (MultiplayerScore)FindFirstObjectByType(typeof(MultiplayerScore));
            _playerScript = (ChangePlayer)FindFirstObjectByType(typeof(ChangePlayer));
        }
        else
        {
            isMultiplayer = false;
            score = (Score)FindFirstObjectByType(typeof(Score)); // Finding the Score instance (for better performance)
            timer = (Timer)FindFirstObjectByType(typeof(Timer));
        }
        
        _gameOverScript = (GameOver)FindFirstObjectByType(typeof(GameOver));
    }

    public void OnMouseDown()
    {   
        if(isMultiplayer == true)
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
                            cardCount +=2;
                            multiplayerScore.UpdateScore();
                            GameObject [] previousCard = GameObject.FindGameObjectsWithTag(faceIndex.ToString());
                            previousCard[0].GetComponent<MainToken>().matched = true;
                            previousCard[1].GetComponent<MainToken>().matched = true;

                            if(cardCount == 16)
                            {
                                _gameOverScript.ActivateGameOverPanel();
                            }
                        }
                    }
                }
            }
        }
        else if (isMultiplayer == false)
        {
            if(matched == false && active == true && timer.IsTimerEnded() == false)
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
                            cardCount +=2;
                            if (SceneManager.GetActiveScene().name != "ChillMode")
                            {
                                score.UpdateScore();
                            }
                            
                            GameObject [] previousCard = GameObject.FindGameObjectsWithTag(faceIndex.ToString());
                            previousCard[0].GetComponent<MainToken>().matched = true;
                            previousCard[1].GetComponent<MainToken>().matched = true;

                            if(cardCount == 16)
                            {
                                timer.ChangeState(true);
                                _gameOverScript.ActivateGameOverPanel();
                            }
                        }
                    }
                }
            }
        }
    }

    private void OnMouseUpAsButton() {
        if (GameControl.TwoCardsUp() == true && matched == false)
        {
            StartCoroutine(WaitBeforeCardsGoBack());
        }
    }

    private IEnumerator WaitBeforeCardsGoBack() 
    {
        active = false;
        yield return new WaitForSeconds(1);
        SecondMethod();
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

            if(isMultiplayer == true)
            {
                _playerScript.ChangeCurrentPlayer();
            }
        }
    }

}
