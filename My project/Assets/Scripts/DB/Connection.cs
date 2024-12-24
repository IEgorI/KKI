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
    public string[] setConnectionDb()
    {
        string[] result = new string[5];
        path = Application.dataPath + "/StreamingAssets/mydb.bytes";
        dbconnection = new SqliteConnection("Data Source=" + path);
        dbconnection.Open();
        if (dbconnection.State == ConnectionState.Open)
        {
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = dbconnection;
            cmd.CommandText = "SELECT * FROM users WHERE login = @login";
            cmd.Parameters.AddWithValue("@login", GlobalData.userlogin);
            SqliteDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                result[0] = r[3].ToString();
                result[1] = r[4].ToString();
                result[2] = r[5].ToString();
                result[3] = r[6].ToString();
                result[4] = r[7].ToString();
            }
            return result;
        }
        else
        {
            Debug.Log("Error connection!");
            return result;
        }
    }

    public void updateConnectionDb(int money)
    {
        path = Application.dataPath + "/StreamingAssets/mydb.bytes";
        dbconnection = new SqliteConnection("Data Source=" + path);
        dbconnection.Open();
        if (dbconnection.State == ConnectionState.Open)
        {
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = dbconnection;
            cmd.CommandText = "UPDATE users SET coins = @money, prov1 = @proverka1, prov2 = @proverka2, prov3 = @proverka3, prov4 = @proverka4 WHERE login = @login";
            cmd.Parameters.AddWithValue("@money", money);
            cmd.Parameters.AddWithValue("@proverka1", GlobalData.prov1);
            cmd.Parameters.AddWithValue("@proverka2", GlobalData.prov2);
            cmd.Parameters.AddWithValue("@proverka3", GlobalData.prov3);
            cmd.Parameters.AddWithValue("@proverka4", GlobalData.prov4);
            cmd.Parameters.AddWithValue("@login", GlobalData.userlogin);
            cmd.ExecuteNonQuery();
        }
        else
        {
            Debug.Log("Error connection!");
        }
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
                if ((r[1].ToString() == logText.text && r[2].ToString() == passText.text) && (logText.text != "" && passText.text != ""))
                {
                    SceneManager.LoadScene("Menu");
                    GlobalData.userlogin = logText.text;
                    GlobalData.coins = int.Parse(r[7].ToString());
                    GlobalData.prov1 = Convert.ToBoolean(int.Parse(r[3].ToString()));
                    GlobalData.prov2 = Convert.ToBoolean(int.Parse(r[4].ToString()));
                    GlobalData.prov3 = Convert.ToBoolean(int.Parse(r[5].ToString()));
                    GlobalData.prov4 = Convert.ToBoolean(int.Parse(r[6].ToString()));
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
                if ((r[1].ToString() == logText.text && r[2].ToString() == passText.text) && logText.text != null)
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
                error.text = "Данный пользователь уже зарегестрирован";
                error.color = Color.red;
                dbconnection.Close();
            }
            else
            {
                bool prov1Sql = false;
                bool prov2Sql = false;
                bool prov3Sql = false;
                bool prov4Sql = false;
                int coins = 1000;
                cmd.CommandText = $"INSERT INTO users (login, password, prov1, prov2, prov3, prov4, coins) VALUES (@mail, @pass, @prov1, @prov2, @prov3, @prov4, @coins)";
                cmd.Parameters.Add(new SqliteParameter("@mail", email));
                cmd.Parameters["@mail"].Value = email;
                cmd.Parameters.Add(new SqliteParameter("@pass", pass));
                cmd.Parameters["@pass"].Value = pass;
                cmd.Parameters.Add(new SqliteParameter("@prov1", prov1Sql));
                cmd.Parameters["@prov1"].Value = prov1Sql;
                cmd.Parameters.Add(new SqliteParameter("@prov2", prov2Sql));
                cmd.Parameters["@prov2"].Value = prov2Sql;
                cmd.Parameters.Add(new SqliteParameter("@prov3", prov3Sql));
                cmd.Parameters["@prov3"].Value = prov3Sql;
                cmd.Parameters.Add(new SqliteParameter("@prov4", prov4Sql));
                cmd.Parameters["@prov4"].Value = prov4Sql;
                cmd.Parameters.Add(new SqliteParameter("@coins", coins));
                cmd.Parameters["@coins"].Value = coins;
                cmd.ExecuteNonQuery();
                error.text = "Регистрация успешна!";
                error.color = Color.green;
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
