using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using V.MvvmCross.CustomCell.Core.Business_Entities;

namespace V.MvvmCross.CustomCell.iOS.Cells
{
    [Register("HoursEntryCell")]
    public class HoursEntryCell : MvxTableViewCell
    {        
        public HoursEntryCell()            
        {
            CreateLayout();
            InitializeBindings();
        }

        public HoursEntryCell(IntPtr handle)
            : base(handle)
        {
            CreateLayout();
            InitializeBindings();
        }

        private UILabel jobId;
        private UILabel hours;
        private UILabel jobName;
       
        private void CreateLayout()
        {
            const int offsetStart = 10;
            Accessory = UITableViewCellAccessory.DisclosureIndicator;
            jobId = new UILabel(new RectangleF(offsetStart, 0, 75, 40));
            hours = new UILabel(new RectangleF(UIScreen.MainScreen.Bounds.Right - 85, 0, 55, 40));
            hours.TextAlignment = UITextAlignment.Right;
            jobName = new UILabel(new RectangleF(jobId.Frame.Right, 0, UIScreen.MainScreen.Bounds.Width - jobId.Frame.Width - hours.Frame.Width - (3 * offsetStart), 40));
            jobName.AdjustsFontSizeToFitWidth = true;
            jobName.Lines = 0;
            jobName.Font = jobName.Font.WithSize(10);
            ContentView.AddSubviews(jobId, jobName, hours);
        }

        private void InitializeBindings()
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<HoursEntryCell, EnterTime>();
                set.Bind(jobId).To(vm => vm.JobId);
                set.Bind(hours).To(vm => vm.Hours);
                set.Bind(jobName).To(vm => vm.JobName);
                set.Apply();
            });
        }
    }
}