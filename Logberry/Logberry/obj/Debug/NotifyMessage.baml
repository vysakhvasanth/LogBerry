   M S B A M L   `   `   `  ����  Logberry    Logberry.NotifyMessage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  NotifyWindow��5   	    � Title$ Message��5   	   $	��139��6   $	��415��6&   
������� � WindowStartupLocation$ CenterScreen=�6E    J� IsHitTestVisible .   � 
ResizeMode$ NoResize=�6�    � Topmost .  J� Opacity$
 0.95Q�6�   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��120* �6   �� 5      $
��250* �6   �� 5	      $	��39* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   � -   5        	 �Name$	 progressBar��5      
 � IsIndeterminate
 . $
��Left=�6B   $��23��6]   $	��Top=�6i   $	��302��6�   $��1��6�   $��	55,19,0,0q�6�   $��2��6�   �� 5   
   -   5         ��Name$ 
messageBox��5      $
��Left=�6$   $��43��6?   $��	9,14,0,59q�6K   $��Center=�6^   $	��392��6y   $��0��6�   $��2��6�   $��3��6�   $��Message��6�   5      5      