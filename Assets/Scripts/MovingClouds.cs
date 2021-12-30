using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingClouds : MonoBehaviour
{
    public Transform Pos1, pos2;
    public GameObject Cloud;
    [SerializeField]
    private float speed;
    Vector2 nextPos;

    private GameObject cloud01;
    private GameObject cloud;
    private GameObject cloud3;
    private GameObject gameCloud;
    private GameObject gameCloud1;
    private GameObject gameCloud3;

    void Start()
    {
        cloud01 = GameObject.Find("Cloud01");
        cloud = GameObject.Find("Cloud");
        cloud3 = GameObject.Find("Cloud3");
        gameCloud = GameObject.Find("GameCloud");
        gameCloud1 = GameObject.Find("GameCloud1");
        gameCloud3 = GameObject.Find("GameCloud3");
        nextPos = Pos1.position;
        transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
    void Update()
    {
        CloudLoop();

        if (transform.position == Pos1.position)
        {
            nextPos = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            Cloud.transform.position = Pos1.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void CloudLoop()
    {
        if (Cloud == cloud01)
        {
            if (transform.position == Pos1.position)
            {
                //pos2.transform.position = new Vector3(Random.Range(950f, 1100f), Random.Range(130f, 250f), 0f);
                nextPos = pos2.position;
            }
            if (transform.position == pos2.position)
            {
                Pos1.transform.position = new Vector3(Random.Range(-1150f, -1380f), Random.Range(-160f, 300f), 0f);
                Cloud.transform.position = Pos1.position;
            }
            transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
        if (Cloud == cloud)
        {
            if (transform.position == Pos1.position)
            {
                //pos2.transform.position = new Vector3(Random.Range(950f, 1100f), Random.Range(130f, 250f), 0f);
                nextPos = pos2.position;
            }
            if (transform.position == pos2.position)
            {
                Pos1.transform.position = new Vector3(Random.Range(-880f, -1000f), Random.Range(150f, 300f), 0f);
                Cloud.transform.position = Pos1.position;
            }
            transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
        if (Cloud == cloud3)
        {
            if (transform.position == Pos1.position)
            {
                //pos2.transform.position = new Vector3(Random.Range(950f, 1100f), Random.Range(130f, 250f), 0f);
                nextPos = pos2.position;
            }
            if (transform.position == pos2.position)
            {
                Pos1.transform.position = new Vector3(Random.Range(-1700f, -2100f), Random.Range(-200f, 100f), 0f);
                Cloud.transform.position = Pos1.position;
            }
            transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
        if (Cloud == gameCloud)
        {
            if (transform.position == Pos1.position)
            {
                //pos2.transform.position = new Vector3(Random.Range(12.5f, 14f), Random.Range(2.75f, 0.9f), 0f);
                nextPos = pos2.position;
            }
            if (transform.position == pos2.position)
            {
                Pos1.transform.position = new Vector3(Random.Range(-11.5f, -15f), Random.Range(-0.2f, -2.5f), 0f);
                Cloud.transform.position = Pos1.position;
                pos2.transform.position = new Vector3(Random.Range(12.35f, 14f), Random.Range(2.75f, 0.9f), 0f);
                nextPos = pos2.position;
            }
            transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
        if (Cloud == gameCloud1)
        {
            if (transform.position == Pos1.position)
            {
                //pos2.transform.position = new Vector3(Random.Range(12.5f, 14f), Random.Range(2.75f, 0.9f), 0f);
                nextPos = pos2.position;
            }
            if (transform.position == pos2.position)
            {
                Pos1.transform.position = new Vector3(Random.Range(-18f, -14.05f), Random.Range(-6f, -4.2f), 0f);
                Cloud.transform.position = Pos1.position;
                pos2.transform.position = new Vector3(Random.Range(11.9f, 14.5f), Random.Range(0.03f, 2.8f), 0f);
                nextPos = pos2.position;
            }
            transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
        if (Cloud == gameCloud3)
        {
            if (transform.position == Pos1.position)
            {
                //pos2.transform.position = new Vector3(Random.Range(12.5f, 14f), Random.Range(2.75f, 0.9f), 0f);
                nextPos = pos2.position;
            }
            if (transform.position == pos2.position)
            {
                Pos1.transform.position = new Vector3(Random.Range(-23f, -16.5f), Random.Range(0f, 2.35f), 0f);
                Cloud.transform.position = Pos1.position;
                //pos2.transform.position = new Vector3(Random.Range(11.9f, 14.5f), Random.Range(0.03f, 2.8f), 0f);
                nextPos = pos2.position;
            }
            transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
    }

    /*private IEnumerator NewPos()
    {
        while (cloudCount < 1)
        {
            Pos1.transform.position = new Vector3(Random.Range(-1680f, -1050f), Random.Range(-190f, 335f), 0f);
            pos2.transform.position = new Vector3(Random.Range(950f, 1400f), Random.Range(130f, 350f), 0f);

            Instantiate(Cloud, new Vector3(Pos1.position.x, Pos1.position.y, 0f), Quaternion.identity);

            yield return new WaitForSeconds(1f);

            cloudCount++;
        }
    }*/
}
