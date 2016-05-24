using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour 
{
    GameObject robot, checkmark, knob;
    GameObject[,] cube;
    GameObject[] gameobject;
    int rnd_x1, rnd_y1, rnd_x2, rnd_y2, rnd_x3, rnd_y3;

    // Use this for initialization
    void Start()
    {
        int k = 0;
        cube = new GameObject[8, 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                cube[i, j] = Instantiate(Resources.Load("Cube"), new Vector3(i, j, k), Quaternion.identity) as GameObject;
                cube[i, j].name = "cube" + (i + 1) + (j + 1);
            }
        }
        for (int i = 0; i < 8; i += 2)
        {
            for (int j = 0; j < 8; j += 2)
            {
                cube[i, j].GetComponent<MeshRenderer>().material.color = Color.red;
                cube[i + 1, j + 1].GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }

        robot = Instantiate(Resources.Load("RobotBoy")) as GameObject;
        robot.name = "RobotBoy";
        knob = Instantiate(Resources.Load("Knob")) as GameObject;
        knob.name = "Knob";
        checkmark = Instantiate(Resources.Load("Checkmark")) as GameObject;
        checkmark.name = "Checkmark";

        System.Random rnd = new System.Random();

        rnd_x1 = rnd.Next(0, 7);
        rnd_y1 = rnd.Next(0, 7);
        robot.transform.parent = cube[rnd_x1, rnd_y1].transform;
        robot.transform.position = new Vector3(cube[rnd_x1, rnd_y1].transform.position.x, cube[rnd_x1, rnd_y1].transform.position.y, -1);

        rnd_x2 = rnd.Next(0, 7);
        rnd_y2 = rnd.Next(0, 7);
        knob.transform.parent = cube[rnd_x2, rnd_y2].transform;
        knob.transform.position = new Vector3(cube[rnd_x2, rnd_y2].transform.position.x, cube[rnd_x2, rnd_y2].transform.position.y, -1);
        knob.transform.localScale *= 3;

        rnd_x3 = rnd.Next(0, 7);
        rnd_y3 = rnd.Next(0, 7);
        checkmark.transform.parent = cube[rnd_x3, rnd_y3].transform;
        checkmark.transform.position = new Vector3(cube[rnd_x3, rnd_y3].transform.position.x, cube[rnd_x3, rnd_y3].transform.position.y, -1);
        checkmark.transform.localScale *= 4;

    }
        // Update is called once per frame
    void Update () 
    {
        /*while (robot.transform.position != new Vector3(rnd_x1, rnd_y1))
        {
            robot.transform.position += new Vector3(0, 0.02f);
        }*/
    }
}
