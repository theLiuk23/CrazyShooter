using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDistance : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Text distanceText;

    // Start is called before the first frame update
    void Start()
    {
        distanceText.text = "distance: 'null'";
    }

    // Update is called once per frame
    void Update()
    {
        distanceText.text = "Distance: " + Convert.ToInt32(CalculateDistance()).ToString();
    }

    float CalculateDistance()
    {
        return Vector3.Distance(player1.position, player2.position);
    }
}
