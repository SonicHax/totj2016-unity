namespace KEggGameStudio.NFC 
{
	public class DefineNFC {
		/// <summary>
		/// NFC功能狀態
		/// Drive status.
		/// </summary>
		public class DriveStatus
		{
			public const int DEVICE_NOT_SUPPOR_NFC 	= 0;
			public const int NFC_OFF 				= 1;
			public const int NFC_ON					= 2;
		}
		/// <summary>
		/// NFC操作.
		/// </summary>
		public class NFC_Operational
		{
			public const int READ 	= 0;
			public const int WRITE 	= 1;
			public const int CLEAR	= 2;
		}
		/// <summary>
		/// 資料編碼方式.
		/// </summary>
		public class CodingType
		{
			public const string US_ASCII 	= "US-ASCII";
			public const string UTF_8		= "UTF-8";
		}
		/// <summary>
		/// 接收訊息的類型
		/// Receiving message type.
		/// </summary>
		public class ReceivingMsgCommand
		{
			public const int TAG_READ			= 0;
			public const int TAG_WRITE			= 1;
			public const int TAG_CLEAR			= 2;
			public const int JAR_ERROR			= 255;
		}
		/// <summary>
		/// 接收訊息資料結構
		/// Receiving message data structure.
		/// </summary>
		public class ReceivingMsgData
		{
			public const int COMMAND_LENGTH		= 4;
		}
		/// <summary>
		/// Jar函式名稱
		/// Jar fun name.
		/// </summary>
		public class JarFunName
		{
			//	Set
			public const string SetlistenerGameObjectName 		= "SetlistenerGameObjectName";	//	設定jar呼叫到上層指定的GameObject和函式名稱
			public const string SetCodingType 					= "SetCodingType";				//	設定編碼類型
			public const string SetWriteTag 					= "SetWriteTag";				//	設定準備寫入Tag資料
			public const string SetOperational 					= "SetOperational";				//	設定NFC操作
			//	Get
			public const string GetReadTag 						= "GetReadTag";					//	取得最新讀取成功Tag資料
			public const string GetDriveStatus 					= "GetDriveStatus";				//	取得裝置狀態
		}
	}
}