using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QualitySystemsEstagio
{
    public class Repositorio
    {
        //Variavel com o caminho de onde se encontra o arquivo Json 
        public static string path = @"D:\DADOS VITOR\Documents\Projetos e Estudos\Estudos\Prova estágio C# - Quality Systems\QualitySystemsEstagio\QualitySystemsEstagio\repositorio.json";
        private static List<Usuario> usuarios;
        public static List<Usuario> Usuarios
        {
            get
            {
                if (usuarios == null)
                {
                    //Caso haja usuario no arquivo repositorio.Json chama o metodo Select que desserializa os dados Json e 
                    //coloca dentro da lista usuario
                    usuarios = Select();

                    //Entra na condicao do segundo IF caso nao tenha nada no arquivo repositorio.Json
                    if (usuarios == null)
                    {
                        GerarUsuario();
                    }
                }

                return usuarios;
            }
            set
            {
                //usuarios = value;
            }
        }

        //Gera um usuario caso não haja nenhum usuario salvo no arquivo repositorio.Json
        private static void GerarUsuario()
        {
            usuarios = new List<Usuario>();
            usuarios.Add(new Usuario
            {
                IdUsuario = 1,
                Nome = "Vitor",
                Email = "teste@teste.com.br",
                Senha = "123456",
                Telefone = 40028922,
                DataNascimento =  new DateTime(1998, 11, 24),
                CPF = "29546656797"

            });
           
        }
        //Metodo que verifica se o CPF do objeto contem apenas characters de numeros e uma string de tamanho 11
        //Caso o CPF nao estiver formatado, o metodo retorna um CPF padrao de 11 numeros 
        public static string FormatarCPF(string CPF)
        {

            if (Regex.IsMatch(CPF, "[0-9]+") && CPF.Length == 11)
            {
                return CPF;
            }
            CPF = "00000000000";
            return CPF;
        }

        //Metodo que serializa a lista de usuarios e escreve no arquivo repositorio.Json
        public static void Insert(List<Usuario> usuarios, string path)
        {
            string jsonString = JsonConvert.SerializeObject(usuarios, Formatting.Indented);

            //var json = JsonConvert.SerializeObject(obj, Formatting.Indented);

            
            using (var sw = new StreamWriter(path))
            {
                sw.Write(jsonString);
            }
        }

        //Metodo que transforma os dados do arquivo Json na lista do objeto Usuario
        private static List<Usuario> Select()
        {
            
                String JSONtxt = File.ReadAllText(path);
                List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(JSONtxt);

                return usuarios;
            
        }


    }
}
