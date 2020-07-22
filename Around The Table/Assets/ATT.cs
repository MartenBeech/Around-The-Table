using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATT : MonoBehaviour
{
    private GameObject cam;
    private GameObject canvas;
    public static GameObject[] point = new GameObject[2];
    public static GameObject[] teamName = new GameObject[4];
    public static GameObject title;
    public static GameObject image;
    public static GameObject next;
    public static GameObject timer;
    public static List<string> names = new List<string>();
    public static float counter = 0f;
    public static int round = 0;
    public static int[] seconds = new int[2];
    public static int[,] points = new int[2, 3] { { 0, 0, 0 }, { 0, 0, 0 } };
    public static int turn = 0;
    public static string[] teamNames = new string[2] { "", "" };

    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        canvas = GameObject.Find("CanvasFF");
        title = GameObject.Find("Title");
        image = GameObject.Find("Image");
        next = GameObject.Find("Next");
        timer = GameObject.Find("Timer");
        point[0] = GameObject.Find("Point0");
        point[1] = GameObject.Find("Point1");
        teamName[0] = GameObject.Find("TeamName0");
        teamName[1] = GameObject.Find("TeamName1");
        teamName[2] = GameObject.Find("TeamName2");
        teamName[3] = GameObject.Find("TeamName3");

        turn = Random.Range(0, 2);
    }

    private void Update()
    {
        if (next.GetComponentInChildren<Text>().text != "Start")
        {
            counter += Time.deltaTime;
            if (counter >= 1f)
            {
                counter -= 1f;
                seconds[turn]++;
                if (seconds[turn] < 10)
                    timer.GetComponentInChildren<Text>().text = "00" + seconds[turn];
                else if (seconds[turn] < 100)
                    timer.GetComponentInChildren<Text>().text = "0" + seconds[turn];
                else
                    timer.GetComponentInChildren<Text>().text = seconds[turn].ToString();
            }
        }
    }

    public void NewRound()
    {
        timer.GetComponentInChildren<Text>().text = "000";
        counter = 0;
        names.Clear();

        names.Add("Søren Bech");
        names.Add("Gordon Ramsay");
        names.Add("Donald Trump");
        names.Add("Kim Kardashian");
        names.Add("Harry Potter");
        names.Add("Justin Bieber");
        names.Add("Michael Jackson");
        names.Add("John Cena");
        names.Add("Mickey Mouse");
        names.Add("Messi");

        names.Add("Arnold Schwarzenegger");
        names.Add("Batman");
        names.Add("Johnny Depp");
        names.Add("Charlie Chaplin");
        names.Add("Mark Zuckerberg");
        names.Add("Mr. Bean");
        names.Add("Kim Jong Un");
        names.Add("Greta Thunberg");
        names.Add("Dronning Margrethe");
        names.Add("Hannah Montana - Miley Cyrus");

    }

    public void NextClicked()
    {
        if (next.GetComponentInChildren<Text>().text == "End")
        {
            Menu menu = new Menu();
            Menu.music = "End";
            next.GetComponentInChildren<Text>().text = "Start";
            image.GetComponentInChildren<Image>().sprite = null;
            points[turn, round] = seconds[turn];
            seconds[turn] = 0;
            for (int i = 0; i < 2; i++)
            {
                ATT.point[i].GetComponentInChildren<Text>().text = "Points:" + "\n\nRound 1:\n" + ATT.points[i, 0] + " sec.\n\nRound 2:\n" + ATT.points[i, 1] + " sec.\n\nRound 3:\n" + ATT.points[i, 2] + " sec.\n\n\n\n" +
                "Total:\n" + (ATT.points[i, 0] + ATT.points[i, 1] + ATT.points[i, 2] + " sec.");
            }

            counter = 0;

            if (turn == 0)
                turn = 1;
            else if (turn == 1)
                turn = 0;

            if (names.Count == 0)
            {
                round++;

                if (points[0, 0] + points[0, 1] + points[0, 2] < points[1, 0] + points[1, 1] + points[1, 2])
                    turn = 0;
                else if (points[1, 0] + points[1, 1] + points[1, 2] < points[0, 0] + points[0, 1] + points[0, 2])
                    turn = 1;
                else
                    turn = Random.Range(0, 2);
            }
            title.GetComponentInChildren<Text>().text = "Round " + (round + 1) + "\nNext up: " + teamNames[turn];
        }
        else
        {
            if (round == 3)
            {
                GameOver();
            }
            else
            {
                if (next.GetComponentInChildren<Text>().text == "Start")
                {
                    Menu menu = new Menu();
                    Menu.music = "Start";
                    timer.GetComponentInChildren<Text>().text = "000";
                    if (names.Count == 0)
                    {
                        NewRound();
                    }
                    next.GetComponentInChildren<Text>().text = "Next";
                }

                int rndName = Random.Range(0, names.Count);
                title.GetComponentInChildren<Text>().text = names[rndName];
                image.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(names[rndName]);
                names.RemoveAt(rndName);

                if (names.Count == 0 || names.Count == 10)
                {
                    next.GetComponentInChildren<Text>().text = "End";
                }
                if (names.Count != 9 && names.Count != 19)
                {
                    Menu.music = "Check";
                }
            }
        }
    }

    public void GameOver()
    {
        cam.transform.position = new Vector3(canvas.transform.position.x, canvas.transform.position.y, -10);
        if (points[0, 0] + points[0, 1] + points[0, 2] < points[1, 0] + points[1, 1] + points[1, 2])
            FF.turn = 0;
        else if (points[1, 0] + points[1, 1] + points[1, 2] < points[0, 0] + points[0, 1] + points[0, 2])
            FF.turn = 1;
        else
            FF.turn = Random.Range(0, 2);
    }
}
