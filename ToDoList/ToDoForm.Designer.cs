namespace ToDoList
{
    partial class ToDoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Today", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Other Tasks", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Completed", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToDoForm));
            this.tbx_taskEntry = new System.Windows.Forms.TextBox();
            this.listView_tasks = new System.Windows.Forms.ListView();
            this.ch_taskName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_taskDeadline = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_taskPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_timer = new System.Windows.Forms.Label();
            this.lbl_currentTask = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_startOrPause = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSaveLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.maximizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbx_taskEntry
            // 
            this.tbx_taskEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_taskEntry.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_taskEntry.Location = new System.Drawing.Point(12, 130);
            this.tbx_taskEntry.Name = "tbx_taskEntry";
            this.tbx_taskEntry.Size = new System.Drawing.Size(317, 27);
            this.tbx_taskEntry.TabIndex = 0;
            this.tbx_taskEntry.TextChanged += new System.EventHandler(this.tbx_taskEntry_TextChanged);
            this.tbx_taskEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_taskEntry_KeyPress);
            // 
            // listView_tasks
            // 
            this.listView_tasks.AllowDrop = true;
            this.listView_tasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_tasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_taskName,
            this.ch_taskDeadline,
            this.ch_taskPriority});
            this.listView_tasks.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_tasks.FullRowSelect = true;
            listViewGroup1.Header = "Today";
            listViewGroup1.Name = "lvg_today";
            listViewGroup2.Header = "Other Tasks";
            listViewGroup2.Name = "lvg_otherTasks";
            listViewGroup3.Header = "Completed";
            listViewGroup3.Name = "lvg_completed";
            this.listView_tasks.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.listView_tasks.HideSelection = false;
            this.listView_tasks.LabelEdit = true;
            this.listView_tasks.LabelWrap = false;
            this.listView_tasks.Location = new System.Drawing.Point(12, 168);
            this.listView_tasks.Name = "listView_tasks";
            this.listView_tasks.Size = new System.Drawing.Size(398, 253);
            this.listView_tasks.TabIndex = 1;
            this.listView_tasks.UseCompatibleStateImageBehavior = false;
            this.listView_tasks.View = System.Windows.Forms.View.Details;
            this.listView_tasks.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_tasks_ItemDrag);
            this.listView_tasks.SelectedIndexChanged += new System.EventHandler(this.listView_tasks_SelectedIndexChanged);
            this.listView_tasks.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_tasks_DragDrop);
            this.listView_tasks.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_tasks_DragEnter);
            this.listView_tasks.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView_tasks_KeyUp);
            // 
            // ch_taskName
            // 
            this.ch_taskName.Text = "Task";
            this.ch_taskName.Width = 253;
            // 
            // ch_taskDeadline
            // 
            this.ch_taskDeadline.Text = "Deadline";
            this.ch_taskDeadline.Width = 81;
            // 
            // ch_taskPriority
            // 
            this.ch_taskPriority.Text = "Priority";
            this.ch_taskPriority.Width = 57;
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.BackColor = System.Drawing.Color.Transparent;
            this.lbl_timer.Font = new System.Drawing.Font("Calibri", 70F);
            this.lbl_timer.Location = new System.Drawing.Point(-5, 2);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(266, 115);
            this.lbl_timer.TabIndex = 2;
            this.lbl_timer.Text = "00:00";
            // 
            // lbl_currentTask
            // 
            this.lbl_currentTask.AutoSize = true;
            this.lbl_currentTask.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_currentTask.Location = new System.Drawing.Point(18, 102);
            this.lbl_currentTask.Name = "lbl_currentTask";
            this.lbl_currentTask.Size = new System.Drawing.Size(220, 15);
            this.lbl_currentTask.TabIndex = 3;
            this.lbl_currentTask.Text = "A sample task that needs to be finished";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(335, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add task";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(-1, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 29);
            this.button2.TabIndex = 5;
            this.button2.Text = "Done";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_startOrPause
            // 
            this.btn_startOrPause.Location = new System.Drawing.Point(-1, 3);
            this.btn_startOrPause.Name = "btn_startOrPause";
            this.btn_startOrPause.Size = new System.Drawing.Size(146, 54);
            this.btn_startOrPause.TabIndex = 6;
            this.btn_startOrPause.Text = "Start Timer";
            this.btn_startOrPause.UseVisualStyleBackColor = true;
            this.btn_startOrPause.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btn_startOrPause);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(265, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(154, 103);
            this.panel2.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(422, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeSaveLocationToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // changeSaveLocationToolStripMenuItem
            // 
            this.changeSaveLocationToolStripMenuItem.Name = "changeSaveLocationToolStripMenuItem";
            this.changeSaveLocationToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.changeSaveLocationToolStripMenuItem.Text = "Change save location...";
            this.changeSaveLocationToolStripMenuItem.Click += new System.EventHandler(this.changeSaveLocationToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipText = "You have successfully minimized Pomodomo";
            this.trayIcon.BalloonTipTitle = "Pomodomo minimized";
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Pomodomo";
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maximizeToolStripMenuItem,
            this.trayMenu_Exit});
            this.trayMenu.Name = "contextMenuStrip1";
            this.trayMenu.Size = new System.Drawing.Size(125, 48);
            // 
            // maximizeToolStripMenuItem
            // 
            this.maximizeToolStripMenuItem.Name = "maximizeToolStripMenuItem";
            this.maximizeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.maximizeToolStripMenuItem.Text = "Maximize";
            this.maximizeToolStripMenuItem.Click += new System.EventHandler(this.maximizeToolStripMenuItem_Click);
            // 
            // trayMenu_Exit
            // 
            this.trayMenu_Exit.Name = "trayMenu_Exit";
            this.trayMenu_Exit.Size = new System.Drawing.Size(124, 22);
            this.trayMenu_Exit.Text = "Exit";
            this.trayMenu_Exit.Click += new System.EventHandler(this.trayMenu_Exit_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ToDoForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 433);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_currentTask);
            this.Controls.Add(this.tbx_taskEntry);
            this.Controls.Add(this.lbl_timer);
            this.Controls.Add(this.listView_tasks);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ToDoForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ToDoForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ToDoForm_KeyUp);
            this.Resize += new System.EventHandler(this.ToDoForm_Resize);
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_taskEntry;
        private System.Windows.Forms.ListView listView_tasks;
        private System.Windows.Forms.ColumnHeader ch_taskName;
        private System.Windows.Forms.ColumnHeader ch_taskDeadline;
        private System.Windows.Forms.ColumnHeader ch_taskPriority;
        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.Label lbl_currentTask;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_startOrPause;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeSaveLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem trayMenu_Exit;
        private System.Windows.Forms.ToolStripMenuItem maximizeToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
    }
}

