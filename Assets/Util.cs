using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Util
{

	//	数字 {01 ~ 09} 表示  {1 ~ 9} 筒
	//
	//	数字 {11 ~ 19} 表示  {1 ~ 9} 条
	//
	//	数字 {21 ~ 29} 表示  {1 ~ 9} 万
	//
	//	数字 {31 33 35 37 } 表示 { 东 南 西 北 }
	//
	//	数字 {41 43 45} 表示 {中 發 白}

	public static bool IsCanHU (List<int> mah, int ID)
	{
		List<int> pais = new List<int> (mah);

		pais.Add (ID);
		//只有两张牌（单钓将，其他为鸣牌）
		if (pais.Count == 2) {
			return pais [0] == pais [1];
		}

		//先排序(排序不影响FindAll方法,主要目的是确保排头是顺子或刻子的第一张,这样就可以剔除123333这种情况)
		pais.Sort ();

		//依据牌的顺序从左到右依次分出将牌
		for (int i = 0; i < pais.Count; i++) {
			Debug.Log (pais [i]);
			List<int> paiT = new List<int> (pais);
			List<int> ds = pais.FindAll (delegate (int d) {
				return pais [i] == d;
			});

			//判断是否能做将牌(暴力尝试将头)
			if (ds.Count >= 2) {
				Debug.Log ("将头是：" + ds [0]);
				//移除两张将牌
				paiT.Remove (pais [i]);
				paiT.Remove (pais [i]);

				//避免重复运算 将光标移到其他牌上(注意一定要-1，这里源代码错了)
				i += (ds.Count - 1);

				if (HuPaiCheck (paiT)) {
					Debug.Log ("胡牌");
					return true;
				} else {
					Debug.Log ("没胡");
				}
			}
		}
		return false;
	}

	/// <summary>
	/// 用递归判断牌型是否构成胡牌（已经不包括将头）
	/// </summary>
	/// <returns><c>true</c>, if pai pan din was hued, <c>false</c> otherwise.</returns>
	/// <param name="mahs">Mahs.</param>
	private static bool HuPaiCheck (List<int> mahs)
	{
		if (mahs.Count == 0) {
			return true;
		}

		List<int> fs = mahs.FindAll (delegate (int a) {
			return mahs [0] == a;
		});
			
		if (fs.Count == 3) {//组成克子
			mahs.Remove (mahs [0]);
			mahs.Remove (mahs [0]);
			mahs.Remove (mahs [0]);

			return HuPaiCheck (mahs);
		} else { //组成顺子
			if (mahs.Contains (mahs [0] + 1) && mahs.Contains (mahs [0] + 2)) {
				mahs.Remove (mahs [0] + 2);
				mahs.Remove (mahs [0] + 1);
				mahs.Remove (mahs [0]);

				return HuPaiCheck (mahs);
			}

			return false;
		}
	}
}
