using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Block block;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;
    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));

        Instantiate(ball);
        Block block1 = Instantiate(block) as Block;
        Block block2 = Instantiate(block) as Block;

        block1.Init(true); // left block
        block2.Init(false); // right block

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
