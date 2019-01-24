using UnityEngine;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke; 

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
			print (breakableCount);
		}
		
		timesHit = 0;
		levelManager =GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.5f);
		if (isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits (){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();
			SmokePuff ();
			Destroy(gameObject);
			
		}
		else {
			LoadSprites();
		}
	}
	
	void LoadSprites (){
		int spriteIndex = timesHit - 1;
		
		if (hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else {
			Debug.LogError ("Brick sprite missing");
		}
	}
	
	void SmokePuff(){
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity)as GameObject;
		ParticleSystem ps = smokePuff.GetComponent<ParticleSystem>();
		ParticleSystem.MainModule main = ps.main;
		main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
		//smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color; //Old Unity 4 way
	}
}
