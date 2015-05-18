using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Control : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
	private int count;
	public Text countText, WinText;
	// Use this for initialization
	void Start () {
		count = 0;
		WinText.text = "";
		rb = GetComponent<Rigidbody> ();
		setCountText ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement*speed);

	}
	// Destroy everything that enters the trigger
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("pickups")) {
			other.gameObject.SetActive(false);
			count = count + 1;
			setCountText();
		}
	}

	void setCountText(){
		
		countText.text = "Count: " + count.ToString ();
		if (count >= 9) {
			WinText.text = "you win";
		}
	}
}
