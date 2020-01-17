using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelScript : MonoBehaviour
{
    public GameObject Panel;
    public Text Timer;
    float TimeValue = 5;
    void Update()
    {
        if (TimeValue > 0)
        {
            Timer.text = ((int)TimeValue).ToString();
        }
        else
        {
            Timer.text = "Go!!!";
            if (TimeValue < -3)
            {
                GameObject.Find("GameField").GetComponent<AiManager>().IsStart = true;
                Panel.SetActive(false);
            }
        }
        TimeValue -= Time.deltaTime;
    }
}
