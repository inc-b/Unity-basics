/**
 * Waypoint.cs
 * Joe Ford
 * Created 2019-03-05
 *
 * Waypoint manager for pathfinding
 */
 
 using UnityEngine;
 
 public class PathManager : MonoBehaviour {
  private Stack<Vector3> currentPath;
  private Vector3 currentWaypointPosition;
  
  private Waypoint findClosestWaypoint(Vector3 target) {
    GameObject closest = null;
    float closestDist = Mathf.Infinity;
    
    foreach (Waypoint waypoint in GameObject.FindGameObjectWithTag("Waypoint")) {
      int dist = (waypoint.transform.position - target).magnitude;
      if (dist < closestDist) {
        closest = waypoint;
        closestDist = dist;
      }
    }
    
    if (closest != null) {
      return closest.GetComponent<Waypoint>();
    }
    return null;
  }
 }
