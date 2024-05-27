using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DialogueManager : MonoBehaviour {

	public TMP_Text dialogueText;

	public RectTransform panel;

	private Queue<string> sentences;
	private Dialogue dialogue;

    // Use this for initialization
    void Awake () 
	{
		sentences = new Queue<string>();		
	}

	public void StartDialogue (Dialogue dialogue)
	{
        panel.DOAnchorPosY(0, 0.2f).SetEase(Ease.InBounce);
		this.dialogue = dialogue;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

        DisplayNextSentence();
	}


    public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
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
        panel.DOAnchorPosY(450, 0.2f).SetEase(Ease.OutBounce);


       
        if (dialogue != null && dialogue.onDialogueEvent != null)
        {
            dialogue.onDialogueEvent.Invoke();
        }
    }
}
