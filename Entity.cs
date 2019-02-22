/**
 * Entity.cs
 * Joe Ford
 * Created 2019-02-22
 *
 * Basic object that can exist in the world
 * Has a tangible form and some attributes like weight, size, temperature, etc
 */

using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Entity : MonoBehaviour {
    Rigidbody rigidbody;
    BoxCollider collider;
    Mesh mesh;

    [SerializeField] private float weight = 1.0f;
    [SerializeField] public int size = 1;

}
