using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public static bool talkToFirstTime = true;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI continueText;
    [SerializeField] private int currentIndex;
    [SerializeField] private bool isTyping;
    [SerializeField] private string currentDialogue;
    [SerializeField] private Queue<string> sentences = new();

    [SerializeField] private GameObject Parchemindialogue;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Debug.LogWarning("C'est la panade!!!");
            Destroy(instance);
            return;
        }
        else
        {
            instance = this;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Parchemindialogue.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();
        talkToFirstTime = false;

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); //Fais rentrer dans une file d'attente chaque dialogue 
        }
        DisplayNextSentence(dialogue);
        talkToFirstTime = false;
    }

    /// <summary>
    /// Si le texte est en train de s'ecrire, il s'affiche en entier sinon il s'ecrit
    /// </summary>
    /// <param name="dialogue">Les strings qui sont en TextArea</param>
    public void DisplayNextSentence(Dialogue dialogue)
    {
        if(currentIndex >= sentences.Count)
        {
            EndDialogue();
            return;
        }
        currentDialogue = dialogue.sentences[currentIndex];

        if (currentDialogue != dialogueText.text)
        {
            if (isTyping)
            {
                StopAllCoroutines();
                isTyping = false;
                dialogueText.text = currentDialogue;
                currentIndex++;
                continueText.text = "C to skip";
            }
            else
            {
               
                StopAllCoroutines();
                StartCoroutine(TypeSentence(currentDialogue));
                continueText.text = "C to skip";
            }
        }
        if(currentIndex == sentences.Count)
        {
                continueText.text = "C to skip";
        }
    }
    // Affiche lettre par lettre les strings demandée
    private IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        isTyping = false;
        continueText.text = "C to skip";
        currentIndex++;
    }
    // Ferme la boite de dialogue
    public void EndDialogue()
    {
        currentIndex = 0;
        talkToFirstTime = true;
        Parchemindialogue.SetActive(false);
    }
}
