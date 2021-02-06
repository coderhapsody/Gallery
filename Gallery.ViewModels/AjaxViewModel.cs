using Gallery.Framework.Base;

namespace Gallery.ViewModels
{
    public class AjaxViewModel : BaseAjaxViewModel
    {
        public dynamic Data { get; private set; }

        public AjaxViewModel(bool isSuccess = true, dynamic data = null, string message = null) : 
            base(isSuccess, message: message)
        {
            Data = data;
        }
    }
}
