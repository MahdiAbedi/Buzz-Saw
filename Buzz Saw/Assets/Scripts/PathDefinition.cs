using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDefinition : MonoBehaviour {

    public Transform[] Points;
    //در واقع تو این تابع ما داریم تو هر مرحله نقطه حرکت بعدی رو مشخص میکنیم
    public IEnumerator<Transform> GetPathEnumarator()
    {
        if (Points==null|| Points.Length<=1)
        {
            yield break;
        }

        var direction = 1;
        var index = 0;

        while (true)
        {
            yield return Points[index];
            if (Points.Length == 1) continue;

            if (index <= 0) direction = 1;

            if (index >= Points.Length - 1) direction = -1;

            index = index + direction;
        }
    }

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
