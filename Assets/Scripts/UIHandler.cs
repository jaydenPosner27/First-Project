using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance { get; private set; }
    public float displayTime = 4f;
    
    private VisualElement m_HealthBar;
    private VisualElement m_NonPlayerDialogue;
    private Label label;
    private float m_TimerDisplay;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_HealthBar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        m_NonPlayerDialogue = uiDocument.rootVisualElement.Q<VisualElement>("NPCDialogue");
        label = uiDocument.rootVisualElement.Q<Label>("Label");
        m_NonPlayerDialogue.style.display = DisplayStyle.None;
        m_TimerDisplay = -1f;
    }
    void Update()
    {
        if (m_TimerDisplay > 0)
        {
            m_TimerDisplay -= Time.deltaTime;
        }
        else
        {
            m_NonPlayerDialogue.style.display = DisplayStyle.None;
        }
    }
    public void SetHealthValue(float healthVal)
    {
        m_HealthBar.style.width = Length.Percent(healthVal * 100f);
    }
    public void DisplayDialogue(String text)
    {
        label.text = text;
        m_TimerDisplay = displayTime;
        m_NonPlayerDialogue.style.display = DisplayStyle.Flex;
    }
}
