/**
 * StorageContainer.cs
 * Joe Ford
 * Created 2019-02-22
 *
 * Entity that can hold other entities
 * Has a max capacity
 */

using System.Collections.Generic;
using UnityEngine;

public class StorageContainer : MonoBehaviour {

    [SerializeField] private int maxCapacity = 3;
    private int currentCapacity = 3;
    private List<Entity> containerContents = new List<Entity>();

    public bool IncomingEntity(Entity newEntity) {
        if (currentCapacity > 0) {
            containerContents.Add(newEntity);
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
            return returnEntity;
        } else {
            Debug.Log("Container Empty");
            return null;
        }
    }
}
