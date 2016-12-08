using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.States;
using UnityEngine.SceneManagement;
using Assets.Scripts.Model;

public class HostController : MonoBehaviour {

    public Text roomName;
    public Dropdown players;
    public Room room;
    public Text error;

	// Use this for initialization
	void Start () {
        room = new Room();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreateLobby()
    {
        if (roomName.text != "")
        {
            string roomID = SQL.Instance.getData("select roomID as result from room where name = '" + roomName.text + "' and active = 'true'");
            Debug.Log(roomID);
            if (roomID != "TRUE")
            {
                error.text = "Deze kamernaam is al in gebruik";
            }
            else
            {
                room.name = roomName.text;
                room.players = players.value;
                room.active = "true";
                room.host = PlayerState.id;
                room.host = 1;

                RoomState.name = room.name;
                RoomState.players = room.players;
                RoomState.active = "true";
                RoomState.host = PlayerState.id;

                SQL.Instance.getData("INSERT INTO `room`(`name`, `active`, `players`, `host`, `started`) VALUES ('" + room.name + "', 'true', " + room.players + "," + room.host + ", 'false')");
                int.TryParse(SQL.Instance.getData("select max(roomID) as result from room"), out RoomState.id);

                SQL.Instance.getData("UPDATE `account` SET `roomID`= " + RoomState.id + " WHERE accountID = '" + PlayerState.id + "'");
                SceneManager.LoadScene("lobby");
            }
        }
    }
}
