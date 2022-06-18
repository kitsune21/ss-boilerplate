using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditPanel : MonoBehaviour
{
    public GameObject titleText;
    public GameObject personText;
    public List<CreditEntry> people;
    private CreditCategory currentCategory = CreditCategory.None;

    void Start()
    {
        people.Sort(delegate(CreditEntry x, CreditEntry y) {
            return x.category.CompareTo(y.category);
        });
        foreach(CreditEntry person in people)
        {
            if(person.category != currentCategory)
            {
                currentCategory = person.category;
                GameObject title = Instantiate(titleText, transform);
                title.GetComponent<Text>().text = person.category.ToString();
            }
            GameObject peon = Instantiate(personText, transform);
            peon.GetComponent<Text>().text = person.personNameFull;
        }
    }
}
