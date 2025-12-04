using LojaRio40.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Data;

namespace LojaRio40.Controllers
{
    public class ClienteController : Controller
    {
        

        private readonly IConfiguration _configuration;
        public ClienteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Listar()
        {
            List<Cliente> cliente = new List<Cliente>();
            using (var conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                conn.Open();
                string sql = "Select * from cliente ";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                conn.Close();
                foreach (DataRow row in dataTable.Rows)
                {
                    cliente.Add(
                        new Cliente
                        {
                            CPF = row["CPF"].ToString(),
                            Nome = row["Nome"].ToString(),
                            Endereco = row["Endereco"].ToString()
                        });


                }
                return View(cliente);
            }





        }

        public IActionResult Editar(string id)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "select * from cliente where CPF=@CPF";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CPF", id);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlDataReader reader;
            Cliente cliente = new Cliente();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                cliente.CPF = Convert.ToString(reader["CPF"]);
                cliente.Nome = Convert.ToString(reader["Nome"]);
                cliente.Endereco = Convert.ToString(reader["Endereco"]);

            }

            return View(cliente);

        }
        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "update cliente set Nome=@Nome, Endereco=@Endereco where CPF=@CPF";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", cliente.Nome);
            command.Parameters.AddWithValue("@Endereco", cliente.Endereco);
            command.Parameters.AddWithValue("@CPF", cliente.CPF);

            command.ExecuteNonQuery();

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "INSERT INTO cliente (CPF, Nome, Endereco) VALUES (@CPF, @Nome, @Endereco)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CPF", cliente.CPF);
            command.Parameters.AddWithValue("@Nome", cliente.Nome);
            command.Parameters.AddWithValue("@Endereco", cliente.Endereco);
            command.ExecuteNonQuery();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Deletar(string id)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "Delete from cliente where CPF = @CPF";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CPF", id);

            command.ExecuteNonQuery();

            return RedirectToAction("Index", "Home");
        }


    }
}

