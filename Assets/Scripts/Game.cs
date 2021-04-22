﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Game : MonoBehaviour
{
    [HideInInspector] public static Game Instance;

    private float goodBadTx; // Good 0 -> 100  |  Bad -100 -> 0

    public GameObject good;
    public GameObject bad;

    public TMPro.TextMeshProUGUI text;
    public CanvasGroup dialogue;

    public int tree = 0;
    public int rock = 0;
    public int box = 0;
    public TMPro.TextMeshProUGUI textTree;
    public TMPro.TextMeshProUGUI textRock;
    public TMPro.TextMeshProUGUI textBox;

    public bool locked = false;

    private void Awake()
    {
        Instance = this;
    }

    public void Help(Transform tf)
    {
        GameObject go = Instantiate(good,tf.position,tf.rotation);
        go.transform.localScale = Vector3.zero;

        go.transform.DOMoveY(go.transform.position.y+2,1f).OnComplete(() => { go.transform.DOMoveY( go.transform.position.y + 2f, 1f); });
        go.transform.DOScale(1, 1f).OnComplete(() => { go.transform.DOScale(0, 1f); });

        goodBadTx += 10;
    }

    public void BadAct(Transform tf)
    {
        GameObject go = Instantiate(bad, tf.position, tf.rotation);
        go.transform.localScale = Vector3.zero;

        go.transform.DOMoveY(go.transform.position.y + 2, 1f).OnComplete(() => { go.transform.DOMoveY(go.transform.position.y + 2f, 1f); });
        go.transform.DOScale(1, 1f).OnComplete(() => { go.transform.DOScale(0, 1f); });

        Destroy(go, 2f);

        goodBadTx -= 10;
    }



    /*
        ------------- UI 
    */

    public void OpenText(string txt)
    {
        dialogue.DOFade(1, 1f);
        text.text = txt;
        locked = true;
    }

    public void CloseText()
    {
        dialogue.DOFade(0, 1f);
        locked = false;
    }

    public void UpdateUI()
    {
        textBox.text = "X " + box;
        textTree.text = "X " + tree;
        textRock.text = "X " + rock;
    }

}
