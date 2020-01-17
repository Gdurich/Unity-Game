using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartScript : MonoBehaviour
{
    public GameObject RightBigWheel;
    public GameObject LeftBigWheel;
    public GameObject LeftSmallWheel;
    public GameObject RightSmallWheel;
    public int Speed;

    public GameObject AiCart;
    public GameObject PlayerCart;
    public GameObject AiGoblin;
    public GameObject PlayerGoblin;

    float Y;
    bool flag = true;
    int a;
    void Start()
    {
        Y = transform.position.y;
        a = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y != Y)
        {
            if (a == 0)
            {
                RightBigWheel.transform.localScale = new Vector3(RightBigWheel.transform.localScale.x, RightBigWheel.transform.localScale.y + (flag ? 0.05f : -0.05f));
                LeftBigWheel.transform.localScale = new Vector3(LeftBigWheel.transform.localScale.x, LeftBigWheel.transform.localScale.y + (flag ? -0.05f : 0.05f));
                LeftSmallWheel.transform.localScale = new Vector3(LeftSmallWheel.transform.localScale.x, LeftSmallWheel.transform.localScale.y + (flag ? 0.025f : -0.025f));
                RightSmallWheel.transform.localScale = new Vector3(RightSmallWheel.transform.localScale.x, RightSmallWheel.transform.localScale.y + (flag ? -0.025f : 0.025f));
                flag = !flag;
                a = Speed; ;
            }
            Y = transform.position.y;
            a--;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "AiStart")
        {
            AiGoblin.SetActive(false);
            AiCart.SetActive(true);
            GameObject.Find("MainField").GetComponent<GameManager>().PalyerCartCount++;
            this.transform.gameObject.SetActive(false);
            return;
        }
        if (collision.gameObject.name == "PlayerStart")
        {
            PlayerGoblin.SetActive(false);
            PlayerCart.SetActive(true);
            GameObject.Find("MainField").GetComponent<GameManager>().AiCartCount++;
            this.transform.gameObject.SetActive(false);
            return;
        }
    }
}
