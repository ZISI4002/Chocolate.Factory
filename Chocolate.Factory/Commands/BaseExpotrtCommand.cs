using Chocolate.Factory.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Chocolate.Factory.Commands
{
  public  abstract class BaseExpotrtCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Получаем имя типа T
            string modelName = typeof(T).Name;
            //убираем слово Model
            string model = "Model";
            modelName = modelName.Replace(model, "");

            // Динамическое имя файла с учетом модели
            string defaultFileName = $"{modelName}s_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.csv";

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.FileName = defaultFileName;
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "CSV File (*.csv)|*.csv|New Excel File (*.xlsx)|*.xlsx|Excel File (*.xls)|*.xls|OpenDocument Spreadsheet(*.ods)|*.ods|Text File (*.txt)|*.txt";
            bool? okClicked = saveFileDialog.ShowDialog() == DialogResult.OK ? (bool?)true : (bool?)false;
            if (okClicked != null && !okClicked.Value)
            {
                return;
            }

            List<T> data = this.GetData();
            ExportHelper.WriteCsv(data, saveFileDialog.FileName);

           
            MessageBox.Show($"Exported to {saveFileDialog.FileName}.", "Data exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        protected abstract List<T> GetData();
    }
}
