using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class AssetBoundTool{

	[MenuItem("Tools/AssetsBound/AllBound")]
	public static void AllBound(){
		Debug.Log ("启动所有的打包");
		BuildPipeline.BuildAssetBundles (Application.dataPath+"/AssetsBundle",BuildAssetBundleOptions.ChunkBasedCompression,BuildTarget.StandaloneWindows64);
	}
	[MenuItem("Tools/AssetsBound/SingleBound")]
	public static void SingleBound(){
		Debug.Log ("打包指定的资源");
		//存储资源包信息的结构体
		AssetBundleBuild build = new AssetBundleBuild ();
		build.assetBundleName="prefabs";
		build.assetBundleVariant="low";
        //存储需要打包的资源的路径
		build.assetNames = new string[]{ "Assets/Resources/Prefabs/cube.prefab"};
		//资源包数组
		AssetBundleBuild[] arr=new AssetBundleBuild[1]{build};
        //打包
		BuildPipeline.BuildAssetBundles (Application.dataPath + "/AssetsBundle", arr, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
	}
	[MenuItem("Tools/AssetsBound/SelectBundle")]
	public static void SelectBundle(){
		Dictionary<string,AssetBundleBuild> assets = new Dictionary<string, AssetBundleBuild> ();
		//获取所有的鼠标选择的对象
		Object[] objList = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);
		//Debug.Log(objList.Length);
		for (var i = 0; i < objList.Length; i++) {
			//Debug.Log (objList[i]);
			//获取该对象的在资源文件夹中的相对路径
			string path=AssetDatabase.GetAssetPath(objList[i]);
			Debug.Log (path);
			//通过路径返回资源设置好的资源包的名字AssetBundleName
			string assetName = AssetImporter.GetAtPath (path).assetBundleName;
			//返回该对象的assetBundleVariant；
			string variant= AssetImporter.GetAtPath (path).assetBundleVariant;
			string key = assetName + "." + variant;
			//Debug.Log (key);
			if (assets.ContainsKey (key)) {
				//原基础更新
				AssetBundleBuild build=assets[key];
				build.assetNames = AppendChild (build.assetNames, path);
				assets [key] = build;
			}else{
				if (key != null && key != ""&&key.Length>1) {
					Debug.Log ("456");
					AssetBundleBuild build = new AssetBundleBuild ();
					build.assetBundleName = assetName;
					build.assetBundleVariant = variant;
					build.assetNames = new string[]{ path };
					assets.Add (key, build);
				} else {
					key = path.Substring (path.LastIndexOf (".") + 1);
					Debug.Log (key);
					if (assets.ContainsKey (key)) {
						//原基础更新
						AssetBundleBuild build=assets[key];
						build.assetNames = AppendChild (build.assetNames, path);
						assets [key] = build;
					}else{
						
						AssetBundleBuild build = new AssetBundleBuild ();
						build.assetBundleName = key;
						build.assetNames = new string[]{ path };
						assets.Add (key, build);
					}

				}
			}
		}
		Debug.Log ("123");
		//启动打包
		AssetBundleBuild[] crr=new AssetBundleBuild[assets.Count];
		assets.Values.CopyTo (crr,0);
		Debug.Log (crr[0].assetBundleName);
		BuildPipeline.BuildAssetBundles (Application.dataPath + "/AssetsBundle", crr, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
	}
	static string[] AppendChild(string[] arr,string value){
		string[] brr = new string[arr.Length + 1];
		for (var i = 0; i < arr.Length; i++) {
			brr [i] = arr [i];
		}
		brr [brr.Length - 1] = value;
		return brr;
	}
}
