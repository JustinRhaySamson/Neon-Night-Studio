using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	public TMP_Text nameText;
	public TMP_Text dialogueText;
	public Image speakerImage;

	public Animator animator;
	public Player_Controller playerController;

	[Header("Speakers Names")]

	public string[] speakers;

	[Header("Speaker Images")]

	public Sprite[] speakerSprites;

	private Queue<string> sentences;
	Dialogue dialogue1 = null;

	int speakerNumber = 0;

	// Use this for initialization
	void Start()
	{
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		dialogue1 = dialogue;
		animator.SetBool("IsOpen", true);

		speakerNumber = 0;

		nameText.text = dialogue.name[0];
		Check_Image();

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		if (dialogue1.sentences.Length - sentences.Count + 1 == dialogue1.SentenceNameChange[speakerNumber])
		{
			print("I am displaying next sentence");
			speakerNumber++;
			Check_Image();
			nameText.text = dialogue1.name[speakerNumber];
		}
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		playerController.Change_Dialogue_False();
		animator.SetBool("IsOpen", false);
	}

	void Check_Image()
    {
		for(int i = 0; i < speakers.Length; i++)
        {
			if (speakers[i].ToLower() == dialogue1.name[speakerNumber].ToLower())
            {
				speakerImage.sprite = speakerSprites[i];
			}
        }
    }

}
