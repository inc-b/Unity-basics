/**
* Waypoint.cs
* Joe Ford
* Created 2019-03-05
*
* Waypoint manager for pathfinding
* Given a starting waypoint and a target destination this script will return a list of waypoints to the requester
*/
 
using UnityEngine;
 
public class PathManager : MonoBehaviour {
	private Stack<Vector3> currentPath;
	private Vector3 currentWaypointPosition;

	public List<Waypoint> newPath(Waypoint startPosition, Waypoint destination) {
		// Add current waypoint to closed list
		// Add neighbouring waypoints to open list
		// Calculate the F, G, & H values for the new nodes (G is distance between current node and start node, H is manhattan distance from current node to end node, F = G + H)
		// Make the node with the lowest F the current waypoint and loop
		// Output the closed list as the path
	}
	
	
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
