// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the FirstViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.FieldBinding;
using Cirrious.MvvmCross.ViewModels;
using V.MvvmCross.CustomCell.Core.Business_Entities;

namespace V.MvvmCross.CustomCell.Core.ViewModels
{
    /// <summary>
    /// Define the FirstViewModel type.
    /// </summary>
    public class FirstViewModel : BaseViewModel, IRemove
    {
        private List<EnterTime> hours;
        /// <summary>
        /// selected date
        /// </summary>
        public List<EnterTime> Hours
        {
            get { return this.hours; }
            set
            {
                this.SetProperty(ref this.hours, value, () => this.Hours);
            }
        }

        private DateTime date;
        /// <summary>
        /// selected date
        /// </summary>
        public DateTime Date
        {
            get { return this.date; }
            set
            {
                this.SetProperty(ref this.date, value, () => this.Date);
                RefreshHours();
            }
        }

        /// <summary>
        /// total hours for the day
        /// </summary>
        public INC<decimal> TotalHours = new NC<decimal>();

        /// <summary>
        /// busy indicator for table refreshes
        /// </summary>
        public INC<bool> IsBusy = new NC<bool>();

        private async void RefreshHours()
        {
            Hours = await SimulatedServerCallGetHours();
            TotalHours.Value = Hours.Sum(x => x.Hours);         
        }

        public override void Start()
        {
            base.Start();
            Date = DateTime.Now;
        }

        private async Task<List<EnterTime>> SimulatedServerCallGetHours()
        {
            //simulate a call to the server
            await Task.Delay(50);
            var returnValue = new List<EnterTime>();
            if (Date.DayOfYear%2 == 0)
            {
                var hourEntry = new EnterTime()
                {
                    Hours = (decimal) 1.5,
                    JobId = "2672",
                    JobName = "Test Job"
                };

                var hourEntry2 = new EnterTime()
                {
                    Hours = (decimal) 5.5,
                    JobId = "150",
                    JobName = "Company Meeting"
                };
                returnValue.Add(hourEntry);
                returnValue.Add(hourEntry2);
            }
            else
            {
                var hourEntry = new EnterTime()
                {
                    Hours = (decimal)0.5,
                    JobId = "1100",
                    JobName = "Project Prep"
                };

                var hourEntry2 = new EnterTime()
                {
                    Hours = (decimal)7,
                    JobId = "1504",
                    JobName = "Close Project"
                };
                var hourEntry3 = new EnterTime()
                {
                    Hours = (decimal)4.5,
                    JobId = "151",
                    JobName = "Meeting"
                };
                returnValue.Add(hourEntry);
                returnValue.Add(hourEntry2);
                returnValue.Add(hourEntry3);
            }
            
            
            return returnValue;
        }

        public System.Windows.Input.ICommand RemoveCommand
        {
            get { throw new System.NotImplementedException(); }
        }

        public System.Windows.Input.ICommand SelectedCommand
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// Move calendar back a day
        /// </summary>
        public void BackCalendarDateCommand()
        {
            Date = Date.AddDays(-1);
        }

        /// <summary>
        /// Move calendar forward a day
        /// </summary>
        public void ForwardCalendarDateCommand()
        {
            Date = Date.AddDays(1);
        }

        private MvxCommand m_ReloadCommand;
        public ICommand ReloadCommand
        {
            get
            {
                return m_ReloadCommand ?? (m_ReloadCommand = new MvxCommand(RefreshHoursFromTable));
            }
        }

        /// <summary>
        /// Pull to refresh support
        /// </summary>
        private async void RefreshHoursFromTable()
        {
            IsBusy.Value = true;
            Hours = await SimulatedServerCallGetHours();
            TotalHours.Value = Hours.Sum(x => x.Hours);
            IsBusy.Value = false;
        }
    }
}
