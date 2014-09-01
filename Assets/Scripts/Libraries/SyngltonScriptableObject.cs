using UnityEngine;
using System;

/// <summary>
/// シングルトンでアクセスできるScriptableObject
/// </summary>
public abstract class SyngltonScriptableObject<T> : ScriptableObject where T : SyngltonScriptableObject<T>
{
	/// <summary>
	/// アセットスクリプト
	/// </summary>
    protected static T instance = null;
	
	/// <summary>
	/// アセットスクリプトの取得
	/// </summary>
    public static T Instance
	{
		get
		{
			if (instance == null)
			{
				Type type = typeof(T);
				instance = Resources.Load(type.Name, type) as T;
			}
			return instance;
		}
		// 内海修正 
		set
		{
			if (instance == null )
			{
				Type type = typeof(T);
				instance = Resources.Load(type.Name, type) as T;
			}
			instance = value;
		}
	}
}
