using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeBookHome
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConectareBazaDate db;
            db = new ConectareBazaDate();

            using (db.connection)
            {
                SqlCommand command;
                string[] fileData;
                int rows = -1;

                command = new SqlCommand
                {
                    Connection = db.connection,
                    CommandType = CommandType.Text,
                    CommandText = "SELECT COUNT(email) FROM Utilizator"
                };

                db.connection.Open();
                rows = (int)command.ExecuteScalar();
                db.connection.Close();

                if(rows == 0)
                {
                    command = new SqlCommand()
                    {
                        Connection = db.connection,
                        CommandType = CommandType.Text,
                        CommandText = "INSERT INTO Utilizator(email, parola, nume, prenume) VALUES(@Email, @Pass,@USirName, @UName)"
                    };

                    fileData = File.ReadAllLines("resources\\utilizatori.txt");

                    for(int i=0; i < fileData.Length; i++)
                    {
                        string[] items = fileData[i].Split(new char[] { '*' });
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@Email", items[0]);
                        command.Parameters.AddWithValue("@Pass", items[1]);
                        command.Parameters.AddWithValue("@USirName", items[2]);
                        command.Parameters.AddWithValue("@UName", items[3]);

                        try
                        {
                            db.connection.Open();
                            command.ExecuteNonQuery();
                            db.connection.Close();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }

                }

                rows = -1;
                command = new SqlCommand
                {
                    Connection = db.connection,
                    CommandType = CommandType.Text,
                    CommandText = "SELECT COUNT(titlu) FROM Carti"
                };


                db.connection.Open();
                rows = (int)command.ExecuteScalar();
                db.connection.Close();

                if (rows == 0)
                {
                    command = new SqlCommand()
                    {
                        Connection = db.connection,
                        CommandType = CommandType.Text,
                        CommandText = "INSERT INTO Carti(titlu, autor, gen) VALUES(@Title, @Auth, @Genre)"
                    };

                    fileData = File.ReadAllLines("resources\\carti.txt");

                    for (int i = 0; i < fileData.Length; i++)
                    {
                        string[] items = fileData[i].Split(new char[] { '*' });
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@Title", items[0]);
                        command.Parameters.AddWithValue("@Auth", items[1]);
                        command.Parameters.AddWithValue("@Genre", items[2]);

                        try
                        {
                            db.connection.Open();
                            command.ExecuteNonQuery();
                            db.connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }

                }

                rows = -1;
                command = new SqlCommand

                {
                    Connection = db.connection,
                    CommandType = CommandType.Text,
                    CommandText = "SELECT COUNT(email) FROM Imprumuturi"
                };

                db.connection.Open();
                rows = (int)command.ExecuteScalar();
                db.connection.Close();

                if (rows == 0)
                {
                    command = new SqlCommand()
                    {
                        Connection = db.connection,
                        CommandType = CommandType.Text,
                        CommandText = "INSERT INTO Imprumuturi(id_carte, email, data_imprumut) VALUES(@Book_Id, @Email, @Date)"
                    };

                    fileData = File.ReadAllLines("resources\\imprumuturi.txt");

                    for (int i = 0; i < fileData.Length; i++)
                    {
                        string[] items = fileData[i].Split(new char[] { '*' });

                        SqlCommand getId = new SqlCommand
                        {
                            Connection = db.connection,
                            CommandType = CommandType.Text,
                            CommandText = "SELECT id_carte FROM Carti WHERE titlu=@Title"
                        };

                        getId.Parameters.Clear();
                        getId.Parameters.AddWithValue("@Title", items[0]);

                        db.connection.Open();
                        int Book_Id = (int)getId.ExecuteNonQuery();
                        db.connection.Close();

                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@Book_Id", Book_Id);
                        command.Parameters.AddWithValue("@Email", items[1]);
                        command.Parameters.AddWithValue("@Date", items[2]);

                        try
                        {
                            db.connection.Open();
                            command.ExecuteNonQuery();
                            db.connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }

                }

            }

            Application.Run(new FreeBookHome());
        }
    }
}
