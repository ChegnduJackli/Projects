   M S B A M L   `   `   `  ����  
RandomGame    WordLookUp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Random Game��5   	   $	��350��6   $	��425��6*    � Icon$+ %/RandomGame;component/Images/over.jpg��66    � WindowState$ Normal=�6c    � WindowStyle$ SingleBorderWindow=�6x    � WindowStartupLocation$ CenterScreen=�6�   .��5   
   �  � ColumnDefinitions 5      �� 5      $
��80px �6#   62   �� 5	      $��* �6#   6/    � RowDefinitions 5      �� 5      $
��50px �6    �� 5      $
��50px �6    �� 5      $
��50px �6    �� 5      $��100px �6   .+�5   
   �� $	��NO:��6   $��0��6   $��0��6.   $��Center=�6;   $��10q�6V   �� 5    
   -   5         ��Name$ txtID��5       $��1��6!   $��0��61   $��10q�6>   �� 5!      $��Name:��6   $��0��6"   $��1��62   $��Center=�6?   $��10q�6Z   �� 5"   
   -   5        $ txtName��5"      $��1��6#   $��1��63   $��10q�6@   �� 5#   
   $��1��6   $��2��6%   $��Center=�62    �� Orientation$ 
Horizontal=�6N   .+�5$      �� -   5        	 ��Name$	 btnStart��5$      $��Start��6'   $��1��67   $��2��6G   $��Center=�6T   $
��70px��6�   $
��10pxq�6�   �� 5%      -   5        $	 btnStop��5%      $
��Stop��6&   $��1��65   $��2��6E   $��Center=�6R   $
��70px��6�   $
��10pxq�6�   5&      �� 5'   
   $��1��6   $��3��6%   $��Center=�62   $��Stretch=�6M   .+�5(   
   �� -   5        
 ��Name$
 	LblResult��5(      $
��auto��6'   $��Stretch=�65   $��WrapWithOverflow=�6S   $��Center=�6s   $��15(�6�   
����  �6�   5)      5*      5,      