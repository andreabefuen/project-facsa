using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager_MM : MonoBehaviour {
    public static int AIScore /*{ get; set; }*/, DBScore, DESScore, DDScore, ERScore, FAScore, FANScore, FILScore, ODScore, PLAScore, PGScore, SDScore, TFQScore,IOScore;
    
    public GameObject AI_SGO, DB_SGO, DES_SGO, DD_SGO, ER_SGO, FA_SGO, FAN_SGO, FIL_SGO, OD_SGO, PLA_SGO, PG_SGO, SD_SGO, TFQ_SGO, IO_SGO;
    private Text AI_SText, DB_SText, DES_SText, DD_SText, ER_SText, FA_SText, FAN_SText, FIL_SText, OD_SText, PLA_SText, PG_SText, SD_SText, TFQ_SText, IO_SText;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        AI_SText = AI_SGO.GetComponent<Text>();
        DB_SText = DB_SGO.GetComponent<Text>();
        DES_SText = DES_SGO.GetComponent<Text>();
        DD_SText = DD_SGO.GetComponent<Text>();
        ER_SText = ER_SGO.GetComponent<Text>();
        FA_SText = FA_SGO.GetComponent<Text>();
        FAN_SText = FAN_SGO.GetComponent<Text>();
        FIL_SText = FIL_SGO.GetComponent<Text>();
        OD_SText = OD_SGO.GetComponent<Text>();
        PLA_SText = PLA_SGO.GetComponent<Text>();
        PG_SText = PG_SGO.GetComponent<Text>();
        SD_SText = SD_SGO.GetComponent<Text>();
        TFQ_SText = TFQ_SGO.GetComponent<Text>();
        TFQ_SText = TFQ_SGO.GetComponent<Text>();
        IO_SText = IO_SGO.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update () {
        AI_SText.text = "Record: " + AIScore;
        DB_SText.text = "Record: " + DBScore;
        DES_SText.text = "Record: " + DESScore;
        DD_SText.text = "Record: " + DDScore;
        ER_SText.text = "Record: " + ERScore;
        FA_SText.text = "Record: " + FAScore;
        FAN_SText.text = "Record: " + FANScore;
        FIL_SText.text = "Record: " + FILScore;
        OD_SText.text = "Record: " + ODScore;
        PLA_SText.text = "Record: " + PLAScore;
        PG_SText.text = "Record: " + PGScore;
        SD_SText.text = "Record: " + SDScore;
        TFQ_SText.text = "Record: " + TFQScore;
        IO_SText.text = "Record: " + IOScore;
    }
}
