using UnityEngine;

/// <summary>
/// Each segment represents a 60 degree section of a hexagon point top, starting from the right and moving clockwise in the expected degree order accounting for the rotation starting in the middle of the right segment when at 0 degrees.
/// </summary>
public enum  RotationSegment
{
    Right,
    TopRight,
    TopLeft,
    Left,
    BottomLeft,
    BottomRight,
}

public static class RotationSegments
{
    public const int SEGMENT_COUNT = 6; 

    public static RotationSegment GetSegmentFromDegrees(float angle)
    {
        const int COUNT = SEGMENT_COUNT * 2; // 12 segments of 30 degrees each to account for middle offset
        angle = Mathf.Abs(angle % 360);
        for (int i = 0; i < COUNT; i++)
        {
            float segmentStart = (i * 30.0f); 
            float segmentEnd = segmentStart + 30f;
            if (angle >= segmentStart && angle < segmentEnd)
            {
                return GetRotationSegmentFromDoubledIndex(i);
            }
        }

        throw new System.ArgumentException("Unable to find correct segment for angle provided.");
    }

    private static RotationSegment GetRotationSegmentFromDoubledIndex(int index)
    {
        switch (index)
        {
            case 0:
            case 11:
                return RotationSegment.Right;
            case 1: 
            case 2:
                return RotationSegment.TopRight;
            case 3:
            case 4:
                return RotationSegment.TopLeft;
            case 5:
            case 6:
                return RotationSegment.Left;
            case 7:
            case 8:
                return RotationSegment.BottomLeft;
            case 9:
            case 10:
                return RotationSegment.BottomRight;
            default:
                throw new System.ArgumentException("Index provided is out of range, expected an index in between 0 and 11.");
        }
    }

    public static float GetSegmentCenterAngle(RotationSegment segment)
    {
        return ((int)segment * 60f); // No offset needed since rotation starts in the middle of a segment.
    }

    public static (float MinAngle, float MaxAngle) GetSegmentAngleRange(RotationSegment segment)
    {
        float centerAngle = GetSegmentCenterAngle(segment);
        return (centerAngle - 30f, centerAngle + 30f);
    }
}
