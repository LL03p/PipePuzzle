using System.Collections;
using UnityEngine;

public class Startgame : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject[] UI;
    private int randomStage;

    void Start()
    {
        StartPanel.SetActive(true);
        SetUIActive(true);
        StartCoroutine(WaitForStart());
    }

    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(0.25f);
        
        StartPanel.SetActive(false);
        SetUIActive(false);
        
        randomStage = Random.Range(1, 6); 
        Debug.Log("Random Stage: " + randomStage);
        
        UI[randomStage - 1].SetActive(true);
        Debug.Log("UI" + randomStage);
    }

    void SetUIActive(bool isActive)
    {
        for (int i = 0; i < UI.Length; i++)
        {
            UI[i].SetActive(isActive);
        }
    }
}