using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    private bool isTyping = false;
    private float changetime = 6;
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
          changetime-= Time.deltaTime;
        if(changetime < 0 && !isTyping)
        {
            NextLine();
            changetime = 6;
        }
        if (Input.GetKeyDown(KeyCode.E) && !isTyping)
        {
            changetime = 6;
            NextLine();
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine(lines[index]));
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        foreach (char c in line.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine(lines[index]));
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
