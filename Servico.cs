using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploResidencia.Class
{
    class Servico
    {
        public DataTable PrepararInfo(DataTable dt) //Metodo que retorna um Objeto do tipo DataTable
        {
            dt.Columns.Add("Coluna tratamento teste"); //Comando que adiciona uma nova coluna a DataTable

            foreach (DataRow myRow in dt.Rows) //Para cada Row na DataTable, realiza os comandos abaixo
            {
                myRow["nome"] = myRow["nome"].ToString() + "/Exemplo de tratamento de info"; //Adiciona um texto na informação existente
                myRow["Coluna tratamento teste"] = "Coluna adicionada na classe de servico"; //Adiciona um texto na coluna criada anteriormente
            }

            return dt;
        }
    }
}
