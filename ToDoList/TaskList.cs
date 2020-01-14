using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ToDoList
{
    /// <summary>
    /// Indexer class that contains TDLItems
    /// </summary>
    public class TaskList
    {
        private TDLItem[] taskArray = new TDLItem[100];
        //private ListViewItem[] listViewArray = new ListViewItem[100];

        public TDLItem this[int index]
        {
            get
            {
                return taskArray[index];
            }
            set
            {
                taskArray[index] = value;
            }
        }

        public int GetFirstEmpty()
        {
            int index = 0;
            foreach (TDLItem task in taskArray)
            {
                if (task == null)
                {
                    return index;
                }

                index++;
            }

            return 0;
        }

        /// <summary>
        /// Saves the items of listView to a file
        /// </summary>
        /// <param name="listViewTasks">The items of the listView object</param>
        public void SaveTaskList(ListView.ListViewItemCollection listViewTasks, string destFolder)
        {
            try
            {
                StreamWriter file = new StreamWriter(destFolder + @"\pomodomo_save.dom");

                foreach (ListViewItem task in listViewTasks)
                {
                    file.WriteLine(task.Text + ";" + task.SubItems[1].Text + ";"
                        + task.SubItems[2].Text + ";" + task.Group);
                }

                file.Close();
            }
            catch
            {
                MessageBox.Show("Error Saving to file.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        public void LoadTaskList(ListView.ListViewItemCollection listViewTasks, ListViewGroupCollection listViewGroup, string loadFolder)
        {
            try
            {
                StreamReader file = new StreamReader(loadFolder + @"\pomodomo_save.dom");

                string line;
                string[] words;
                ListViewItem newItem;

                while ((line = file.ReadLine()) != null)
                {
                    // We then split the line at the ';' character
                    words = line.Split(';');

                    // We add this to the listView
                    newItem = listViewTasks.Add(words[0]);

                    // We then add the deadline
                    newItem.SubItems.Add(words[1]);

                    // We then add the prioirty
                    newItem.SubItems.Add(words[2]);

                    if (words[3] == "Other Tasks")
                    {
                        newItem.Group = listViewGroup[1];
                    }
                    else if (words[3] == "Today")
                    {
                        newItem.Group = listViewGroup[0];
                    }
                    else if (words[3] == "Completed")
                    {
                        newItem.Group = listViewGroup[2];
                    }
                }

                file.Close();
            }
            catch
            {
                MessageBox.Show("Couldn't load the task list file from directory " + loadFolder + @"\pomodomo_save.dom",
                     "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            }
        }

        public bool UpdateTaskList(ListView.ListViewItemCollection listViewTasks)
        {
            //GetTasksFromListView(listViewTasks);

            return false;
        }

        internal void CheckIfGroupsAreEmpty(ListView listViewList)
        {
            ListViewItem newItem;
            // If the list is empty
            if (listViewList.Groups[0].Items.Count <= 0)
            {
                newItem = listViewList.Items.Add("Empty");
                newItem.Group = listViewList.Groups[0];
                newItem.SubItems.Add("");
                newItem.SubItems.Add("");
            }
            

            if (listViewList.Groups[1].Items.Count <= 0)
            {
                newItem = listViewList.Items.Add("Empty");
                newItem.Group = listViewList.Groups[1];
                newItem.SubItems.Add("");
                newItem.SubItems.Add("");
            }
        }
    }
}
