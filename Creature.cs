/**
 * Creature.cs
 * Joe Ford
 * Created 2019-02-22
 *
 * Living creatures that move around the world
 * Has attributes like movement speed, turning speed, health, stamina, etc
 * This class has no brain - an extension of the class is required to provide control
 * Extends from default entity class
 */
 
 using UnityEngine;

public class Creature : Entity {
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float turnSpeed = 1.0f;
    [SerializeField] private int health = 100;
    private int currentHealth;
    [SerializeField] private int stamina = 100;
    private int currentStamina;
    private Entity inventory;

    private void Start() {
        currentHealth = health;
        currentStamina = stamina;
    }
    private void FixedUpdate() {
        
    }

    private void GiveInventory(StorageContainer storageContainer) {
        if (inventory != null) {
            bool success = storageContainer.IncomingEntity(inventory);
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
            inventory = storageContainer.OutgoingEntity(0);
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
