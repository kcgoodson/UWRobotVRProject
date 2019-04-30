using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectScript : MonoBehaviour
{
    public Button button;
    public Button button2;
    void Start()
    {
        button.Select();
        button2.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
