using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExemploResidencia.Class
{
    class Repositorio //Classes de repositório guardam todos os metodos relacionados ao armazenamento de informações no banco de dados
    {
        public void SelectToGrv(Object[] dataObj, DataGridView dgvId, int indice)
        {
            string myConnectionString = "server=localhost;database=casa;uid=root;pwd=root;"; //Faz a conexão com o banco de dados
            MySqlConnection conn = new MySqlConnection(myConnectionString);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um problema ao conectar-se com o servidor");
            }

            try
            {
                Servico servico = new Servico(); //Instancia a classe servico

                using (DataTable dt = new DataTable()) //Cria o objeto DataTable capaz de guardar informações em forma de matriz
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(SelectQuery(dataObj, conn, indice))) //Usa o adapter para ler as informações a partir do SqlCommand
                    //O comand é obtido através do metodo SelectQuery, que recebe o Objeto, a conexão e o indice que foram definidos na Tela Inicial.
                    {
                        adapter.Fill(dt); //O adapter com o resultado do comando SQL preenche a tabela
                    }

                    switch (indice)
                    {
                        default: //Caso o valor do indice não ser um case do Switch, o default é utilizado

                            dgvId.DataSource = servico.PrepararInfo(dt); //Executa o metodo da classe servico e preenche o DataGridView com os valores retornados, requer uma DataTable para manipulação
                            break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao preencher os dados");
            }
            conn.Close();
        }
        
        private MySqlCommand SelectQuery(Object[] dataObj, MySqlConnection conn, int indice) //Método que cria o comando SQL para trazer as informações do banco
        {
            switch (indice)
            {
                default:

                    String query;
                    query = "SELECT casa.rua, cidade.nome, cidade.estado FROM Tbl_casa as casa inner join tbl_cidade as cidade on casa.id = cidade.id where casa.id = @ID;"; //Utiliza as anotações @ para evitar SQL Injection

                    MySqlCommand command = new MySqlCommand(query, conn); //Comando que executa a query definita na conexão fornecida pelo metodo anterior
                    command.Parameters.AddWithValue("@ID", SqlDbType.Int);//Define o tipo do @ID
                    command.Parameters["@ID"].Value = dataObj[0];//Define o valor do @ID
                    return command;
            }
        }
    }
}
