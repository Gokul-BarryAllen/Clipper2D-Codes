using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public int gemCount;
    public Text CoinText;
    public Text GemText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = "x " +coinCount.ToString();
        GemText.text = "x " +gemCount.ToString();
    }
}
