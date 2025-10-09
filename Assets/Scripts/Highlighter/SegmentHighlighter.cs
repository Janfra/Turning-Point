using Extensions;
using System;
using Unity.Collections;
using UnityEngine;

public class SegmentHighlighter : MonoBehaviour
{
    [SerializeField]
    private RotationSegmentProviderComponent _segmentProvider;

    [SerializeField]
    private Color _defaultColor;
    [SerializeField]
    private Color _highlightColor;

    [SerializeField]
    private SpriteRenderer _topRightSprite;
    [SerializeField]
    private SpriteRenderer _rightSprite;
    [SerializeField]
    private SpriteRenderer _bottomRightSprite;
    [SerializeField]
    private SpriteRenderer _topLeftSprite;
    [SerializeField]
    private SpriteRenderer _leftSprite;
    [SerializeField]
    private SpriteRenderer _bottomLeftSprite;

    private RotationSegment _currentHighlight;

    private void Awake()
    {
        this.AssertReference(_segmentProvider);
        this.AssertReference(_topRightSprite);
        this.AssertReference(_rightSprite);
        this.AssertReference(_bottomRightSprite);
        this.AssertReference(_topLeftSprite);
        this.AssertReference(_leftSprite);
        this.AssertReference(_bottomLeftSprite);
    }

    private void Start()
    {
        _segmentProvider.OnSegmentChanged += UpdateHighlight;
        _currentHighlight = _segmentProvider.CurrentSegment;
    }

    private void UpdateHighlight(RotationSegment segment)
    {
        SpriteRenderer oldSegment = GetRendererForSegment(_currentHighlight);
        oldSegment.color = _defaultColor;
        _currentHighlight = segment;
        GetRendererForSegment(_currentHighlight).color = _highlightColor;
    }

    private SpriteRenderer GetRendererForSegment(RotationSegment segment)
    {
        switch (segment)
        {
            case RotationSegment.TopRight:
                return _topRightSprite;
            case RotationSegment.Right:
                return _rightSprite;
            case RotationSegment.BottomRight:
                return _bottomRightSprite;
            case RotationSegment.BottomLeft:
                return _bottomLeftSprite;
            case RotationSegment.Left:
                return _leftSprite;
            case RotationSegment.TopLeft:
                return _topLeftSprite;
            default:
                throw new ArgumentException($"Provided argument: {segment} is not supported by {GetType()} in {name}");
        }
    }
}
