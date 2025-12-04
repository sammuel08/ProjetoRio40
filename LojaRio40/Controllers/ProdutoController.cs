using LojaRio40.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace LojaRio40.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IConfiguration _configuration;
        public ProdutoController(IConfiguration configuration)
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
            List<Produto> produtos = new List<Produto>();
            using (var conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                conn.Open();
                string sql = "Select * from produto ";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                conn.Close();
                foreach (DataRow row in dataTable.Rows)
                {
                    produtos.Add(
                        new Produto
                        {
                            Prodid = Convert.ToInt32(row["Prodid"]),
                            Prodnome = row["Prodnome"].ToString(),
                            Proddescr = row["Proddescr"].ToString()
                        });


                }
                return View(produtos);
            }





        }

        public IActionResult Editar(int id)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "select * from produto where Prodid=@Prodid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Prodid", id);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlDataReader reader;
            Produto produto = new Produto();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                produto.Prodid = Convert.ToInt32(reader["Prodid"]);
                produto.Prodnome = Convert.ToString(reader["Prodnome"]);
                produto.Proddescr = Convert.ToString(reader["Proddescr"]);

            }

            return View(produto);

        }
        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "update produto set Prodnome = @Prodnome,Proddescr=@Proddescr where Prodid=@Prodid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Prodnome", produto.Prodnome);
            command.Parameters.AddWithValue("@Proddescr", produto.Proddescr);
            command.Parameters.AddWithValue("@Prodid", produto.Prodid);

            command.ExecuteNonQuery();

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "INSERT INTO produto (Prodnome, Proddescr) VALUES (@Prodnome, @Proddescr)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Prodnome", produto.Prodnome);
            command.Parameters.AddWithValue("@Proddescr", produto.Proddescr);
            command.ExecuteNonQuery();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Deletar(int id)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "Delete from produto where Prodid = @Prodid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Prodid", id);

            command.ExecuteNonQuery();

            return RedirectToAction("Index", "Home");
        }


    }





}

