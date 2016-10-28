using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADFGX_Cloud_Solver
{
    class Result
    {
        private int rank = 0;
        private string key = String.Empty;
        private float score = 0;
        private string returnVal = String.Empty;
        private string from = String.Empty;
        private DateTime timestamp = DateTime.MinValue;
        
        public int Rank
        {
            get
            {
                return rank;
            }
            set
            {
                rank = value;
            }
        }
        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }
        public float Score
        {
            get
            {
                return score;
            }
            set
            { 
                score = value;
            }
        }
        public string Return
        {
            get
            {
                return returnVal;
            }
            set
            {
                returnVal = value;
            }
        }
        public string From
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
            }
        }
        public DateTime Date
        {
            get
            {
                return timestamp.Date;
            }

        }

        public DateTime Timestamp
        {
            get
            {
                return timestamp;
            }
            set
            {
                timestamp = value;
            }
        }
    }
}
