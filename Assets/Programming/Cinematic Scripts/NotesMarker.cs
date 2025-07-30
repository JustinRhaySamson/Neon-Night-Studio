using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

public class NotesMarker : Marker
{
    public string title = "empty";
    public Color color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    public bool showLineOverlay = false;
    [TextArea(10, 15)] public string note;
}
