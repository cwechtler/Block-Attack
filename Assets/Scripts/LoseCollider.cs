using UnityEngine;

public class LoseCollider : MonoBehaviour {
	
	private LevelManager levelManager;
	
	void OnTriggerEnter2D (Collider2D Trigger){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		//print ("Trigger");
		levelManager.LoadLevel ("Lose Screen");
	}
	void OnCollisionEnter2D (Collision2D collision) {
		//print ("Collision");
	}
}
