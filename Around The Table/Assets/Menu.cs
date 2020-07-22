using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioSource check;
    public AudioSource quack;
    public AudioSource quizStart;
    public AudioSource quizProgress;
    public AudioSource quizEnd;
    public static string music = "";

    static GameObject[] teamNames = new GameObject[2];
    
    static GameObject startGame;
    private GameObject cam;
    private GameObject canvas;
    void Start()
    {
        teamNames[0] = GameObject.Find("InputName0");
        teamNames[1] = GameObject.Find("InputName1");
        
        startGame = GameObject.Find("StartGame");

        cam = GameObject.Find("Main Camera");
        canvas = GameObject.Find("CanvasATT");

        music = "Start";
    }

    private void Update()
    {
        if (music == "Start")
        {
            quizStart.Play();
            quizProgress.Stop();
            quizEnd.Stop();
            music = "Progress";
        }
        else if (music == "Progress" && !quizStart.isPlaying)
        {
            quizStart.Stop();
            quizProgress.Play();
            quizEnd.Stop();
            music = "";
        }
        else if (music == "End")
        {
            quizStart.Stop();
            quizProgress.Stop();
            quizEnd.Play();
            music = "";
        }

        if (music == "Check")
        {
            check.Play();
            music = "";
        }
        if (music == "Quack")
        {
            quack.Play();
            music = "";
        }
    }

    public void StartGameClicked()
    {
        if (teamNames[0].GetComponentInChildren<InputField>().text.Length > 0 && teamNames[1].GetComponentInChildren<InputField>().text.Length > 0)
        {
            cam.transform.position = new Vector3(canvas.transform.position.x, canvas.transform.position.y, -10);
            FirstRound();
        }
    }

    public void FirstRound()
    {
        music = "End";
        ATT.teamNames[0] = teamNames[0].GetComponentInChildren<InputField>().text;
        ATT.teamNames[1] = teamNames[1].GetComponentInChildren<InputField>().text;

        ATT.turn = Random.Range(0, 2);

        ATT.title.GetComponentInChildren<Text>().text = "Round " + (ATT.round + 1) + "\nNext up: " + ATT.teamNames[ATT.turn];

        for (int i = 0; i < 2; i++)
        {
            ATT.point[i].GetComponentInChildren<Text>().text = "Points:" + "\n\nRound 1:\n" + ATT.points[i, 0] + " sec.\n\nRound 2:\n" + ATT.points[i, 1] + " sec.\n\nRound 3:\n" + ATT.points[i, 2] + " sec.\n\n\n\n" +
            "Total:\n" + (ATT.points[i, 0] + ATT.points[i, 1] + ATT.points[i, 2] + " sec.");
        }
        ATT.teamName[0].GetComponentInChildren<Text>().text = ATT.teamName[2].GetComponentInChildren<Text>().text = ATT.teamNames[0];
        ATT.teamName[1].GetComponentInChildren<Text>().text = ATT.teamName[3].GetComponentInChildren<Text>().text = ATT.teamNames[1];
    }

    public void InputTextClicked(int i)
    {
        teamNames[i].GetComponentInChildren<InputField>().text = "";
    }
}

