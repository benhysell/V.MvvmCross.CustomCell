// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the TestTestFirstViewModelModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace V.MvvmCross.CustomCell.Core.Tests.ViewModels
{
    using Core.ViewModels;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines the TestTestFirstViewModelModel type.
    /// </summary>
    [TestClass]
    public class TestTestFirstViewModelModel : BaseTest
    {
        /// <summary>
        /// The FirstViewModel model.
        /// </summary>
        private FirstViewModel firstViewModel;

        /// <summary>
        /// Creates an instance of the object to test.
        /// To allow Ninja automatically create the unit tests
        /// this method should not be changed.
        /// </summary>
        public override void CreateTestableObject()
        {
            this.firstViewModel = new FirstViewModel();
        }
    }
}
