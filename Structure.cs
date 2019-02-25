/**
 * Structure.cs
 * Joe Ford
 * Created 2019-02-26
 *
 * A thing that can be placed into the world. Unlike an entity a structure can't be picked up again, it must be destroyed.
 * Has a position and rotation in the world
 * Has a mesh and mesh collider
 */

using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Structure : MonoBehaviour {
  
}
