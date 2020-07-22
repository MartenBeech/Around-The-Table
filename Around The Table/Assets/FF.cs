using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FF : MonoBehaviour
{
    public AudioSource ff;
    public AudioSource clap;
    public AudioSource ding;

    public static GameObject[] answers = new GameObject[8];
    public static GameObject question;
    public static GameObject[] scores = new GameObject[2];
    public static int round = 0;
    public static int turn = 0;
    public static string currentQuestion;
    public static int[] score = new int[2] { 0, 0 };
    public static bool roundSkipped = false;

    private void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            answers[i] = GameObject.Find("Answer" + i);
        }
        question = GameObject.Find("Question");
        scores[0] = GameObject.Find("Score0");
        scores[1] = GameObject.Find("Score1");

        scores[0].GetComponentInChildren<Text>().text = "Points:\n\n" + score[0];
        scores[1].GetComponentInChildren<Text>().text = "Points:\n\n" + score[1];
    }

    private void Update()
    {
        if (round > 0)
        {
            if (Input.GetKeyDown("1"))
                AnswerClicked(0);
            else if (Input.GetKeyDown("2"))
                AnswerClicked(1);
            else if (Input.GetKeyDown("3"))
                AnswerClicked(2);
            else if (Input.GetKeyDown("4"))
                AnswerClicked(3);
            else if (Input.GetKeyDown("5"))
                AnswerClicked(4);
            else if (Input.GetKeyDown("6"))
                AnswerClicked(5);
            else if (Input.GetKeyDown("7"))
                AnswerClicked(6);
            else if (Input.GetKeyDown("8"))
                AnswerClicked(7);
            else if (Input.GetKeyDown("0"))
                AnswerClicked(8);
        }
    }

    public void QuestionClicked()
    {
        round++;
        roundSkipped = false;
        ff.Stop();
        ff.Play();
        for (int i = 0; i < 8; i++)
        {
            answers[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
        }
        switch(round)
        {
            case 1:
                currentQuestion = "Nævn noget som bedstemor lægger frem eller tager ud, for at vise bedstefar at hun har lyst til noget stok";
                question.GetComponentInChildren<Text>().text = ATT.teamNames[turn] + ":\n" + currentQuestion;
                break;

            case 2:
                currentQuestion = "Nævn grunde for at du ikke tror din kone nogensinde vil forlade dig";
                question.GetComponentInChildren<Text>().text = ATT.teamNames[turn] + ":\n" + currentQuestion;
                answers[7].GetComponentInChildren<Text>().text = "- - -";
                break;

            case 3:
                currentQuestion = "Nævn ting en kvinde vil hade at hendes ekskæreste/mand bruger penge på lige efter de går fra hinanden";
                question.GetComponentInChildren<Text>().text = ATT.teamNames[turn] + ":\n" + currentQuestion;
                answers[7].GetComponentInChildren<Text>().text = "- - -";
                break;

            case 4:
                GameOver();
                break;
        }
    }

    public void AnswerClicked(int i)
    {
        int points = 0;
        if (i == 8)
        {
            Menu.music = "Quack";
        }
        else
        {
            switch (round)
            {
                case 1:
                    switch (i)
                    {
                        case 0:
                            points = 8;
                            answers[i].GetComponentInChildren<Text>().text = "Hendes tænder";
                            break;

                        case 1:
                            points = 7;
                            answers[i].GetComponentInChildren<Text>().text = "Alkohol";
                            break;

                        case 2:
                            points = 6;
                            answers[i].GetComponentInChildren<Text>().text = "Crème de la crème";
                            break;

                        case 3:
                            points = 5;
                            answers[i].GetComponentInChildren<Text>().text = "Lingerie";
                            break;

                        case 4:
                            points = 4;
                            answers[i].GetComponentInChildren<Text>().text = "Stearinlys/duftlys";
                            break;

                        case 5:
                            points = 3;
                            answers[i].GetComponentInChildren<Text>().text = "Hendes hængepartier";
                            break;

                        case 6:
                            points = 2;
                            answers[i].GetComponentInChildren<Text>().text = "Legetøj";
                            break;

                        case 7:
                            points = 1;
                            answers[i].GetComponentInChildren<Text>().text = "Bedstefars viagra";
                            break;

                        default:
                            break;
                    }
                    break;

                case 2:
                    switch (i)
                    {
                        case 0:
                            points = 8;
                            answers[i].GetComponentInChildren<Text>().text = "Jeg er rig";
                            break;

                        case 1:
                            points = 7;
                            answers[i].GetComponentInChildren<Text>().text = "Hun elsker mig <3";
                            break;

                        case 2:
                            points = 6;
                            answers[i].GetComponentInChildren<Text>().text = "Ægteskabsløfte";
                            break;

                        case 3:
                            points = 5;
                            answers[i].GetComponentInChildren<Text>().text = "Jeg styrer i sengen";
                            break;

                        case 4:
                            points = 4;
                            answers[i].GetComponentInChildren<Text>().text = "Jeg er for nice";
                            break;

                        case 5:
                            points = 3;
                            answers[i].GetComponentInChildren<Text>().text = "Vi er gode sammen";
                            break;

                        case 6:
                            points = 2;
                            answers[i].GetComponentInChildren<Text>().text = "Vores hus";
                            break;

                        default:
                            break;
                    }
                    break;

                case 3:
                    switch (i)
                    {
                        case 0:
                            points = 8;
                            answers[i].GetComponentInChildren<Text>().text = "En bil/ferrari";
                            break;

                        case 1:
                            points = 7;
                            answers[i].GetComponentInChildren<Text>().text = "En ny vielsesring";
                            break;

                        case 2:
                            points = 6;
                            answers[i].GetComponentInChildren<Text>().text = "Et hus";
                            break;

                        case 3:
                            points = 5;
                            answers[i].GetComponentInChildren<Text>().text = "En ny kvinde";
                            break;

                        case 4:
                            points = 4;
                            answers[i].GetComponentInChildren<Text>().text = "Lola nede ved strøget";
                            break;

                        case 5:
                            points = 3;
                            answers[i].GetComponentInChildren<Text>().text = "Nyt tøj/klædeskab";
                            break;

                        case 6:
                            points = 2;
                            answers[i].GetComponentInChildren<Text>().text = "En båd";
                            break;

                        default:
                            break;
                    }
                    break;
            }

            ding.Play();
        }
        if (!roundSkipped)
        {
            score[turn] += points;
            scores[turn].GetComponentInChildren<Text>().text = "Points:\n\n" + "(+" + points + ") " + score[turn];


            if (turn == 0)
                turn = 1;
            else
                turn = 0;
        }

        question.GetComponentInChildren<Text>().text = ATT.teamNames[turn] + ":\n" + currentQuestion;
    }

    public void GameOver()
    {
        ff.Stop();
        clap.Play();
        if (score[0] > score[1])
        {
            question.GetComponentInChildren<Text>().text = "Hold " + ATT.teamNames[0] + " har vundet";
        }
        else if (score[1] > score[0])
        {
            question.GetComponentInChildren<Text>().text = "Hold " + ATT.teamNames[1] + " har vundet";
        }
        else
        {
            question.GetComponentInChildren<Text>().text = "Det står lige, I taber alle sammen";
        }
        answers[0].GetComponentInChildren<Text>().text = "Tillykke!";
        answers[1].GetComponentInChildren<Text>().text = "Congratulations!";
        answers[2].GetComponentInChildren<Text>().text = "Felicitaciones!";
        answers[3].GetComponentInChildren<Text>().text = "Complimenti!";
        answers[4].GetComponentInChildren<Text>().text = "Parabéns!";
        answers[5].GetComponentInChildren<Text>().text = "Tebrikler!";
        answers[6].GetComponentInChildren<Text>().text = "Glückwunsch!";
        answers[7].GetComponentInChildren<Text>().text = "Skål!";
    }

    public void SkipClicked()
    {
        roundSkipped = true;
    }
}
