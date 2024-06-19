using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    public class Data
    {
        public DateTime STD_DT { get; set; } //날짜,시간
        
        public int NUM {  get; set; } //인덱스
        public int MELT_TEMP { get; set; } //용해 온도
        public double MOTORSPEED { get; set; }//용해 교반속도
        public int MELT_WEIGHT { get; set; }//용해 탱크 내용량(중량)
        public float INSP { get; set; }//생산품의 수분함유량(%)

        public string TAG { get; set; }//불량 여부

    }
}
