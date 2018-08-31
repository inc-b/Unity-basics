using UnityEngine;
using System.Collections;

public class standardBrain : MonoBehaviour {

	// BASE STATS
	// Physical
    public float speed = 100.0f;
	float defaultSpeed = speed;
	public float health = 100.0f;
	float defaultHealth = health;
	public float turningSpeed = 100.0f;
	float defaultTurningSpeed = turningSpeed;
	// Sensory
	public float visionRange = 100.0f;
	float defaultVisionRange = visionRange;
	public float visionAngle = 100.0f;
	float defaultVisionAngle = visionAngle;
	
	// STATUS VARIABLES
	bool isAlive = true;
	bool isMoving = true;
	bool isTurning = true;
	bool turningLeft = true; // If you're turning and aren't turning left, then you're turning right
		

    void Update () {
		
		testBrain(); // Test function to make sure the brain is working
		
		// If this thing is alive, then do stuff
        if (isAlive) {
			// Is it currently moving?
			if (isMoving){
				transform.Translate(Vector3.forward * speed * Time.deltaTime);
			}
			// Is it currently turning?
			if(isTurning){
				if (turningLeft) {
					Transform.Roatate(Vector3.left * turningSpeed * Time.deltaTime);
				} else {
					Transform.Roatate(Vector3.right * turningSpeed * Time.deltaTime);
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
}
