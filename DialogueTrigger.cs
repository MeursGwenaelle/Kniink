using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField] private bool isNear;
    [SerializeField] private GameObject iconDialog;
    
    

 
    private void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.C))
        {
            TriggerDialogue();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            iconDialog.SetActive(DialogueManager.talkToFirstTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isNear = true;
            StartCoroutine(DisplayIcon(isNear));
            iconDialog.SetActive(true);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isNear = false;
            StartCoroutine(DisplayIcon(isNear));
            DialogueManager.instance.EndDialogue();
            
        }
    }

    private IEnumerator DisplayIcon(bool isActive)
    {
        yield return new WaitForSeconds(1.5f);
        iconDialog.SetActive(isActive);
    }

    private void TriggerDialogue()
    { 
        if (DialogueManager.talkToFirstTime)
        {
            DialogueManager.instance.StartDialogue(dialogue);
        }else
        {
            DialogueManager.instance.DisplayNextSentence(dialogue);
        }
    }
}
