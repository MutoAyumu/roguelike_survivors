using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// オブジェクトプールのインターフェース
/// </summary>
public interface IObjectPool
{
    bool IsActive { get; }
    void DisactiveForInstantiate();
    void Create();
    void Create(EnemyStatus status);
    void Destroy();
}
