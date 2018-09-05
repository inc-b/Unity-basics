using UnityEngine;
using System.Collections;

public class standardBrain : MonoBehaviour {
	
	// Technical attributes
	Animator myAnimator;
	Collider mySensor;

	// Physical stats
    public float mySpeed = 100.0f; // How fast can I move?
	float myDefaultSpeed = speed;
	public float myHealth = 100.0f; // How strong/healthy am I?
	float myDefaultHealth = health;
	public float myTurningSpeed = 100.0f; // How fast can I turn?
	float myDefaultTurningSpeed = turningSpeed;
	
	// Sensory stats
	public float myVisionRange = 100.0f; // How far can I see?
	float myDefaultVisionRange = visionRange;
	public float myVisionAngle = 100.0f; // How widely can I see?
	float myDefaultVisionAngle = visionAngle;
	public float myDetectionRange = 100.0f; // How close would something get before I notice it?
	float myDefaultDetectionRange = detectionRange;
	
	// Status flags
	bool isAlive = true; // Am I alive?
	bool isMoving = true; // Am I active? (usually only active if visible)
	bool isTurning = true; // Am I turning?
	bool turningLeft = true; // If I'm turning and am not turning left, then I'm turning right
	
	// Inventories
	List<GameObject> seenThings = new List<GameObject>();
	List<GameObject> myPossessions = new List<GameObject>();
		
	// Startup actions
	void Start () {
		myAnimator = GetComponent<Animator>();
		mySensingRange = this.GameObject.AddComponent<SphereCollider>();
		mySensingRange.center = Vector3.zero;
		mySensingRange.radius = myDetectionRange;
	}
	
	// Constant actions
    void Update () {
		
		// If I'm active then do things
		if (isActive) {
			
			lookyLook(); // Look around
			
			testBrain(); // Test function to make sure my brain is working
			
			// If I'm alive then do physical things
			if (isAlive) {
				// Am I moving?
				if (isMoving){
					transform.Translate(Vector3.forward * mySpeed * Time.deltaTime);
				}
				// Am I turning?
				if(isTurning){
					if (turningLeft) {
						Transform.Roatate(Vector3.left * myTurningSpeed * Time.deltaTime);
					} else {
						Transform.Roatate(Vector3.right * myTurningSpeed * Time.deltaTime);
					}
				}
			}
		}
    }
	
	// Brain testing function full of random goodies
	void testBrain () {
		
		// Test the turning mechanisms by randomly turning left or right
		float turnTest = Random.Range(0.0f,100.0f);
		int turnChance = 50; // Percentage chance of turning in either direction
		isTurning = false;
		if (turnTest > turnChance) {
			isTurning = true;
			turningLeft = true;
		} else if (turnTest <= turnChance) {
			isTurning = true;
			turningLeft = false;
		}
		
	}
	
	// What can I see?
	void lookyLook () {
		
		RaycastHit hit;
		
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, myVisionRange, layerMask)) {
			// Oh, I see something!
			GameObject seenThing = hit.transform.gameObject;
			
		}
	}
	
	// I've sensed something!
	void onCollisionStay (Collision sensedThing) {
		Vector3 sensedDirection = sensedThing.transform.position - transform.position;
		float angle = Vector3.Angle(sensedDirection,transform.forward);
		if (angle < myVisionAngle / 2) {
			seenThings.Add(sensedThing);
		}
	}
	
	// I've stopped sensing something...
	void onCollisionExit (collision sensedThing) {
		// I can no longer see it
		if (seenThings.Contains(sensedThing){
			seenThings.remove(sensedThing);
		}
	}
	
	// Something hit me!
	public void doHarm (float damageInflicted) {
		myHealth -= damageInflicted;
		if (myHealth =< 0) {
			isAlive = false;
		}
	}
	
}
