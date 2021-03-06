﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IgniteModule;

public class Example : MonoBehaviour
{
    public enum ExampleEnum
    {
        OptionA,
        OptionB,
        OptionC,
        OptionD
    }
    IgniteWindow logWindow = null;

    void Start()
    {
        logWindow = IgniteWindow.Create("Log", open: false)
                                .SetRightTopPos();

        ATweening.ATween.To(() => sliderValue, v => sliderValue = v, 1f, 1f).SetLoops(-1, ATweening.LoopType.Yoyo);
        ExampleWindow();
    }

    float sliderValue = 0f;
    void ExampleWindow()
    {
        IgniteWindow.Create("Window")
                    .AddLabel("Label")
                    .AddButton("Grid", () => Grid())
                    .AddButton("SetPos", () => SetWindowPos())
                    .AddRGBSlider(color => Camera.main.backgroundColor = color, Camera.main.backgroundColor)
                    .AddMonitoringSlider(() => sliderValue)
                    .AddVector2Field(vec => logWindow.AddLabel(vec.ToString()), initialValue: new Vector2(123, 456))
                    .AddVector3Field("vector3", vec => logWindow.AddLabel(vec.ToString()), initialValue: new Vector2(123, 456))
                    .AddEnumDropdown<ExampleEnum>(v => logWindow.AddLabel(v.ToString()))
                    .AddButton("Clear LogWindow", () => logWindow.Clear())
                    .AddButton("CreateWindow", () => ExampleWindow())
                    .AddButton("ExampleButton", () => logWindow.AddLabel("Button Click"))
                    .AddMonitoringLabel(() => System.DateTime.Now.ToString())
                    .AddButton("Label", "Labelbutton", () => logWindow.AddLabel("Button Click"))
                    .AddToggle(v => logWindow.AddLabel("Toggle: " + v))
                    .AddToggle("Label", v => logWindow.AddLabel("Toggle: " + v))
                    .AddToggleWithButton("Button", v => logWindow.AddLabel("Button Click: " + v))
                    .AddSlider(v => logWindow.AddLabel("Slider Value Change" + v))
                    .AddSlider("Slider", v => logWindow.AddLabel("Slider: " + v), -100f, 100f, true)
                    .AddFoldout("Foldout")
                        .LastNestedGroup
                        .AddLabel("Label")
                        .AddButton("Button", () => logWindow.AddLabel("Button Click"))
                    .Parent
                    .AddLabel("ToggleGroup")
                    .AddToggleGroup()
                        .LastNestedGroup
                        .AddToggle("Toggle 1", v => logWindow.AddLabel("Toggle1: " + v))
                        .AddToggle("Toggle 2", v => logWindow.AddLabel("Toggle2: " + v))
                        .AddToggle("Toggle 3", v => logWindow.AddLabel("Toggle3: " + v))
                    .Parent
                    .AddDropdown(v => logWindow.AddLabel("Dropdown Value: " + v), "option A", "option B", "option C")
                    .AddInputField(v => logWindow.AddLabel("InputField Value: " + v), v => logWindow.AddLabel("InptuField EndEdit:" + v), "Input", "PlaceHolder")
                    .AddInputField("InputField", v => logWindow.AddLabel("InputField Value: " + v), v => logWindow.AddLabel("InptuField EndEdit:" + v), "Input", "PlaceHolder")
                    .AddInputFieldWithButton("OpenURL", url => Application.OpenURL(url), initialValue: "https://www.youtube.com/channel/UCmgWMQkenFc72QnYkdxdoKA")
        ;
    }

    void SetWindowPos()
    {
        IgniteWindow.Create("SetPos")
                    .AddButton("LeftTop", () => IgniteWindow.Create("LeftTop").SetLeftTopPos())
                    .AddButton("LeftBottom", () => IgniteWindow.Create("LeftBottom").SetLeftBottomPos())
                    .AddButton("RightTop", () => IgniteWindow.Create("RightTop").SetRightTopPos())
                    .AddButton("RightBottom", () => IgniteWindow.Create("RightBottom").SetRightBottomPos())
                    ;
    }

    void Grid()
    {
        var grid = IgniteWindow.Create("Grid")
                                .AddFoldout("Grid")
                                .LastNestedGroup
                                .AddGridGroup(new Vector2(100, 30))
                                .LastNestedGroup;

        for (int i = 0; i < 10; ++i)
        {
            var index = i;
            grid.AddButton(i.ToString("D8"), () => Debug.Log("Grid: " + index));
        }
    }
}
