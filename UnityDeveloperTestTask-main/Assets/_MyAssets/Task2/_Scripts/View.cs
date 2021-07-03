using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class View : Element
{
    //scrollbar
    [SerializeField] private Scrollbar horScroll;
    [SerializeField] private Scrollbar myScroll;

    //элементы очков и уровней
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI pointsTextBack;

    public TextMeshProUGUI[] levelsTxt;

    //начисление очков и анимация текстового блока
    public float durationPlusPoints;
    public float durationScale;

    public RectTransform textBlock;
    public RectTransform star;
    public Ease animEase;

    //анимация боковых полей
    public Image[] Arrows;

    public void LevelPlus(string level)
    {
        if (app.model.levels[Int32.Parse(level)-1]<app.model.maxLevels[Int32.Parse(level)-1])
        {
            int pointsStart = app.model.points;
            app.Notify(Notifications.PlusPoints, this);
            app.Notify(level, this);
        
            //анимация текстового блока
            DOVirtual.Float (pointsStart, app.model.points, durationPlusPoints, (v)=> pointsText.text = ((int)v).ToString());

            Sequence seq = DOTween.Sequence();

            seq
                .Append (textBlock.DOScale(1.3f, durationScale))
                .Append (textBlock.DOScale(1f, durationScale));

            star
                .DORotate(new Vector3(0,0,360), durationPlusPoints, RotateMode.FastBeyond360);
        }
    }

    void Update()
    {
        //значение скроллбара
        myScroll.value = horScroll.value;
        pointsTextBack.text = pointsText.text;

        //анимация боковых полей
        if (myScroll.value != 0 && myScroll.value != 1)
        {
            for (int i=0; i< Arrows.Length;i++)
            {
                Arrows[i].DOFade(1,durationPlusPoints);
            }
        }
        else if (myScroll.value == 0 || myScroll.value == 1)
        {
            for (int i=0; i< Arrows.Length;i++)
            {
                Arrows[i].DOFade(0,durationPlusPoints);
            }
        }
    }

    //задание текстовых значений уровней
    public void SetLevelsText()
    {
        for (int i=0; i<levelsTxt.Length;i++)
        {
            levelsTxt[i].text = app.model.levels[i].ToString();
        }
    }
}
