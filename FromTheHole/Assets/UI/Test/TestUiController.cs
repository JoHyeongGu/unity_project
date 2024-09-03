using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TestUiController : MonoBehaviour
{
    private Button startBtn;
    private Button closeBtn;
    private VisualElement windowContainer;
    private VisualElement windowBack;
    private VisualElement window;

    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        startBtn = root.Q<Button>("StartBtn");
        closeBtn = root.Q<Button>("CloseBtn");
        windowContainer = root.Q<VisualElement>("TopGround");
        windowBack = root.Q<VisualElement>("WindowBack");
        window = root.Q<VisualElement>("TopWindow");
        startBtn.RegisterCallback<ClickEvent>(OpenWindow);
        closeBtn.RegisterCallback<ClickEvent>(CloseWindow);
        window.RegisterCallback<TransitionEndEvent>(DisplayOffWindowContainer);
        windowContainer.style.display = DisplayStyle.None;
    }

    private void OpenWindow(ClickEvent e)
    {
        windowContainer.style.display = DisplayStyle.Flex;
        windowBack.AddToClassList("window-back--up");
        window.AddToClassList("window--up");
    }

    private void CloseWindow(ClickEvent e)
    {
        windowBack.RemoveFromClassList("window-back--up");
        window.RemoveFromClassList("window--up");
    }

    private void DisplayOffWindowContainer(TransitionEndEvent e)
    {
        if (!window.ClassListContains("window--up"))
        {
            windowContainer.style.display = DisplayStyle.None;
            Debug.Log("Close Windows!!");
        }
    }
}
