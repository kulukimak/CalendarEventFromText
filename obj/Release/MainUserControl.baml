   M S B A M L   `   `   `  ����   CalendarEventFromText+    %CalendarEventFromText.MainUserControl   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .���   � ColumnDefinitions  �� $	��447��$	��447 ��� $
��Auto ���  � RowDefinitions �� �� $
��Auto �$	��200��.+��� -    ��Name$ SourceTextBox��$��0��$��5q� �� TextWrapping$ WrapWithOverflow=� �� AcceptsReturn .  �� 
AcceptsTab . " �� VerticalScrollBarVisibility$
 Auto=�$ �� HorizontalScrollBarVisibility$ Visible=��� -    ��Name$ EnableGruppeCheckBox��$��
Categories��$
��Left=�$��5,8,0,0q�$��1��$	��Top=�$��15��$��78���� -   $ GruppeTextBox��$
��Left=�$��20��$��88,5,0,0q�$��1��$
 Wrap=�$	��Top=�$��82��{�.  �� -   $ EnableSubjectCheckBox��$��Subject��$
��Left=�$��5,32,0,0q�$��1��$	��Top=�$��15��$��59���� -   $ SubjectTextBox��{�.  $
��Left=�$��20��$��	88,30,0,0q�$��1��$
 Wrap=�$	��Top=�$��83���� -   $# EnableBodyRichTextBoxCheckBox��$
��Body��$
��Left=�$��	206,8,0,0q�$��1��$	��Top=�$��15��$��47���� -   	 ��Name$	 BodyRichTextBox��{�.  $��	258,5,0,0q�$��1��$��80��$	��Top=�$
��Left=�$	��185��$
 Auto=�$
 Auto=�. �/� .T�J� .*�.*��� $� ���� -   
 ��Name$
 PreviewButton��$��
Preview...��$
��Left=�$��5,65,0,0q�$��1��$	��Top=�$��75��$��20���� -	    ��Name$ PreviewsCreatedTextBlock��$
��Left=�$��	94,68,0,0q�$��1��$
��Wrap=�$	��Top=�$	��151���� -
   $
 CreateEventsButton��$��Create Events��$
��Left=�$��5,90,0,0q�$��1��$	��Top=�$��87��$��20��&   System.Windows.Controls.DataGrid  -     Name$ MainDataGrid��   CanUserResizeRows .  {�.     AutoGenerateColumns .  $��2��$��0��$��2��$��Stretch=�$��5q�$��Stretch=�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Subject��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	Subject+  $ 
Start Time�� �� *Start+ �� StringFormat$ {0:dd.MM.yyyy HH:mm}��  $ End Time�� �� *End+$ {0:dd.MM.yyyy HH:mm}��  $ Location�� �� *
Location+  $ 
Categories�� �� *
Categories+  $
 Body�� �� *Body+�� -   $ EventsCreatedTextBlock��$
��Left=�$��
102,92,0,0q�$��1��$
��Wrap=�$	��Top=�$	��151���� $��0��$��1���� $��0��$��1��$��2�� �� ResizeDirection$ Columns=�$��3��$
��Auto��$��Stretch=�$��Stretch=��� $��0��$��1��  -   $ RevertableListBox�� .     CanUserAddRows .   .     CanUserDeleteRows .  $
��Left=�$��98��$��
258,92,0,0q�$��1��$��0��$	��Top=�$	��185��   $ ID�� �� *ID+ �� Mode$ OneWay=�  $ Subjects�� �� *UniqueSubjects+$ OneWay=�  $ Count�� �� *NumberEvents+$ OneWay=� � ContextMenu �� .@�m� -    m�Name$ 
RevertItem��$��Revert��