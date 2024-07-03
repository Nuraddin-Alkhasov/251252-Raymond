using HMI.CO.General;
using HMI.CO.Recipe;
using HMI.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.CO.Protocol
{
    public class Loading
    {
        public Loading()
        {
        }

        public Loading(string V)
        {
            IVariableService VS = ApplicationService.GetService<IVariableService>();
            Event = VS.GetVariable(V);
            Event.Change += Event_Loading;
        }

        #region - - - Properties - - - 
        IVariable Event;
        public int Machine { set; get; }
        public IVariable Data_1 { set; get; }
        public IVariable Data_2 { set; get; }
        public IVariable Data_3 { set; get; }
        public IVariable MR_Id { set; get; }
        int Article_Id { set; get; }
        public IVariable Order_Id { set; get; }
        public IVariable Box_Id { set; get; }
        private int Protocol_MR_Id { set; get; }
        #endregion

        #region - - - Event Handlers - - - 
        private void Event_Loading(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                Event.Value = false;
                Task.Run(() =>
                {
                    Order_Id.Value = NewOrder();
                    Box_Id.Value = NewBox();
                    CopyMR();
                    CopyArticle();
                });
            }
        }

        #endregion

        #region - - - Methods - - - 
        private int NewOrder()
        {
            DataTable DT = new MSSQLEAdapter("Orders", "SELECT * " +
                                             "FROM Orders " +
                                             "WHERE Data_1 ='" + Data_1.Value + "'; ").DB_Output();
            if (DT.Rows.Count == 0)
            {
                new MSSQLEAdapter("Orders", "INSERT " +
                                      "INTO Orders " +
                                      "(Data_1, Data_2, Data_3, [User]) " +
                                      "VALUES ('" +
                                      Data_1.Value + "','" +
                                      Data_2.Value + "','" +
                                      Data_3.Value + "','" +
                                      ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "')").DB_Input();

                DT = new MSSQLEAdapter("Orders", "SELECT * " +
                                       "FROM Orders " +
                                       "WHERE Data_1 ='" + Data_1.Value + "'; ").DB_Output();
            }

            return (int)DT.Rows[0]["Id"];

        }
        private int NewBox()
        {
            DataTable DT = new MSSQLEAdapter("Orders", "SELECT MAX(Box) as Box " +
                                             "FROM Boxes " +
                                             "WHERE Order_Id ='" + Order_Id.Value + "'; ").DB_Output();

            int Box = 1;
            if (DT.Rows[0][0] != DBNull.Value)
            {
                Box = (int)DT.Rows[0]["Box"] + 1;
            }
            new MSSQLEAdapter("Orders", "INSERT " +
                                 "INTO Boxes " +
                                 "(Order_Id, Machine, Box, [User]) " +
                                 "VALUES (" +
                                 Order_Id.Value + "," +
                                 Machine + "," +
                                 Box + ",'" +
                                 ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "')").DB_Input();

            DT = new MSSQLEAdapter("Orders", "SELECT * " +
                                   "FROM Boxes " +
                                   "WHERE Order_Id = " + Order_Id.Value + " AND " +
                                   "Box = " + Box + "; ").DB_Output();

            return (int)DT.Rows[0]["Id"];
        }
        private void CopyMR()
        {
            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *" +
                                                        "FROM Recipes_MR " +
                                                        "WHERE Id = '" + MR_Id.Value + "'").DB_Output();
            Article_Id = (int)DT.Rows[0]["Article_Id"];

            new MSSQLEAdapter("Orders", "INSERT " +
                    "INTO Recipes_MR " +
                    "(Order_Id, Box_Id, [Name], [Description], LastChanged, [User]) " +
                    "VALUES (" +
                    Order_Id.Value.ToString() + "," + 
                    Box_Id.Value.ToString() + ",'" +
                    (string)DT.Rows[0]["Name"] + "','" + 
                    (DT.Rows[0]["Description"] == DBNull.Value ? "" : (string)DT.Rows[0]["Description"]) + "','" +
                    GetDataTimeFormated((DateTime)DT.Rows[0]["LastChanged"]) + "','" +
                    (string)DT.Rows[0]["User"] + "'); ").DB_Input();

            DataTable pmid = new MSSQLEAdapter("Orders", "SELECT * " +
                                  "FROM Recipes_MR " +
                                  "WHERE Order_Id = " + Order_Id.Value + " AND " +
                                  "Box_Id = " + Box_Id.Value + "; ").DB_Output();
            Protocol_MR_Id =(int)pmid.Rows[0]["Id"];
        }
        private void CopyArticle()
        {
            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *" +
                                                        "FROM Recipes_Article " +
                                                        "WHERE Id = '" + Article_Id + "'").DB_Output();

            new MSSQLEAdapter("Orders", "INSERT " +
                    "INTO Recipes_Article " +
                    "(Order_Id, Box_Id, MR_Id, [Name], [Description], Art_Id, Art, Image, Type_Id, Type, Size_Id, Size, LD_VWRecipe, BT_VWRecipe, PO_VWRecipe, LastChanged, [User]) " +
                    "VALUES (" +
                    Order_Id.Value.ToString() + "," +
                    Box_Id.Value.ToString() + "," +
                    Protocol_MR_Id + ",'" +
                    (string)DT.Rows[0]["Name"] + "','" +
                    (DT.Rows[0]["Description"] == DBNull.Value ? "" : (string)DT.Rows[0]["Description"]) + "'," +
                    (int)DT.Rows[0]["Art_Id"] + "," +
                    "'@Lists.ArticleArts.Text"+ ((int)DT.Rows[0]["Art_Id"] + 1 ).ToString() + "','" +
                    (int)DT.Rows[0]["Art_Id"] + "'," +
                     (int)DT.Rows[0]["Type_Id"] + "," +
                     "'@Lists.YesNo.Text" + ((int)DT.Rows[0]["Type_Id"] + 1).ToString() + "'," +
                    (int)DT.Rows[0]["Size_Id"] + "," +
                     "'@Lists.ArticleSize.Text" + ((int)DT.Rows[0]["Size_Id"] + 1).ToString() + "','" +
                    (string)DT.Rows[0]["LD_VWRecipe"] + "','" +
                    (string)DT.Rows[0]["BT_VWRecipe"] + "','" +
                    (string)DT.Rows[0]["PO_VWRecipe"] + "','" +
                    GetDataTimeFormated((DateTime)DT.Rows[0]["LastChanged"]) + "','" +
                    (string)DT.Rows[0]["User"] + "'); ").DB_Input();

        }
        private string GetDataTimeFormated(DateTime t)
        {
            return t.ToString("yyyyMMdd HH:mm:ss");
        }

        #endregion

    }
}
