using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePathController : MonoBehaviour
{
    [System.Serializable]
    public class ZombieGroup
    {
        public GameObject[] zombies;
        public Transform[] waypoints;
    }

    public ZombieGroup[] zombieGroups;

    void Start()
    {
        foreach (ZombieGroup group in zombieGroups)
        {
            AssignWaypointsToZombies(group.zombies, group.waypoints);
        }
    }

    void AssignWaypointsToZombies(GameObject[] zombies, Transform[] waypoints)
    {
        foreach (GameObject zombie in zombies)
        {
            Zambi_handler pathFollower = zombie.GetComponent<Zambi_handler>();
            if (pathFollower != null)
            {
                pathFollower.waypoints = waypoints;
            }
            pathFollower.Move = true;
            pathFollower.SetNextTarget();

        }
    }
}
