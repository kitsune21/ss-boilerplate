using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    private SystemsController sc;
    private Queue<DialogueSentence> sentences;
    public GameObject dialogueBox;
    public GameObject responseBox;
    public GameObject responseButton;
    public TMP_Text characterNameText;
    public TMP_Text dialougeText;
    public GameObject continueText;
    private Animator anim;
    public float typingSpeed;
    private TopDownPlayerController controller;
    private DialogueSentence currentSentence;
    private List<GameObject> responseButtons;

    void Awake()
    {
        sentences = new Queue<DialogueSentence>();
        anim = dialogueBox.GetComponent<Animator>();
        controller = new TopDownPlayerController();
        sc = SystemsController.systemInstance;
        responseButtons = new List<GameObject>();
    }

    private void OnEnable() {
      controller.Menu.NextDialogue.performed += displayNextSentenceOnAction;
      controller.Menu.NextDialogue.Enable();
      controller.Menu.SelectDialogue1.performed += selectResponse1;
      controller.Menu.SelectDialogue1.Enable();
      controller.Menu.SelectDialogue2.performed += selectResponse2;
      controller.Menu.SelectDialogue2.Enable();
      controller.Menu.SelectDialogue3.performed += selectResponse3;
      controller.Menu.SelectDialogue3.Enable();
    }

    private void displayNextSentenceOnAction(InputAction.CallbackContext obj) {{
        displayNextSentence();
    }}

    private void selectResponse1(InputAction.CallbackContext obj) {{
        if(currentSentence.type == DialogueType.question) {
            responseButtonClicked(0);
        }
    }}

    private void selectResponse2(InputAction.CallbackContext obj) {{
        if(currentSentence.type == DialogueType.question) {
            responseButtonClicked(1);
        }
    }}

    private void selectResponse3(InputAction.CallbackContext obj) {{
        if(currentSentence.type == DialogueType.question) {
            responseButtonClicked(2);
        }
    }}

    private void OnDisable() {
        controller.Menu.OpenCloseMenu.Disable();
        controller.Menu.SelectDialogue1.Disable();
        controller.Menu.SelectDialogue2.Disable();
        controller.Menu.SelectDialogue3.Disable();
    }

    public void loadDialogue(Dialouge dialouge) {
        sc.gsm.setStateGamePaused();
        anim.SetBool("isShow", true);
        sentences.Clear();
        foreach(DialogueSentence sentence in dialouge.sentences) {
            sentences.Enqueue(sentence);
        }

        characterNameText.text = dialouge.characterName;

        displayNextSentence();
    }

    public void displayNextSentence() {
        if(sentences.Count == 0) {
            endDialogue();
            return;
        }

        currentSentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(writeSentence(currentSentence.sentence));
        if(currentSentence.type == DialogueType.question) {
            showResponses(currentSentence);
        } else {
            if(!continueText.activeSelf) {
                continueText.SetActive(true);
                responseBox.SetActive(false);
            }
        }
    }

    private void endDialogue() {
        anim.SetBool("isShow", false);
        sc.gsm.setStateInGame();
    }

    private IEnumerator writeSentence(string sentence) {
        dialougeText.text = "";

        foreach(char letter in sentence.ToCharArray()) {
            dialougeText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }

    private void showResponses(DialogueSentence currentSentence) {
        continueText.SetActive(false);
        responseBox.SetActive(true);
        for(int i = 0; i < currentSentence.questions.Length; i++) {
            GameObject responseButt = Instantiate(responseButton, transform.position, transform.rotation, responseBox.transform);
            responseButt.GetComponent<DialogueResponseButton>().setResponseText(currentSentence.questions[i], i);
            responseButt.GetComponent<Button>().onClick.AddListener(delegate {responseButtonClicked(responseButt.GetComponent<DialogueResponseButton>().getIndex()); });
            responseButtons.Add(responseButt);
        }
    }

    public void responseButtonClicked(int index) {
        continueText.SetActive(true);
        responseBox.SetActive(false);
        clearButtons();
        StopAllCoroutines();
        StartCoroutine(writeSentence(currentSentence.responses[index]));
    }

    private void clearButtons() {
        foreach(GameObject button in responseButtons) {
            Destroy(button);
        }
    }
}
