   M S B A M L   `   `   `  ����K  GSokoban Game WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Sokoban_Game_WPFSokoban_Game_WPF  5   	   !    Sokoban_Game_WPF.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Sokoban_Game_WPF     5   	     � Title$  
MainWindow��5   	   $	��906��6   $	��814��6)   .��5	      � -   5         �Name$ MainGrid��5	      .+�5
   
   �� $��Move Count:��6   $
��Left=�6&   $��	10,10,0,0q�6A   $	��Top=�6T   $��Unispace)�6l   $��28(�6�    J� RenderTransformOrigin$	 0,0&�6�   �� 5   
   -   5         ��Name$ 	MoveCount��5      $��10��6#   $
��Left=�60   $��
213,10,0,0q�6K   $	��Top=�6_   $��Unispace)�6w   $��28(�6�   $	 0,0&�6�   �� 5   
   $��Arrow Keys - Move��6   $
��Left=�6,   $��
280,10,0,0q�6G   $	��Top=�6[   $��Tahoma)�6s   $��24(�6�   $ 0.5,0&�6�   �� 5   
   $��Esc - Pause��6   $
��Left=�6&   $��
541,10,0,0q�6A   $	��Top=�6U   $��Tahoma)�6m   $��24(�6�   $ 0.5,0&�6�   �� 5   
   $��Backspace - Undo��6   $
��Left=�6+   $��
507,54,0,0q�6F   $	��Top=�6Z   $��Tahoma)�6r   $��24(�6�   $ 0.5,0&�6�    � Cursor$  ��6�   �� 5   
   $��Space - Reset��6   $
��Left=�6(   $��
307,54,0,0q�6C   $	��Top=�6W   $��Tahoma)�6o   $��24(�6�   $ 0.5,0&�6�   5      5      