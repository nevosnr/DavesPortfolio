using MudBlazor;

namespace DavesPortfolio.Client.Pages
{
    public partial class Recognise
    {
        int calledResult = 0;
        int result = 0;

        private void AddResult()
        {
            result++;
        }

        private void ResetResult()
        {
            Console.WriteLine("I've reset!");
            result = 0;
            calledResult = 0;
        }

        private int ReturnResult()
        {
            Console.WriteLine(result);
            return result;
        }

        private void CallResult()
        {
            calledResult = ReturnResult();
        }
    }
}