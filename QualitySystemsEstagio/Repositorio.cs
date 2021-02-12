using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QualitySystemsEstagio
{
    public class Repositorio
    {
        //Path de onde esta o arquivo Json 
        public static string path = @"D:\DADOS VITOR\Documents\Projetos e Estudos\Estudos\Prova estágio C# - Quality Systems\QualitySystemsEstagio\QualitySystemsEstagio\repositorio.json";
        private static List<Usuario> usuarios;
        public static List<Usuario> Usuarios
        {
            get
            {
                
                if (usuarios == null)
                {
                    usuarios = Select();

                    //Segundo IF caso o Json não tenha nada
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
        public static void Insert(List<Usuario> obj, string path)
        {
            string jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented);

            //var json = JsonConvert.SerializeObject(obj, Formatting.Indented);

            
            using (var sw = new StreamWriter(path))
            {
                sw.Write(jsonString);
            }
        }

        private static List<Usuario> Select()
        {
            
                String JSONtxt = File.ReadAllText(path);
                List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(JSONtxt);

                return usuarios;
            
        }


    }
}
