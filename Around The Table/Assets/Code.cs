using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Code : MonoBehaviour
{
    public static GameObject[] point = new GameObject[2];
    public static GameObject[] teamName = new GameObject[2];
    public static GameObject title;
    public static GameObject image;
    public static GameObject skip;
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
        title = GameObject.Find("Title");
        image = GameObject.Find("Image");
        skip = GameObject.Find("Skip");
        next = GameObject.Find("Next");
        timer = GameObject.Find("Timer");
        point[0] = GameObject.Find("Point0");
        point[1] = GameObject.Find("Point1");
        teamName[0] = GameObject.Find("TeamName0");
        teamName[1] = GameObject.Find("TeamName1");

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
        names.Add("Dwayne 'The Rock' Johnson");
        names.Add("Justin Bieber");
        names.Add("Michael Jackson");
        names.Add("John Cena");
        names.Add("Linse Kessler");
        names.Add("Messi");

        names.Add("Arnold Schwarzenegger");
        names.Add("Batman");
        names.Add("Johnny Depp");
        names.Add("Harry Styles (One Direction)");
        names.Add("Mark Zuckerberg (Facebook)");
        names.Add("Mr. Bean");
        names.Add("Adolf Hitler");
        names.Add("Greta Thunberg");
        names.Add("Dronning Margrethe");
        names.Add("Elton John");

    }

    public void NextClicked()
    {
        if (next.GetComponentInChildren<Text>().text == "End")
        {
            next.GetComponentInChildren<Text>().text = "Start";
            points[turn, round] = seconds[turn];
            seconds[turn] = 0;
            Code.point[0].GetComponentInChildren<Text>().text = "Points:" + "\n\n" + Code.points[0, 0] + "\n\n" + Code.points[0, 1] + "\n\n" + Code.points[0, 2];
            Code.point[1].GetComponentInChildren<Text>().text = "Points:" + "\n\n" + Code.points[1, 0] + "\n\n" + Code.points[1, 1] + "\n\n" + Code.points[1, 2];

            counter = 0;

            if (turn == 0)
                turn = 1;
            else if (turn == 1)
                turn = 0;

            if (names.Count == 0)
            {
                round++;
                if (round == 3)
                {
                    GameOver();
                }

                if (points[0, 0] + points[0, 1] + points[0, 2] < points[1, 0] + points[1, 1] + points[1, 2])
                    turn = 0;
                else if (points[1, 0] + points[1, 1] + points[1, 2] < points[0, 0] + points[0, 1] + points[0, 2])
                    turn = 1;
                else
                    turn = Random.Range(0, 2);
            }
            title.GetComponentInChildren<Text>().text = "Round " + (round + 1) + "\n" + teamNames[turn];
        }
        else
        {
            if (next.GetComponentInChildren<Text>().text == "Start")
            {
                timer.GetComponentInChildren<Text>().text = "000";
                if (names.Count == 0)
                {
                    NewRound();
                }
                next.GetComponentInChildren<Text>().text = "Next";
            }

            int rndName = Random.Range(0, names.Count);
            title.GetComponentInChildren<Text>().text = names[rndName];
            names.RemoveAt(rndName);

            if (names.Count == 0 || names.Count == 10)
            {
                next.GetComponentInChildren<Text>().text = "End";
            }
        }
    }

    public void GameOver()
    {

    }
}
