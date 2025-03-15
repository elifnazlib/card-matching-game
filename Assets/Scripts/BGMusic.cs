using UnityEngine;

public class BGMusic : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] sceneClip;
    private static BGMusic bgmusic;
    void Start()
    {
        if(bgmusic != null)
        {
            Destroy(gameObject);
        }
        else
        {
            bgmusic = this;
            
        }
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        // audioSource.clip = sceneClip[0];
        // audioSource.Play();
    }

    public void ChangeMusic(string sceneName)
    {
        switch (sceneName)
        {
            case "MainMenu":
            if (sceneClip[0] != null)
            {
                audioSource.clip = sceneClip[0];
                audioSource.Play();
            }
            break;

            case "ChillMode":
            if (sceneClip[1] != null)
            {
                audioSource.clip = sceneClip[1];
                audioSource.Play();
            }
            break;

            case "EasyMode":
            if (sceneClip[2] != null)
            {
                audioSource.clip = sceneClip[2];
                audioSource.Play();
            }
            break;

            case "MediumMode":
            if (sceneClip[3] != null)
            {
                audioSource.clip = sceneClip[3];
                audioSource.Play();
            }
            break;

            case "HardMode":
            if (sceneClip[4] != null)
            {
                audioSource.clip = sceneClip[4];
                audioSource.Play();
            }
            break;

            case "Multiplayer":
            if (sceneClip[5] != null)
            {
                audioSource.clip = sceneClip[5];
                audioSource.Play();
            }
            break;
        }
    }

}