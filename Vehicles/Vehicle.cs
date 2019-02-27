/**
 * Vehicle.cs
 * Joe Ford
 * Created 2019-02-27
 *
 * A physical thing in the world that moves about.
 * Must be placed and built like a structure, can have controls like a player, can have inventory like a storage container
 * Attributes: speed, health, turn speed, degrees of motion
 * Has a mesh and mesh collider
 */

using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Vehicle : MonoBehaviour {
  
}
