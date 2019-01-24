using UnityEngine;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;

	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	void Update () {
		if (!hasStarted){
			//Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			//Wait for a mouse press to launch.
			if (Input.GetMouseButtonDown(0)){	
				//print ("Mouse Click, Launch Ball");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f,10f);
				//print ("Launch");
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		Vector2 tweak = new Vector2 (Random.Range(-0.2f, 0.2f), Random.Range (-0.2f, 0.2f));
	
		if (hasStarted){
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity +=tweak;
			
		}
	}
}
