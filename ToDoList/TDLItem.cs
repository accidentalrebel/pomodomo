using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ToDoList
{
    public class TDLItem
    {
        enum DayAbbrev { Sun, Mon, Tue, Wed, Thu, Fri, Sat};
        enum Months
        {
            January=1, February, March, April, May, June, July, August, September, October, November,
            December, Jan, Feb, Mar, Apr, may, Jun, Jul, Aug, Sept, Oct, Nov, Dec
        };

        List<int> indicesToRemove = new List<int>();
        int indexPointer = 0;
        
        private string taskTitle = "";
        private DateTime deadline = new DateTime();
        private int priority = 0;

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
            List<string> wordArray = DivideString(_toBeParsed);
            deadline = GetDeadline(wordArray);            
            priority = GetPriorityNumber(ref wordArray);
            RemoveUsedIndices(ref wordArray);
            taskTitle = GetTaskTitle(wordArray);
        }

        public string TaskTitle
        {
            get { return taskTitle; }
        }
        public string Deadline
        {
            get { return deadline.ToShortDateString(); }
        }
        public int Priority
        {
            get { return priority; }
        }

        /// <summary>
        /// Gets the task title from the wordArray
        /// </summary>
        /// <param name="wordArray">The list to check</param>
        /// <returns>The title of the task</returns>
        private string GetTaskTitle(List<string> wordArray)
        {
            string stringToDisplay = "";
            foreach (string element in wordArray)
            {
                stringToDisplay += element + " ";
            }
            return stringToDisplay;
        }

        /// <summary>
        /// Gets the priority number
        /// </summary>
        /// <param name="wordArray">The wordArray to check</param>
        /// <returns>The priority number. 3 is the default.</returns>
        private int GetPriorityNumber(ref List<string> wordArray)
        {
            int theNum = 0;
            int index = 0;
            foreach (string word in wordArray)
            {
                for (int numToCheck = 1; numToCheck <= 3; numToCheck++)
                {
                    int.TryParse(word, out theNum);
                    if (theNum == numToCheck)
                    {
                        MarkIndexAsUsed(index);
                        return theNum;
                    }
                }
                index++;
            }
            return 3;
        }

        /// <summary>
        /// Gets the deadline, if there is any, from the wordArray
        /// </summary>
        /// <param name="wordArray">The array of words that contains the task input</param>
        /// <returns>The deadline in the form of DateTime</returns>
        private DateTime GetDeadline(List<string> wordArray)
        {
            int indexOfNext;
            int theIndex;
            bool nextKeyword = false;
            Tuple<DateTime, int> dateAndIndex;
            DateTime theDate;

            // Check if the deadline is today            
            if ((theIndex = SearchInWordArray("today", wordArray)) != 0)
            {
                MarkIndexAsUsed(theIndex - 1);
                return DateTime.Today;
            }
            else if ((theIndex = SearchInWordArray("tomorrow", wordArray)) != 0)
            {
                MarkIndexAsUsed(theIndex - 1);
                return DateTime.Today.AddDays(1);
            }
            else if ((theDate = GetTheDate(wordArray)) != DateTime.MinValue)
            {
                //MarkIndexAsUsed(theIndex - 1);
                return theDate;
            }
            else if ((dateAndIndex = CheckIfThereIsDayNumber(wordArray)).Item1 != DateTime.MinValue)
            {
                MarkIndexAsUsed(dateAndIndex.Item2 - 1);
                CheckDeadlineKeywords(wordArray, dateAndIndex.Item2 - 1, true);
                return dateAndIndex.Item1;
            }
            else
            {
                // We check if there is a "next" keyword in the array
                if ((indexOfNext = SearchInWordArray("next", wordArray)) != 0)
                {
                    MarkIndexAsUsed(indexOfNext - 1);
                    nextKeyword = true;

                    // We check if "next week"
                    if (indexOfNext + 1 == SearchInWordArray("week", wordArray))
                    {
                        MarkIndexAsUsed(indexOfNext);
                        return DateTime.Today.AddDays(7.0);
                    }
                    else if (indexOfNext + 1 == SearchInWordArray("month", wordArray))
                    {
                        MarkIndexAsUsed(indexOfNext);
                        return DateTime.Today.AddMonths(1);
                    }
                    else if (indexOfNext + 1 == SearchInWordArray("year", wordArray))
                    {
                        MarkIndexAsUsed(indexOfNext);
                        return DateTime.Today.AddMonths(12);
                    }
                }

                // We check if specified in this week
                if ((dateAndIndex = CheckIfInWeek(wordArray, nextKeyword)).Item2 != 0)
                {
                    if (nextKeyword)
                    {
                        // We then check if immediately preceding the next keyword is a day
                        if (dateAndIndex.Item2 == indexOfNext + 1)
                        {
                            MarkIndexAsUsed(indexOfNext);
                            // If so, we return only the DateTime but with an added 7 days
                            return dateAndIndex.Item1.AddDays(7.0);
                        }
                    }
                    else
                    {
                        MarkIndexAsUsed(dateAndIndex.Item2-1);
                        return dateAndIndex.Item1;
                    }
                }
                // We check if specified in this month
                else if ((dateAndIndex = CheckIfInMonth(wordArray)).Item2 != 0)
                {
                    if (nextKeyword)
                    {
                        // We then check if immediately preceding the next key is a month
                        if (dateAndIndex.Item2 == indexOfNext + 1)
                        {
                            MarkIndexAsUsed(indexOfNext);
                            return dateAndIndex.Item1.AddYears(1);
                        }
                    }
                }
            }

            return new DateTime();
        }

        /// <summary>
        /// Checks if there is are deadline keywords near the given index inside wordArray
        /// </summary>
        /// <param name="wordArray">The list to check</param>
        /// <param name="indexStart">The index to check</param>
        /// <param name="onThe">If true, check for the keyword "on the", if false, only check "on"</param>
        private void CheckDeadlineKeywords(List<string> wordArray, int indexStart, bool onThe = false)
        {
            if (onThe)
            {
                if (indexStart >= 2)
                {
                    if (wordArray[indexStart - 2].ToLower() == "on" && wordArray[indexStart - 1].ToLower() == "the")
                    {
                        MarkIndexAsUsed(indexStart - 1);
                        MarkIndexAsUsed(indexStart);
                    }
                }
            }
            else
            {
                if (indexStart >= 1)
                {
                    if (wordArray[indexStart - 1].ToLower() == "on")
                    {
                        MarkIndexAsUsed(indexStart);
                    }
                }
            }
        }

        /// <summary>
        /// Saves the index to indicesToRemove which will be removed
        /// through the use of the function RemoveUsedIndices
        /// </summary>
        /// <param name="indexToRemove"></param>
        private void MarkIndexAsUsed(int indexToRemove)
        {
            try
            {
                indicesToRemove.Add(indexToRemove);
            }
            catch
            {
                MessageBox.Show("Error with AddToRemoveLaterList",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Removes the indices found at the indicesToRemove list object from wordArray
        /// </summary>
        /// <param name="wordArray">Reference to the WordArray</param>
        private void RemoveUsedIndices(ref List<string> wordArray)
        {            
            int indexAdjust = 0; // This is used for adjusting the index
            int indexToRM = 0;

            foreach (int index in indicesToRemove)
            {
                if ( (indexToRM = index - indexAdjust) >= 0 )
                {
                    // We remove the element at index with indexAdjust                
                    wordArray.RemoveAt(indexToRM);
                }

                indexAdjust++;
            }
        }

        /// <summary>
        /// Used to display the content of a List<string> object
        /// </summary>
        /// <param name="toDisplay">The List<string> object to display</param>
        private void DisplayContent(List<string> toDisplay)
        {
            string stringToDisplay = "";
            foreach (string element in toDisplay)
            {
                stringToDisplay += element + " ";
            }

            MessageBox.Show("Content is: " + stringToDisplay);
        }

        /// <summary>
        /// Gets the date, if there is any, from the wordArray
        /// </summary>
        /// <param name="wordArray">The word array to check</param>
        /// <returns>The date in DateTime</returns>
        private DateTime GetTheDate(List<string> wordArray)
        {
            int index;
            int theNumber;  
            Tuple<DateTime, int> dateAndIndex;
            DateTime theDate;

            if ((dateAndIndex = CheckIfInMonth(wordArray)).Item2 != 0)
            {
                theDate = dateAndIndex.Item1;
                index = dateAndIndex.Item2;

                if (wordArray.Count > index)
                {
                    // We remove any any ',' character
                    wordArray[index] = wordArray[index].Replace(",", "");

                    // We then check if there is a number on the given index
                    theNumber = CheckIfNumber(wordArray, index);

                    // We then check if the number is a day or a year
                    // If there is none
                    if (theNumber == 0)
                    {
                        CheckDeadlineKeywords(wordArray, index-1);
                        MarkIndexAsUsed(index-1);   // Remove the index where the month is locaed
                        return YearAdjuster(theDate); ;
                    }
                    // If the number is a year
                    else if (theNumber > 1000 && theNumber < DateTime.MaxValue.Year )
                    {
                        MarkIndexAsUsed(index - 1);   // Remove the index where the month is located
                        MarkIndexAsUsed(index);   // Remove the index where theNumber is located
                        return YearAdjuster(new DateTime(theNumber, theDate.Month, theDate.Day));                         
                    }
                    else if (theNumber > 0 && theNumber <= 31)
                    {
                        theDate = new DateTime(theDate.Year, theDate.Month, theNumber);   

                        // We then check if there is a year after this date
                        if ( index <= wordArray.Count )
                        {
                            if ( index < wordArray.Count-1 && (theNumber = CheckIfNumber(wordArray, index + 1)) != 0)
                            {
                                if (theNumber > 1000 && theNumber < DateTime.MaxValue.Year)
                                {
                                    MarkIndexAsUsed(index - 1);   // Remove the index where the month is located
                                    MarkIndexAsUsed(index);         // Remove the index where date is located
                                    MarkIndexAsUsed(index + 1);   // Remove the index where year is located
                                    return YearAdjuster(new DateTime(theNumber, theDate.Month, theDate.Day));
                                }
                            }
                            else
                            {
                                MarkIndexAsUsed(index - 1);   // Remove the index where the month is located
                                MarkIndexAsUsed(index);   // Remove the index where the date is located
                                return YearAdjuster(theDate);
                            }
                        }                        
                    }
                }

                return YearAdjuster(theDate);
            }

            return DateTime.MinValue;
        }

        /// <summary>
        /// Adjusts the year depending on whether the date specified is
        /// earlier than the current date today
        /// </summary>
        /// <param name="theDate">The date to compare with</param>
        /// <returns>The date, adjusted or not</returns>
        private DateTime YearAdjuster(DateTime theDate)
        {
            // If this date is earlier than toady, then add a year
            if (theDate.CompareTo(DateTime.Today) < 0)
            {                
                theDate.AddYears(1);
                //MessageBox.Show("Earlier: " + theDate.ToShortDateString());
                return theDate;
            }
            return theDate;
        }

        /// <summary>
        /// Checks whether the value inside wordArray pointed by index is a number
        /// </summary>
        /// <param name="wordArray">The array from which to check.</param>
        /// <param name="index">The index to check</param>
        /// <returns>0 if not a number. Otherwise returns the number.</returns>
        private int CheckIfNumber(List<string> wordArray, int index)
        {
            bool isNum = false;
            int num;    

            isNum = int.TryParse(wordArray[index], out num);
            
            if (!isNum || num == 0)
            {
                return 0;
            }
            else
            {
                return num;
            }
        }

        /// <summary>
        /// Checks the whole list if there is a number
        /// </summary>
        /// <param name="wordArray">The list to check</param>
        /// <returns>Index where the number is found. With offset 1. Returns 0 if none.</returns>
        private Tuple<DateTime, int> CheckIfThereIsDayNumber(List<string> wordArray)
        {
            int index = 1;            
            int theNum = 0;
            int num2 = 0;
            bool isNum = false;
            int suffixIndex = 1;

            foreach (string word in wordArray)
            {
                for (int numToCompareWith = 1; numToCompareWith <= 31; numToCompareWith++)
                {
                    // We check if the first character is a number
                    if (word.Length > 0)
                    {
                        isNum = int.TryParse(word[0].ToString(), out theNum);

                        if (isNum == true && word.Length > 1)
                        {
                            // We then check if the second character is a number
                            isNum = int.TryParse(word[1].ToString(), out num2);

                            // If the second character is a number
                            if (isNum == true)
                            {  
                                // We then get the 2 digit number
                                theNum = (theNum * 10) + num2;
                            }
                        }
                    }

                    if (theNum == numToCompareWith)
                    {
                        // Check if there is a "th or "nd" after the number
                        if (word.Length > 1)
                        {
                            // If a two-digit number
                            if (theNum >= 10)
                            {
                                suffixIndex = 2;  
                            }

                            // Checks whether the suffix is "nd", "rd", "th", or "st"
                            if (word[suffixIndex] == 'n' || word[suffixIndex] == 't'
                                || word[suffixIndex] == 's' || word[suffixIndex] == 'r')
                            {
                                DateTime theDate = new DateTime(DateTime.Today.Year,
                                    DateTime.Today.Month, theNum);
                                
                                // This checks if the generated date is earlier than today
                                if ( theDate.CompareTo(DateTime.Today) <= 0 )
                                {
                                    // If it is, then set the date to next month
                                    theDate = theDate.AddMonths(1);
                                }

                                return new Tuple<DateTime, int>(theDate, index);
                            }
                        }               
                    }
                }
                
                index++;
            }

            return new Tuple<DateTime, int>(DateTime.MinValue, index);
        }

        /// <summary>
        /// Checks whether there is a day inside the wordArray
        /// Checks Sunday to Saturday and Sun to Sat
        /// </summary>
        /// <param name="wordArray">The wordArray to check</param>
        /// <param name="ifNextWeek">If this check precedes a "next" keyword</param>
        /// <returns>The date of the found word and the index that it is on</returns>
        private Tuple<DateTime, int> CheckIfInWeek(List<string> wordArray, bool ifNextWeek = false)
        {
            int numOfdays = 7;
            int index = 0;
            string dayToCheck = "";

            for (int i = 0; i < numOfdays * 2; i++)
            {
                // We check if there is a day of the week found in the wordarray
                // Loop through full worded days (Sunday-Saturday)
                // before the abbreviated ones (Sun-Sat)
                if (i < numOfdays)
                {
                    dayToCheck = (DayOfWeek.Sunday + i).ToString();
                }
                else
                {
                    dayToCheck = (DayAbbrev.Sun + i - numOfdays).ToString();
                }

                index = SearchInWordArray(dayToCheck, wordArray);

                // If found in wordArray
                if (index != 0)
                {
                    // We get the difference of the two in days
                    int dayDifference = ((DayOfWeek.Sunday + i) - DateTime.Now.DayOfWeek);

                    // If a negative number
                    if (dayDifference < 0)
                    {
                        dayDifference = 7 + dayDifference;
                    }
                    // If the difference is zero
                    else if (dayDifference == 0 )
                    {
                        dayDifference = 7;
                    }
                    // If the difference is 7 and it is preceding the "next" keyword
                    else if (dayDifference == 7 && ifNextWeek )
                    {
                        dayDifference = 0;
                    }
                    
                    // We return the deadline and the index
                    return new Tuple<DateTime, int>(DateTime.Today.AddDays(dayDifference), index);
                }
            }

            return new Tuple<DateTime, int>(new DateTime(), 0);
        }

        /// <summary>
        /// Checks whether there is a month inside the wordArray
        /// Checks January to December and Jan to Dec
        /// </summary>
        /// <param name="wordArray">The wordArray to check</param>
        /// <param name="ifNextWeek">If this check precedes a "next" keyword</param>
        /// <returns>The date of the found word and the index that it is on</returns>
        private Tuple<DateTime, int> CheckIfInMonth(List<string> wordArray, bool ifNextMonth = false)
        {
            int numOfMonths = 12;
            int index = 0;
            string monthToCheck = "";

            for (int i = 0; i < numOfMonths * 2; i++)
            {
                // We check if there is a day of the week found in the wordarray
                // Loop through full worded days (Sunday-Saturday)
                // before the abbreviated ones (Sun-Sat)
                if (i < numOfMonths)
                {
                    monthToCheck = (Months.January + i).ToString();
                }
                else
                {
                    monthToCheck = (Months.Jan + i - numOfMonths).ToString();
                }

                index = SearchInWordArray(monthToCheck, wordArray);

                // If found in wordArray
                if (index != 0)
                {
                    int monthDifference;
                    // We get the difference of the two in months                  
                    if (i < numOfMonths)
                    {
                        monthDifference = (((int)Months.January + i) - DateTime.Today.Month);
                    }
                    else
                    {
                        monthDifference = (((int)Months.Jan + i) - 24 - DateTime.Today.Month);
                    }
                    
                    // We return the deadline and the index
                    return new Tuple<DateTime, int>(DateTime.Today.AddMonths(monthDifference), index);
                }
            }

            return new Tuple<DateTime, int>(new DateTime(), 0);
        }

        /// <summary>
        /// Searches the wordArray for the given string. If found, function returns
        /// the index of the word
        /// </summary>
        /// <param name="toBeSearched">The string to be searched</param>
        /// <param name="wordArray">The wordArray to search</param>
        /// <return>The index of the word. 0 means not found.</return></returns>
        private int SearchInWordArray(string toBeSearched, List<string> wordArray)
        {
            toBeSearched = toBeSearched.ToLower();
            int i = 1;
            foreach (string word in wordArray)
            {
                if (word.ToLower() == toBeSearched)
                {                    
                    return i;
                }
                i++;
            }

            return 0;
        }

        /// <summary>
        /// Divides a received string
        /// </summary>
        /// <param name="toBeDivided"></param>
        /// <returns></returns>
        private List<string> DivideString(string toBeDivided)
        { 
            // Convert multiple spaces to single
            toBeDivided = Regex.Replace(toBeDivided, @"\s+", " ");

            return new List<string>(toBeDivided.Split(' '));
        }
               
    }
}
