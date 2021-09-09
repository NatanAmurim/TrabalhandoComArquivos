using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TesteFile
{
    /// <summary>
    /// Prove métodos para acessar pastas, subpastas e arquivos.
    /// </summary>
    public static class AcessoDiretorios
    {
        /// <summary>
        /// Método para retornar uma lista de diretórios.
        /// </summary>
        /// <param name="caminhoBase"></param>
        /// <returns>Lista de diretório de um caminho especificado.</returns>
        ///<exception cref="System.Exception"></exception>
        public static IEnumerable<string> AcessarListaDiretoriosDirectory(string caminhoBase)
        {
            try
            {
                var caminhoPuro = ExtrairCaminho(caminhoBase);
                return Directory.EnumerateDirectories(caminhoPuro, "*.*", SearchOption.AllDirectories);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Método para retornar a lista de arquivos dentro de um diretório.
        /// </summary>
        /// <param name="caminhoBase"></param>
        /// <returns>Lista de arquivos de um diretório especificado.</returns>
        ///<exception cref="System.Exception"></exception>
        public static IEnumerable<string> AcessarListaArquivosDirectory(string caminhoBase)
        {
            try
            {
                var caminhoPuro = ExtrairCaminho(caminhoBase);
                return Directory.EnumerateFiles(caminhoPuro, "*.*", SearchOption.AllDirectories);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Metódo para criar diretório, caso não o mesmo não exista.
        /// </summary>
        /// <param name="caminhoNovoDiretorio">Nome do novo diretório junto ao caminho onde ele será criado.</param>
        /// <exception cref="System.Exception"></exception>
        public static void CriarDiretorio(string caminhoNovoDiretorio)
        {
            try
            {
                var caminhoNovoDiretorioPuro = ExtrairCaminho(caminhoNovoDiretorio);
                if (!VericarSeExisteDiretorio(caminhoNovoDiretorioPuro))
                    Directory.CreateDirectory(caminhoNovoDiretorioPuro);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private static string ExtrairCaminho(string caminho)
        {
            //var posicaoUltimaBarra = caminho.LastIndexOf(@"\");
            //return caminho.Remove(posicaoUltimaBarra);
            return Path.GetDirectoryName(caminho);
        }

        /// <summary>
        /// Método que retorna se um diretório já existe.
        /// </summary>
        /// <param name="caminhoDiretorio"></param>
        /// <returns>Verdadeiro ou falso.</returns>
        public static bool VericarSeExisteDiretorio(string caminhoDiretorio) 
        {
            var caminhoNovoPuro = ExtrairCaminho(caminhoDiretorio);
            return Directory.Exists(caminhoNovoPuro);
        }
    }
}
