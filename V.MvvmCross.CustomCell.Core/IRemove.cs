using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace V.MvvmCross.CustomCell.Core
{
    public interface IRemove
    {
        ICommand RemoveCommand { get; }
        ICommand SelectedCommand { get; }
    }
}
