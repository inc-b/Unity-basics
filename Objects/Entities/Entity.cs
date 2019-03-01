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
    new protected Rigidbody rb;
    new protected BoxCollider boxCollider;
    protected Mesh mesh;

    [SerializeField] private float weight = 1.0f;
    [SerializeField] public int size = 1;

    protected void Start() {
        rb = this.GetComponent<Rigidbody>();
        boxCollider = this.GetComponent<BoxCollider>();
        mesh = this.GetComponent<Mesh>();
    }

    public void Taken() {
        //
    }
}
