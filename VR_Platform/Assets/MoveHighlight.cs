using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHighlight : MonoBehaviour
{
    private RectTransform rect;

    public void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    public void moveIntro()
    {
        rect.anchoredPosition = new Vector2(-753, 216);
    }
    public void moveMomentary()
    {
        rect.anchoredPosition = new Vector2(-242, 216);
    }
    public void moveStressStory()
    {
        rect.anchoredPosition = new Vector2(257, 216);
    }
    public void moveExit()
    {
        rect.anchoredPosition = new Vector2(672, 216);
    }
}
