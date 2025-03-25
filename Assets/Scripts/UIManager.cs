using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    public Button[] colorButtons;
    public Button[] shapeButtons;

    void Start()
    {
        for (int i = 0; i < colorButtons.Length; i++)
        {
            int index = i;
            colorButtons[i].onClick.AddListener(() =>
            {
                settings.currentColor = colorButtons[index].GetComponent<Image>().color;
            });
        }

        for (int i = 0; i < shapeButtons.Length; i++)
        {
            int index = i;
            shapeButtons[i].onClick.AddListener(() =>
            {
                settings.currentShapeIndex = index;
            });
        }
    }
}