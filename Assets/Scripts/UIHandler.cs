using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance{ get; private set; }
    private VisualElement m_HealthBar;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_HealthBar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
    }
    public void SetHealthValue(float healthVal)
    {
        m_HealthBar.style.width = Length.Percent(healthVal * 100f);
    }
}
