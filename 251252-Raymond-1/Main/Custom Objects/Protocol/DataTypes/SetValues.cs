using HMI.CO.Recipe;
using VisiWin.ApplicationFramework;

namespace HMI.CO.Protocol
{
    public class SetValues : AdapterBase
    {

        public SetValues()
        {
        }
        public long Id { set; get; } = -1;
        public long Order_Id { set; get; } = -1;
        public long Box_Id { set; get; } = -1;
        public long Charge_Id { set; get; } = -1;
        public long Layer_Id { set; get; } = -1;
        public float PaintTemp { set; get; } = 0;
        public float PZTemp { set; get; } = 0;
        public float WZTemp { set; get; } = 0;
        public float HZTemp { set; get; } = 0;
        public float CZTemp { set; get; } = 0;

        public void SetCoating(long RecipeCoating_Id)
        {

        }
    }
}
