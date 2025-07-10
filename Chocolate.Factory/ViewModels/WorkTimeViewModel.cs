using Chocolate.Factory.Commands.WorkTimeCommands;
using Chocolate.Factory.Core.Domain.Entities;
using Chocolate.Factory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chocolate.Factory.ViewModels
{
    public class WorkTimeViewModel
    {
        public WorkTimeViewModel()
        {
            List<WorkTime> workTimes = ApplicationContext.UnitOfWork.WorkTimeRepository.GetAll();

            WorkTimeModels = new ObservableCollection<WorkTimeModel>();

            foreach (WorkTime workTime in workTimes)
            {
                WorkTimeModel model = new WorkTimeModel
                {
                    Id = workTime.Id,
                    ThisDay = workTime.ThisDay,
                    StartTime = workTime.StartTime,
                    StopTime = workTime.StopTime,
                    Production = workTime.Production,
                    IsInspected = workTime.IsInspected,
                    MachineSerialNumber=workTime.Machine.SerialNumber,               
                };

                WorkTimeModels.Add(model);
            }

            this.OpenAddWorkTime = new OpenAddWorkTimeCommand(this);
            this.DeleteWorkTime = new DeleteWorkTimeCommand(this);
            this.ExportWorkTime = new ExportWorkTimeCommand(this);
        }

        public ObservableCollection<WorkTimeModel> WorkTimeModels { get; set; }

        public ICommand OpenAddWorkTime { get; set; }
        public ICommand OpenUpdateWorkTime { get; set; }
        public ICommand DeleteWorkTime { get; set; }
        public ICommand ExportWorkTime { get; set; }
        public int SelectedWorkTimeIndex { get; set; }
    }

}
