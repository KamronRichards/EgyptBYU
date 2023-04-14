using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace EgyptBYU
{
    //public class Mummy_Data
    //{
    //    public float squarenorthsouth { get; set; }
    //    public float squareeastwest { get; set; }
    //    public float depth { get; set; }
    //    public string? sex { get; set; }
    //    public string? adultsubadult { get; set; }
    //    public string? facebundle { get; set; }
    //    public string? haircolor { get; set; }
    //    public string? area { get; set; }
    //    public string? ageatdeath { get; set; }

    //    public Tensor<float> AsTensor()
    //    {
    //        string?[] data = new string?[]
    //        {
    //        squarenorthsouth.ToString(), squareeastwest.ToString(), depth.ToString(), sex, adultsubadult, facebundle, haircolor, area, ageatdeath
    //        };
    //        int[] dimensions = new int[] { 1, 9 };
    //        return new DenseTensor<float>(data, dimensions);
    //    }
    //}

    public class Mummy_Data
    {
        public float squarenorthsouth { get; set; }
        public float squareeastwest { get; set; }
        public float depth { get; set; }
        public float sex_F { get; set; }
        public float sex_M { get; set; }
        public float adultsubadult_A { get; set; }
        public float adultsubadult_C { get; set; }
        public float adultsubadult_N_LL { get; set; }
        public float facebundles_TR_E { get; set; }
        public float facebundles_Y { get; set; }
        public float haircolor_A { get; set; }
        public float haircolor_B { get; set; }
        public float haircolor_D { get; set; }
        public float haircolor_K { get; set; }
        public float haircolor_R { get; set; }
        public float haircolor_T { get; set; }
        public float haircolor_Y { get; set; }
        public float area_NE { get; set; }
        public float area_NNW { get; set; }
        public float area_NW { get; set; }
        public float area_SE { get; set; }
        public float area_SW { get; set; }
        public float ageatdeath_A { get; set; }
        public float ageatdeath_C { get; set; }
        public float ageatdeath_I { get; set; }
        public float ageatdeath_IN { get; set; }
        //public float ageatdeath_In { get; set; }
        public float ageatdeath_N { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
            squarenorthsouth, squareeastwest, depth, sex_F, sex_M, adultsubadult_A,
            adultsubadult_C, adultsubadult_N_LL, facebundles_TR_E, facebundles_Y, haircolor_A,
            haircolor_B, haircolor_D, haircolor_K, haircolor_R, haircolor_T, haircolor_Y,
            area_NE, area_NNW, area_NW, area_SE, area_SW, ageatdeath_A, ageatdeath_C,
            ageatdeath_I, ageatdeath_IN, ageatdeath_N
            };
            int[] dimensions = new int[] { 1, 27 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
