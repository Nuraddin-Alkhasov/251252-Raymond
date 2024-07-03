using System.Collections.Generic;

namespace HMI.CO.Recipe
{
    public class MR
    {
       
        public MR()
        {
        }
        #region - - - Properties - - - 
        public RecipeInfo Header { set; get; } = new RecipeInfo();
        public Article Article { set; get; } = new Article();
        public List<MCP> Layers { set; get; } = new List<MCP>();
      
        #endregion

        #region - - - Methods - - - 

        public override string ToString()
        {
            return Header.Id.ToString() + " - " + Header.Name;
        }
        public int Check()
        {
            if (Article.Header.Id == -1) { return 1; }
            int j = 0;
            for (int i = 0; i <= Layers.Count - 1; i++) 
            {
                if (Layers[i].Coating.Header.Id == -1) { return j + 2; }
                if (Layers[i].Paint.Header.Id == -1) { return j + 3 ; }
                if (Layers[i].Machine == 0) { return j + 4; }
                j = j + 3;
            }
            return 0;
        }
            #endregion

        }
}
