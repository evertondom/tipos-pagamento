using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Aula4
{
    public partial class Form1 : Form
    {
        decimal valor = 0.00m;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //criar uma arraylist
            ArrayList formaPagto = new ArrayList();
            formaPagto.Add(new FormaDePgto(0, "Selecione Opção"));
            formaPagto.Add(new FormaDePgto(1, "Dinheiro"));
            formaPagto.Add(new FormaDePgto(2, "Cartão"));
            formaPagto.Add(new FormaDePgto(3, "Boleto"));
            formaPagto.Add(new FormaDePgto(4, "Pix"));

            //vincular ao combobox1
            comboBox1.DataSource = formaPagto;
            comboBox1.DisplayMember = "Descricao";
            comboBox1.ValueMember = "ID";
           
        }

        public class FormaDePgto
        {
            public int ID { get; set; }
            public string Descricao { get; set; }

            public FormaDePgto(int iD, string descricao)
            {
                ID = iD;
                Descricao = descricao;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            valor = decimal.Parse(txtValor.Text);
            int escolha = comboBox1.SelectedIndex;
            switch (escolha)
            {
                case 0:
                    lblEscolhido.Text = "Escolha Opção";
                    break;
                case 1:
                    lblEscolhido.Text = "Dinheiro";
                    lblValorTotal.Text = $"Valor a ser pago: {valor:F2} ";
                    break;
                case 2:
                    lblEscolhido.Text = "Cartão";
                    ArrayList qtdPagto = new ArrayList();
                    for (int i = 0; i < 10; i++)
                    {
                        qtdPagto.Add(i+1);
                    }
                    comboBox2.DataSource = qtdPagto;

                    lblValorTotal.Text = $"{comboBox2.SelectedIndex}x de {valor / comboBox2.SelectedIndex + 1}";
                    
                    break;
                case 3:
                    lblEscolhido.Text = "Boleto";
                    lblValorTotal.Text = $"Valor a ser pago: {valor:F2} ";
                    break;
                case 4:
                    lblEscolhido.Text = "Pix";
                    lblValorTotal.Text = $"Valor a ser pago: {valor:F2} ";
                    break;
                default:
                    lblEscolhido.Text = ""; 
                    break;
            }

            
        }
    }
}
