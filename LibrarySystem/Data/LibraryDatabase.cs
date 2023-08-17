using LibrarySystem.Exceptions;
using LibrarySystem.Data;
using LibrarySystem.Models;
using MySqlConnector;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace LibrarySystem.Data;

public class LibraryDatabase : Book
{
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;
    public LibraryDatabase()
    {
        Initialize();
    }

    private void Initialize()
    {
        server = "localhost";
        database = "librarydb";
        uid = "root";
        password = "password";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        connection = new MySqlConnection(connectionString);
    }

    //open connection to database
    private bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            switch (ex.Number)
            {
                case 0:
                    Console.WriteLine("Cannot connect to server.  Contact administrator");
                    break;
                case 1045:
                    Console.WriteLine("Invalid username/password, please try again");
                    break;

            }
            return false;
        }
    }
    //Close connection
    private bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    //select statement
    public List<Book> Select()
    {
        string query = "SELECT * FROM books";

        //Create a list to store the result
        List<Book> list = new List<Book>();

        //Open connection
        if (this.OpenConnection() == true)
        {
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                list.Add(new Book(dataReader["title"].ToString(), dataReader["isbn"].ToString(), dataReader["author_fn"].ToString(), dataReader["author_ln"].ToString(), dataReader["publisher"].ToString(), dataReader["genre"].ToString()));
            }

            //close Data Reader
            dataReader.Close();

            //close Connection
            this.CloseConnection();

            //return list to be displayed
            return list;
        }
        else // if connection is not open 
        {
            throw new ConnectionNotFound();
        }
    }

}
