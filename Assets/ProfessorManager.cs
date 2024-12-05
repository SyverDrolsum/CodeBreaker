using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorManager : MonoBehaviour
{
    public List<GameObject> textPanels;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OpenPanelByIndex(0);
    }


    public void OpenPanelByIndex(int index)
    {
        for (int i = 0; i < textPanels.Count; i++)
        {
            GameObject panel = textPanels[i];
            panel.SetActive(index == i);
        }
    }
}
