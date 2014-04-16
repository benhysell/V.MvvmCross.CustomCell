// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the FirstView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Drawing;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.BindingContext;
using V.MvvmCross.CustomCell.iOS.Helpers;

namespace V.MvvmCross.CustomCell.iOS.Views
{
    using Core.ViewModels;
    using MonoTouch.Foundation;
    using MonoTouch.UIKit;

    /// <summary>
    /// Defines the FirstView type.
    /// </summary>
    [Register("FirstView")]
    public class FirstView : BaseView
    {
        private FirstViewModel viewModel;
        public new FirstViewModel ViewModel
        {
            get { return viewModel ?? (viewModel = base.ViewModel as FirstViewModel); }
        }
        /// <summary>
        /// Views the did load.
        /// </summary>
        /// <summary>
        /// Called when the View is first loaded
        /// </summary>
        public override void ViewDidLoad()
        {
            this.View = new UIView { BackgroundColor = UIColor.White };

            base.ViewDidLoad();
            Title = "Enter Time";
            
            var fieldHeight = 40;
            var fieldSeparatorY = 40; //separation of fields
            var location = new RectangleF(UIScreen.MainScreen.Bounds.Width / 2 - 100, 10, 200, fieldHeight);

            var dateField = new UITextField(location);
            dateField.TextAlignment = UITextAlignment.Center;
            var datePicker = new UIDatePicker();
            datePicker.Mode = UIDatePickerMode.Date;
            dateField.InputView = datePicker;

            //close date picker
            var toolbar = new UIToolbar(new RectangleF(0, 0, UIScreen.MainScreen.Bounds.Width, 40));
            var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, (delegate
            {
                dateField.ResignFirstResponder();
            }));
            var spaceButton = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
            toolbar.Items = new[] { spaceButton, doneButton };
            dateField.InputAccessoryView = toolbar;

            location = new RectangleF(10, 10, 50, 40);
            var leftButton = new UIButton(UIButtonType.RoundedRect);
            leftButton.Frame = location;
            leftButton.SetTitle("\U000025C0\U0000FE0E", UIControlState.Normal);

            location.X = UIScreen.MainScreen.Bounds.Width - 60;
            var rightButton = new UIButton(UIButtonType.RoundedRect);
            rightButton.Frame = location;
            rightButton.SetTitle("\U000025B6\U0000FE0E", UIControlState.Normal);



            location = new RectangleF(0, location.Y + fieldSeparatorY, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height - UIApplication.SharedApplication.StatusBarFrame.Size.Height - fieldHeight - (3 * fieldSeparatorY));

            var hoursTable = new UITableView(location);
            var hoursTableSource = new MvxDeleteTableViewSource(ViewModel, hoursTable);
            var refreshControl = new MvxUIRefreshControl();
            hoursTable.AddSubview(refreshControl);

            location.Y += hoursTable.Frame.Height + fieldSeparatorY / 2;
            location.Height = fieldHeight;
            location.X = UIScreen.MainScreen.Bounds.Width / 2 + 20;
            location.Width = 60;
            var totalHoursLabel = new UILabel(location);
            totalHoursLabel.Text = "Hours";
            location.X += totalHoursLabel.Frame.Width;
            var totalHours = new UILabel(location);
            totalHours.TextAlignment = UITextAlignment.Right;
            hoursTable.Source = hoursTableSource;
            hoursTable.ReloadData();

            View.AddSubviews(dateField, leftButton, rightButton, hoursTable, totalHoursLabel, totalHours);
            var set = this.CreateBindingSet<FirstView, FirstViewModel>();

            set.Bind(datePicker).For(d => d.Date).To(vm => vm.Date);
            set.Bind(dateField).To(vm => vm.Date);
            set.Bind(dateField).To("Format('{0:dddd dd MMM yyyy}', Date)");
            set.Bind(leftButton).To("BackCalendarDateCommand");
            set.Bind(rightButton).To("ForwardCalendarDateCommand");
            set.Bind(hoursTableSource).To(vm => vm.Hours);
            set.Bind(totalHours).To(vm => vm.TotalHours);
            set.Bind(refreshControl).For(r => r.RefreshCommand).To(vm => vm.ReloadCommand);
            set.Bind(refreshControl).For(r => r.IsRefreshing).To(vm => vm.IsBusy);
            set.Apply();          
        }
    }
}
