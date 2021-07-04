using BulkCertificationToolNova.Contracts;
using BulkCertificationToolNova.Models;
using Novacode;
using Spire.Doc;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BulkCertificationToolNova.Services
{
    internal class WordService : IWordService
    {
        private DocX _doc;

        public IResult<Boolean> LoadTemplate(String fileName)
        {
            try
            {
                _doc = DocX.Load(fileName);
                return new Result<Boolean>(true);
            }
            catch (Exception ex)
            {
                return new Result<Boolean>(false, ex.Message);
            }
        }

        public IResult<Boolean> ApplyChanges(TemplateParts parts)
        {
            try
            {
                Replace(parts.SourceLanguage);
                Replace(parts.TargetLanguage);
                Replace(parts.NovaReference);
                Replace(parts.StudyNumber);
                Replace(parts.FileName);

                Replace(parts.Manager);
                ReplaceImage(parts.ManagerSignature);

                return new Result<Boolean>(true);
            }
            catch (Exception ex)
            {
                return new Result<Boolean>(false, ex.Message);
            }
        }

        public Task<IResult<Boolean>> SaveFileAsAsync(String fileName)
        {
            return Task.Factory.StartNew<IResult<Boolean>>(() =>
            {
                try
                {
                    //save file to temp directory
                    //open in Spire.Doc and save as Pdf

                    var temp = Path.Combine(Path.GetTempPath(), Path.GetFileName(fileName) ?? String.Empty);
                    _doc.SaveAs(temp);

                    var document = new Document();
                    document.LoadFromFile(temp);
                    document.SaveToFile(fileName.Replace(".docx", ".pdf"), FileFormat.PDF);

                    File.Delete(temp);

                    return new Result<Boolean>(true);
                }
                catch (Exception ex)
                {
                    return new Result<Boolean>(false, ex.Message);
                }
            });
        }

        #region Private

        private void Replace(TemplateItem templateItem)
        {
            var template = templateItem.Template;
            var value = templateItem.Value;

            var items = _doc.Paragraphs.Where(p => p.Text.Contains(template));
            foreach (var item in items)
            {
                item.ReplaceText(template, value, false, RegexOptions.IgnoreCase);
            }
        }

        private void ReplaceImage(String imagePath)
        {
            var image = _doc.AddImage(imagePath);

            var paragraph = _doc.Paragraphs.FirstOrDefault(p => p.Pictures.Any());
            if (paragraph != null)
            {
                paragraph.Pictures[0].Remove();
                paragraph.InsertPicture(image.CreatePicture());
            }
        }

        #endregion
    }
}
