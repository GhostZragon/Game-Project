using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    SceneManager sceneManager;
    [SerializeField] AudioSource audioSource;

    

    private void Awake()
    {
        //SceneManager.SetActiveScene();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnOfMusic()
    {
        audioSource.Stop();
    }
    public void TurnOnMusic()
    {
        audioSource.Play();
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        //SceneManager.SetActiveScene
    }
}
