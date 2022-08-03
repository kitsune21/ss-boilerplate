using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestDialogue
{
    
    [MenuItem("Test/Dialogue/Test Dialogue")]
    public static void testDialogue() {
        DialogueManager dm = SystemsController.Instance.Dialogue;
        Dialouge test = ScriptableObject.CreateInstance<Dialouge>();
        test.CharacterName = "Jimbo";
        DialogueSentence testSentence = ScriptableObject.CreateInstance<DialogueSentence>();
        testSentence.Type = DialogueType.statement;
        testSentence.Sentence = "This is a test";
        DialogueSentence testQuestion = ScriptableObject.CreateInstance<DialogueSentence>();
        testQuestion.Type = DialogueType.question;
        testQuestion.Sentence = "This is a test question?";
        string[] questions = new string[3]{"Yes", "No", "Maybe"};
        testQuestion.Questions = questions;
        string[] responses = new string[3]{"Response to yes", "Response to no", "Response to maybe"};
        testQuestion.Responses = responses;
        DialogueSentence[] sentences = new DialogueSentence[2]{testSentence, testQuestion};
        test.Sentences = sentences;
        dm.LoadDialogue(test);
    }
}
