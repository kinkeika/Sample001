using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UserCoreHydriteConst : SyngltonScriptableObject<UserCoreHydriteConst> {


	//コアハイドライト減算表
    [Serializable]
	public class SubtractionCoreHydriteMaster 
	{
		/// <summary>
		/// 経過時間
		/// </summary>
		public int ElapsedTime;

		/// <summary>
		/// 減算するコアハイドライトのパーセンテージ
		/// </summary>
		public int Subtraction;
	}

	/// <summary>
	/// コアハイドライト減算表
	/// コアハイドライトは「プレイしていないと減る」
	/// ログアウト後3時間毎にログアウト時に所持していたコアハイドライトから減算する
	/// </summary>
	[SerializeField]
	public List<SubtractionCoreHydriteMaster> subtractionCoreHydriteList = new List<SubtractionCoreHydriteMaster> ();


	/// <summary>
	/// レベルマスターレベル情報を取得
	/// </summary>
	/// <returns>レベルマスターレベル情報の一覧</returns>
	public static List<SubtractionCoreHydriteMaster> GetSubtractionCoreHydrite()
	{
		List<SubtractionCoreHydriteMaster> list = new List<SubtractionCoreHydriteMaster>();
		foreach(SubtractionCoreHydriteMaster data in Instance.subtractionCoreHydriteList)
		{
			list.Add(data);
		}
		return list;
	}
}
