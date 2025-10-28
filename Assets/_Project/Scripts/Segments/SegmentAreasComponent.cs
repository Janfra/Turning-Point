using System;
using System.Collections.Generic;
using UnityEngine;

public class SegmentAreasComponent : MonoBehaviour
{
    [Serializable]
    private class SegmentAreaData
    {
        public RotationSegment RotationSegment;
        public Collider2D AreaCollider;
    }

    [SerializeField]
    private SegmentAreaData[] _segmentAreas;
    private Dictionary<RotationSegment, SegmentAreaData> _segmentAreaMap = new();

    private void Awake()
    {
        foreach (var segmentArea in _segmentAreas)
        {
            _segmentAreaMap[segmentArea.RotationSegment] = segmentArea;
        }
    }

    public Collider2D GetColliderForSegment(RotationSegment segment)
    {
        if (_segmentAreaMap.TryGetValue(segment, out var areaData))
        {
            return areaData.AreaCollider;
        }

        throw new ArgumentException($"No collider found for segment: {segment} in {name}");
    }   
}
