   M S B A M L   `   `   `  ����  WordFind    WordFind.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Translation��5   	   $��400px��6   $	��525��6,   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��10px �6   6.   �� 5      $��* �6   6+   �� 5	      $
��10px �6   6.    � RowDefinitions 5   
   �� 5      $
��40px �6   �� 5      $��120px �6   �� 5      $
��30px �6   �� 5      $��120px �6   �� 5      .+�5   
   �� $��1��6   $��0��6%   $��Center=�62   $��300px��6M   $��Center=�6[    �� Orientation$ 
Horizontal=�6x   .+�5      �� $��From:��6   $
��50px��6$   �� 5      -   5         ��Name$ LanguageFrom��5      $
��70px��6-    �� SelectedIndex$ 0��6_   ��6:   �� *languageList+6_   �� 5      $	��To:��6   $
��50px��6"   �� 5      -   5        $ 
LanguageTo��5      $
��70px��6+   $ 1��6^   ��69   �� *languageList+6^   5      �� 5   
   $��1��6   $��1��6%   $��Center=�62   $��Stretch=�6M   $��120px��6k   .+�5      �� $��Translate From:��6   $��Center=�6/   �� 5      -   5         ��Name$ txtWord��5      $
��80px��6'    �� TextWrapping$
 Wrap=�65    �� AcceptsReturn . $	��Top=�6^   5      �� 5   
   -   5        	 ��Name$	 	btnSearch��5      $��	Translate��6$   $��1��68   $��2��6H   $��Center=�6U   $��300px��6�   $
��40px��6�   
�������6�   �� 5!   
   $��1��6   $��3��6%   $��Center=�62   $��Stretch=�6M   $��120px��6k   .+�5#      �� $��Translated text:��6   $��Center=�60   �� 5$      -   5        $ 
txtbResult��5$      $
 Wrap=�6*   $
��80px��6>   $	��top=�6M   5%      5&      5'      