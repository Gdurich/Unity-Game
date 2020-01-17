using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiManager : MonoBehaviour
{
    public bool IsStart = false;
    public GameObject Goblin1;
    public GameObject Goblin2;
    public GameObject Goblin3;
    float StartTimeGoblin1 = 0, StartTimeGoblin2 = 0, StartTimeGoblin3 = 0;
    void Start()
    {
        
    }
    void Update()
    {
        if (IsStart)
        {
            if (Goblin1.GetComponent<GoblinScript>().isRuning == false)
            {
                if (Goblin1.GetComponent<DragHandler>().startPosition == Goblin1.transform.position && StartTimeGoblin1 < 0)
                    StartTimeGoblin1 = Random.Range(1, 4);
                StartTimeGoblin1 -= Time.deltaTime;
                if (StartTimeGoblin1 < 0)
                {
                    Vector3 vector3 = new Vector3();
                    vector3.x = Random.Range(-1, 2) * 370;
                    vector3.y = Goblin1.transform.localPosition.y - 300;
                    vector3.z = 0;
                    Goblin1.transform.localPosition = vector3;
                    Goblin1.transform.parent = GameObject.Find("GameField").transform;
                    Goblin1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                    Goblin1.GetComponent<GoblinScript>().isRuning = true;
                }
            }
            if (Goblin2.GetComponent<GoblinScript>().isRuning == false)
            {
                if (Goblin2.GetComponent<DragHandler>().startPosition == Goblin2.transform.position && StartTimeGoblin2 < 0)
                    StartTimeGoblin2 = Random.Range(1, 4);
                StartTimeGoblin2 -= Time.deltaTime;
                if (StartTimeGoblin2 < 0)
                {
                    Vector3 vector3 = new Vector3();
                    vector3.x = Random.Range(-1, 2) * 370;
                    vector3.y = Goblin2.transform.localPosition.y - 300;
                    vector3.z = 0;

                    Goblin2.transform.localPosition = vector3;
                    Goblin2.transform.parent = GameObject.Find("GameField").transform;
                    Goblin2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                    Goblin2.GetComponent<GoblinScript>().isRuning = true;
                }
            }
            if (Goblin3.GetComponent<GoblinScript>().isRuning == false)
            {
                if (Goblin3.GetComponent<DragHandler>().startPosition == Goblin3.transform.position && StartTimeGoblin3 < 0)
                    StartTimeGoblin3 = Random.Range(1, 4);
                StartTimeGoblin3 -= Time.deltaTime;
                if (StartTimeGoblin3 < 0)
                {
                    Vector3 vector3 = new Vector3();
                    vector3.x = Random.Range(-1, 2) * 370;
                    vector3.y = Goblin3.transform.localPosition.y - 300;
                    vector3.z = 0;

                    Goblin3.transform.localPosition = vector3;
                    Goblin3.transform.parent = GameObject.Find("GameField").transform;
                    Goblin3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                    Goblin3.GetComponent<GoblinScript>().isRuning = true;
                }
            }
        }
    }
}
