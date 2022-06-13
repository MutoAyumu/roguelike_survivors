using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpecialSkill
{
    void Setup(PlayerController player);

    void Update();

    void Use();

    bool IsAction();

}
public enum SpecalSkillDef
{
    Invalid = 0,
    ReflectedLaser = 1,
}