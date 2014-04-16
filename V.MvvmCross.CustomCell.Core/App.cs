// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the App type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace V.MvvmCross.CustomCell.Core
{
    using Cirrious.CrossCore.IoC;
    using Cirrious.MvvmCross.ViewModels;
    using V.MvvmCross.CustomCell.Core.ViewModels;

    /// <summary>
    /// Define the App type.
    /// </summary>
    public class App : MvxApplication
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public override void Initialize()
        {
            this.CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //// Start the app with the First View Model.
            this.RegisterAppStart<FirstViewModel>();
        }
    }
}