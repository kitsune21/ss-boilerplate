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
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject responseBox;
    [SerializeField] private GameObject responseButton;
    [SerializeField] private TMP_Text characterNameText;
    [SerializeField] private TMP_Text dialougeText;
    [SerializeField] private GameObject continueText;
    private Animator anim;
    [SerializeField] private float typingSpeed;
    private TopDownPlayerController controller;
    private DialogueSentence currentSentence;
    private List<GameObject> responseButtons;
    private int hoveredDialogueIndex = 0;

    void Awake()
    {
        sentences = new Queue<DialogueSentence>();
        anim = dialogueBox.GetComponent<Animator>();
        controller = new TopDownPlayerController();
        sc = SystemsController.Instance;
        responseButtons = new List<GameObject>();
    }

    void OnEnable() {
      controller.Menu.NextDialogue.performed += displayNextSentenceOnAction;
      controller.Menu.NextDialogue.Enable();
      controller.Menu.SelectDialogue1.performed += selectResponse1;
      controller.Menu.SelectDialogue1.Enable();
      controller.Menu.SelectDialogue2.performed += selectResponse2;
      controller.Menu.SelectDialogue2.Enable();
      controller.Menu.SelectDialogue3.performed += selectResponse3;
      controller.Menu.SelectDialogue3.Enable();
      controller.Menu.MoveDialogueRight.performed += handleMoveDialogueRight;
      controller.Menu.MoveDialogueRight.Enable();
      controller.Menu.MoveDialogueLeft.performed += handleMoveDialogueLeft;
      controller.Menu.MoveDialogueLeft.Enable();
    }

    void OnDisable() {
        controller.Menu.OpenCloseMenu.Disable();
        controller.Menu.SelectDialogue1.Disable();
        controller.Menu.SelectDialogue2.Disable();
        controller.Menu.SelectDialogue3.Disable();
        controller.Menu.MoveDialogueRight.Disable();
        controller.Menu.MoveDialogueLeft.Disable();
    }

    private void displayNextSentenceOnAction(InputAction.CallbackContext obj) {{
        if(currentSentence.Type == DialogueType.statement) {
            DisplayNextSentence();
        } else {
            if(responseButtons.Count > 0) {
                responseButtonClicked(hoveredDialogueIndex);
            } else {
                DisplayNextSentence();
            }
        }
    }}

    private void selectResponse1(InputAction.CallbackContext obj) {{
        if(currentSentence.Type == DialogueType.question) {
            responseButtonClicked(0);
        }
    }}

    private void selectResponse2(InputAction.CallbackContext obj) {{
        if(currentSentence.Type == DialogueType.question) {
            responseButtonClicked(1);
        }
    }}

    private void selectResponse3(InputAction.CallbackContext obj) {{
        if(currentSentence.Type == DialogueType.question) {
            responseButtonClicked(2);
        }
    }}

    private void handleMoveDialogueRight(InputAction.CallbackContext obj) {{
        if(sc.State.CurrentState == GameStates.InDialogue) {
            if(hoveredDialogueIndex < responseButtons.Count - 1) {
                hoveredDialogueIndex += 1;
            } else {
                hoveredDialogueIndex = 0;
            }
            highlightButtons();
        }
    }}

    private void handleMoveDialogueLeft(InputAction.CallbackContext obj) {{
        if(sc.State.CurrentState == GameStates.InDialogue) {
            if(hoveredDialogueIndex > 0) {
                hoveredDialogueIndex -= 1;
            } else {
                hoveredDialogueIndex = responseButtons.Count - 1;
            }
            highlightButtons();
        }
    }}

    public void LoadDialogue(Dialouge dialouge) {
        sc.State.UpdateGameState(GameStates.InDialogue);
        anim.SetBool("isShow", true);
        sentences.Clear();
        foreach(DialogueSentence sentence in dialouge.Sentences) {
            sentences.Enqueue(sentence);
        }

        characterNameText.text = dialouge.CharacterName;

        DisplayNextSentence();
    }

    private void DisplayNextSentence() {
        if(sentences.Count == 0) {
            endDialogue();
            return;
        }

        currentSentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(writeSentence(currentSentence.Sentence));
        if(currentSentence.Type == DialogueType.question) {
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
        sc.State.UpdateGameState(GameStates.InGame);
    }

    private IEnumerator writeSentence(string sentence) {
        dialougeText.text = "";

        foreach(char letter in sentence.ToCharArray()) {
            dialougeText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }

    private void showResponses(DialogueSentence currentSentence) {
        hoveredDialogueIndex = 0;
        continueText.SetActive(false);
        responseBox.SetActive(true);
        for(int i = 0; i < currentSentence.Questions.Length; i++) {
            GameObject responseButt = Instantiate(responseButton, transform.position, transform.rotation, responseBox.transform);
            responseButt.GetComponent<DialogueResponseButton>().setResponseText(currentSentence.Questions[i], i);
            if(i == 0) {
                responseButt.GetComponent<DialogueResponseButton>().HighLightText();
            }
            responseButt.GetComponent<Button>().onClick.AddListener(delegate {responseButtonClicked(responseButt.GetComponent<DialogueResponseButton>().getIndex()); });
            responseButtons.Add(responseButt);
        }
    }

    public void responseButtonClicked(int index) {
        continueText.SetActive(true);
        responseBox.SetActive(false);
        clearButtons();
        StopAllCoroutines();
        StartCoroutine(writeSentence(currentSentence.Responses[index]));
    }

    private void clearButtons() {
        foreach(GameObject button in responseButtons) {
            Destroy(button);
        }
        responseButtons.Clear();
    }

    private void highlightButtons() {
        foreach(GameObject button in responseButtons) {
            button.GetComponent<DialogueResponseButton>().UnHighLightText();
        }
        responseButtons[hoveredDialogueIndex].GetComponent<DialogueResponseButton>().HighLightText();
    }
}
