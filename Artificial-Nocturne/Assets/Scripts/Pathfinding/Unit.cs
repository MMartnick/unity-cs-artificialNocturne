using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public Transform target;
    public bool chase;

    public float speed;
    int targetIndex;

    public Vector3 targetCurrent;
    Vector3[] path;

    // private Vector3 targetVar = new Vector3(6.1635f, 5.1728‬, 0); 
    // ^ This Vector 3 was to account for the fact that there was an offset in the path coordinates by this much
    // The fix for that problem was actually a scaling issue, increasing the project size and resolution fixed this. 


    void Start()
    {
        target = GetComponentInParent<CharacterData>().Target;
        speed = GetComponent<CharacterData>().Dexterity;
    }

    void Update()
    {
        chase = GetComponent<GoblinController>().setChase;
        target = GetComponentInParent<CharacterData>().Target;
        speed = GetComponent<CharacterData>().Dexterity;

        if (chase == true)
        {
            if (targetCurrent != target.position)
            {
                StopCoroutine("FollowPath");
                StopCoroutine("FindPath");
                GetTarget();
                PathRequestManager.RequestPath(this.transform.position, targetCurrent, OnPathFound);
            }
        }

        if (chase == false)
        {
            StopCoroutine("FollowPath");
            StopCoroutine("FindPath");  
        }
    }

    void GetTarget()
    {
        targetCurrent =  target.position;
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = newPath;
            targetIndex = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];
        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }

            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;

        }
    }

    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
}