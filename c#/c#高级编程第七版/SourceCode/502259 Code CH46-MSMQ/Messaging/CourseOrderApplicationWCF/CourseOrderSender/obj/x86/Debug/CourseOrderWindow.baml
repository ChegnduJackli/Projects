   M S B A M L   `   `   `  ����  CourseOrderSender0    *Wrox.ProCSharp.Messaging.CourseOrderWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Course Order��5   	   $	��300��6   $	��300��6+    � 	Resources 5       
  Style1 �� Property �� Value �� 
TargetType �� BasedOn��%c  &	        '�� e     7   '�� �     7   '�� �     7   '�� �     7   '�� �     7   �� 5   
   .�5      ��  � ��$ Center=�6:   �� 5	       � ��$ 5q�6/   5
      �� 5   
   " ��6   8   5      �� 5   
   " ��6   8   6-   �� 5   
   " ��6   8   6/   �� 5   
   " ��6   8   6.   �� 5   
   " ��6   8   6/   5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5       $��* �6   �� 5!      $��2* �6   .+�5#   
   �� -   5         ��Name$ labelCourse��5#      $��0��6%   $��0��62   .��6B   	Course:6K   �� 5$   
   -   5        $ labelCompany��5$      $��1��6&   $��0��63   .��6C   
Company:6M   �� 5%   
   -   5        $ labelContact��5%      $��2��6&   $��0��63   .��6C   
Contact:6M   �� 5&   
   -   5        	 ��Name$	 checkBoxPriority��5&      $��3��6-   $��0��6:   .��6J   High Priority6Y   �� 5'   
   -   5        
 ��Name$
 comboBoxCourses��5'      $��0��6,   $��1��69   .@�5(      �� .��6   Advanced .NET Programming66   �� 5)      .��6   Programming with LINQ62   �� 5*      .��6   #!Distributed Applications with WCF6>   5+      �� 5,   
   -   5         ��Name$ textCompany��5,      $��1��6'   $��1��64   �� 5-   
   -   5        $ textContact��5-      $��2��6'   $��1��64   �� 5.   
   -   5         ��Name$ buttonSubmit��5.      $��3��6C   $��1��6P   .��6`   Submit the Order6r   53      54      