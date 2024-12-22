using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYPE { SHORTSTUDY, LONGSTUDY, SHORTREST, LONGREST}

[CreateAssetMenu(fileName = "NewData", menuName = "Data")]
public class Data : ScriptableObject
{
    public float time;
    public TYPE type;

    // 데이터 복사본 만들기
    public Data Clone()
    {
        Data clonedData = Instantiate(this);
        clonedData.time = this.time;
        clonedData.type = this.type;
        return clonedData;

    }
}
