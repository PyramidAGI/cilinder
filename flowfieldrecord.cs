namespace cilinder
{
    class flowfieldrecord
    {
        /* for more information on the elements and value see paper 1 
         * a card is one of the onto-items in this subplane
         * a subplane can also be seen as a situation
         * the flowfield will traverse all records and inspect which quarks/aspects dominate
         */
        public string ffid; //to which flowfield does this sent belong
        public string cardid; //to which card does this sent belong
        public string e0;
        public string e1;
        public string e2;
        public string e3;
        public int val;
        public int perc; //how true is this sent
        public string nlsentence; //gives more detail for historical inspection
    }
}
