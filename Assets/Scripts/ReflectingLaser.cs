using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectingLaser : ISpecialSkill
{
    public void Action()
    {
        //必殺技の処理を書く
    }

    public void Setup()
    {
        Debug.Log($"<color=yellow>{this}</color> : 必殺技の追加");
    }
}
