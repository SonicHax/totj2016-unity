using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace KEggGameStudio.NFC
{
	public class NFC_Mgr : MonoBehaviour {
        public Text text;
        
		private const string UnityActivityClassName	= "com.unity3d.player.UnityPlayer";

		public static NFC_Mgr Self { get { return _Self;}}
		//	是否顯示Log在Unity Console.
		public static bool IsShowLog = false;

		private static NFC_Mgr _Self;
		private static AndroidJavaObject EgNfCJavaObject;

		void Awake()
		{
			_Self = this;
			_Self.Init();
		}

		#region Call Jar Fun
		/// <summary>
		/// 初始化
		/// Init this instance.
		/// </summary>
		private void Init() {
            if (Application.isEditor)
            {
                Debug.LogWarning("You have to be tested NFC on the entity.");
                return;
            }
			AndroidJavaClass jc = new AndroidJavaClass(UnityActivityClassName); 
			EgNfCJavaObject = jc.GetStatic<AndroidJavaObject>("currentActivity");
            text.text = "init succesfull";
		}
		/// <summary>
		/// Get the NFC drive status.
		/// </summary>
		public int GetNFC_DriveStatus() {
			int _DriveStatus = EgNfCJavaObject.Call<int>(DefineNFC.JarFunName.GetDriveStatus);
			string JavaLog = "";
			switch(_DriveStatus)
			{
			case DefineNFC.DriveStatus.DEVICE_NOT_SUPPOR_NFC:
				JavaLog = "This device doesn't support NFC.";
				break;
			case DefineNFC.DriveStatus.NFC_OFF:
				JavaLog = "NFC Off.";
				break;
			case DefineNFC.DriveStatus.NFC_ON:
				JavaLog = "NFC On.";
				break;
			default:
				JavaLog = string.Format("Can't found DriveStatus. DriveStatus: {0}", _DriveStatus);
				break;
			}
			EgDebugLog("GetNFC_DriveStatus JavaLog: " + JavaLog);
			return _DriveStatus;
		}
		/// <summary>
		/// 設定針對 Tag 處理狀態
		/// Sets the status.
		/// </summary>
		public void SetOperational(int _Operational) {
			EgNfCJavaObject.Call(DefineNFC.JarFunName.SetOperational, ToObjects(_Operational));
		}
		/// <summary>
		/// 讀取 Tag 裡面的資料
		/// Get the tag data.
		/// </summary>
		public string ReadTagData() {
			string sReadTag = EgNfCJavaObject.Call<string>(DefineNFC.JarFunName.GetReadTag);
			EgDebugLog("GetTagData JavaLog: " + sReadTag);
			return sReadTag;
		}
		/// <summary>
		/// 將資料寫入 Tag 裡面
		/// Write the specified NFC_Info.
		/// </summary>
		public void WriteTagData(string NFC_Info) {
			EgNfCJavaObject.Call(DefineNFC.JarFunName.SetWriteTag, ToObjects(NFC_Info));
		}
		/// <summary>
		/// 設定資料寫入和讀取Tag編碼方式
		/// Sets the type of the coding.  _CodingType ex: "UTF-8", "US-ASCII" ..etc
		/// </summary>
		public void SetCodingType(string _CodingType) {
			EgNfCJavaObject.Call(DefineNFC.JarFunName.SetCodingType, ToObjects(_CodingType));
		}
		/// <summary>
		/// 設定監聽的GameObject.
		/// Set Listener cell Gameobject.
		/// </summary>
		public void SetListener(GameObject obj, string _ReceivingFunName) {
			EgNfCJavaObject.Call(DefineNFC.JarFunName.SetlistenerGameObjectName, ToObjects(obj.name, _ReceivingFunName));
		}
		#endregion

		#region EG NFC Log
		private void EgDebugLog( string Log) { if(IsShowLog) Debug.Log(Log);}
		private void EgDebugLogWarning( string Log) { if(IsShowLog) Debug.LogWarning(Log);}
		private void EgDebugLogError( string Log) { if(IsShowLog) Debug.LogError(Log);}
		#endregion

		/// <summary>
		/// 參數轉換參數集合
		/// Tos the objects.
		/// </summary>
		private object[] ToObjects(object arg1, object arg2 = null, object arg3 = null) {
			int nCount = 0;

			if(arg1 != null) nCount++;
			if(arg2 != null) nCount++;
			if(arg3 != null) nCount++;
			if(nCount == 0) return null;

			object[] m_objects = new object[nCount];

			if(arg1 != null) m_objects[0] = arg1;
			if(arg2 != null) m_objects[1] = arg2;
			if(arg3 != null) m_objects[2] = arg3;

			return m_objects;
		}
	}
}