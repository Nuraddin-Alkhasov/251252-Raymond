
namespace HMI.CO.Recipe
{
    public class Article
    {
        public Article()
        {
        }

        public Article(RecipeInfo _Header, VWRecipe _LD_VWRecipe, VWRecipe _BT_VWRecipe, VWRecipe _PO_VWRecipe)
        {
            Header = _Header;
            LD = new LD()
            {
                Header = _Header,
                VWRecipe = _LD_VWRecipe
            };
            BT = new BT()
            {
                Header = _Header,
                VWRecipe = _BT_VWRecipe
            };
            PO = new PO()
            {
                Header = _Header,
                VWRecipe = _PO_VWRecipe
            };
        }
        public RecipeInfo Header { set; get; } = new RecipeInfo();
        public string Art_Id { get; set; } = "Nor";
        public int Type_Id { get; set; } = 0;
        public int Size_Id { get; set; } = 0;
        public LD LD { set; get; } = new LD();
        public BT BT { set; get; } = new BT();
        public PO PO { set; get; } = new PO();

    }
}
