using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float leftLimit = 0.0f;
    public float rightLimt = 0.0f;
    public float topLimit = 0.0f;
    public float bottomLimit = 0.0f;

    public GameObject subBackScreen;

    public bool isForceScrollX = false;     // x�� ���� ��ũ�� �÷���
    public float forceScrollSpeedX = 0.5f;  // 1�ʰ� ������ x�� �Ÿ�
    public bool isForceScrollY = false;     // y�� ���� ��ũ�� �÷���
    public float forceScrollSpeedY = 0.5f;  // 1�ʰ� ������ y�� �Ÿ� 

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            Debug.LogError("Player ���ӿ�����Ʈ�� ã���� ����.");
            return;
        }

        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = this.transform.position.z;

        if (isForceScrollX)
        {
            x = transform.position.x + (forceScrollSpeedX * Time.deltaTime);
        }

        if (x < leftLimit)
        {
            x = leftLimit;
        }
        else if(x > rightLimt)
        {
            x = rightLimt;
        }

        if (isForceScrollY)
        {
            y = transform.position.y + (forceScrollSpeedY * Time.deltaTime);
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

        if (subBackScreen != null)
        {
            y = subBackScreen.transform.position.y;
            z = subBackScreen.transform.position.z;

            Vector3 vSub = new Vector3(x / 2.0f, y, z);
            subBackScreen.transform.position = vSub;
        }
    }
}
