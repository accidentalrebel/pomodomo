using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace ToDoList
{
    public partial class ToDoForm : Form
    {
        TimerHandler timerHandler;
        TaskList taskList;

        public ToDoForm()
        {
            InitializeComponent();            
        }

        private void ToDoForm_Load(object sender, EventArgs e)
        {
            timerHandler = new TimerHandler(lbl_timer, timer);
            taskList = new TaskList();
            listView_tasks.AllowDrop = true;

            // We get the saveDestination from our settings file
            folderBrowserDialog.SelectedPath = pomodomo.Default.SaveDestination;

            // We then load the tasks from our savefile
            taskList.LoadTaskList(listView_tasks.Items, listView_tasks.Groups, folderBrowserDialog.SelectedPath);
        }

        private void tbx_taskEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checks if the enter key is pressed
            if (e.KeyChar == Convert.ToChar(13))
            {
                TDLItem newTDLItem = new TDLItem(tbx_taskEntry.Text);
                taskList[taskList.GetFirstEmpty()] = newTDLItem;

                // The following removes the ... character if it is present
                if ( listView_tasks.Groups[1].Items.Count == 1 )
                {
                    ListViewItem toDelete;
                    if ((toDelete = listView_tasks.Groups[1].Items[0]).Text == "Empty")
                    {
                        listView_tasks.Items.Remove(toDelete);                        
                    }
                }

                // We add this newly created task to the listView
                ListViewItem newlyAdded = listView_tasks.Items.Add(new ListViewItem
                   (new[] { newTDLItem.TaskTitle, newTDLItem.Deadline, newTDLItem.Priority.ToString() },
                    listView_tasks.Groups[1]));

                // We then save the taskList                
                taskList.SaveTaskList(listView_tasks.Items, folderBrowserDialog.SelectedPath);

                tbx_taskEntry.Clear();
                listView_tasks.Select();
                listView_tasks.SelectedIndices.Clear();                
                listView_tasks.Items[newlyAdded.Index].Selected = true;
            }
        }

        private void tbx_taskEntry_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView_tasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_tasks.SelectedItems.Count > 0)
            {
                lbl_currentTask.Text = listView_tasks.SelectedItems[0].Text;
            }
        }

        private void listView_tasks_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listView_tasks_DragDrop(object sender, DragEventArgs e)
        {
            //Returns the location of the mouse pointer in the ListView control.
            Point cp = listView_tasks.PointToClient(new Point(e.X, e.Y));
            ListViewItem dragToItem = listView_tasks.GetItemAt(cp.X, cp.Y);
            
            // If there is none, don't continue, just return
            if (dragToItem == null)
            {
                return;
            }

            //Obtain the index of the item at the mouse pointer.
            int dragIndex = dragToItem.Index;

            ListViewItem draggedItem;
            ListViewItem insertItem;

            // Copy all selected items to sel
            ListViewItem[] sel = new ListViewItem[listView_tasks.SelectedItems.Count];
            for (int j = 0; j < listView_tasks.SelectedItems.Count; j++)
            {
                sel[j] = listView_tasks.SelectedItems[j];
            }

            // We then start moving the items
            for (int i = 0; i < sel.GetLength(0) ; i++ )
            {
                // Skip if this is the blank item
                if (sel[i].Text != "Empty")
                {
                    // We set the element as the dragged item
                    draggedItem = sel[i];

                    // We then clone this item to be used later
                    insertItem = (ListViewItem)sel[i].Clone();

                    // We set the group of insert item to its respective group
                    insertItem.Group = dragToItem.Group;

                    // We remove the dragged item
                    listView_tasks.Items.Remove(draggedItem);

                    // We then insert the copy to its respective index
                    listView_tasks.Items.Insert(dragIndex, insertItem);

                    if (dragToItem.Text == "Empty")
                    {
                        listView_tasks.Items.Remove(dragToItem);
                    }

                    // This fixes the bug where the ordering is not working
                    listView_tasks.Alignment = ListViewAlignment.Default;
                    listView_tasks.Alignment = ListViewAlignment.Top;
                }
            }

            // We then save the taskList
            taskList.CheckIfGroupsAreEmpty(listView_tasks);
            taskList.SaveTaskList(listView_tasks.Items, folderBrowserDialog.SelectedPath);
        }

        private void listView_tasks_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView_tasks.DoDragDrop(listView_tasks.SelectedItems, DragDropEffects.Move);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void changeSaveLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // We save the destination to our settings file
                pomodomo.Default.SaveDestination = folderBrowserDialog.SelectedPath;
                pomodomo.Default.Save();

                MessageBox.Show("Changed save folder to: " + folderBrowserDialog.SelectedPath, "Note");
                taskList.LoadTaskList(listView_tasks.Items, listView_tasks.Groups, folderBrowserDialog.SelectedPath);
            }
        }

        private void listView_tasks_KeyUp(object sender, KeyEventArgs e)
        {
            // We delete the highlighted task
            if (listView_tasks.SelectedItems.Count > 0)
            {
                // If the delete or 'delete' key is pressed
                if (e.KeyValue == 46 )
                {
                    foreach (ListViewItem item in listView_tasks.SelectedItems)
                    {
                        if (item.Text != "Empty")
                        {
                            listView_tasks.Items.Remove(item);
                        }
                    }

                    taskList.CheckIfGroupsAreEmpty(listView_tasks);
                    taskList.SaveTaskList(listView_tasks.Items, folderBrowserDialog.SelectedPath);                   
                }
                // We mark as done if c or d is pressed
                if (e.KeyValue == 67 || e.KeyValue == 68)
                {
                    foreach (ListViewItem item in listView_tasks.SelectedItems)
                    {
                        if (item.Text != "Empty")
                        {
                            item.Group = listView_tasks.Groups[2];
                        }
                    }
                    taskList.CheckIfGroupsAreEmpty(listView_tasks);
                    taskList.SaveTaskList(listView_tasks.Items, folderBrowserDialog.SelectedPath);                   
                }

                // If the delete or 'a' key is pressed
                else if (e.KeyValue == 65)
                {
                    // Set the taskEntry as the activecontrol
                    tbx_taskEntry.Select();
                }
            }            
        }

        private void ToDoForm_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void ToDoForm_Resize(object sender, EventArgs e)
        {
            // If this window is minimized
            if (this.WindowState == FormWindowState.Minimized)
            {
                trayIcon.Visible = true;
                trayIcon.ShowBalloonTip(500);
                this.Hide();
            }
            else if ( this.WindowState == FormWindowState.Normal )
            {
                trayIcon.Visible = false;
            }
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void trayMenu_Exit_Click(object sender, EventArgs e)
        {
            OnExit(sender, e);
        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StartTimer();
        }

        private void StartTimer()
        {
            if (timerHandler.isRunning == false)
            {
                timerHandler.StartTimer();
                btn_startOrPause.Text = "Pause Timer";
            }
            else if (timerHandler.isRunning == true)
            {
                timerHandler.PauseTimer();
                btn_startOrPause.Text = "Resume Timer";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {   
            timerHandler.Tick();
        }       
        
    }
}
