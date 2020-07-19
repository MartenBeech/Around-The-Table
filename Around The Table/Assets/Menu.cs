using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    static GameObject[] teamNames = new GameObject[2];
    
    static GameObject startGame;
    private GameObject cam;
    private GameObject board;
    void Start()
    {
        teamNames[0] = GameObject.Find("InputName0");
        teamNames[1] = GameObject.Find("InputName1");
        
        startGame = GameObject.Find("StartGame");

        cam = GameObject.Find("Main Camera");
        board = GameObject.Find("Canvas");
    }

    public void StartGameClicked()
    {
        if (teamNames[0].GetComponentInChildren<InputField>().text.Length > 0 && teamNames[1].GetComponentInChildren<InputField>().text.Length > 0)
        {
            cam.transform.position = new Vector3(board.transform.position.x, board.transform.position.y, -10);
            FirstRound();
        }
    }

    public void FirstRound()
    {
        Code.teamNames[0] = teamNames[0].GetComponentInChildren<InputField>().text;
        Code.teamNames[1] = teamNames[1].GetComponentInChildren<InputField>().text;

        Code.turn = Random.Range(0, 2);

        Code.title.GetComponentInChildren<Text>().text = "Round " + (Code.round + 1) + "\n" + Code.teamNames[Code.turn];

        Code.point[0].GetComponentInChildren<Text>().text = "Points:" + "\n\n" + Code.points[0, 0] + "\n\n" + Code.points[0, 1] + "\n\n" + Code.points[0, 2];
        Code.point[1].GetComponentInChildren<Text>().text = "Points:" + "\n\n" + Code.points[1, 0] + "\n\n" + Code.points[1, 1] + "\n\n" + Code.points[1, 2];
        Code.teamName[0].GetComponentInChildren<Text>().text = Code.teamNames[0];
        Code.teamName[1].GetComponentInChildren<Text>().text = Code.teamNames[1];
    }

    public void InputTextClicked(int i)
    {
        teamNames[i].GetComponentInChildren<InputField>().text = "";
    }
}

