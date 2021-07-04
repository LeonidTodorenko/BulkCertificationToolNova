using BulkCertificationToolNova.Contracts;
using BulkCertificationToolNova.Enums;
using BulkCertificationToolNova.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing;

namespace BulkCertificationToolNova
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            //StartProcessFiles(new[] {"D:\\6.docx"});
            //return;

            if (args.Length < 1)
            {
                MessageBox.Show(@"There is no file to analyze.", @"Bulk Certification Tool Nova", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //first instance will get all filenames from other instances and will process them
            var mutex = new Mutex(false, "BulkCertificationToolNova");
            var pipeName = "BulkCertificationToolNovaPipe";
            var fileNames = new ConcurrentStack<String>();
            var items = new String[256];

            try
            {
                if (mutex.WaitOne(0, false))
                {
                    fileNames.Push(args[0]);

                    using (var pipeServer = new PipesManager(pipeName))
                    {
                        pipeServer.StartServer(fileNames);

                        //wait for getting messages from another instances
                        Thread.Sleep(500);

                        fileNames.TryPopRange(items);
                    }
                }
                else
                {
                    var pipeClient = new PipesManager(pipeName);
                    pipeClient.SendClientMessage(args[0]);

                    //It need finish a process after sended filename to the server
                    return;
                }
            }
            finally
            {
                mutex.Close();
                mutex = null;
            }

            StartProcessFiles(items);
        }

        private static void StartProcessFiles(IEnumerable<String> fileNames)
        {
            // Excel file with users and languages lists
            var excelFile = ConfigurationManager.AppSettings["excelData"];

            // Word files for certificate template
            var wordFiles = new Dictionary<AppMode, String>
            {
                { AppMode.ForwardTranslation, ConfigurationManager.AppSettings["forwardTranslationFile"] },
                { AppMode.ForwardTranslationWithStudy, ConfigurationManager.AppSettings["forwardTranslationWithStudyFile"] },
                { AppMode.BackTranslation, ConfigurationManager.AppSettings["backTranslationFile"] },
                { AppMode.BackTranslationWithStudy, ConfigurationManager.AppSettings["backTranslationWithStudyFile"] }
            };

            // Path to templates (Word files, Excel files etc.)
            var templatesPath = ConfigurationManager.AppSettings["templatesPath"];

            // Filename prefix for saving
            var filePrefix = ConfigurationManager.AppSettings["filePrefix"];

            var parts = new TemplateParts
            {
                SourceLanguage = new TemplateItem(ConfigurationManager.AppSettings["sourceLanguageTmpl"]),
                TargetLanguage = new TemplateItem(ConfigurationManager.AppSettings["targetLanguageTmpl"]),
                NovaReference = new TemplateItem(ConfigurationManager.AppSettings["novaReferenceTmpl"]),
                StudyNumber = new TemplateItem(ConfigurationManager.AppSettings["studyNumberTmpl"]),
                FileName = new TemplateItem(ConfigurationManager.AppSettings["fileNameTmpl"]),
                Manager = new TemplateItem(ConfigurationManager.AppSettings["managerTmpl"])
            };

            var data = new GeneratorData
            {
                TemplatesPath = templatesPath,
                FilePrefix = filePrefix,
                ExcelFile = excelFile,
                WordFiles = wordFiles,
                FileNames = fileNames.Where(name => !String.IsNullOrWhiteSpace(name)),
            };

            ICertificateGenerator generator = new CertificateGenerator(parts, data);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(generator));
        }
    }
}
