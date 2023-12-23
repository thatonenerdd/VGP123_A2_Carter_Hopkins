using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelscript : MonoBehaviour
{
    public int StartingLives = 3;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager.Instance.SpawnPlayer(spawnPoint);
        gamemanager.Instance.Lives = StartingLives;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
