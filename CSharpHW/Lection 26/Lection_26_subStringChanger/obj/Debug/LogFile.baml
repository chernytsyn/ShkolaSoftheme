   M S B A M L   `   `   `  ����V  RLection_26_subStringChanger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Lection_26_subStringChangerLection_26_subStringChanger  5   	   )    #Lection_26_subStringChanger.LogFile   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Lection_26_subStringChanger     5   	     � Title$  LogFile��5   	   $	��450��6   $
��1000��6&   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5
      $
��Left=�6%   $��	10,10,0,0q�6@   $	��Top=�6S   $	��400��6k   $	��972��6x      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *TimeOfChange+6T     5      $
 Path��6%   $	 470 6L    63   �� *Path+6L     5      $ 
LineNumber��6%   $ 80 6X    69   �� *
LineNumber+6X     5      $ PreviousValue��6%   $ * 6^    6<   �� *PreviousValue+6^     5      $ NewValue��6%   $ * 6T    67   �� *
NewValue+6T   5      5      5      