using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCtrl_3 : MonoBehaviour {

    public TextAsset TextA;
    string data;
    string[] lines;
    public int textNum = 0;

    public Text m_LineText;

    int o;

    private void Awake()
    {
        data = TextA.ToString();
        lines = data.Split(new char[] { '\n', '-' }, System.StringSplitOptions.RemoveEmptyEntries);
        SetTextLine(textNum);
        textNum = 0;
       
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_LineText.text = lines[textNum];
    }
    public void SetTextLine(int num)
    {
        textNum += num;
        if (textNum == lines.Length - 1)
        {
            textNum -= 1;
        }
    }
    public void Home()
    {
        textNum = lines.Length-1;
    }
}

