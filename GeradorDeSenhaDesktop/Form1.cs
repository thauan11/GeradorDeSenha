using System.Text;
using System.Text.RegularExpressions;

// 
// H
// W
// P
// 

namespace GeradorDeSenhaDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txbSenhaGerada.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbTamanhoSenha_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txbSenhaGerada_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tamanhoSenha = txbTamanhoSenha.Text;

            if (Regex.IsMatch(tamanhoSenha, @"^[0-9]+$"))// Se o numero estivero vazio
            {
                int qnt = int.Parse(txbTamanhoSenha.Text);

                string abcPossiveis = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                    "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower();

                string numPossiveis = "123456789";

                string caracteresPossiveis = "!@#$%";

                Random random = new Random();
                int numeroRandom = 0;
                int numeroRandom2 = 0;
                StringBuilder passwordABC = new StringBuilder();
                StringBuilder passwordNUM = new StringBuilder();
                StringBuilder passwordCarac = new StringBuilder();

                if (checkBox1.Checked == true) //Caractere Especial marcado
                {
                    for (int t = 0; t < (1); t++)
                    {
                        numeroRandom = random.Next(0, caracteresPossiveis.Length - 1);
                        passwordCarac.Append(caracteresPossiveis[numeroRandom]);
                    }

                    if (checkBox2.Checked == true) //Caractere e Numero marcado
                    {
                        for (int t = 0; t < (qnt / 2); t++)
                        {
                            numeroRandom = random.Next(0, abcPossiveis.Length - 1);
                            passwordABC.Append(abcPossiveis[numeroRandom]);
                            numeroRandom2 = random.Next(0, numPossiveis.Length - 1);
                            passwordNUM.Append(numPossiveis[numeroRandom2]);
                        }
                    }
                    else //Caractere marcado e Numero desmarcado
                    {
                        for (int t = 0; t < (qnt - 1); t++)
                        {
                            numeroRandom = random.Next(0, abcPossiveis.Length - 1);
                            passwordABC.Append(abcPossiveis[numeroRandom]);
                        }
                    }
                }
                else  //Caractere desmarcado
                {
                    if (checkBox2.Checked == true) //Caractere desmarcado e Numero marcado
                    {
                        int converteTcbTamSenha = int.Parse(txbTamanhoSenha.Text);
                        if (converteTcbTamSenha % 2 == 0) // Se for par
                        {
                            for (int t = 0; t < (qnt / 2); t++)
                            {
                                numeroRandom = random.Next(0, abcPossiveis.Length - 1);
                                passwordABC.Append(abcPossiveis[numeroRandom]);
                            }
                            for (int t = 0; t < (qnt / 2); t++)
                            {
                                numeroRandom2 = random.Next(0, numPossiveis.Length - 1);
                                passwordNUM.Append(numPossiveis[numeroRandom2]);
                            }
                        }
                        else // Se for impar (adiciona uma letra a mais)
                        {
                            for (int t = 0; t < (qnt / 2 + 1); t++)
                            {
                                numeroRandom = random.Next(0, abcPossiveis.Length - 1);
                                passwordABC.Append(abcPossiveis[numeroRandom]);
                            }
                            for (int t = 0; t < (qnt / 2); t++)
                            {
                                numeroRandom2 = random.Next(0, numPossiveis.Length - 1);
                                passwordNUM.Append(numPossiveis[numeroRandom2]);
                            }
                        }

                    }
                    else //Caractere e Numero desmarcado
                    {
                        for (int t = 0; t < (qnt); t++)
                        {
                            numeroRandom = random.Next(0, abcPossiveis.Length - 1);
                            passwordABC.Append(abcPossiveis[numeroRandom]);
                        }
                    }
                }

                string password = $"{passwordABC}{passwordNUM}{passwordCarac}";

                txbSenhaGerada.Text = password.ToString();
                errorProvider1.SetError(txbTamanhoSenha, "");
            }
            else
            {
                errorProvider1.SetError(txbTamanhoSenha, "Aten��o!");
                
            }

        }
    }
}