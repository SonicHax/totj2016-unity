using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using KEggGameStudio.NFC;

public class Example_EgNFC_Demo : MonoBehaviour {

	// NFC Android Plugin
	private string ReceivingFunName = "OnReceivingMsg"; //  Receive function Name

	// Demo UI
	private Text mText_ReceivingMsg;
	private Text mText_Status;
	private Button mBtn_Write;
	private Button mBtn_Read;
	private Button mBtn_Start;
	private InputField mInput_Info;

	void Awake ()   {   
		mText_ReceivingMsg = transform.Find("Panel_ReceivingMsg/Text").GetComponent<Text>();
		mText_Status = transform.Find("Panel_Status/Text_Status").GetComponent<Text>();
		mBtn_Write = transform.Find("Btn_Read").GetComponent<Button>();
		mBtn_Read = transform.Find("Btn_Write").GetComponent<Button>();
		mInput_Info = transform.Find("InputField").GetComponent<InputField>();
	} 

	#region  Click Event
	public void OnClick_Init() {
		Init_NFC();
		// Default Status
		mText_Status.text = "Read";
	}
	
	public void OnClick_Read() {
		NFC_Mgr.Self.SetOperational(DefineNFC.NFC_Operational.READ);
		mText_Status.text = "Read";
	}

	public void OnClick_Write() {
		NFC_Mgr.Self.SetOperational(DefineNFC.NFC_Operational.WRITE);
		NFC_Mgr.Self.WriteTagData(mInput_Info.text);
		mText_Status.text = "Write";
	}

	public void OnClick_Clear() {
		NFC_Mgr.Self.SetOperational(DefineNFC.NFC_Operational.CLEAR);
		mText_Status.text = "Clear";
	}

	public void OnClick_CodeType1() {
		NFC_Mgr.Self.SetCodingType(DefineNFC.CodingType.UTF_8);
	}

	public void OnClick_CodeType2() {
		NFC_Mgr.Self.SetCodingType(DefineNFC.CodingType.US_ASCII);
	}
	#endregion

	/// <summary>
	/// 初始化NFC元件
	/// Inits the NFC.
	/// </summary>
	private void Init_NFC() {
		NFC_Mgr.Self.SetCodingType(DefineNFC.CodingType.US_ASCII);
		NFC_Mgr.Self.SetOperational(DefineNFC.NFC_Operational.READ);
		NFC_Mgr.Self.SetListener(this.gameObject, ReceivingFunName);
	}
	/// <summary>
	/// 註冊送出後回傳成功訊息.
	/// Listen Regist cell back.
	/// </summary>
	private void OnReceivingMsg(string str) {
		//	string lenght is less than to command length. 資料長度如果小於命令長度.
		if(str.Length < DefineNFC.ReceivingMsgData.COMMAND_LENGTH) { Debug.LogError("ReceivingMsgData Length < COMMAND_LENGTH."); return;}
		//	Get command. 取得命令.
		int _ReceivingMsgCommand = Convert.ToInt32(str.Substring(0, DefineNFC.ReceivingMsgData.COMMAND_LENGTH));
		//	Get call back Information. 取得資訊.
		string _ReceivingMsgData = str.Substring(DefineNFC.ReceivingMsgData.COMMAND_LENGTH, str.Length - DefineNFC.ReceivingMsgData.COMMAND_LENGTH);  
		//  According command to do somthing. 依照命令做某件事.
		switch(_ReceivingMsgCommand)
		{
		case DefineNFC.ReceivingMsgCommand.TAG_READ:
			mText_ReceivingMsg.text = "Read tag data: " + _ReceivingMsgData;
			break;
		case DefineNFC.ReceivingMsgCommand.TAG_WRITE:
			mText_ReceivingMsg.text = "Write tag data Succeeded";
			break;
		case DefineNFC.ReceivingMsgCommand.TAG_CLEAR:
			mText_ReceivingMsg.text = "Clear tag data succeeded";
			break;
		case DefineNFC.ReceivingMsgCommand.JAR_ERROR:
			mText_ReceivingMsg.text = "Jar error msg: " + _ReceivingMsgData;
			break;
		default:
			Debug.LogError("Can't found ReceivingMsgCommand. ReceivingMsgCommand: " + _ReceivingMsgCommand);
			break;
		}
	}
}