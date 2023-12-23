using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{



    public float minXClamp;
    public float maxXClamp;
    public float minYClamp;
    public float maxYClamp;

    // Start is called before the first frame update
    private void LateUpdate()
    {
        if (gamemanager.Instance.playerInstance == null) return;
        Vector3 cameraPos;

        cameraPos = transform.position;
        cameraPos.x = Mathf.Clamp(gamemanager.Instance.playerInstance.transform.position.x, minXClamp, maxXClamp);
        cameraPos.y = Mathf.Clamp(gamemanager.Instance.playerInstance.transform.position.y, minYClamp, maxYClamp);
        transform.position = cameraPos;

    }
}
