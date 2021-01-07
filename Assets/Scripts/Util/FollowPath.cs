using System.Collections.Generic;
using UnityEngine;
public class FollowPath : MonoBehaviour
{
    public enum FollowType
    {
        MoveTowards,
        Lerp
    }

    public FollowType type = FollowType.MoveTowards;
    public PathDefinition path;
    public float speed = 1f;
    public float maxDistanceToGoal = .1f;
    private IEnumerator<Transform> currentPoint;

    public void Start()
    {
        if (path == null)
        {
            Debug.LogError("path cannot be null", gameObject);
            return;
        }

        currentPoint = path.GetPathEnumerator();
        currentPoint.MoveNext();

        if (currentPoint.Current == null)
        {
            return;
        }

        transform.position = currentPoint.Current.position;
    }

    public void FixedUpdate()
    {
        if (currentPoint == null || currentPoint.Current == null)
        {
            return;
        }

        if (type == FollowType.MoveTowards)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPoint.Current.position, Time.deltaTime * speed);
        }
        else if (type == FollowType.Lerp)
        {
            transform.position = Vector3.Lerp(transform.position, currentPoint.Current.position, Time.deltaTime * speed);
        }

        var distanceSquared = (transform.position - currentPoint.Current.position).sqrMagnitude;
        if (distanceSquared < maxDistanceToGoal * maxDistanceToGoal)
        {
            currentPoint.MoveNext();
        }
    }

    public int MoveHorizontal()
    {
        if (transform.position.x < currentPoint.Current.position.x)
        {
            return 1;
        }
        else if (transform.position.x > currentPoint.Current.position.x)
        {
            return -1;
        } 
        else
        {
            return 0;
        }
    }

    public int MoveVertical()
    {
        if (transform.position.y < currentPoint.Current.position.y)
        {
            return 1;
        }
        else if (transform.position.y > currentPoint.Current.position.y)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
