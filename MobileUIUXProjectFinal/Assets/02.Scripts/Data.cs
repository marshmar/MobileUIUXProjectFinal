using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYPE { SHORTSTUDY, LONGSTUDY, SHORTREST, LONGREST}

[CreateAssetMenu(fileName = "NewData", menuName = "Data")]
public class Data : ScriptableObject
{
    public float time;
    public TYPE type;

    // ������ ���纻 �����
    public Data Clone()
    {
        Data clonedData = Instantiate(this);
        clonedData.time = this.time;
        clonedData.type = this.type;
        return clonedData;

    }
}
