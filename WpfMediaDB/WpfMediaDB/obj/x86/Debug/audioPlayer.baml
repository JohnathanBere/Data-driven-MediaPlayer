   M S B A M L   `   `   `  ����  
WpfMediaDB    WpfMediaDB.audioPlayer   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  MusicPlayer��5   	   $	��300��6   $	��300��6*   $	��300��5   	    � SizeToContent$ WidthAndHeight=�6    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5	   
   -   5           Command$ ApplicationCommands.Open��5	      6Y     5
   
   -   5        $ MediaCommands.Play��5
      6S     5   
   -   5        $ MediaCommands.Pause��5      6U     5   
   -   5        $ MediaCommands.Stop��5      6S   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   c� .@�5      �� $��MediaCommands.Play��6   .��62   Open68   �� 5      �� 5      $��MediaCommands.Play��6   .��62   Play68   �� 5      $��MediaCommands.Pause��6   .��63   Pause6:   �� 5      $��MediaCommands.Stop��6   .��62   Stop68   5      r� 5   
   -   5        $��aPlayer��5      $��1��6&    r� LoadedBehavior$ Manual=�63    r� Stretch$
 None=�6K    J� Opacity$ 0Q�6Z   �� 5   
   $��2��6   ��5      �� 5       .R�5!      �  � ColumnDefinitions 5"      �� 5#      $
��Auto �6/   �� 5$      $��* �6/   �� 5%      $
��Auto �6/   5'      5(      .@�5*      �� .��5+      �� -   5        $��lblProgressStatus��5+      
00:00:006?   5,      �� 5-      $��1��6   $��Stretch=�6,   .��5.      �� -   5        $��sliProgress��5.      6�   5/      �� 50      $��2��6   .��51      � -   5        $��pbVolume��51      $��50��6.   $��12��69   	 � Maximum$	 1Q�6E   
 � Value
 6Q   ��  �� ElementName$ aPlayer�� �� Path$ Volume�52      53      54      55      