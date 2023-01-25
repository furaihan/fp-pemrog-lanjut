namespace PinusPengger.ViewModel.BasePageVM
{
    public interface IBasePage
    {
        string ErrorMessage { get; set; }
        void GetData();
        void ProcessData();
    }
}
