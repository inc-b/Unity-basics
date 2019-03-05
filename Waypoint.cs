/**
 * Waypoint.cs
 * Joe Ford
 * Created 2019-03-05
 *
 * Generic waypoint for pathfinding
 */
 
using UnityEngine;

public class Waypoint : Monobehaviour {
  
  public List<Waypoint> neighbours;
  
  public Waypoint previous {
    get;
    set;
  }
  
  public float distance {
    get;
    set;
  }
  
  public void OnDrawGizmos() {
    if (neighbours == null) return;
    Gizmos.colour = new Color(1f, 0f, 1f);
    foreach (Waypoint neighbour in neighbours) {
      if (neighbour != null) {
        Gizmos.DrawLine (transform.position, neighbour.transform.position);
      }
    }
  }
}
