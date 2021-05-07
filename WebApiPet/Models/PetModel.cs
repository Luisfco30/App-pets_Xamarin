using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPet.Models
{
    public class PetModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public int Age { get; set; }

        public string ImageBase64 { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public ApiResponse GetAll (string connectionString)
        {
            List<PetModel> list = new List<PetModel>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string tsql = "SELECT * FROM Pet";
                    using (MySqlCommand cmd = new MySqlCommand(tsql, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader()) {

                            while (reader.Read())
                            {
                                list.Add(new PetModel
                                {
                                    ID = int.Parse(reader["ID"].ToString()),
                                    Name = reader["Name"].ToString(),
                                    Breed = reader["Breed"].ToString(),
                                    Age = int.Parse(reader["Age"].ToString()),
                                    ImageBase64 = reader["ImageBase64"].ToString(),
                                    Latitude = double.Parse(reader["Latitude"].ToString()),
                                    Longitude = double.Parse(reader["Longitude"].ToString())
                                });
                            }
                        }
                    }
                 }
                return new ApiResponse
                {
                    IsSucces = true,
                    Message = "Las mascota fueron obtenidas correctamente",
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSucces = false,
                    Message = $"Se genero un error al consultar las mascotas ({ex.Message})",
                    Result = null
                };
            }

        }
        public ApiResponse Get(string connectionString, int id)
        {
            PetModel obj = new PetModel();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string tsql = "SELECT * FROM Pet WERE ID = @ID";
                    using (MySqlCommand cmd = new MySqlCommand(tsql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                obj = new PetModel
                                {
                                    ID = int.Parse(reader["ID"].ToString()),
                                    Name = reader["Name"].ToString(),
                                    Breed = reader["Breed"].ToString(),
                                    Age = int.Parse(reader["Age"].ToString()),
                                    ImageBase64 = reader["ImageBase64"].ToString(),
                                    Latitude = double.Parse(reader["Latitude"].ToString()),
                                    Longitude = double.Parse(reader["Longitude"].ToString())
                                };
                            }
                        }
                    }
                }
                return new ApiResponse
                {
                    IsSucces = true,
                    Message = "La mascota fue obtenida correctamente",
                    Result = obj
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSucces = false,
                    Message = $"Se genero un error al consultar la mascotas ({ex.Message})",
                    Result = null
                };
            }
        }

        public ApiResponse Insert(string connectionString)
        {
            try
            {
                object newID;
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string tsq = "INSERT INTO Pet (Name, Breed, Age, ImageBase64, Latitude, Longitude) VALUES(@Name,@Breed,@Age,@ImageBase64,@Latitude,@Longitude); SELECT LAST_INSERT_ID();";
                    using (MySqlCommand cmd = new MySqlCommand(tsq, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Breed", Breed);
                        cmd.Parameters.AddWithValue("Age", Age);
                        cmd.Parameters.AddWithValue("@ImageBase64", ImageBase64);
                        cmd.Parameters.AddWithValue("@Latitude", Latitude);
                        cmd.Parameters.AddWithValue("@Longitude", Longitude);

                        newID = cmd.ExecuteScalar();
                        if(newID !=null &&  newID.ToString().Length > 0)
                        {
                            return new ApiResponse
                            {
                                IsSucces = true,
                                Message = "La mascota fua agregada correctamente",
                                Result = newID
                            };
                        }
                        else
                        {
                            return new ApiResponse
                            {
                                IsSucces = false,
                                Message = "Se genero un error al insertar mascota",
                                Result = null
                            };
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return new ApiResponse
                {
                    IsSucces = false,
                    Message = $"Se genero un error al insertar mascota ({ex.Message})",
                    Result = null
                };
            }
        }

        public ApiResponse Update(string connectionString)
        {
            try
            {
                object newID;
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string tsq = "UPDATE Pet SET Name=@Name, Breed=@Breed, Age=@Age, ImageBase64=@ImageBase64, Latitude=@Latitude, Longitude=@Longitude WHERE ID = @ID;";
                    using (MySqlCommand cmd = new MySqlCommand(tsq, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Breed", Breed);
                        cmd.Parameters.AddWithValue("Age", Age);
                        cmd.Parameters.AddWithValue("@ImageBase64", ImageBase64);
                        cmd.Parameters.AddWithValue("@Latitude", Latitude);
                        cmd.Parameters.AddWithValue("@Longitude", Longitude);
                        cmd.Parameters.AddWithValue("@ID", ID);
                        newID = cmd.ExecuteNonQuery();
                       
                            return new ApiResponse
                            {
                                IsSucces = true,
                                Message = "La mascota se actualizo correctamente",
                                Result = null
                            };              
                    }
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSucces = false,
                    Message = $"Se genero un error al actualizar la mascota ({ex.Message})",
                    Result = null
                };
            }
        }

        public ApiResponse Delete(string connectionString, int id)
        {
            try
            {
            
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string tsql = "DELETE FROM Pet WHERE ID = @ID;";
                    using (MySqlCommand cmd = new MySqlCommand(tsql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();

                        return new ApiResponse
                        {
                            IsSucces = true,
                            Message = "La mascota se elimino correctamente",
                            Result = null
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSucces = false,
                    Message = $"Se genero un error al eliminar la mascota ({ex.Message})",
                    Result = null
                };
            }
        }
    }
}
