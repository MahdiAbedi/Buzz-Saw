using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {

    public enum FollowType
    {
        MoveTowards,
        lerp
    }

    public FollowType Type = FollowType.MoveTowards;
    public PathDefinition Path;
    public float Speed = 1f;
    public float MaxDistanceToGoal = 0.1f;

    private IEnumerator<Transform> _currentPoint;

	// Use this for initialization
	void Start () {
        if (Path==null)
        {
            Debug.LogError("path cannot be null",gameObject);
            return;
        }

        _currentPoint = Path.GetPathEnumarator();
        _currentPoint.MoveNext();

        if (_currentPoint.Current == null) return;

        transform.position = _currentPoint.Current.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (_currentPoint == null || _currentPoint.Current == null) return;

        if (Type==FollowType.MoveTowards)
        {
            transform.position = Vector3.MoveTowards(transform.position,_currentPoint.Current.position,Time.deltaTime*Speed);
        }
        else if (Type==FollowType.lerp)
        {
            transform.position = Vector3.Lerp(transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);
        }

        var distanceSquared = (transform.position-_currentPoint.Current.position).sqrMagnitude;
        if (distanceSquared<MaxDistanceToGoal*MaxDistanceToGoal)
        {
            _currentPoint.MoveNext();
        }
	}
}
