using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBulletPool : MonoBehaviour
{
    [SerializeField] BulletBase _bullet = default;
    [SerializeField] int _createLimit = 10;

    List<BulletBase> _bulletList;

    private void Awake()
    {
        Debug.Log(this + " : CreatePoolを開始");
        CreatePool();
    }

    void CreatePool()
    {
        _bulletList = new List<BulletBase>();

        for(int i = 0; i < _createLimit; i++)
        {
            var bu = CreateBullet();
            bu.gameObject.SetActive(false);
            _bulletList.Add(bu);
        }

        Debug.Log(this + $" : {_createLimit}個生成終了");
    }
    BulletBase CreateBullet()
    {
        return Instantiate(_bullet, this.transform.position, Quaternion.identity, this.transform);
    }
    public BulletBase GetBullet()
    {
        foreach(var obj in _bulletList)
        {
            if(!obj.gameObject.activeSelf)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        var bu = CreateBullet();
        _bulletList.Add(bu);

        return bu;
    }
}
