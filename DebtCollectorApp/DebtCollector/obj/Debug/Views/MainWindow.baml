   M S B A M L   `   `   `  ????H  DDebtCollector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DebtCollectorDebtCollector  5   	   $    DebtCollector.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   'localclr-namespace:DebtCollector  5   	   -   5        !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX?5
   	   $
??auto??5   !   $	??450??6/    ? WindowStartupLocation$ CenterScreen=?5   	    ? SizeToContent$ Height=?5   	    ? 
ResizeMode$ NoResize=?5   	      BackgroundBrush#???   5   	    ? Title 5   	   ?? *Title+.??5      ]? -   5        $??dockPanelMain??5      .+?5   
   o? -   5        $??mainMenu??5   $   $	??Top=?6   .@?5      m? $??_File??6   .@?5      m? $
??_New??6    m? Command 6)   ?? *NewFileCommand+m? 5      $??_Open??6    6*   ?? *OpenFileCommand+m? 5      $??_Save??6    6*   ?? *SaveCommand+m? 5      $??Save _As??6    6-   ?? *SaveAsCommand+5      5      ? 5   
   $	??Top=?6   $??10q?6)   .+?5      ?? $??The Debt book??5      $??5q?5      ?? 5       $??
Add debtor??5!      $??5q?5#      $??25??5$      $??75??5%        CustomButtonStyle#??[ 5&      ??5"      ?? *
AddCommand+5&      5(      &   System.Windows.Controls.DataGrid  5*   
   -   5        $??	DataGrid1??5/      $ ?? IsSynchronizedWithCurrentItem$
 TrueY?5.      $??10q?50         CanUserAddRows .     CanUserDeleteRows .  	   AutoGenerateColumns	 .  
   
IsReadOnly
 . ??5+      ??  ?? Path$ Debtors? ?? SelectedItem 5,      ?? $ CurrentDebtor? ?? SelectedIndex 5-      ?? $ CurrentIndex?   Columns 56      0  *System.Windows.Controls.DataGridTextColumn  57      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name??58         CanUserResize .     Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 5:      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5;      ?? $
 Name?  5<      $ Saldo??5=       .  $	 100 5?       5@      ?? $ Saldo?*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5B      +  %Microsoft.Xaml.Behaviors.EventTrigger  5C         	EventName$ MouseDoubleClick??6!   *	  $Microsoft.Xaml.Behaviors.TriggerBase 	  Actions. 5D      -
  'Prism.Interactivity.InvokeCommandAction
   
  Command 60   ?? *CheckSaldoCommand+5E      5G      5H      5I      