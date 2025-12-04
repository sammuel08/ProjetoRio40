MODEL CLIENTE

Arquivo: Cliente.cs

public class Cliente
{
    [Display(Name = "CPF do Cliente")]
    public string? CPF { get; set; }

    [Display(Name = "Nome do Cliente")]
    public string? Nome { get; set; }

    [Display(Name = "Endereço do Cliente")]
    public string? Endereco { get; set; }
}

Função:

Representa um cliente.

Usado nas telas e nas queries do MySQL.

O CPF funciona como chave de identificação.

MODEL PRODUTO

Arquivo: Produto.cs

public class Produto
{
    [Display(Name = "Código do Produto")]
    public int Prodid { get; set; }

    [Display(Name = "Nome do Produto")]
    public string? Prodnome { get; set; }

    [Display(Name = "Descrição do Produto")]
    public string? Proddescr { get; set; }
}

Função:

Representa um produto.

Prodid funciona como chave primária.

Facilita o mapeamento com o banco de dados.

                        CONTROLLERS

        ClienteController

O controller responsável por todas as funções do CRUD de Cliente.

     Cadastrar (GET)

public IActionResult Cadastrar()

Apenas abre a View de cadastro.

     Cadastrar (POST)

public IActionResult Cadastrar(Cliente cliente)

Recebe o formulário.

Insere um novo cliente no banco MySQL:

INSERT INTO cliente (CPF, Nome, Endereco)

             LISTAR

public IActionResult Listar()

Faz SELECT no banco.

Lê todo mundo da tabela cliente.

Carrega na view em formato de lista.

     Editar (GET)

public IActionResult Editar(string id)

Busca um único cliente pelo CPF.

Preenche os campos para edição.

    Editar (POST)

public IActionResult Editar(Cliente cliente)

Atualiza no MySQL:

UPDATE cliente SET Nome=@Nome, Endereco=@Endereco WHERE CPF=@CPF

            DELETAR

public IActionResult Deletar(string id)

Executa o DELETE no banco:

DELETE FROM cliente WHERE CPF=@CPF

            ProdutoController

Controla o CRUD de Produto.

     Cadastrar (GET)

Abre a tela de cadastro.

     Cadastrar (POST)

Insere no MySQL:

INSERT INTO produto (Prodnome, Proddescr)

         Listar

Carrega todos os produtos usando SELECT.

    Editar (GET)

Busca um produto pelo ID (Prodid).

    Editar (POST)

Atualiza no MySQL:

UPDATE produto SET Prodnome=@Prodnome, Proddescr=@Proddescr WHERE Prodid=@Prodid

Deletar

Remove produto pelo ID.

            VIEWS

        Views do Cliente
        
    Cadastrar.cshtml

Formulário para adicionar cliente.

Campos: CPF, Nome, Endereço.

Envia via POST para Cliente/Cadastrar.

    Editar.cshtml

Tela para editar um cliente existente.

Campos carregam automaticamente com as informações do banco.

    Listar.cshtml

Tabela com todos os clientes.

Links para Editar e Deletar.

Possui botão para adicionar novo cliente.


            Views do Produto

            
    Cadastrar.cshtml

Formulário para adicionar produto.

Campos: Prodid, Prodnome, Proddescr.

    Editar.cshtml

Tela para edição de produto.

O campo Prodid fica travado (readonly).

    Listar.cshtml

Mostra todos os produtos em tabela.

Possui links de edição e exclusão.



     BANCO DE DADOS – appsettings.json

     

Arquivo:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;database=dbLoja;user=root;password=12345678"
  },

  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

    Função:

Configura a conexão com o MySQL.

O controller usa essa string para abrir a conexão:

_configuration.GetConnectionString("DefaultConnection")


