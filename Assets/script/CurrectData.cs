using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create EnemyData")]
public class CurrectData : ScriptableObject
{
	public string[] CurrectDirection = new string[4];
	public int[] CurrectNum = new int[4];
}
