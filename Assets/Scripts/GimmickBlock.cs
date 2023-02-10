using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBlock : MonoBehaviour
{
    public float length = 0.0f;     // 플레이어와의 거리 셋팅
    public bool isDelete = false;   // 바닥에 닿이면 사라질것인지 아닌지 

    bool isFell = false;            // 바닥에 닿였는지 플래그
    float fadeTime = 0.5f;          // 페이드 아웃 연출 시간
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float d = Vector2.Distance(transform.position, player.transform.position);
            if (length >= d)
            {
                Rigidbody2D rbody = GetComponent<Rigidbody2D>();
                if (rbody.bodyType == RigidbodyType2D.Static)
                {
                    rbody.bodyType = RigidbodyType2D.Dynamic;
                }
            }

        }

        if (isFell)
        {
            // 떨어진것 확인후 --- 사라질 오브젝트이면 페이드아웃 연출 효과
            fadeTime -= Time.deltaTime;
            Color col = GetComponent<SpriteRenderer>().color;
            col.a = fadeTime;

            GetComponent<SpriteRenderer>().color = col;
            if (fadeTime <= 0.0f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (isDelete)
        {
            isFell = true;
        }
    }

}
