/**
 * LandAnimal.cs
 * Joe Ford
 * Created 2019-03-05
 *
 * Walking animal
 * Extends from default creature class
 *
 * A land animal can move around on land and in shallow water. Can also jump.
 */
 
using UnityEngine;

public class LandAnimal : Creature {
  // Movement functions

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("GROUND")) {
            touchingGround = true;
            isJumping = false;
        }
    }
        
    private void OnCollisionExit(Collision collision) {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("GROUND")) {
            touchingGround = false;
        }
    }

    public void walkForward() {
        isMoving = true;
        moveDirection = Vector3.forward;
    }

    public void walkBackward() {
        if (isMoving) {
            isMoving = false;
        } else {
            isMoving = true;
            moveDirection = Vector3.back;
        }
    }

    public void turnTo(float turnAngle) {
        if (turnAngle > 0) {
            turningRight = true;
            turningLeft = false;
        } else {
            turningRight = false;
            turningLeft = true;
        }
    }

    public void stopMoving() {
        isMoving = false;
        turningLeft = false;
        turningRight = false;
        moveDirection = Vector3.zero;
    }

    public void jump() {
        if (touchingGround) {
            isJumping = true;
            rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
        }
    }
}
