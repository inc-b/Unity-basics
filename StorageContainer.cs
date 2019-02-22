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
