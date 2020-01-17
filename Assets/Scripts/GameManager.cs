using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> GoblinList;
    public GameObject ResultPanel;

    public int AiCartCount = 0;
    public int PalyerCartCount = 0;
    void Update()
    {
        if((PalyerCartCount + AiCartCount) > 2)
        {
            if(PalyerCartCount > AiCartCount)
            {
                ResultPanel.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Text>().text = "You Win!!!";
            }
            else
            {
                ResultPanel.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Ai Win!!!";
            }
            foreach (var item in GoblinList) item.SetActive(false);
            ResultPanel.SetActive(true);
        }
    }
}
