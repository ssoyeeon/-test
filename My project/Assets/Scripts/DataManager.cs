using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public Dictionary<int, StatData> stat = new Dictionary<int, StatData>();
    public HashSet<BulletController> Bullets = new HashSet<BulletController>();
    public StatData Setting(bool _isPlayer, int _max, int _current, int _bulletDMG, int _bulletLV, int _moveSPD)
    {
        StatData _data = new StatData();
        _data.maxHp = _max;
        _data.currentHp = _current;
        _data.bulletDamage = _bulletDMG;
        _data.bulletLevel = _bulletLV;
        _data.moveSpeed = _moveSPD;
        if (_isPlayer)
        {
            Init(_data, 0);
        }
        else
        {
            Init(_data, stat.Count);
        }
        return _data;

    }

    public void Init(StatData _data, int CreatureNumber)
    {
        if(stat.ContainsKey(CreatureNumber))
        {
            if (stat[CreatureNumber] == _data)
            {
            }
            else
            {
                Debug.LogWarning($"이미 있음 {CreatureNumber}를 가진 몬스터가 데이터에 하지만 번호가 달라요");
                Init(_data, CreatureNumber+1);
            }
        }
        else
        {
            stat.Add(CreatureNumber, _data);
        }
    }
}

public class StatData
{
    public float maxHp;
    public float currentHp;
    public int bulletDamage;
    public int bulletLevel;
    public int moveSpeed;
}
