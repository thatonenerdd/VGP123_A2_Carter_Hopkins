using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemspawner : MonoBehaviour
{



    public GameObject[] ItemChoice;
    public int itemchoicemax = 2;


    // Start is called before the first frame update
    void Start()
    {
        int randomindex = Random.Range(0, itemchoicemax);
        GameObject selectedItem = ItemChoice[randomindex];
        Instantiate(selectedItem, transform.position, Quaternion.identity );


    }

    // Update is called once per frame
    void Update()
    {

    }
}

