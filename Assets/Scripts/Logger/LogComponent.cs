using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class LogComponent : MonoBehaviour
{
#if UNITY_EDITOR
    private enum LogLevel
    {
        None,
        Error,
        Warning,
        Info
    }

    [SerializeField, Tooltip("Determines which logs will be shown. Any level with higher concern will continue to show when selecting a lower level, e.g. warning shows both warning and error but not info since info is less concern but error is higher concern.")]
    private LogLevel _logLevel = LogLevel.Error;
    [SerializeField]
    private string _logPrefix;
    [SerializeField]
    private Color _prefixColor = Color.white;

    private string _cachedPrefix;

    private void Awake()
    {
        string colorHex = ColorUtility.ToHtmlStringRGB(_prefixColor);
        _cachedPrefix = $"<color=#{colorHex}>[{_logPrefix}]</color>";
    }
#endif

    [Conditional("UNITY_EDITOR")]
    public void Log(string message, Object context = null)
    {
        if (_logLevel >= LogLevel.Info)
        {
            Debug.Log(GetOutputMessage(message), context);
        }
    }

    [Conditional("UNITY_EDITOR")]
    public void LogWarning(string message, Object context = null) 
    {
        if (_logLevel >= LogLevel.Warning)
        {
            Debug.LogWarning(GetOutputMessage(message), context);
        }
    }

    [Conditional("UNITY_EDITOR")]
    public void LogError(string message, Object context = null) 
    {
        if (_logLevel >= LogLevel.Error)
        {
            Debug.LogError(GetOutputMessage(message), context);
        }
    }

    private string GetOutputMessage(string message)
    {
#if UNITY_EDITOR
        return $"{_cachedPrefix} {message}";
#endif
    }
}
