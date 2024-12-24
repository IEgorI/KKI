 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CardBase : ScriptableObject
{
    public string[] CardName = new string[2];
    public int[] Health = new int[2];
    public int[] Dmg = new int[2];
    public Sprite[] Face = new Sprite[2];
}
