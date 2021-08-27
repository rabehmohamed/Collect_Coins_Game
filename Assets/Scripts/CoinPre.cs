using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinPre : MonoBehaviour
{
    public float counter = 0;
    public GameManage script;

    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.Find("gamer").GetComponent<GameManage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        script.updateScore(1);
        Destroy(gameObject);
    }
}
