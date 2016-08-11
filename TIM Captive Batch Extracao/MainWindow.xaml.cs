using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TIM_Captive_Batch_Extracao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string servidor;
        private string usuario;
        private string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Servidor
        {
            get { return servidor; }
            set { servidor = value; }
        }

        
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Executar()
        {
            Servidor = tbServidor.Text;
            Usuario = tbUsuario.Text;
            Senha = pbSenha.Password;

            if (validarPreenchimentoFormulario())
            {
                try
                {
                    using (var client = new SshClient(Servidor, Usuario, Senha))
                    {
                        client.Connect();
                        //client.RunCommand("etc/init.d/networking restart");
                        client.Disconnect();
                    }
                }
                catch(Exception e)
                {

                }
            }
        }

        private bool validarPreenchimentoFormulario()
        {
            if (string.IsNullOrEmpty(Servidor) || string.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Senha))
                return false;
            else
                return true;
        }

        private void btnVaiPlaneta_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Executar();
        }
    }
}
