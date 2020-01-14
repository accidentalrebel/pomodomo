using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoList
{
    class TDLItem
    {
        private string title = "";
        private string toBeParsed = "";

        /// <summary>
        /// Default constructor
        /// </summary>
        public TDLItem() { }

        /// <summary>
        /// Constructor that accepts a string to be parsed
        /// </summary>
        /// <param name="taskTitle">The string to be parsed</param>
        public TDLItem(string _toBeParsed)
        {
            toBeParsed = _toBeParsed;
            System.Windows.Forms.MessageBox.Show(DivideString(toBeParsed)[0]);
        }

        /// <summary>
        /// Divides a received string
        /// </summary>
        /// <param name="toBeDivided"></param>
        /// <returns></returns>
        private string[] DivideString(string toBeDivided)
        {
            //string[] wordHolder = new string[30];
            //wordHolder = toBeDivided.Split(' ');
            //return toBeDivided.Split(' ')[0].ToString() ;

            return toBeDivided.Split(' '); ;
        }

        public string ToBeParsed
        {
            set { toBeParsed = value; }
            get { return toBeParsed; }
        }
        
    }
}
