using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextCtrl_0 : MonoBehaviour {

    public Text MomLine, MyLine;
    public TextAsset OpeningText;
    private string[] lines;
    int i = 0;
    string data;
    string whoSay;
    public bool isEnd;
    // Use this for initialization
    void Start()
    {
        data = OpeningText.ToString();
        lines = data.Split(new char[] { '\n', '\n' } , System.StringSplitOptions.RemoveEmptyEntries);
        for (int c = 0; c < lines.Length; c++)
        {
            Debug.Log(lines[c]);
            c++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            whoSay =lines[i].Substring(0, 1);
            data=lines[i].Replace(whoSay, "");
            if (whoSay.Equals("M"))
            {
                MomLine.text = data;

            }
            else
            {
                MyLine.text = data;
            }
            i++;
            if (isEnd)
            {
                Application.LoadLevel("Page1");
            }
        }
        if (i >= lines.Length)
        {
            i = lines.Length-1;
            isEnd = true;
        }
    }
    public void ECick()
    {
        whoSay = lines[i].Substring(0, 1);
        data = lines[i].Replace(whoSay, "");
        if (whoSay.Equals("M"))
        {
            MomLine.text = data;

        }
        else
        {
            MyLine.text = data;
        }
        i++;

        if (i >= lines.Length)
        {
            i = lines.Length - 1;
        }
    }
}


