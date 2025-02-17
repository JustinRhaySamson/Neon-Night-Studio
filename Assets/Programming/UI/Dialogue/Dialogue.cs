using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{

	public string[] name;
	public int[] SentenceNameChange;

	[TextArea(3, 10)]
	public string[] sentences;

	public bool events;

	public Dialogue_Events dialogue_Events;

}
