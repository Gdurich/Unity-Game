using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinScript : MonoBehaviour
{

    public GameObject Feet;
    public GameObject Hand1;
    public GameObject Hand2;
    public GameObject Shadow1;
    public GameObject Shadow2;
    public int AnimationSpeed = 30;
    public float CharacterSpeed = 0.04f;
    public bool isRuning = false;
    public GameObject Wall;

    bool flag = true;
    int animationSpeed;
    float seconds;
    float lifetime;
    void Start()
    {
        animationSpeed = AnimationSpeed;

        GenerateRandomValue();

    }

    void Update()
    {
        if (isRuning && BeginRun())
        {
            Run();
            if (isDead())
            {
                Dead();
            }
        }
    }


    void Dead()
    {
        isRuning = false;
        flag = false;
        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Hand1.SetActive(false);
        Hand2.SetActive(true);
        GenerateRandomValue();
        transform.parent = GameObject.Find("MainField").transform;
        transform.position = GetComponent<DragHandler>().startPosition;
        GetComponent<DragHandler>().IsDecided = true;
    }
    bool isDead()
    {
        if (lifetime < 0)
            return true;
        lifetime -= Time.deltaTime;
        return false;
    }
    void GenerateRandomValue()
    {
        seconds = Random.Range(1, 4);
        lifetime = Random.Range(3, 6);
    }

    bool BeginRun()
    {
        if (seconds < 0)
            return true;
        seconds -= Time.deltaTime;
        return false;
    }
    void Run()
    {
        if(transform.rotation.z == 0)
            transform.position = new Vector3(transform.position.x, transform.position.y + CharacterSpeed, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y - CharacterSpeed, transform.position.z);
        if (animationSpeed == 0)
        {
            Shadow1.SetActive(flag);
            Shadow2.SetActive(!flag);
            Feet.SetActive(flag);
            flag = !flag;
            animationSpeed = AnimationSpeed;
        }
        animationSpeed--;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Cart")
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        if(collision.gameObject == Wall)
        {
            lifetime = -1;
        }
        if (isRuning && collision.gameObject.name == "Cart")
        {
            Hand1.SetActive(true);
            Hand2.SetActive(false);
        }
        if (isRuning == false && collision.gameObject.name == "PlayerStart")
        {
            Dead();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Cart")
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            isRuning = false;
        }
    }
}
