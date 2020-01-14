using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public int hitCount = 0;
	[SerializeField]
	float speed;

	float radius;
	Vector2 direction; 
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
    	//wall collision
        transform.Translate (direction * speed * Time.deltaTime);
        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0){
        	direction.y = -direction.y;
        }
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0){
        	direction.y = -direction.y;
        }

        //win condition
        transform.Translate (direction * speed * Time.deltaTime);
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0){
        	Debug.Log ("Game Over");
        }
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0){
        	Debug.Log ("Game Over");
        }
    }

    void OnTriggerEnter2D(Collider2D other){
    	if (other.tag == "Block"){
    		bool isRight = other.GetComponent<Block>().isRight;

    		if (isRight && direction.x > 0){
    			direction.x = -direction.x;
    		}
    		if (!isRight && direction.x < 0){
    			direction.x = -direction.x;
    		}
    	}
    	speed +=0.5f;
    	hitCount++;
    	Debug.Log ("Score: "+hitCount);
    }
}
