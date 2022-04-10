using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace BIMDataPowerBI
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Command4 : IExternalCommand
    {
        private string url = "https://api.powerbi.com/beta/0684ed1b-ca0f-48a7-975e-2334ad41db56/datasets/8c5c0def-956c-4e67-ae6f-29b83c38e07e/rows?noSignUpCheck=1&cmpid=pbi-glob-head-snn-signin&key=TQpepnGKpfEw8FXP1UZbFtdFEIquzEETsCPXjUfD9guKtvAG2Kgd5X1x%2B6bLIyzhpWVkc84t2jwIyG0baGBqaA%3D%3D";  // replace url value with your POWER BI Push URL
        public DataParser dataParser = new DataParser();
        public API api = new API();
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
        {
            Document doc = revit.Application.ActiveUIDocument.Document;
            DataParser.Data data = this.dataParser.GetData(doc);

            string apiResponse = api.PostRequest(data, url);

            TaskDialog.Show("Data Parsed", url + "\n\n" + apiResponse.ToString());
            return Autodesk.Revit.UI.Result.Succeeded;
        }
        public void Run(Document doc)
        {
            DataParser.Data data = this.dataParser.GetData(doc);
            api.PostRequest(data, url);
        }
    }
}