using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class GoldSystem : MonoBehaviour
{
    public float gold = 300;
    [SerializeField] Text goldText;
    [SerializeField] Text gainedGoldText;
    public float time;
    float gainedGold;
    public float eatedAppleCount = 0;
    [SerializeField] GameObject backwardTail;
    float lastGolds;
    bool addGolds = false;
    bool doubleGolds = false;
    string gameId = "4105635";
    bool testMode = true;
    [SerializeField] Button adButton;
    // Start is called before the first frame update
    void Start()
    {
        lastGolds = gold;
        Advertisement.Initialize(gameId, testMode);
    }

    // Update is called once per frame
    void Update()
    {
        AdButton();
        if (FindObjectOfType<StartandPause>().isStarted && !FindObjectOfType<LeadingPoint>().isFinished)
        {
            time += Time.deltaTime;
        }
        if (addGolds)
        {
            gold = Mathf.Round(Mathf.Lerp(gold, lastGolds, .1f));
        }
        else if (FindObjectOfType<LeadingPoint>().isFinished)
        {
            gainedGold = (time * 5) + (float.Parse(backwardTail.name) * 100) + (eatedAppleCount * 50);
      
            
            gainedGoldText.text = Mathf.Round(gainedGold).ToString();
            lastGolds = Mathf.Round(gainedGold + gold);
            if (doubleGolds)
                lastGolds *= 2;
            
             
        }

        
        goldText.text = gold.ToString();

    }
    public void AddGolds()
    {
        addGolds = true;
    }
    public void AdButton()
    {
        if (Advertisement.IsReady())
        {
            adButton.interactable = true;
        }
    }
    public void ShowAdd()
    {
        Advertisement.Show();
        doubleGolds = true;
    }
    
}
