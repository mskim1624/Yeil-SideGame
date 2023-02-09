using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float leftLimit = 0.0f;
    public float rightLimt = 0.0f;
    public float topLimit = 0.0f;
    public float bottomLimit = 0.0f;

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            Debug.LogError("Player 게임오브젝트를 찾을수 없음.");
            return;
        }

        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = this.transform.position.z;

        if (x < leftLimit)
        {
            x = leftLimit;
        }
        else if(x > rightLimt)
        {
            x = rightLimt;
        }

        if(y < bottomLimit)
        {
            y = bottomLimit;
        }
        else if (y > topLimit)
        {
            y = topLimit;
        }

        Vector3 v3 = new Vector3(x, y, z);
        transform.position = v3;
    }
}
