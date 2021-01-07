﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathDefinition : MonoBehaviour
{
    public Transform[] points;

    public IEnumerator<Transform> GetPathEnumerator()
    {
        if (points == null || points.Length < 1)
        {
            yield break;
        }

        var direction = 1;
        var index = 0;
        while (true)
        {
            yield return points[index];

            if (points.Length == 1)
            {
                continue;
            }

            if (index <= 0)
            {
                direction = 1;
            }
            else if (index >= points.Length - 1)
            {
                direction = -1;
            }

            index += direction;
        }
    }

    public void OnDrawGizmos()
    {
        if (points == null || points.Length < 2)
        {
            return;
        }

        var coors = points.Where(t => t != null).ToList();
        if (coors.Count < 2)
        {
            return;
        }

        for (var i = 1; i < coors.Count; i++)
        {
            Gizmos.DrawLine(coors[i - 1].position, coors[i].position);
        }
    }
}
