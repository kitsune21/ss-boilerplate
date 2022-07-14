using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestDialogue
{
    
    [MenuItem("Test/Dialogue/Test Dialogue")]
    public static void testDialogue() {
        DialogueManager dm = SystemsController.systemInstance.dm;
        Dialouge test = ScriptableObject.CreateInstance<Dialouge>();
        test.characterName = "Jimbo";
        DialogueSentence testSentence = ScriptableObject.CreateInstance<DialogueSentence>();
        testSentence.type = DialogueType.statement;
        testSentence.sentence = "This is a test";
        DialogueSentence testQuestion = ScriptableObject.CreateInstance<DialogueSentence>();
        testQuestion.type = DialogueType.question;
        testQuestion.sentence = "This is a test question?";
        string[] questions = new string[3]{"Yes", "No", "Maybe"};
        testQuestion.questions = questions;
        string[] responses = new string[3]{"Response to yes", "Response to no", "Response to maybe"};
        testQuestion.responses = responses;
        DialogueSentence[] sentences = new DialogueSentence[2]{testSentence, testQuestion};
        test.sentences = sentences;
        dm.loadDialogue(test);
    }
}
