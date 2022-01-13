using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smile : MonoBehaviour
{
    [SerializeField] private GameObject smileGood;
    [SerializeField] private GameObject smileBad;

    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        smileGood.SetActive(false);
        smileBad.SetActive(false);
    }

    public void SetGoodSmile()
    {
        Reset();
        smileGood.SetActive(true);
        smileBad.SetActive(false);
    }
    public void SetBadSmile()
    {
        Reset();
        smileGood.SetActive(false);
        smileBad.SetActive(true);
    }
}
