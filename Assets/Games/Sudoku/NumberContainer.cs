using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberContainer : MonoBehaviour
{
    [SerializeField] private Sprite sprite0;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;
    [SerializeField] private Sprite sprite4;
    [SerializeField] private Sprite sprite5;
    [SerializeField] private Sprite sprite6;
    [SerializeField] private Sprite sprite7;
    [SerializeField] private Sprite sprite8;
    [SerializeField] private Sprite sprite9;

    public Sprite GetSpriteFromNumber(int number)
    {
        switch (number)
        {
            case 0:
                return sprite0;
            case 1:
                return sprite1;
            case 2:
                return sprite2;
            case 3:
                return sprite3;
            case 4:
                return sprite4;
            case 5:
                return sprite5;
            case 6:
                return sprite6;
            case 7:
                return sprite7;
            case 8:
                return sprite8;
            case 9:
                return sprite9;
            default:
                return sprite0;
        }
    }
}
