using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.SqliteClient;

public class BDDController : MonoBehaviour //esto tiene que estar en la primera escena en un objeto unico. no se puede poner en dos objetos
{

    private SqliteConnection connection;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        connection = new SqliteConnection("URI=file:" + Application.dataPath + "/BDD/GradiusData.db");
    }

    public void ConnectDataBase(int score, int room, string player)
    {
        connection.Open();
        string uploadPTS = "INSERT INTO Score (Points,Room,Player) VALUES (" + score + "," + room + "," + player + ");";
        SqliteCommand cmd = new SqliteCommand(uploadPTS, connection);
        cmd.ExecuteNonQuery();
        connection.Close();
    }

}
