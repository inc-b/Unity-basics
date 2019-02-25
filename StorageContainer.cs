/**
 * StorageContainer.cs
 * Joe Ford
 * Created 2019-02-22
 *
 * Object that can hold entities
 * Has a max capacity
 *
 * TO IMPLEMENT
 * A storage container must be attached to an entity and an entity with a storage container attached can't be put into a storage container
 * The contents of a storage container are based on the current time, the time it was last updated/viewed, and the action of the entity it is attached to
 * Eg, a hopper attached to a furnace - the hopper entity will send the inventory details, current time, and last update time to the furnace entity, calculate a result then both entities will update their attached storage containers
 */

using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class StorageContainer : MonoBehaviour {

    [SerializeField] private int maxCapacity = 3;
    private List<Entity> containerContents = new List<Entity>();

    public bool IncomingEntity(Entity newEntity) {
        if (containerContents.Count < maxCapacity) {
            containerContents.Add(newEntity);
            Debug.Log("Item added");
            return true;
        } else {
            Debug.Log("Container Full!");
            return false;
        }
    }

    public Entity OutgoingEntity(int entitySelected) {
        if (containerContents.Count != 0) {
            Entity returnEntity = containerContents[entitySelected];
            containerContents.Remove(returnEntity);
            Debug.Log("Item taken");
            return returnEntity;
        } else {
            Debug.Log("Container Empty");
            return null;
        }
    }
}
