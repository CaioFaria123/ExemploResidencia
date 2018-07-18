using ExemploResidencia.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExemploResidencia
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void btnPesq_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipo1Id.Text)) //Verifica se a String é nula ou espaço
            {
                MessageBox.Show("Por favor preencher o campo de ID"); 
            }
            else 
            {
                bool isNumeric = int.TryParse(txtTipo1Id.Text, out int n); // Bool que tenta converter a informação desejada, neste caso, um texto para int.
                //Caso seja possível converter, retorna true.

                if (isNumeric)
                {
                    Object[] dataObj = new Object[] {txtTipo1Id.Text}; //Cria uma array de objetos de n elementos
                    Repositorio repo = new Repositorio(); //Instancia a classe repositório
                    repo.SelectToGrv(dataObj, dgvId, 0); //Chama o metodo e informa os atributos necessários.
                    //Neste casso os atributos são o Objeto com os dados, o Objeto DataGridView que receberá as informações e um indice.
                }
                else
                {
                    MessageBox.Show("Digite um ID válido (número natural)");
                }
            }
        }
    }
}
