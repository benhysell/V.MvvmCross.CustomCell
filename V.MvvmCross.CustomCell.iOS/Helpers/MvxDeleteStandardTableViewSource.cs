using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using V.MvvmCross.CustomCell.Core;
using V.MvvmCross.CustomCell.iOS.Cells;

namespace V.MvvmCross.CustomCell.iOS.Helpers
{
    public class MvxDeleteTableViewSource : MvxTableViewSource
    {

        //#region Constructors
        //public MvxDeleteStandardTableViewSource(IRemove viewModel, UITableView tableView, UITableViewCellStyle style, NSString cellIdentifier, IEnumerable<MvxBindingDescription> descriptions, UITableViewCellAccessory tableViewCellAccessory = 0)
        //    : base(tableView, style, cellIdentifier, descriptions, tableViewCellAccessory)
        //{
        //    m_ViewModel = viewModel;
        //}


        //public MvxDeleteStandardTableViewSource(IRemove viewModel, UITableView tableView, string bindingText)
        //    : base(tableView, bindingText)
        //{
        //    m_ViewModel = viewModel;
        //    tableView.RegisterClassForCellReuse(typeof(HoursEntryCell), new NSString("HoursEntryCell"));
        //}

        //public MvxDeleteStandardTableViewSource(IRemove viewModel, UITableView tableView, NSString cellIdentifier)
        //    : base(tableView, cellIdentifier)
        //{
        //    m_ViewModel = viewModel;
        //}

        private IRemove viewModel;
        public MvxDeleteTableViewSource(IRemove viewModel, UITableView tableView)
            : base(tableView)
        {
            this.viewModel = viewModel;
            tableView.RegisterClassForCellReuse(typeof(HoursEntryCell), new NSString("HoursEntryCell"));
        }


        //public MvxDeleteStandardTableViewSource(IRemove viewModel, UITableView tableView, UITableViewCellStyle style, NSString cellId, string binding, UITableViewCellAccessory accessory)
        //    : base(tableView, style, cellId, binding, accessory)
        //{
        //    m_ViewModel = viewModel;
        //}
        //#endregion

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true;
        }


        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                   // m_ViewModel.RemoveCommand.Execute(indexPath.Row);
                    break;
                case UITableViewCellEditingStyle.None:
                    break;
            }
        }

        public override UITableViewCellEditingStyle EditingStyleForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return UITableViewCellEditingStyle.Delete;
        }

        public override bool CanMoveRow(UITableView tableView, NSIndexPath indexPath)
        {
            return false;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //put here b.c. this is a UI item, does not belong in core
            //var messenger = Mvx.Resolve<IMvxMessenger>();
            //messenger.Publish(new NavigationBarHiddenMessage(this, false));
            //m_ViewModel.SelectedCommand.Execute(indexPath.Row);
        }
        
        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return (HoursEntryCell)tableView.DequeueReusableCell("HoursEntryCell");
        }
    }
}