using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public enum PickupType
    {
        powerup = 0,
        Life = 1,
        Score = 2,
        End = 3,
    }


    public PickupType currentPickup;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            switch (currentPickup)
            { case PickupType.powerup:

                    collision.GetComponent<PlayerController>().StartSpeedChange();
                    break; 
              case PickupType.Life:
           
                    gamemanager.Instance.Lives++;
                    break;
                        
                        case PickupType.Score:
                    gamemanager.Instance.score++;
                    break;

                case PickupType.End:

                    gamemanager.Instance.ChangeScene(3);
                    break;
            }
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
