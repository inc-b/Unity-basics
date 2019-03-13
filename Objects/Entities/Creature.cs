/**
 * Creature.cs
 * Joe Ford
 * Created 2019-02-22
 *
 * Living creatures that move around the world
 * Has attributes like movement speed, turning speed, health, stamina, etc
 * This class has no brain - an extension of the class is required to provide control
 * Extends from default entity class
 *
 * A creature can move around the world, run into structures, pick entities up, drop entities
 * Way points are used to dictate where a creature can go
 *
 * TDL
 * Implement movement - movement commands will be as methods. Eg, MoveForward, TurnLeft, TurnRight
 */
 
 using UnityEngine;

public class Creature : Entity {
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float turnSpeed = 1.0f;
    [SerializeField] private int jumpSpeed = 5;

    [SerializeField] private int health = 100;
    private int currentHealth;
    [SerializeField] private int stamina = 100;
    private int currentStamina;

    private Entity inventory;
    private Vector3 moveDirection;
    private bool isMoving = true;
    private bool touchingGround = false;
    private bool isJumping = false;
    private bool turningRight = false;
    private bool turningLeft = false;

    private void Start() {
        base.Start();
        currentHealth = health;
        currentStamina = stamina;
    }




    // Interaction functions

    private void GiveInventory(StorageContainer storageContainer) {
        if (inventory != null) {
            bool success = storageContainer.GetComponent<InventoryManager>().IncomingEntity(inventory);
            if (success) {
                inventory = null;
            } else {
                Debug.Log("Target Container Full!");
            }
        } else {
            Debug.Log("Inventory empty!");
        }
    }

    private void TakeFromContainer(StorageContainer storageContainer) {
        if (inventory == null) {
            inventory = storageContainer.GetComponent<InventoryManager>().OutgoingEntity(0);
            Debug.Log("Taken object");
        } else {
            Debug.Log("Inventory full!");
        }
    }

    private void DropInventory() {
        if (inventory != null) {
            Instantiate(inventory);
            inventory = null;
            Debug.Log("Dropped object");
        } else {
            Debug.Log("Inventory empty!");
        }
    }

    private void TakeObject(Entity newInventoryItem) {
        if (inventory != null) {
            inventory = newInventoryItem;
            newInventoryItem.Taken();
            Debug.Log("Picked up object");
        } else {
            Debug.Log("Inventory full!");
        }
    }
}
