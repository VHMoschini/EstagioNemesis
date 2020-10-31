using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SoundBank_", menuName = "SoundBank")]
public class SoundBank : ScriptableObject
{
    public SoundData shot1;

    public SoundData shot2;
    public SoundData shot3;

    public SoundData takeDamage;
    public SoundData droneFail;

    public SoundData defeatFanfarre;
}
