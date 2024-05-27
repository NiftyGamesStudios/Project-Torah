using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue[] dialogue;
    private RectTransform panel;
    private DialogueManager manager;

    private void Start()
    {
        this.Wait(0.2f,()=> TriggerDialogue(0));
        manager = FindObjectOfType<DialogueManager>();
        panel = manager.panel;
    }
    public void TriggerDialogue (int index)
	{
        manager.StartDialogue(dialogue[index]);
	}
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.F)|| Input.GetKeyDown(KeyCode.Return)) && panel.anchoredPosition.y == 0)
        {
            manager.DisplayNextSentence();
        }
    }
}
