using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYPE { SHORTSTUDY, LONGSTUDY, SHORTREST, LONGREST}
public class Data : MonoBehaviour
{
    public float time;
    public TYPE type;

    public void DestroyThisObject()
    {
        Destroy(this.gameObject);
    }
}
