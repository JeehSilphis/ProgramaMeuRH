using System;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;
using System.ComponentModel;



public class BancoDados
{
    private string connectionString;
    private string caminhoBanco;
    public string CaminhoBanco => caminhoBanco;

    public BancoDados()
    {

        string pastaExe = AppDomain.CurrentDomain.BaseDirectory;
        caminhoBanco = Path.Combine(pastaExe, "ponto_eletronico.db");
        connectionString = $"Data Source={caminhoBanco};Version=3;";

    }

    public SQLiteConnection Conectar()
    {
        try
        {
            if (!File.Exists(caminhoBanco))
            {
                MessageBox.Show($"O banco de dados não foi encontrado:\n\n{caminhoBanco}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new FileNotFoundException("Banco de dados não encontrado.", caminhoBanco);
            }

            var conexao = new SQLiteConnection(connectionString);
            conexao.Open();

            using (var cmdPragma = new SQLiteCommand(
                "PRAGMA foreign_keys = ON; PRAGMA journal_mode=WAL; PRAGMA busy_timeout = 5000;",
                conexao))
            {
                cmdPragma.ExecuteNonQuery();
            }

            return conexao;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao conectar ao banco:\n\n{ex.Message}",
                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw;
        }
    }



    private void CriarTabelasIniciais(SQLiteConnection conexao)
    {
        string sqlFuncionarios = @"
        CREATE TABLE IF NOT EXISTS Funcionarios (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            CPF TEXT NOT NULL UNIQUE,
            RE TEXT NOT NULL UNIQUE,
            Nome TEXT NOT NULL,
            data_nascimento TEXT NOT NULL,
            genero TEXT NOT NULL,
            telefone TEXT NOT NULL,
            email TEXT NOT NULL,
            cep TEXT NOT NULL,
            endereco TEXT NOT NULL,
            periodico TEXT NOT NULL,
            inicio TEXT NOT NULL,
            entrada TEXT NOT NULL,
            saida TEXT NOT NULL,
            foto BLOB,
            cargo TEXT NOT NULL,
            convocacao TEXT,
            Confirmado TEXT DEFAULT 'Não',
            Numero INTEGER
        );";

        string sqlAtestados = @"
        CREATE TABLE IF NOT EXISTS Atestados (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            CPF TEXT,
            FuncionarioId INTEGER,
            NomeFuncionario TEXT,
            DataAtestado TEXT,
            DiasAfastado INTEGER,
            CaminhoArquivo BLOB,
            Status TEXT DEFAULT 'Pendente',
            Notificado INTEGER DEFAULT 0,
            FOREIGN KEY (FuncionarioId) REFERENCES Funcionarios(Id),
            FOREIGN KEY (CPF) REFERENCES Funcionarios(CPF)
        );";

        string sqlRegistrosPonto = @"
        CREATE TABLE IF NOT EXISTS RegistrosPonto (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            FuncionarioId INTEGER,
            DataHora TEXT,
            Tipo TEXT,
            FOREIGN KEY (FuncionarioId) REFERENCES Funcionarios(Id)
        );";

        using (var cmd1 = new SQLiteCommand(sqlFuncionarios, conexao))
            cmd1.ExecuteNonQuery();

        using (var cmd2 = new SQLiteCommand(sqlAtestados, conexao))
            cmd2.ExecuteNonQuery();

        using (var cmd3 = new SQLiteCommand(sqlRegistrosPonto, conexao))
            cmd3.ExecuteNonQuery();
    }
}
