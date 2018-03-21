using System;
using Service.Model;
using Service.Controllers;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Service.Connector
{
      public class Mysql{
        private string connstring;
        public Mysql()
        {
          
            connstring = @"server=localhost;userid=root;password=kaerkgcd39;database=DB_OpenFace";
        }
        public List<Member> UserList()
        {

            List<Member> allUser = new List<Member>();


            using (MySqlConnection connMysql = new MySqlConnection(connstring))
            {

                using (MySqlCommand cmdd = connMysql.CreateCommand())
                {


                    cmdd.CommandText = "Select * from Member";
                    cmdd.CommandType = System.Data.CommandType.Text;

                    cmdd.Connection = connMysql;

                    connMysql.Open();

                    using (MySqlDataReader reader = cmdd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            allUser.Add(new Member()
                            {
                                Mem_id = reader.GetInt32(reader.GetOrdinal("Mem_id")) ,
                                Mem_em_id = reader.GetString(reader.GetOrdinal("Mem_em_id")),
                                Mem_firstname = reader.GetString(reader.GetOrdinal("Mem_firstname")),
                                Mem_lastname = reader.GetString(reader.GetOrdinal("Mem_lastname")),
                                Mem_id_card = reader.GetString(reader.GetOrdinal("Mem_id_card")),
                                Mem_tel = reader.GetString(reader.GetOrdinal("Mem_tel")),
                                Mem_address = reader.GetString(reader.GetOrdinal("Mem_address")),
                                Mem_images = reader.GetString(reader.GetOrdinal("Mem_images"))
                                // Em_images = reader.GetString(reader.GetOrdinal("Em_images"))
                            });
                        }
                    }
                }

                connMysql.Close();
            }



            return allUser;

        }
        public List<History> HistortList()
        {
             List<History> allHistory = new List<History>();
             using (MySqlConnection connMysql = new MySqlConnection(connstring))
            {
                using (MySqlCommand cmdd = connMysql.CreateCommand())
                {
                    cmdd.CommandText = "Select * from History";
                    cmdd.CommandType = System.Data.CommandType.Text;
                    cmdd.Connection = connMysql;
                    connMysql.Open();
                    using (MySqlDataReader reader = cmdd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            allHistory.Add(new History()
                            {
                                His_id = reader.GetInt32(reader.GetOrdinal("His_id")) ,
                                His_date = reader.GetString(reader.GetOrdinal("His_date")),
                                His_em_id = reader.GetString(reader.GetOrdinal("His_em_id")),
                                His_name = reader.GetString(reader.GetOrdinal("His_name")),
                                His_surname = reader.GetString(reader.GetOrdinal("His_surname")),
                                His_time	 = reader.GetString(reader.GetOrdinal("His_time")),
                            
                            });
                        }
                    }
                }
            }
             return allHistory;
        }
        public string Register(string id,string firstname,string lastname,string card,string tel,string address,string img){
            MySqlConnection conn = new MySqlConnection(connstring);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@firstname", firstname);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@card", card);
            cmd.Parameters.AddWithValue("@tel", tel);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@img", img);
            cmd.CommandText = "INSERT INTO `Member`(`Mem_em_id`, `Mem_firstname`, `Mem_lastname`, `Mem_id_card`, `Mem_tel`, `Mem_address`,`Mem_images`) VALUES (@id,@firstname,@lastname,@card,@tel,@address,@img)";
            cmd.Connection = conn;
            
            conn.Open();
            try {
                int aff = cmd.ExecuteNonQuery();
              
                Console.WriteLine(aff + " rows were affected.");
                return "success";
            }
            catch {
                return "Not success";
            }
            finally {
                conn.Close();
            }

      }
      public string DeleteMember(int id){
            MySqlConnection conn = new MySqlConnection(connstring);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@id", id);
           
            cmd.CommandText = "DELETE FROM `Member` WHERE `Mem_id` = @id";
            cmd.Connection = conn;
            
            conn.Open();
            try {
                int aff = cmd.ExecuteNonQuery();
              
                Console.WriteLine(aff + " rows were affected.");
                return "success";
            }
            catch {
                return "Not success";
            }
            finally {
                conn.Close();
            }
      }
       public string EditMember(int id,string em_id,string firstname,string lastname,string card,string tel,string address){
            MySqlConnection conn = new MySqlConnection(connstring);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@em_id", em_id);
            cmd.Parameters.AddWithValue("@firstname", firstname);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@card", card);
            cmd.Parameters.AddWithValue("@tel", tel);
            cmd.Parameters.AddWithValue("@address", address);
           
            cmd.CommandText = "UPDATE `Member` SET `Mem_em_id`= @em_id,`Mem_firstname`=@firstname,`Mem_lastname`=@lastname,`Mem_id_card`=@card,`Mem_tel`=@tel,`Mem_address`=@address  WHERE `Mem_id`=@id";
            cmd.Connection = conn;
            
            conn.Open();
            try {
                int aff = cmd.ExecuteNonQuery();
              
                Console.WriteLine(aff + " rows were affected.");
                return "success";
            }
            catch {
                return "Not success";
            }
            finally {
                conn.Close();
            }
      }
      public string SaveHistory(int EmId,string Name,string Surname,string Tel,string Date){
            MySqlConnection conn = new MySqlConnection(connstring);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@EmId", EmId);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Surname", Surname);
            cmd.Parameters.AddWithValue("@Tel", Tel);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.CommandText = "INSERT INTO `History`(`His_date`, `His_em_id`, `His_name`, `His_surname`, `His_time`) VALUES (@Date,@EmId,@Name,@Surname,@Date)";
            cmd.Connection = conn;
            
            conn.Open();
            try {
                int aff = cmd.ExecuteNonQuery();
              
                Console.WriteLine(aff + " rows were affected.");
                Console.WriteLine(cmd);
                return "success";
            }
            catch {
                return "Not success";
            }
            finally {
                conn.Close();
            }
           
      }
      public string TestPost(string Mem_em_id){
            MySqlConnection conn = new MySqlConnection(connstring);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@Mem_em_id", Mem_em_id);
            cmd.CommandText = "INSERT INTO `Member`(`Mem_id`, `Mem_em_id`, `Mem_firstname`, `Mem_lastname`, `Mem_id_card`, `Mem_tel`, `Mem_address`, `Mem_images`) VALUES (@Mem_em_id,@Mem_em_id,@Mem_em_id,@Mem_em_id,@Mem_em_id,@Mem_em_id,@Mem_em_id,@Mem_em_id)";
            cmd.Connection = conn;
            conn.Open();
             try {
                int aff = cmd.ExecuteNonQuery();
                return "OK";
            }
            catch {
                return "Not success";
            }
            finally {
                conn.Close();
            }
      }
}
}