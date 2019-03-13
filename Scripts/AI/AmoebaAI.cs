
/**
 * AmoebaAI.cs
 * Joe Ford
 * Created 2019-03-13
 *
 * The simplest NPC AI. Looks for food, moves towards the food, eats the food.
 * If there's no food in sight then it will wander in a non-random way.
 * Effect of food are applied via the Munch method
 *
 * STATES
 * Wander: Move around the world, waiting for a state change to be triggered.
 * Eat: Eat the nearest piece of food.
 */

using UnityEngine;

public class AmoebaAI : MonoBehaviour {
  public Creature creature;
  public float turnChance = 0.7f;
  private bool turnLeft = true;
  
  private void WanderingState() {
    // Move forward
    // creature.Forward();
    
    // Select a turn direction using y probability (if RND greater than y then turn in same direction as last time)
    float randomNumber = Random.Range(0.0f, 1.0f)
    if (randomNumber > turnChance) {
      if (turnLeft) {
        turnLeft = false;
      }
    }
    
    // Turn the creature
    if (turnLeft) {
      // creature.turnLeft();
    } else {
      // creature.turnRight();
    }
  }
  
  private void EatingState() {
    // Look for nearby food
    // If there's no food then go back to WanderingState
    // Else select the nearest food
    // Destroy the selected food
    // Trigger the Munch method
  }
  
  private virtual void Munch() {
    // Apply food effects
  }
}
