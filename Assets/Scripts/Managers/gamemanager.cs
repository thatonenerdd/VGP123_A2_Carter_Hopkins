using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;

[DefaultExecutionOrder(-1)]
public class gamemanager : MonoBehaviour
{ static gamemanager instance = null;
    public static gamemanager Instance => instance;
    public int plives = 3;
    public int Lives
    {
        get => plives;
        set
        {
            if (Lives > value)
                Respawn();
            plives = value;

            if (plives > maxlife)
                Lives = maxlife;
            if (plives <= 0)
            {
                SceneManager.LoadScene("Game over");
                plives = 3;
                score = 0;

            }
            
            OnLivesValueChanged?.Invoke(plives);
         

        }
    }
    public int score = 0;
    
    
    


    public int maxlife = 10;

    public PlayerController playerPrefab;
    public UnityEvent<int> OnLivesValueChanged;

    
    
    [HideInInspector] public PlayerController playerInstance;
    [HideInInspector] public Transform spawnPoint;
    // Start is called before the first frame update
    private void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);

    }
    
      
    
    public void SpawnPlayer(Transform spawnLocation)

    {
        playerInstance = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
        spawnPoint = spawnLocation;
    }


    public void Respawn()
    {
        playerInstance.transform.position = spawnPoint.position;
    }
    public void UpdateSpawnPoint(Transform updatedPoint)

    {
        spawnPoint = updatedPoint;
    }
}
    