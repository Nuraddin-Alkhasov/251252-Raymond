﻿
using VisiWin.ApplicationFramework;

namespace HMI.CO.Protocol
{
    public class ActualValues : AdapterBase
    {

        public ActualValues()
        {
        }
        public long Id { set; get; } = -1;
        public long Order_Id { set; get; } = -1;
        public long Box_Id { set; get; } = -1;
        public long Charge_Id { set; get; } = -1;
        public long Layer_Id { set; get; } = -1;
        public float PaintTemp { set; get; } = 0;
        public float PZTempMin { set; get; } = 0;
        public float PZTemp { set; get; } = 0;
        public float PZTempMax { set; get; } = 0;
        public float WZTempMin { set; get; } = 0;
        public float WZTemp { set; get; } = 0;
        public float WZTempMax { set; get; } = 0;
        public float HZTempMin { set; get; } = 0;
        public float HZTemp { set; get; } = 0;
        public float HZTempMax { set; get; } = 0;
        public float CZTempMin { set; get; } = 0;
        public float CZTemp { set; get; } = 0;
        public float CZTempMax { set; get; } = 0;

    }
}
