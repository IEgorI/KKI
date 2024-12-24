using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;
public class Connection : MonoBehaviour
{
    public SqliteConnection dbconnection;
    // Start is called before the first frame update
    private  string path;
    public InputField logText;
    public InputField passText;
    public Text error;
    public Button logBtn;
    public Button regBtn;
    //private float t = 0;
    //private float tmax = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //t = t + Time.deltaTime;
        //if (t >= tmax)
        //{
        //    error.text = "";
        //}
    }
    public void setConnection()
    {
        path = Application.dataPath + "/StreamingAssets/mydb.bytes";
        dbconnection = new SqliteConnection("Data Source=" + path);
        dbconnection.Open();
        if (dbconnection.State == ConnectionState.Open)
        {
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = dbconnection;
            cmd.CommandText = "SELECT * FROM users";
            SqliteDataReader r = cmd.ExecuteReader();
            int i = 0;
            int wrong = 0;
            while (r.Read())
            {
                i++;
                if (r[1].ToString() == logText.text && r[2].ToString() == passText.text)
                {
                    SceneManager.LoadScene("Menu");
                    break;
                }
                else
                {
                    //t = 0;
                    wrong++;
                }
            }
            if (i == wrong)
            {
                error.text = "Неверный логин или пароль!";
                error.color = Color.red;
                Debug.Log("Неверный логин или пароль!");
                i = 0;
                wrong = 0;
            }
        }
        else
        {
            Debug.Log("Error connection!");
        }
    }
    public bool proverka(string pochta, string password)
    {
        path = Application.dataPath + "/StreamingAssets/mydb.bytes";
        dbconnection = new SqliteConnection("Data Source=" + path);
        dbconnection.Open();
        if (dbconnection.State == ConnectionState.Open)
        {
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = dbconnection;
            cmd.CommandText = "SELECT * FROM users";
            SqliteDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                if (r[1].ToString() == logText.text && r[2].ToString() == passText.text)
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            return true;
        }
    }
    public void setRecord()
    {
        path = Application.dataPath + "/StreamingAssets/mydb.bytes";
        dbconnection = new SqliteConnection("Data Source=" + path);
        dbconnection.Open();
        if (dbconnection.State == ConnectionState.Open)
        {
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = dbconnection;
            string email = logText.text;
            string pass = passText.text;
            if (!proverka(email, pass))
            {
                Debug.Log("Error connection! Cod:1");
                dbconnection.Close();
            }
            else
            {
                cmd.CommandText = $"INSERT INTO users (login, password) VALUES (@mail, @pass)";
                cmd.Parameters.Add(new SqliteParameter("@mail", email));
                cmd.Parameters["@mail"].Value = email;
                cmd.Parameters.Add(new SqliteParameter("@pass", pass));
                cmd.Parameters["@pass"].Value = pass;
                cmd.ExecuteNonQuery();
                Debug.Log(cmd.CommandText);
            }
        }
        else
        {
            Debug.Log("Error connection!");
        }

        //CREATE TABLE users(
        //    id INTEGER PRIMARY KEY AUTOINCREMENT,
        //    login VARCHAR(50),
        //    password VARCHAR(50));
    }
}
