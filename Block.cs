using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    float speed;
    float height;

    float offset;

    string input;
    public bool isRight;

    public void Init(bool isRightPaddle)
    {
        Vector2 pos = new Vector2(0,0);

        if(isRightPaddle){
            pos = new Vector2(GameManager.topRight.x,0);
            pos -= new Vector2(1,0) * transform.localScale.x;

            input = "BlockRight";
        }
        else{
            pos = new Vector2(GameManager.bottomLeft.x,0);
            pos += new Vector2(1,0) * transform.localScale.x;

            input = "BlockLeft";
        }

        transform.position = pos;
        transform.name = input;
        isRight = isRightPaddle;
    }
    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        offset = height/2;
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (transform.position.y < GameManager.bottomLeft.y + offset && move < 0){
            move = 0f;
        }
        if (transform.position.y > GameManager.topRight.y - offset && move > 0){
            move = 0f;
        }

        transform.Translate(move * Vector2.up);
    }
}
