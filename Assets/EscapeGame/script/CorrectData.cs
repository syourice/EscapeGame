using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create EnemyData")]
public class CorrectData : ScriptableObject
{
	public string[] CorrectDirection = new string[4];
	public int[] CorrectNum = new int[4];
}
