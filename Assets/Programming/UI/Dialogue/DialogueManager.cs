using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMODUnity;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
	public TMP_Text leftNameText;
	public TMP_Text rightNameText;
	public TMP_Text dialogueTextLeft;
	public TMP_Text dialogueTextRight;
	public Image leftSpeakerImage;
	public Image rightSpeakerImage;
	public Image dialogueBox;
	public Image Background1;
	public Image Background2;
	public RectTransform dialogueBoxTransform;
	public Animator bars;

	public Animator animator;
	public Player_Controller playerController;

	[Header("Speakers Names")]

	public string[] leftSpeakers;
	public string[] rightSpeakers;

	[Header("Speaker Images")]

	public Sprite[] leftSpeakerSprites;
	public Sprite[] rightSpeakerSprites;

	[Header("Dialogue Boxes")]

	public Sprite[] leftDialogueBoxes;
	public Sprite[] rightDialogueBoxes;

    [Header("Dialogue Events")]
	public EventReference[] leftDialogueEvents;
    public EventReference[] rightDialogueEvents;


    [Header("Text Speed")]
	[Range(0.01f,0.05f)]public float speed = 0.02f;

	private Queue<string> sentences;
	Dialogue dialogue1 = null;

	int speakerNumber = 0;
	bool left = false;
	bool right = false;
	bool writing = false;
	string stored_sentence;
	Show_Controls showControls;
	EventReference sound;

	// Use this for initialization
	void Start()
	{
		sentences = new Queue<string>();
		leftSpeakerImage.enabled = false;
		rightSpeakerImage.enabled = false;
		showControls = FindFirstObjectByType<Show_Controls>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
        dialogueBoxTransform.localScale = new Vector3(Mathf.Abs(dialogueBoxTransform.localScale.x),
                    dialogueBoxTransform.localScale.y,
                    dialogueBoxTransform.localScale.z);
        writing = false;
		dialogue1 = dialogue;
		animator.SetBool("IsOpen", true);
		bars.SetBool("Stay", false);
		

		speakerNumber = 0;

		leftNameText.text = dialogue.name[0];
		rightSpeakerImage.enabled = false;
		leftSpeakerImage.enabled = false;
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
		if (sentences.Count == 0 && !writing)
		{
			EndDialogue();
			return;
		}
		if (!showControls.active)
		{
			if (!writing)
			{
				writing = true;
				if (dialogue1.sentences.Length - sentences.Count + 1 == dialogue1.SentenceNameChange[speakerNumber])
				{
					print("I am displaying next sentence");
					speakerNumber++;
					Check_Image();
					//leftNameText.text = dialogue1.name[speakerNumber];
				}
				string sentence = sentences.Dequeue();
				Store_Sentence_Text(sentence);
				StopAllCoroutines();
				if (left)
				{
					StartCoroutine(TypeSentenceLeft(sentence));
				}
				else if (right)
				{
					StartCoroutine(TypeSentenceRight(sentence));
				}
			}
			else if (writing)
			{
				writing = false;
				StopAllCoroutines();
				if (left)
				{
					dialogueTextLeft.text = stored_sentence;
				}
				else if (right)
				{
					dialogueTextRight.text = stored_sentence;
				}
			}
		}
	}

	IEnumerator TypeSentenceLeft(string sentence)
	{
		dialogueTextLeft.text = "";
		dialogueTextRight.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			if (letter == '%')
			{
				string left_stick = "<size=18> <sprite=5> </size>";
                dialogueTextLeft.text += left_stick;
            }
			else if(letter == '[')
			{
                string left_stick = "<size=18> <sprite=2> </size>";
                dialogueTextLeft.text += left_stick;
            }
            else if (letter == ']')
            {
                string left_stick = "<size=18> <sprite=0> </size>";
                dialogueTextLeft.text += left_stick;
            }
            else if (letter == '{')
            {
                string left_stick = "<size=18> <sprite=3> </size>";
                dialogueTextLeft.text += left_stick;
            }
            else if (letter == '}')
            {
                string left_stick = "<size=18> <sprite=4> </size>";
                dialogueTextLeft.text += left_stick;
            }
			else if (letter == '@')
			{
                string left_stick = "<size=18> <sprite=1> </size>";
                dialogueTextLeft.text += left_stick;
            }
			else
			{
				dialogueTextLeft.text += letter;
			}	
            AudioManager.instance.PlaySoundOneShot(sound, gameObject);
            if (dialogueTextLeft.text == stored_sentence)
			{
				writing = false;
			}
			yield return new WaitForSeconds(speed);
		}
	}

	IEnumerator TypeSentenceRight(string sentence)
	{
		dialogueTextLeft.text = "";
		dialogueTextRight.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
            if (letter == '%')
            {
                string left_stick = "<size=18> <sprite=5> </size>";
                dialogueTextRight.text += left_stick;
            }
            else if (letter == '[')
            {
                string left_stick = "<size=18> <sprite=2> </size>";
                dialogueTextRight.text += left_stick;
            }
            else if (letter == ']')
            {
                string left_stick = "<size=18> <sprite=0> </size>";
                dialogueTextRight.text += left_stick;
            }
            else if (letter == '{')
            {
                string left_stick = "<size=18> <sprite=3> </size>";
                dialogueTextRight.text += left_stick;
            }
            else if (letter == '}')
            {
                string left_stick = "<size=18> <sprite=4> </size>";
                dialogueTextRight.text += left_stick;
            }
            else if (letter == '@')
            {
                string left_stick = "<size=18> <sprite=1> </size>";
                dialogueTextRight.text += left_stick;
            }
            else
            {
                dialogueTextRight.text += letter;
            }
            AudioManager.instance.PlaySoundOneShot(sound, gameObject);
            if (dialogueTextRight.text == stored_sentence)
			{
				writing = false;
			}
			yield return new WaitForSeconds(speed);
		}
	}

	public void Store_Sentence_Text(string sentence)
	{
		stored_sentence = "";
        foreach (char letter in sentence.ToCharArray())
        {
            if (letter == '%')
            {
                string left_stick = "<size=18> <sprite=5> </size>";
                stored_sentence += left_stick;
            }
            else if (letter == '[')
            {
                string left_stick = "<size=18> <sprite=2> </size>";
                stored_sentence += left_stick;
            }
            else if (letter == ']')
            {
                string left_stick = "<size=18> <sprite=0> </size>";
                stored_sentence += left_stick;
            }
            else if (letter == '{')
            {
                string left_stick = "<size=18> <sprite=3> </size>";
                stored_sentence += left_stick;
            }
            else if (letter == '}')
            {
                string left_stick = "<size=18> <sprite=4> </size>";
                stored_sentence += left_stick;
            }
            else if (letter == '@')
            {
                string left_stick = "<size=18> <sprite=1> </size>";
                stored_sentence += left_stick;
            }
            else
            {
                stored_sentence += letter;
            }
        }
    }

	void EndDialogue()
	{
		if(dialogue1 != null)
        {
			playerController.Change_Dialogue_False();
		}
		animator.SetBool("IsOpen", false);
		if (dialogue1.events && dialogue1 != null)
		{
			dialogue1.dialogue_Events.finish_dialogue.Invoke();
			dialogue1 = null;
		}
		bars.SetBool("Stay", true);
	}

	void Check_Image()
    {
		bool left_grey = true;
		bool right_grey = true;
		for(int i = 0; i < leftSpeakers.Length; i++)
        {
			if (leftSpeakers[i].ToLower() == dialogue1.name[speakerNumber].ToLower())
            {
				leftSpeakerImage.sprite = leftSpeakerSprites[i];
				dialogueBox.sprite = leftDialogueBoxes[i];
				sound = leftDialogueEvents[i];
				dialogueBoxTransform.localScale = new Vector3(Mathf.Abs(dialogueBoxTransform.localScale.x),
					dialogueBoxTransform.localScale.y,
					dialogueBoxTransform.localScale.z);
				left_grey = false;
			}
        }

		if (left_grey)
        {
			leftSpeakerImage.color = Color.grey;
			leftNameText.text = " ";
			left = false;
        }

		else if (!left_grey)
        {
			leftSpeakerImage.color= Color.white;
			leftSpeakerImage.enabled = true;
			leftNameText.text = dialogue1.name[speakerNumber];
			print(leftNameText.text);
			left = true;
		}

		for (int i = 0; i < rightSpeakers.Length; i++)
		{
			if (rightSpeakers[i].ToLower() == dialogue1.name[speakerNumber].ToLower())
			{
				rightSpeakerImage.sprite = rightSpeakerSprites[i];
				dialogueBox.sprite = rightDialogueBoxes[i];
				sound = rightDialogueEvents[i];
				print(sound);
				dialogueBoxTransform.localScale = new Vector3(dialogueBoxTransform.localScale.x * -1, 
					dialogueBoxTransform.localScale.y, 
					dialogueBoxTransform.localScale.z);
				right_grey = false;
			}
		}

		if (right_grey)
		{
			rightSpeakerImage.color = Color.grey;
			rightNameText.text = " ";
			right = false;
		}

		else if (!right_grey)
		{
			rightSpeakerImage.color = Color.white;
			rightSpeakerImage.enabled = true;
			rightNameText.text = dialogue1.name[speakerNumber];
            if (rightNameText.text.Contains("_Right"))
            {
				rightNameText.text = rightNameText.text.Replace("_Right", "");

			}
			right = true;
		}
	}

	public void Text_Speed(float number)
    {
		speed = Mathf.Abs(number);
    }
}
