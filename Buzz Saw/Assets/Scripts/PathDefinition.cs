using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDefinition : MonoBehaviour {

    public Transform[] Points;



    void OnDrawGizmos()
    {
        if (Points==null || Points.Length<2)
        {
            return;
        }

        for (int i = 1; i < Points.Length; i++)
        {
            Gizmos.DrawLine(Points[i - 1].position, Points[i].position);
        }
    }
}
