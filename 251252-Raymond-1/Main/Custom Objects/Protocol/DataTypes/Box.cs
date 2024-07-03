using HMI.CO.General;
using HMI.CO.Recipe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using VisiWin.ApplicationFramework;
using VisiWin.Language;

namespace HMI.CO.Protocol
{
    public class Box : AdapterBase
    {
        public Box() { }
        public Box(int MR_Id)
        {
            MR = new MR() { Header = new RecipeInfo() { Id = MR_Id } };
        }

        public int Id { set; get; } = -1;
        public int Order_Id { set; get; } = -1;
        public MR MR { set; get; } = new MR();
        public int Machine { set; get; } = 0;
        public int BoxNr { set; get; } = 0;      
        public bool Alarm { set; get; } = false;
        public int Charges { set; get; } = 0;
        public float Weight { set; get; } = 0;
        public string Start { set; get; } = "";
        public string End { set; get; } = "";
        public string User { set; get; } = "";
        public List<Charge> ChargesList { set; get; } = new List<Charge>();
        public void FillChargesList()
        {
            List<Charge> temp = new List<Charge>();

            DataTable DT = new MSSQLEAdapter("Orders", "Select * From Charges WHERE Box_Id = " + Id).DB_Output();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    Thread.Sleep(20);
                    temp.Add(new Charge()
                    {
                        Id = (int)r["Id"],
                        Order_Id = (int)r["Order_Id"],
                        Box_Id = Id,
                        Start = ((DateTime)r["Start"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        End = r["End"] == DBNull.Value ? "" : ((DateTime)r["End"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        ChargeNr = (int)r["Charge"],
                        Layers = (int)r["Layers"],
                        Weight = (float)r["Weight"],
                        Alarm = (bool)r["Alarm"],
                        RMO = (bool)r["RMO"],
                        User = (string)r["User"]
                    });

                }

            }
            ChargesList = temp;
        }
        public void SetMR(int MR_Id)
        {
            ILanguageService textService = ApplicationService.GetService<ILanguageService>();
            DataTable temp_MR = new MSSQLEAdapter("Orders", "Select * From Recipes_MR WHERE Id = " + MR_Id).DB_Output();
            RecipeInfo Header = new RecipeInfo()
            {
                Id = (int)temp_MR.Rows[0]["Id"],
                Name = (string)temp_MR.Rows[0]["Name"],
                Description = temp_MR.Rows[0]["Description"] == DBNull.Value ? "" : (string)temp_MR.Rows[0]["Description"],
                LastChanged = ((DateTime)temp_MR.Rows[0]["LastChanged"]).ToString("dd.MM.yyyy HH:mm:ss"),
                User = temp_MR.Rows[0]["User"] == DBNull.Value ? "" : (string)temp_MR.Rows[0]["User"],
            };

            DataTable temp_A = new MSSQLEAdapter("Orders", "Select * From Recipes_Article WHERE MR_Id = " + MR_Id).DB_Output();
            Article Article = new Article()
            {
                Header = new RecipeInfo()
                {
                    Id = (int)temp_A.Rows[0]["Id"],
                    Name = (string)temp_A.Rows[0]["Name"],
                    Description = temp_A.Rows[0]["Description"] == DBNull.Value ? "" : (string)temp_A.Rows[0]["Description"]
                },
                Art_Id = temp_A.Rows[0]["Art_Id"].ToString(),
                Type_Id = (int)temp_A.Rows[0]["Type_Id"],
                Size_Id = (int)temp_A.Rows[0]["Size_Id"]
            };

            List<MCP> Layers = new List<MCP>() { new MCP(), new MCP() , new MCP() , new MCP() , new MCP() };
            for (int i = 0; i <= 4; i++) 
            {
                DataTable temp_C = new MSSQLEAdapter("Orders", "Select TOP (1) * From Recipes_Coating WHERE MR_Id = " + MR_Id + " AND Layer = " + i.ToString()).DB_Output();
                if (temp_C.Rows.Count != 0) 
                {
                    int layer = (int)temp_C.Rows[0]["Layer"];
                    if (layer > 0)
                    {
                        Layers[layer - 1].Coating = new Recipe.Coating()
                        {
                            Header = new RecipeInfo()
                            {
                                Id = (int)temp_C.Rows[0]["Id"],
                                Name = (string)temp_C.Rows[0]["Name"],
                                Description = temp_C.Rows[0]["Description"] == DBNull.Value ? "" : (string)temp_C.Rows[0]["Description"],
                                LastChanged = ((DateTime)temp_C.Rows[0]["LastChanged"]).ToString("dd.MM.yyyy HH:mm:ss"),
                                User = temp_C.Rows[0]["User"] == DBNull.Value ? "" : (string)temp_C.Rows[0]["User"],
                            },
                            VWRecipe = new VWRecipe((string)temp_C.Rows[0]["VWRecipe"])
                        };
                    }
                }
                DataTable temp_P = new MSSQLEAdapter("Orders", "Select TOP (1) * From Recipes_Paint WHERE MR_Id = " + MR_Id + " AND Layer = " + i.ToString()).DB_Output();
                if (temp_P.Rows.Count != 0)
                {
                    int layer = (int)temp_P.Rows[0]["Layer"];
                    if (layer > 0)
                    {
                        Layers[layer - 1].Paint = new Recipe.Paint()
                        {
                            Header = new RecipeInfo()
                            {
                                Id = (int)temp_P.Rows[0]["Id"],
                                Name = (string)temp_P.Rows[0]["Name"],
                                Description = temp_P.Rows[0]["Description"] == DBNull.Value ? "" : (string)temp_P.Rows[0]["Description"],
                                LastChanged = ((DateTime)temp_P.Rows[0]["LastChanged"]).ToString("dd.MM.yyyy HH:mm:ss"),
                                User = temp_P.Rows[0]["User"] == DBNull.Value ? "" : (string)temp_P.Rows[0]["User"],
                            },
                            VWRecipe = new VWRecipe((string)temp_P.Rows[0]["VWRecipe"])
                        };
                    }
                }
                
            }
            MR = new MR()
            {
                Header = Header,
                Article = Article,
                Layers = Layers
            };
          
        }
    }
}
