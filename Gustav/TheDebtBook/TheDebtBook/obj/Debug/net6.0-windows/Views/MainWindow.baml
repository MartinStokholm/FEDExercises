   M S B A M L   `   `   `  ????  TheDebtBook"    TheDebtBook.Views.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   -   5        !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5	   	    ? Title$ The Debt Book??5
   	   $	??450??6   $	??500??6,   .??5      ]? -   5        $??dockPanelMain??5      .+?5   
   o? -   5        $??mainMenu??5   $   $	??Top=?6   .@?5      m? $??_File??6   .@?5      m? $
??_New??6    m? Command 6)   ?? *NewFileCommand+m? 5      $??_Open??6    6*   ?? *OpenFileCommand+m? 5      $??_Save??6    6*   ?? *SaveCommand+m? 5      $??Save _As??6    6-   ?? *SaveAsCommand+5      5      ?? 5   
   
???   ?$??2q?6%   ._?5      ? $??Stretch=?6   $??Stretch=?61   $??0,0,0,0q?6M    ? RowDefinitions 5      ?? 5      $	??100 ?6$   ?? 5       ? ColumnDefinitions 5      ?? 5      ?? 5      $	??150 ?6'   .+?5"      ?? $??
Add debtor??5#      $??Center=?5$      $	??Top=?5%      $??24(?6)   $??1??67   $??1??6D   $??0,40,0,0q?5&   0   ??6   ?? *
AddCommand+60   ?? 5*      $??Debtors??6   $
??Left=?5+      $??	25,20,0,0q?5,      $	??Top=?5-      $??36(?6(   $
??Bold"?66   &   System.Windows.Controls.DataGrid  50      -   5        $??	DataGrid1??56      $ ?? IsSynchronizedWithCurrentItem$
 TrueY?54         AutoGenerateColumns$ False??55      $??	20,5,10,5q?57      $??0??58      $??1??59         CanUserAddRows$ False??5:         CanUserDeleteRows$ False??5;      	   
IsReadOnly$
	 True??5<      
   MinRowHeight$
 12Q?5=      ??51      ??  ?? Path$ Debtors? ?? SelectedItem 52      ?? $ CurrentDebtor? ?? SelectedIndex 53      ?? $ CurrentIndex?   Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name??6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   ?? $
 Name?  5B      $ Balance??6-   $ 1* 6>    6I   ?? $ Balance?*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5D      +  %Microsoft.Xaml.Behaviors.EventTrigger  5E         	EventName$ MouseDoubleClick??6)   *	  $Microsoft.Xaml.Behaviors.TriggerBase 	  Actions. 5F      -
  'Prism.Interactivity.InvokeCommandAction
   
  Command 68   ?? *CheckBalanceCommand+5G      5I      ?? 5L      
???   ?	 ?? X1$ 0??6'   	 ?? Y1$ 95??6.   	 ?? X2$
 2000??66   	 ?? Y2$ 95??6@   5M      5N      5O      5P      