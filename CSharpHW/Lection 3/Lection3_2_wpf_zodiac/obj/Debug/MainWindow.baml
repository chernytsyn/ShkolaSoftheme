   M S B A M L   `   `   `  ����P  LLection2_3_wpf_zodiac, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Lection2_3_wpf_zodiacLection2_3_wpf_zodiac  5   	   &     Lection2_3_wpf_zodiac.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Lection2_3_wpf_zodiac     5   	     � Title$  
MainWindow��5   	   $	��300��6   $	��425��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ 
labelInput��5
      $"��Enter your birthday dd/mm/yy��6$   $
��Left=�6K   $��	30,30,0,0q�6f   $	��Top=�6y   $	��172��6�   �� 5   
   -   5        $ label1��5      $��	Result : ��6    $
��Left=�64   $��
217,30,0,0q�6O   $	��Top=�6c   $	��140��6{   �� 5   
   -   5        $ label2��5      $��Zodiac sign : ��6    $
��Left=�69   $��	30,99,0,0q�6T   $	��Top=�6g   $	��140��6   �� 5   
   -   5         ��Name$ birthdayTextBox��5      $
��Left=�6+   $��23��6F   $��	30,61,0,0q�6R    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��140��6�   �� 5   
   -   5         ��Name$ Result��5      $
��Left=�6$   $��
217,61,0,0q�6?   $
��Wrap=�6S   $	��Top=�6g   $��50��6   $	��177��6�   �� 5   
   -   5         ��Name$ 	signImage��5      $
��Left=�6#   $	��120��6>   $��
30,130,0,0q�6K   $	��Top=�6_   $	��185��6w   �� 5   
   -   5         ��Name$ submitBirthday��5      $��Submit��6)   $
��Left=�6:   $��267,130,0,0q�6U   $	��Top=�6j   $��75��6�   6�   �� 5   
   -   5        $ closeApp��5      $
��Exit��6#   $
��Left=�62   $��267,228,0,0q�6M   $	��Top=�6b   $��75��6z   6�   5      5      