
namespace HMI.CO.Recipe
{
    public class MCP
    {
        public MCP()
        {
        }

        public MCP(int _Machine, Coating _Coating, Paint _Paint)
        {
            Machine = _Machine;
            Coating = _Coating;
            Paint = _Paint;
        }
        public int Machine { set; get; } = 0;
        public Coating Coating { set; get; } = new Coating();
        public Paint Paint { set; get; } = new Paint();
       
    }
}
