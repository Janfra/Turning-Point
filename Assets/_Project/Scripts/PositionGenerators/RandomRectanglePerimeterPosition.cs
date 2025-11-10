using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct RandomRectanglePerimeterPosition
{
    [SerializeField]
    public Vector2 Size;
    
    public Vector2 GetRandomPosition()
    {
        const float MAX_RANGE = (2 * Mathf.PI);
        float angle = Random.Range(0.0f, MAX_RANGE);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
		
        float absSinAngle = Mathf.Abs(Mathf.Sin(angle));
        float absCosAngle = Mathf.Abs(Mathf.Cos(angle));
		
	// Vertical side else horizontal
        if (Size.x * absSinAngle < Size.y * absCosAngle)
        {
            direction *= (Size.x * 0.5f) / absCosAngle;
        }
        else
        {
            direction *= (Size.y * 0.5f) / absSinAngle;
        }

        return direction;
    }
}
