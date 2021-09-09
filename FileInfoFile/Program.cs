using System;
using System.IO;

namespace TesteFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var caminhoFonte = @"C:\Estudos\TrabalhandoComArquivos\FileInfoFile\FileTeste.txt";
            var caminhoAlvo = @"C:\Estudos\TrabalhandoComArquivos\FileInfoFile\FileTeste2.txt";
            var caminhoNovoDiretorio = @"C:\Estudos\TrabalhandoComArquivos\Teste\teste.txt";
            string[] texto = new string[10];

            if (!AcessoDiretorios.VericarSeExisteDiretorio(caminhoNovoDiretorio))
                AcessoDiretorios.CriarDiretorio(caminhoNovoDiretorio);
            //AcessarDiretoriosDirectory(caminhoFonte);
            //AcessarArquivosDiretorioDirectory(caminhoFonte);
            //EscreverNoArquivoFile(caminhoFonte, texto);
            //LerArquivoComFile(caminhoFonte);
            //LerArquivoComFileStream(caminhoFonte);
            //EscreverArquivoComStreamWriter(caminhoAlvo);
            Console.ReadKey();
        }

        /// <summary>
        /// Escreve o array de strings informado no arquivo solicitado utilizando a classe File.
        /// </summary>
        /// <param name="caminho">Caminho onde o arquivo encontra-se.</param>
        /// <param name="texto">Array de strings</param>
        static void EscreverNoArquivoFile(string caminho, string[] texto)
        {
            for (var contador = 0; contador < texto.Length; contador++)            
                texto[contador] = $"Teste {contador}.";
            

            try
            {
                File.WriteAllLines(caminho, texto);
                Console.WriteLine("Arquivo finalizado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Houve um problema ao escrever no arquivo. :( \n" + "Erro: " + e.Message);
            }
        }

        /// <summary>
        /// Ler o arquivo especificado utilizando a classe File.
        /// </summary>
        /// <param name="caminho">Caminho onde o arquivo encontra-se.</param>
        static void LerArquivoComFile(string caminho) 
        {
            try
            {
                string[] texto = File.ReadAllLines(caminho);

                Console.WriteLine("O conteúdo do seu arquivo é: ");
                Console.WriteLine("");
                foreach (var linha in texto)
                {
                    Console.WriteLine(linha);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Houve um problema ao escrever no arquivo. :( \n" + "Erro: " + "Não foi possível encontrar o arquivo especificado.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Houve um problema ao escrever no arquivo. :( \n" + "Erro: " + e.Message);
            }                       

        }

        /// <summary>
        /// Lê o arquivo utilizando as classes FileStream e o StreamReader.
        /// </summary>
        /// <param name="caminho">Caminho onde o arquivo encontra-se.</param>
        static void LerArquivoComFileStream(string caminho) 
        {
            try
            {
                using (var arquivo = new FileStream(caminho, FileMode.Open))
                {
                    using (var streamReader = new StreamReader(arquivo))
                        Console.WriteLine(streamReader.ReadToEnd());
                }
            }
            catch (IOException e)
            {

                Console.WriteLine("Ocorreu um erro ao ler o arquivo :(");
                Console.WriteLine($"Erro: {e.Message}.");
            }
                      
        }

        /// <summary>
        /// Lê o arquivo utilizando as classes StreamReader e o File.
        /// </summary>
        /// <param name="caminho">Caminho onde o arquivo encontra-se.</param>
        static void LerArquivoComStreamReader(string caminho)
        {
            try
            {
                using (var streamReader = File.OpenText(caminho))
                    Console.WriteLine(streamReader.ReadToEnd());
            }
            catch (IOException e)
            {

                Console.WriteLine("Ocorreu um erro ao ler o arquivo :(");
                Console.WriteLine($"Erro: {e.Message}.");
            }

        }

        /// <summary>
        /// Escreve o arquivo utilizando as classes StreamWriter e FileInfo.
        /// </summary>
        /// <param name="caminho">Caminho onde o arquivo encontra-se.</param>
        static void EscreverArquivoComStreamWriter(string caminho)
        {
            try
            {
                using (var streamWriter = new FileInfo(caminho).CreateText()) // File.CreateText(caminho))
                    for (var i = 10; i >= 0; i--)
                        streamWriter.WriteLine($"Texto: {i}");
            }
            catch (IOException e)
            {

                Console.WriteLine("Ocorreu um erro ao ler o arquivo :(");
                Console.WriteLine($"Erro: {e.Message}.");
            }

        }

        /// <summary>
        /// Lista diretórios utilizando a classe Directory.
        /// </summary>
        /// <param name="caminho">Caminho onde o arquivo encontra-se.</param>
        static void AcessarDiretoriosDirectory(string caminho) 
        {
            var listaDiretorios = AcessoDiretorios.AcessarListaDiretoriosDirectory(caminho);
            foreach (var diretorio in listaDiretorios)
                Console.WriteLine(diretorio);        
        }

        /// <summary>
        /// Lista arquivos de um diretório utilizando a classe Directory.
        /// </summary>
        /// <param name="caminho">Caminho onde o arquivo encontra-se.</param>
        public static void AcessarArquivosDiretorioDirectory(string caminho)
        {
            var listaArquivo = AcessoDiretorios.AcessarListaArquivosDirectory(caminho);
            foreach (var arquivo in listaArquivo)
                Console.WriteLine(arquivo);
        }
    }
}
