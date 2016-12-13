using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardController : MonoBehaviour {

    public Image tile1;
    public Image tile2;
    public Image tile3;
    public Image tile4;
    public Image tile5;
    public Image tile6;
    public Image tile7;
    public Image tile8;
    public Image tile9;
    public Image tile10;
    public Image tile11;
    public Image tile12;
    public Image tile13;
    public Image tile14;
    public Image tile15;
    public Image tile16;
    public Image tile17;
    public Image tile18;
    public Image tile19;
    public Image tile20;
    public Image tile21;
    public Image tile22;
    public Image tile23;
    public Image tile24;
    public Image tile25;
    public Image tile26;
    public Image tile27;
    public Image tile28;
    public Image tile29;
    public Image tile30;

    public Image prefab;

    private Image[] tiles;

    private int currentTile;
	// Use this for initialization
	void Start () {
        currentTile = 0;
        tiles = new Image[30];

        tiles[1] = tile2;
        tiles[2] = tile3;
        tiles[3] = tile4;
        tiles[4] = tile5;
        tiles[5] = tile6;
        tiles[6] = tile7;
        tiles[7] = tile8;
        tiles[8] = tile9;
        tiles[9] = tile10;
        tiles[10] = tile11;
        tiles[11] = tile12;
        tiles[12] = tile13;
        tiles[13] = tile14;
        tiles[14] = tile15;
        tiles[15] = tile16;
        tiles[16] = tile17;
        tiles[17] = tile18;
        tiles[18] = tile19;
        tiles[19] = tile20;
        tiles[20] = tile21;
        tiles[21] = tile22;
        tiles[22] = tile23;
        tiles[23] = tile24;
        tiles[24] = tile25;
        tiles[25] = tile26;
        tiles[26] = tile27;
        tiles[27] = tile28;
        tiles[28] = tile29;
        tiles[29] = tile30;

    }
	
	// Update is called once per frame
	void Update () {
        onScan();

	}


    public void onScan()
    {
        tile1.sprite = prefab.sprite;
        currentTile++;
    }
}
