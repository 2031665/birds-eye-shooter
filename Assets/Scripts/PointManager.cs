using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public Text pointsText;
    public static int currentPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Score: "+ Mathf.Round(currentPoint);
    }
         public void addPoint(){

        currentPoint+=Enemy_controller.enemyPoints;
        pointsText.text = currentPoint.ToString("");  
    }
}
